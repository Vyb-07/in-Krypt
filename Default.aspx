<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>P2P LENDING</h1>
        <p class="lead">Loans backed by Ether</p>
         <p>Don't sell Your Crypto, Borrow against it!</p>
        <center>
            <p>
                <asp:Button ID="btncalculator" OnClick="btncalculator_Click" runat="server" CssClass="btn btn-primary btn-lg" Text="View Loan Calculator" />
            </p>
        </center>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                With P2P Lending, you get a portion of your monthly payment back to your crypto wallet in the form of crypto rewards (available in Ether Coin).
            </p>
            
        </div>
        <div class="col-md-4">
            <h2>Instant Loans</h2>
            <p>
                Unlike a traditional loan that takes your credit score into account, an P2P Lending loan is an asset-backed loan in which your cryptoassets act as collateral for your line of credit. Once you pay back your loan, we’ll return your assets to you.
            </p>
            
        </div>
        <div class="col-md-4">
            <h2>Highly Secured</h2>
            <p>
                Smart contract-based applications used for Decentralized Finance (DeFi) borrowing has a unique feature that lets you keep custody of your funds, but you can’t use them until you fully repay the loan.
            </p>
            
        </div>
    </div>
</asp:Content>
