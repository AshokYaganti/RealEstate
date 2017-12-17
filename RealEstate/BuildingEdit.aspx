<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="BuildingEdit.aspx.cs" Inherits="BuildingEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Top" Runat="Server">

        <ul>
            <li><a href="BuilderHome.aspx">Home</a></li>
            <li><a href="MyRequests.aspx">My Requests</a></li>
			<li><a href="CashDetails.aspx">Cash Details</a></li>        
           	<li><a href="Logout.aspx">Logout</a></li>
        </ul> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Middle" Runat="Server">

 <table style="width: 100%">
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Building Name</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td rowspan="12" style="width: 199px">
                 <asp:Image ID="Image1" runat="server" 
                    ImageUrl='<%# "~/Handler1.ashx?ID=" + Eval("id")%>' Width="175px" 
                    Height="155px"/>  &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Building/Room Size</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:TextBox ID="TextBox2" disabled="true" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Building Type</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:TextBox ID="TextBox3" disabled="true" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Building Cost($)</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Total Rooms</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Room Cost($)</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
               <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Building Address</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                City</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                 <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                State</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
               <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Zip Code</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Created Date</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                 <asp:TextBox ID="TextBox11" disabled="true" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Status</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:TextBox ID="TextBox12" disabled="true" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
     <br />
    <table style="width: 100%">
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style3" style="font-size: medium; color: #00FFFF">               
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    style="font-size: medium; font-family: 'Times New Roman', Times, serif; background-color: #FF9900" 
                    Text="Update" />
            </td>
        </tr>
    </table>

</asp:Content>

