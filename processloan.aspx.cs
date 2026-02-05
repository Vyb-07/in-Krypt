using inKryptDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class processloan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
            inKryptDataSet.tbl_UsersDataTable itbl = new inKryptDataSet.tbl_UsersDataTable();
            itbl = iusers.GetByusername(Session["username"].ToString());
            if (itbl.Rows.Count > 0)
            {
                foreach (inKryptDataSet.tbl_UsersRow irow in itbl.Rows)
                {
                    if (irow.IsfullnameNull())
                    {
                        txtfullname.Text = "";
                    }
                    else
                    {
                        txtfullname.Text = irow.fullname;
                    }

                    if (irow.IsbankNull())
                    {
                        txtbank.Text = "";
                    }
                    else
                    {
                        txtbank.Text = irow.bank;
                    }
                    if (irow.Isaccount_nameNull())
                    {
                        txtaccountname.Text = "";
                    }
                    else
                    {
                        txtaccountname.Text = irow.account_name;
                    }
                    if (irow.Isaccount_numberNull())
                    {
                        txtaccountnumber.Text = "";
                    }
                    else
                    {
                        txtaccountnumber.Text = irow.account_number;
                    }
                }
            }
        }

        txtloanamount.Text = Session["loanamt"].ToString();
        txtrepaymentamount.Text = Session["repayamt"].ToString();
        txtloandate.Text = Session["loandate"].ToString();
        txtrepaymentdate.Text = Session["repaydate"].ToString();
        txtloaninterest.Text = Session["interest"].ToString();
        lblethamt.Text = Session["etheramt"].ToString();

    }
    

    protected void btnprocess_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["username"] == null || Session["loanamt"] == null)
            {
                lblmsg.Text = "Session expired. Please calculate loan again.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            tbl_UserLoansTableAdapter iloans = new tbl_UserLoansTableAdapter();
            
            string username = Session["username"].ToString();
            double loanamt = Convert.ToDouble(Session["loanamt"]);
            DateTime loandate = Convert.ToDateTime(Session["loandate"]);
            double repaymentamt = Convert.ToDouble(Session["repayamt"]);
            DateTime repaydate = Convert.ToDateTime(Session["repaydate"]);
            string duration = "3 Months"; // This should ideally come from session too, but currently defaults to 3 in some places. I'll use a placeholder or check session.
            
            // Re-evaluating duration based on months added
            if (repaydate.Month == loandate.AddMonths(3).Month) duration = "3 Months";
            else if (repaydate.Month == loandate.AddMonths(6).Month) duration = "6 Months";
            else if (repaydate.Month == loandate.AddMonths(12).Month) duration = "1 Year";

            string interest = Session["interest"].ToString();
            string status = "Open";
            string ethAddress = lblethaddress.Text == "Label" ? "" : lblethaddress.Text;
            double ethLocked = Convert.ToDouble(lblethamt.Text);

            iloans.Insert(username, loanamt, loandate, repaymentamt, repaydate, duration, interest, status, ethAddress, ethLocked);
            
            lblmsg.Text = "Loan Processed Successfully";
            lblmsg.ForeColor = System.Drawing.Color.Green;
            btnprocess.Enabled = false;

        }
        catch(Exception ex)
        {
            lblmsg.Text = "Error: " + ex.Message;
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }
}