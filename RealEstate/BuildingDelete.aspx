<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="BuildingDelete.aspx.cs" Inherits="BuildingDelete" %>

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
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="font-size: medium; width: 220px">
                Rental Cost(Per month)($)</td>
            <td class="style3" style="width: 21px; font-size: medium">
                :</td>
            <td class="style6" style="width: 126px">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
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
                <asp:Label ID="Label19" runat="server" style="color: #009933" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
     <br />
    <table style="width: 100%">
        <tr>
            <td class="style3" style="font-size: medium; color: #00FFFF">
                Are you sure do you want to delete?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    style="font-size: medium; font-family: 'Times New Roman', Times, serif; background-color: #CC3300" 
                    Text="Yes, Delete" />
            </td>
        </tr>
    </table>
   
   

</asp:Content>

