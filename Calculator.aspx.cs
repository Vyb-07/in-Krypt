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
        string selectedValue = ddlpayback.SelectedItem.Value;
        if (selectedValue == "-1") return;

        double loanamt;
        if (!double.TryParse(txtamount.Value, out loanamt) || loanamt <= 0)
        {
            lblrepaymentamount.Text = "Invalid Amount";
            lblether.Text = "0";
            lbldepositamount.Text = "Please enter a valid loan amount.";
            return;
        }

        CalculateLoan(loanamt, selectedValue);
    }

    private void CalculateLoan(double loanamt, string duration)
    {
        double interestRate = 0;
        double etherCollateral = 0;
        string durationText = "";
        int monthsToAdd = 0;

        switch (duration)
        {
            case "3":
                interestRate = 0.05;
                etherCollateral = 0.0001;
                durationText = "3 Months";
                monthsToAdd = 3;
                break;
            case "6":
                interestRate = 0.10;
                etherCollateral = 0.0002;
                durationText = "6 Months";
                monthsToAdd = 6;
                break;
            case "1":
                interestRate = 0.15;
                etherCollateral = 0.00035;
                durationText = "1 Year";
                monthsToAdd = 12;
                break;
            default:
                return;
        }

        double repaymentamount = loanamt * (1 + interestRate);
        
        lblrepaymentamount.Text = repaymentamount.ToString("N2");
        lblamount.Text = loanamt.ToString("N2");
        lblinterest.Text = (interestRate * 100).ToString() + "%";
        lblrepaymentduration.Text = durationText;
        lbldepositamount.Text = "You need to deposit Ether Collateral of";
        lblether.Text = etherCollateral.ToString();

        // Store in Session
        Session["loanamt"] = loanamt;
        Session["repayamt"] = repaymentamount;
        Session["interest"] = lblinterest.Text;
        Session["etheramt"] = lblether.Text;
        Session["loandate"] = DateTime.Now.ToShortDateString();
        Session["repaydate"] = DateTime.Now.AddMonths(monthsToAdd);
    }

    protected void btnstart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Register.aspx");
    }
}