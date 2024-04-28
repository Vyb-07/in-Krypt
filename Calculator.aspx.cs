using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            btnstart.Visible = false;
            btndeposit.Visible = true;
        }
        else
        {
            btnstart.Visible = true;
            btndeposit.Visible = false;
        }
    }

    protected void ddlpayback_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpayback.SelectedItem.Value == "3")
        {
            // 5% loan interest

            double loanamt = Convert.ToDouble(txtamount.Value);
            double repaymentamount = Convert.ToDouble((0.05 * loanamt) + loanamt);
            lblrepaymentamount.Text = repaymentamount.ToString();

            lblamount.Text = loanamt.ToString();
            lblinterest.Text = "5%";
            lblrepaymentduration.Text = "3 Months";

            lbldepositamount.Text = "You need to deposit Ether Collateral of";
            lblether.Text = "0.0001";

            Session["loanamt"] = loanamt;
            Session["repayamt"] = repaymentamount;
            Session["interest"] = lblinterest.Text;
            Session["etheramt"] = lblether.Text;
            Session["loandate"] = DateTime.Now.ToShortDateString();
            Session["repaydate"] = DateTime.Now.AddMonths(3);

        }
        else if (ddlpayback.SelectedItem.Value == "6")
        {
            // 10% loan interest
            double loanamt = Convert.ToDouble(txtamount.Value);
            double repaymentamount = Convert.ToDouble((0.10 * loanamt) + loanamt);
            lblrepaymentamount.Text = repaymentamount.ToString();

            lblamount.Text = loanamt.ToString();
            lblinterest.Text = "10%";
            lblrepaymentduration.Text = "6 Months";

            lbldepositamount.Text = "You need to deposit Ether Collateral of";
            lblether.Text = "0.0002";

            Session["loanamt"] = loanamt;
            Session["repayamt"] = repaymentamount;
            Session["interest"] = lblinterest.Text;
            Session["etheramt"] = lblether.Text;
            Session["loandate"] = DateTime.Now.ToShortDateString();
            Session["repaydate"] = DateTime.Now.AddMonths(6);

        }
        else if (ddlpayback.SelectedItem.Value == "1")
        {
            // 15% loan interest
            double loanamt = Convert.ToDouble(txtamount.Value);
            double repaymentamount = Convert.ToDouble((0.15 * loanamt) + loanamt);
            lblrepaymentamount.Text = repaymentamount.ToString();

            lblamount.Text = loanamt.ToString();
            lblinterest.Text = "15%";
            lblrepaymentduration.Text = "1 Year";

            lbldepositamount.Text = "You need to deposit Ether Collateral of";
            lblether.Text = "0.00035";

            Session["loanamt"] = loanamt;
            Session["repayamt"] = repaymentamount;
            Session["interest"] = lblinterest.Text;
            Session["etheramt"] = lblether.Text;
            Session["loandate"] = DateTime.Now.ToShortDateString();
            Session["repaydate"] = DateTime.Now.AddMonths(12);

        }
    }

    protected void btnstart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Register.aspx");
    }
}