using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
public partial class ManageAdministrators : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadAdTableData();
    }

    private void loadAdTableData()
    {
        DataSet ds = new DataSet();
        DAL obj = new DAL();
        string username11 = Convert.ToString(Session["username"]);
        ds = obj.GetAdministrators(username11);

        StringBuilder sb = new StringBuilder();
        DataTable dt = ds.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<form runat='server'>");
                    sb.Append("<tr class='tabledata'>");
                    sb.Append("<td>");
                    sb.Append((dr["username"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["fname"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["lname"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["email"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["created_at"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='adminedit.aspx?username=" + dr["username"].ToString() + "' id='admineidt' class='btn-warning btn-xs updatecls' style='text-decoration:none'>Edit</a>");
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<input type='button' ID='btnConfirm' data-id='" + dr["username"].ToString() + "' value='Delete' class='btn-warning btn-xs deletecls'/>");
                    sb.Append("</td>");                  
                    sb.Append("</tr>");

                    sb.Append("</form>");
                }
        ltData.Text = sb.ToString();

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAdministrator.aspx");
    }

    [WebMethod]
    public static string deleteAdministrator(string username)
    {
        DAL obj = new DAL();
       int result = obj.deleteAdministrator(username);
       string msg = string.Empty;
       if (result > 0)
       {
           msg = "success";
       }
       else
       {
           msg = "failure";
       }
       return msg;
    }
}