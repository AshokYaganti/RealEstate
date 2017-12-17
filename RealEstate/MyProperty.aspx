<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="MyProperty.aspx.cs" Inherits="MyProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Top" Runat="Server">
        <ul>
            <li><a href="CustomerHome.aspx">Home</a></li>
            <li><a href="MyProperty.aspx">My Property</a></li>	
            <li><a href="CashBox.aspx">Cash Box</a></li>           		      
           	<li><a href="Logout.aspx">Logout</a></li>
        </ul> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Middle" Runat="Server">

  <table style="width: 100%">
        <tr>
            <td class="style3" style="text-align: center; font-size: large; color: #FFCC00">
                Your Property Details</td>
        </tr>
    </table>
    <br />

    <table id="myProperty" style="width: 588px">
                    <thead style="font-family:Times New Roman;">
                        <tr>
                            <th hidden="true">ID</th>
                            <th align="center">Owner</th>
                            <th align="center">Company</th>
                            <th align="center">Building Name</th>
                            <th style="text-align:center;">Size</th>
                            <th align="center">Type</th>                         
                            <th align="center">Bought/Rented</th> 
                             <th align="center">ToDate</th> 
                            <th align="center">PDF</th>                                                                                                         
                        </tr>
                    </thead>  
                    <tbody style="color:white; font-family:Times New Roman;">
                     <asp:Literal runat="server" ID="ltData"></asp:Literal>
                    </tbody>             
              </table>

</asp:Content>

