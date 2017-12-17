<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Top" Runat="Server">

        <ul>
            <li><a href="AdminHome.aspx">Home</a></li>
            <li><a href="ManageAdministrators.aspx">Manage Administrators</a></li>	
            <li><a href="RegUsers.aspx">Registered Users</a></li>		
            <li><a href="ChangePassword.aspx">Change Password</a></li>	
            <li><a href="LoginLog.aspx">Login Log</a></li>			      
           	<li><a href="Logout.aspx">Logout</a></li>
        </ul> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Middle" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="style3" style="text-align: center; font-size: large; color: #996633">
                Change Password</td>
        </tr>
    </table>
    <br />
    <table style="width: 68%; height: 132px;" align="center">
        <tr>
            <td style="font-size: medium; width: 171px">
                <span class="style3">New Password</td>
            <td style="width: 16px">
                :</span></td>
            <td>
                <asp:TextBox ID="TextBox1" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: medium; width: 171px">
                <span class="style3">Confirm Password</td>
            <td style="width: 16px">
                :</span></td>
            <td>
                <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: medium; width: 171px">
                <span class="style3"></td>
            <td style="width: 16px">
                </span></td>
            <td>
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: small; background-color: #009900" 
                    Text="Change Password" />
            </td>
        </tr>
    </table>
</asp:Content>

