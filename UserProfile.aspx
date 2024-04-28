<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtfullname" CssClass="col-md-2 control-label">Full name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtfullname" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtfullname"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Select Bank</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlbank" CssClass="form-control" runat="server">
                    <asp:ListItem Text="--select bank--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="State Bank" Value="statebank"></asp:ListItem>
                    <asp:ListItem Text="Indian Bank" Value="indianbank"></asp:ListItem>
                    <asp:ListItem Text="Union Bank" Value="unionbank"></asp:ListItem>
                    <asp:ListItem Text="ICICI  Bank" Value="icicibank"></asp:ListItem>
                </asp:DropDownList>
                
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
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="btnupdate" OnClick="btnupdate_Click" Text="Update Profile" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

