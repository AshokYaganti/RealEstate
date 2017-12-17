<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="MyRequests.aspx.cs" Inherits="MyRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Top" Runat="Server">

        <ul>
            <li><a href="BuilderHome.aspx">Home</a></li>
            <li><a href="MyRequests.aspx">My Requests</a></li>
			<li><a href="CashDetails.aspx">Building Transactions</a></li>        
           	<li><a href="Logout.aspx">Logout</a></li>
        </ul> 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Middle" Runat="Server">

              <table id="brequests" style="width: 588px">
                    <thead style="font-family:Times New Roman;">
                        <tr>
                            <th hidden="true">ID</th>
                            <th align="center">Building Name</th>
                            <th style="text-align:center;">Size</th>
                            <th align="center">Type</th>                           
                            <th align="center">Status</th> 
                            <th align="center">Created_Date</th> 
                            <th align="center">&nbsp;</th> 
                            <th align="center">&nbsp;</th> 
                            <th align="center">&nbsp;</th>                                                                                  
                        </tr>
                    </thead>  
                    <tbody style="color:white; font-family:Times New Roman;">
                     <asp:Literal runat="server" ID="ltData"></asp:Literal>
                    </tbody>             
                </table>

</asp:Content>

