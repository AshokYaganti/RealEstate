<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationPage.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

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

            <table id="buildingrequests" style="width: 588px">
                    <thead style="font-family:Times New Roman;">
                        <tr>
                            <th hidden="true">ID</th>
                            <th align="center">Name</th>
                            <th align="center">Company</th>
                            <th align="center">Building Name</th>
                            <th style="text-align:center;">Size</th>
                            <th align="center">Type</th>                           
                            <th align="center">Status</th> 
                            <th align="center">Created_Date</th> 
                            <th align="center">&nbsp;</th> 
                            <th align="center">&nbsp;</th> 
                            <th align="center">&nbsp;</th>                                                                                  
                        </tr>
                    </thead>  
                    <tbody style="color:white; font-family:Times New Roman;">
                     <asp:Literal runat="server" ID="ltData"></asp:Literal>
                    </tbody>             
              </table>

</asp:Content>

