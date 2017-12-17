<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="AddAdministrator.aspx.cs" Inherits="AddAdministrator" %>

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
            <td class="style3" 
                style="font-size: medium; text-align: center; color: #996633">
                Add Administrator</td>
        </tr>
    </table>
    <br />

    <table align="center" style="width: 74%; height: 169px">
        <tr>
            <td class="style3" style="width: 193px; font-size: medium">
                First Name</td>
            <td style="width: 16px">
                :</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" style="width: 193px; font-size: medium">
                Last Name</td>
            <td style="width: 16px">
                :</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" style="width: 193px; font-size: medium">
                Username</td>
            <td style="width: 16px">
                :</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" style="width: 193px; font-size: medium">
                Email</td>
            <td style="width: 16px">
                :</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 193px">
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: large; background-color: #009933" 
                    Text="Submit" />
            </td>
        </tr>
    </table>

</asp:Content>

