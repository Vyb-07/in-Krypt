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
                        ddlbank.SelectedItem.Text = irow.bank;
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