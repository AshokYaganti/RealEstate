<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="CashDetails.aspx.cs" Inherits="CashDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Top" Runat="Server">

        <ul>
            <li><a href="BuilderHome.aspx">Home</a></li>
            <li><a href="MyRequests.aspx">My Requests</a></li>
			<li><a href="CashDetails.aspx">Building Transactions</a></li>        
           	<li><a href="Logout.aspx">Logout</a></li>
        </ul>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Middle" Runat="Server">
 <table style="width: 100%">
        <tr>
            <td class="style3" 
                style="text-align: center; font-size: x-large; color: #FFCC00">
                My Credit Details</td>
        </tr>
    </table>
    <br />

    <table style="width: 100%">
        <tr>
            <td class="style3" style="text-align: center; font-size: large; color: #FFCC00">
                <span style="color: #996633">Total amount credited is :</span> 
                <asp:Label ID="Label1" runat="server" Text="Label" style="color: #CC0099"></asp:Label></td>
        </tr>
    </table>
    <br />

<table id="mycredit" style="width: 588px">
                    <thead style="font-family:Times New Roman;">
                        <tr>
                            <th hidden="true">ID</th>
                            <th align="center">Customer</th>                           
                            <th align="center">Building Name</th>                            
                            <th align="center">Type</th>   
                            <th align="center">Credited Amount</th>                         
                            <th align="center">Bought/Rented</th> 
                            <th align="center">ToDate</th>                                                                                                                                    
                        </tr>
                    </thead>  
                    <tbody style="color:white; font-family:Times New Roman;">
                     <asp:Literal runat="server" ID="ltData"></asp:Literal>
                    </tbody>             
              </table>

</asp:Content>

