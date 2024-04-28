using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using inKrypt;
using System.Web.Security;
using inKryptDataSetTableAdapters;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        try
        {
            Membership.CreateUser(UserName.Text, Password.Text);
            tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
            iusers.Insert(txtfullname.Text, UserName.Text, "", "", "");
            Response.Redirect("~/Account/Login.aspx");
        }
        catch(Exception ex)
        {
            ErrorMessage.Text = ex.ToString();
        }
    }
}