using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoanRepayment : System.Web.UI.Page
{
    private const string _key = "rzp_test_e8kHhT9iq11Ws5";
    private const string _secret = "SnnfSY6ctz6Za25v7tjKbJUq";
    private const decimal registrationAmount = 100;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                FetchActiveLoan(username);
                FetchUserDetails(username);
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }

    private void FetchActiveLoan(string username)
    {
        try
        {
            inKryptDataSetTableAdapters.tbl_UserLoansTableAdapter iloans = new inKryptDataSetTableAdapters.tbl_UserLoansTableAdapter();
            inKryptDataSet.tbl_UserLoansDataTable itbl = iloans.GetData();
            
            // Find the latest "Open" loan for this user
            var activeLoan = itbl.AsEnumerable()
                                .Where(r => r.Field<string>("username") == username && r.Field<string>("status") == "Open")
                                .OrderByDescending(r => r.Field<DateTime>("loan_date"))
                                .FirstOrDefault();

            if (activeLoan != null)
            {
                txtAmount.Text = activeLoan.Field<double>("repayment_amount").ToString("N2");
                txtAmount.ReadOnly = true; 
                Session["active_loan_id"] = activeLoan.Field<int>("user_loan_id");
            }
            else
            {
                txtAmount.Text = "0.00";
                btnRepay.Enabled = false;
                // Add a message if no active loan
            }
        }
        catch (Exception ex)
        {
            // Log or show error
        }
    }

    private void FetchUserDetails(string username)
    {
        inKryptDataSetTableAdapters.tbl_UsersTableAdapter iusers = new inKryptDataSetTableAdapters.tbl_UsersTableAdapter();
        inKryptDataSet.tbl_UsersDataTable itbl = iusers.GetByusername(username);
        if (itbl.Rows.Count > 0)
        {
            var userRow = itbl[0];
            txtName.Text = userRow.IsfullnameNull() ? "" : userRow.fullname;
        }
    }

    protected void btnRepay_Click(object sender, EventArgs e)
    {
        decimal amount;
        if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0) return;

        decimal amountinSubunits = amount * 100;
        string currency = "INR";
        string name = "In-Krypt";
        string description = "Loan Repayment for " + Session["username"].ToString();
        string imageLogo = "";
        string profileName = txtName.Text;
        string profileMobile = txtMobile.Text;
        string profileEmail = txtEmail.Text;
        Dictionary<string, string> notes = new Dictionary<string, string>()
            {
                { "username", Session["username"].ToString() }, 
                { "loan_id", Session["active_loan_id"]?.ToString() ?? "0" }
            };

        string orderId = CreateOrder(amountinSubunits, currency, notes);

        string jsFunction = "OpenPaymentWindow('" + _key + "', '" + amountinSubunits + "', '" + currency + "', '" + name + "', '" + description + "', '" + imageLogo + "', '" + orderId + "', '" + profileName + "', '" + profileEmail + "', '" + profileMobile + "', '" + JsonConvert.SerializeObject(notes) + "');";
        ClientScript.RegisterStartupScript(this.GetType(), "OpenPaymentWindow", jsFunction, true);
    }
    private string CreateOrder(decimal amountInSubunits, string currency, Dictionary<string, string> notes)
    {
        try
        {
            int paymentCapture = 1;

            RazorpayClient client = new RazorpayClient(_key, _secret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amountInSubunits);
            options.Add("currency", currency);
            options.Add("payment_capture", paymentCapture);
            options.Add("notes", notes);

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.Expect100Continue = false;

            Order orderResponse = client.Order.Create(options);
            var orderId = orderResponse.Attributes["id"].ToString();
            return orderId;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex); 
            throw;
        }
    }
}