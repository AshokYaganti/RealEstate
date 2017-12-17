<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="LoginLog.aspx.cs" Inherits="LoginLog" %>

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
 <table id="brequests" style="width: 588px">
                    <thead style="font-family:Times New Roman;">
                        <tr>
                            <th align="center">User Name</th>
                            <th align="center">Name</th>
                            <th style="text-align:center;">Role</th>
                            <th align="center">Log</th>                         
                        </tr>
                    </thead>  
                    <tbody style="color:white; font-family:Times New Roman;">
                     <asp:Literal runat="server" ID="ltData"></asp:Literal>
                    </tbody>             
                </table>


</asp:Content>

