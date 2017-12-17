<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Middle" Runat="Server">



    <table style="width: 100%">
        <tr>
            <td class="style3" 
                style="text-align: center; font-size: x-large; color: #CC6600">
                Login Page</td>
        </tr>
    </table>

    <br />

    <table align="center" style="width: 58%; height: 117px">
        <tr>
            <td class="style8" 
                style="font-family: 'Times New Roman', Times, serif; width: 121px">
                Username</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8" 
                style="font-family: 'Times New Roman', Times, serif; width: 121px">
                Password</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8" 
                style="font-family: 'Times New Roman', Times, serif; width: 121px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: medium; background-color: #009933" 
                    Text="Login" />
            </td>
        </tr>
    </table>
  
    <table style="width: 100%">
        <tr>
            <td style="text-align: center">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="51px" 
                    ImageUrl="images/register.png" onclick="ImageButton1_Click" Width="218px" />
            </td>
        </tr>
    </table>
</asp:Content>

