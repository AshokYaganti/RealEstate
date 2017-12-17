<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Middle" Runat="Server">



    <table align="center" style="width: 78%; height: 443px">
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            First Name</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            Last Name</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            User Name</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            Password</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            Confirm Password</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            Email</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            Role</td>
        <td style="width: 51px">
            :</td>
        <td>
         <select id="DropDownList1" name="DropDownList1">
             <option value="0">------ Select -------</option>
             <option value="u">Customer</option>
             <option value="b">Agent</option>
           </select>            
        </td>
    </tr>
     <tr id="company" style="display:none;">
        <td class="style3" style="font-size: medium; width: 210px">
            Company Name</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            Address</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </td>
    </tr>   
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            State</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            City</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            ZIP Code</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3" style="font-size: medium; width: 210px">
            Mobile</td>
        <td style="width: 51px">
            :</td>
        <td>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 210px">
            &nbsp;</td>
        <td style="width: 51px">
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                style="font-family: 'Times New Roman', Times, serif; background-color: #009900" 
                Text="Create Account" />
        </td>
    </tr>
</table>



</asp:Content>

