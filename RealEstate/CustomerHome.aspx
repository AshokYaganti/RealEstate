<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="CustomerHome.aspx.cs" Inherits="CustomerHome" %>

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
                Building Search</td>
        </tr>
    </table>
    <br />


    <table align="center" style="width: 82%; height: 94px">
        <tr>
            <td class="style3" style="font-size: medium; width: 152px">
                Search By</td>
            <td style="width: 196px">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" AutoPostBack="true" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    style="font-family: 'Times New Roman', Times, serif" Width="172px">
                    <asp:ListItem Value="0">-------- Select --------</asp:ListItem>
                    <asp:ListItem Value="category">Category</asp:ListItem>
                    <asp:ListItem Value="state">State</asp:ListItem>
                    <asp:ListItem Value="city">City</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    style="font-family: 'Times New Roman', Times, serif" Width="146px">
                   
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 152px">
                &nbsp;</td>
            <td style="width: 196px">
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: medium; background-color: #009900" 
                    Text="Search" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />

     <table id="buildingrequests" style="width: 588px">
                    <thead style="font-family:Times New Roman;">
                        <tr>
                            <th hidden="true">ID</th>
                            <th align="center">Owner</th>
                            <th align="center">Company</th>
                            <th align="center">Building Name</th>
                            <th style="text-align:center;">Size</th>
                            <th align="center">Type</th>                         
                            <th align="center">Created_Date</th> 
                            <th align="center">&nbsp;</th>                                                                                                         
                        </tr>
                    </thead>  
                    <tbody style="color:white; font-family:Times New Roman;">
                     <asp:Literal runat="server" ID="ltData"></asp:Literal>
                    </tbody>             
              </table>

</asp:Content>

