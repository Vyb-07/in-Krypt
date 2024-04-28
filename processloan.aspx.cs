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
            tbl_UserLoansTableAdapter iloans = new tbl_UserLoansTableAdapter();
            //iloans.Insert(Session["username"].ToString(), Convert.ToDouble(Session["loanamt"]), Convert.ToDateTime(Session["loandate"]), Convert.ToDouble(Session["repayment"]), Convert.ToDateTime(Session["repaydate"]), "3 Months", Session["interest"].ToString(), "Open", lblethaddress.Text, Convert.ToDouble(lblethamt.Text));
            double etheramt = double.Parse(lblethamt.Text);
            lblmsg.Text = "Loan Processed Successfully";

        }
        catch(Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
}