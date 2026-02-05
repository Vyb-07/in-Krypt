using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using inKryptDataSetTableAdapters;

public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
            inKryptDataSet.tbl_UsersDataTable itbl = new inKryptDataSet.tbl_UsersDataTable();
            itbl = iusers.GetByusername(Session["username"].ToString());
            if(itbl.Rows.Count > 0)
            {
                foreach(inKryptDataSet.tbl_UsersRow irow in itbl.Rows)
                {
                    if(irow.IsfullnameNull())
                    {
                        txtfullname.Text = "";
                    }
                    else
                    {
                        txtfullname.Text = irow.fullname;
                    }

                    if (irow.IsbankNull())
                    {
                        ddlbank.Text = "";
                    }
                    else
                    {
                        // Note: Setting by color/text might be tricky if values don't match exactly.
                        // Assuming DDL items match database values.
                        var item = ddlbank.Items.FindByText(irow.bank);
                        if (item != null) item.Selected = true;
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
            BindUserLoans(Session["username"].ToString());
        }
    }

    private void BindUserLoans(string username)
    {
        try
        {
            tbl_UserLoansTableAdapter iloans = new tbl_UserLoansTableAdapter();
            inKryptDataSet.tbl_UserLoansDataTable loanTable = iloans.GetData();
            
            // Filter by username and bind
            var userLoans = loanTable.AsEnumerable()
                                     .Where(r => r.Field<string>("username") == username)
                                     .OrderByDescending(r => r.Field<DateTime>("loan_date"))
                                     .ToList();

            if (userLoans.Any())
            {
                gvLoans.DataSource = userLoans.CopyToDataTable();
                gvLoans.DataBind();
            }
        }
        catch (Exception) { /* Handle error */ }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            tbl_UsersTableAdapter iuser = new tbl_UsersTableAdapter();
            iuser.UpdateUser(txtfullname.Text, txtaccountnumber.Text, txtaccountname.Text, ddlbank.SelectedItem.Text, Session["username"].ToString());
            lblmsg.Text = "Update Successful";
        }
        catch(Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
}