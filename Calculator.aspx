<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Calculator.aspx.cs" Inherits="Calculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        window.onload = function () {
            if (typeof web3 == 'undefined') {
                document.getElementById("metamask").innerHTML = "U need metamask installed";
            }

        }

        function depositEth() {
            try {
                var abi = [
                    {
                        "anonymous": false,
                        "inputs": [
                            {
                                "indexed": false,
                                "internalType": "address",
                                "name": "",
                                "type": "address"
                            },
                            {
                                "indexed": false,
                                "internalType": "uint256",
                                "name": "",
                                "type": "uint256"
                            }
                        ],
                        "name": "addFund",
                        "type": "event"
                    },
                    {
                        "inputs": [
                            {
                                "internalType": "address",
                                "name": "_address",
                                "type": "address"
                            },
                            {
                                "internalType": "uint256",
                                "name": "_ethdeposited",
                                "type": "uint256"
                            }
                        ],
                        "name": "addFunds",
                        "outputs": [],
                        "stateMutability": "payable",
                        "type": "function"
                    },
                    {
                        "inputs": [
                            {
                                "internalType": "uint256",
                                "name": "",
                                "type": "uint256"
                            }
                        ],
                        "name": "borrowerAccts",
                        "outputs": [
                            {
                                "internalType": "address",
                                "name": "",
                                "type": "address"
                            }
                        ],
                        "stateMutability": "view",
                        "type": "function"
                    },
                    {
                        "inputs": [
                            {
                                "internalType": "address",
                                "name": "_address",
                                "type": "address"
                            }
                        ],
                        "name": "getBorrower",
                        "outputs": [
                            {
                                "internalType": "uint256",
                                "name": "",
                                "type": "uint256"
                            },
                            {
                                "internalType": "bool",
                                "name": "",
                                "type": "bool"
                            }
                        ],
                        "stateMutability": "view",
                        "type": "function"
                    },
                    {
                        "inputs": [
                            {
                                "internalType": "address",
                                "name": "_tobrw",
                                "type": "address"
                            }
                        ],
                        "name": "withdrawFunds",
                        "outputs": [],
                        "stateMutability": "nonpayable",
                        "type": "function"
                    }
                ]

                var contractaddress = "0x000095e79eac4d76aab57cb2c1f091d553b36ca0";
                myAbi = web3.eth.contract(abi);
                var myfunction = myAbi.at(contractaddress);

                var amtEth = web3.toWei(document.getElementById('<%=lblether.ClientID %>').innerText, 'ether');

                web3.eth.getAccounts(function (error, acct) {
                    sessionStorage.setItem("ethAddress", acct);
                    
                    myfunction.addFunds(acct, amtEth, { from: web3.eth.accounts[0], gas: 4000000, value: amtEth }, function (err, result) {
                        if (result) {
                            window.location.replace("processloan.aspx");
                        }
                    });
                });

            } catch (err) {
                document.getElementById("metamask").innerHTML = err;
            }
        }

    </script>

    <div id="metamask"></div>
    <div class="jumbotron text-center">
        <h2>Calculate your Loan</h2>
       <div class="row">
           <div class="col-md-6" style="align-content:center">
               <h3>How much do U want to Borrow?</h3>
               <br />
               <input id="txtamount" runat="server" type="text"  placeholder="Enter anount in Rupees" />
               <br />
               <h3>How long do U need to payback?</h3>
               <br />
               <asp:DropDownList ID="ddlpayback" AutoPostBack="true" OnSelectedIndexChanged="ddlpayback_SelectedIndexChanged" runat="server">
                   <asp:ListItem Text="--select duration--" Value="-1"></asp:ListItem>
                   <asp:ListItem Text="3 Months" Value="3"></asp:ListItem>
                   <asp:ListItem Text="6 Months" Value="6"></asp:ListItem>
                   <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
               </asp:DropDownList>            
           </div>
           <div class="col-md-6" style="align-content:center">
               <h3>Repayment(
                   <asp:Label ID="lblrepaymentduration" runat="server" Text="3 months"></asp:Label>
                   )</h3>
               <br />
               <h1>
                   <asp:Label ID="lblrepaymentamount" runat="server" Text="Label"></asp:Label>
               </h1>
               <br />
               <table style="width:100%">
                   <tr>
                       <td>
                           Loan Amount
                       </td>
                       <td>
                           Interest
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblamount" runat="server" Text="Label"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="lblinterest" runat="server" Text="Label"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2">
                           <asp:Label ID="lbldepositamount" runat="server"></asp:Label>
                           
                           <asp:Label ID="lblether" runat="server" Text="0"></asp:Label>

                       </td>
                   </tr>
               </table>
           </div>
       </div>
        <hr />
        <a href="processloan.aspx" runat="server" id="btndeposit" class="btn btn-lg btn-info" onclick="depositEth()">Make Deposit</a>
        <%--<asp:Button ID="btndeposit" OnClientClick="depositEth()" runat="server" CssClass="btn btn-lg btn-info" Text="Make Deposit" />--%>
        <asp:Button ID="btnstart" OnClick="btnstart_Click" runat="server" CssClass="btn btn-lg btn-info" Text="Get Started" />
    </div>
</asp:Content>

