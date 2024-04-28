using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using inKrypt;
using inKryptDataSetTableAdapters;
using System.Web.Security;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LogIn(object sender, EventArgs e)
        {
        if(Membership.ValidateUser(UserName.Text, Password.Text))
        {
            Session["username"]=UserName.Text;
            FormsAuthentication.SetAuthCookie(UserName.Text, true);
            Response.Redirect("~/Default.aspx");
        }
        }
}