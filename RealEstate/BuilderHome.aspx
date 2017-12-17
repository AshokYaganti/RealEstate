<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="BuilderHome.aspx.cs" Inherits="BuilderHome" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Top" Runat="Server">
  
        <ul>
            <li><a href="BuilderHome.aspx">Home</a></li>
            <li><a href="MyRequests.aspx">My Requests</a></li>
			<li><a href="CashDetails.aspx">Building Transactions</a></li>        
           	<li><a href="Logout.aspx">Logout</a></li>
        </ul>  

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Middle" Runat="Server">
    
          <h4>Add Bulding Request</h4>       
         
         <table id="addrequesttable" align="center" style="height: 387px">
          <tr>
            <td class="style3" style="font-size: medium">Building Name</td>
            <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
         </tr>
         <tr>
            <td class="style3" style="font-size: medium">Building Size(Sqft)</td>
              <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
         </tr>        
         <tr>
         <td class="style3" style="font-size: medium">Building Type</td>
         <td>
           <select id="BuildingType" name="BuildingType">
             <option value="0">------ Select -------</option>
             <option value="s">For Sale</option>
             <option value="r">For Rental</option>
           </select>         
         </td>
         </tr>         
          <tr id="sell" style="display:none;">
            <td class="style3" style="font-size: medium">Cost($)</td>
              <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
         </tr>     
         <tr id="rental" style="display:none;">
            <td class="style3" style="font-size: medium">Total Rooms</td>
              <td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
         </tr>
          <tr id="rental1" style="display:none;">
            <td class="style3" style="font-size: medium">Cost$(Per month)</td>
              <td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
         </tr>        
         <tr>
            <td class="style3" style="font-size: medium">Buliding Address</td>
              <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
         </tr>
         <tr>
            <td class="style3" style="font-size: medium">City</td>
              <td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
         </tr>
           <tr>
            <td class="style3" style="font-size: medium">State</td>
              <td> <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList></td>
         </tr>
          <tr>
            <td class="style3" style="font-size: medium">Zip Code</td>
              <td><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
         </tr>
         <tr>
            <td class="style3" style="font-size: medium">Upload Image</td>
            <td width="100"><input type="file" id="FileUpload0" runat="server" style="width:192px;"/></td>           
          </tr> 
          <tr>
          <td></td>              
          <td><asp:Button ID="Button1" runat="server" Text="Add Request" 
                  onclick="Button1_Click" 
                  style="font-family: 'Times New Roman', Times, serif; font-size: medium; background-color: #009933" /></td>
          </tr>                 
         </table>

   
</asp:Content>


