<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="BuildingApprove.aspx.cs" Inherits="BuildingApprove" %>

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
            <td style="text-align: center; width: 271px">
                <asp:Button ID="Button1" runat="server" Text="Approve" onclick="Button1_Click" 
                    style="text-align: right; font-size: medium; font-family: 'Times New Roman', Times, serif; background-color: #009900" />
                </td><td>
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click"                     
                    Text="Reject" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: medium; text-align: center; background-color: #FF3300" />
            </td>
        </tr>
    </table>
   

</asp:Content>

