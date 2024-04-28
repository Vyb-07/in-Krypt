<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="processloan.aspx.cs" Inherits="processloan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        window.onload = function () {
            document.getElementById('<%=lblethaddress.ClientID%>').innerText = sessionStorage.getItem("ethAddress");
        }
    </script>

    <h4>Process Your Loan</h4>
        <hr />
        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>

    <div class="row">
        <div class="col-md-6">
            <div class="form-horizontal">
              
        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Full name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtfullname" CssClass="form-control" />
                
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label"> Bank</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtbank" CssClass="form-control" />
                
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Account Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtaccountname" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Account Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtaccountnumber" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Eth Address</asp:Label>
            <div class="col-md-10">
                <asp:Label ID="lblethaddress" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Eth Deposited</asp:Label>
            <div class="col-md-10">
                <asp:Label ID="lblethamt" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
       
        
    </div>
        </div>

        <div class="col-md-6">
            <div class ="form-horizontal">
            <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Loan Amount</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtloanamount" CssClass="form-control" />
                
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label"> Loan Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtloandate" CssClass="form-control" />
                
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Repayment Amount</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtrepaymentamount" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Repayment Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtrepaymentdate" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Loan Interest</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtloaninterest" CssClass="form-control" />
            </div>
        </div>
       
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="btnprocess" OnClick="btnprocess_Click"  Text="Process Loan" CssClass="btn btn-default" />
            </div>
        </div>

            </div>
        </div>
        </div>

</asp:Content>

