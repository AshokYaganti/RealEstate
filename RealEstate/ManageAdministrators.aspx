<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="ManageAdministrators.aspx.cs" Inherits="ManageAdministrators" %>

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
            <td style="text-align: right">
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    style="font-size: medium; font-family: 'Times New Roman', Times, serif; text-align: right; background-color: #009900" 
                    Text="Add Administrator" />
            </td>
        </tr>
    </table>
<br />
<table id="admins" style="width: 588px">
                    <thead style="font-family:Times New Roman;">
                        <tr>                            
                            <th align="center">User Name</th>
                            <th style="text-align:center;">First Name</th>
                            <th align="center">Last Name</th>                           
                            <th align="center">Email</th> 
                            <th align="center">Created_Date</th> 
                            <th align="center">&nbsp;</th> 
                            <th align="center">&nbsp;</th>                                                                                                            
                        </tr>
                    </thead>  
                    <tbody style="color:white; font-family:Times New Roman;">
                     <asp:Literal runat="server" ID="ltData"></asp:Literal>
                    </tbody>             
                </table>

</asp:Content>

