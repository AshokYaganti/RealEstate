using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadAdTableData();
    }

    private void loadAdTableData()
    {
        DataSet ds = new DataSet();
        DAL obj = new DAL();
       ds = obj.GetAdminBuildingRequests();

        StringBuilder sb = new StringBuilder();
        DataTable dt = ds.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {

                    sb.Append("<tr class='tabledata'>");
                    sb.Append("<td hidden='true'>");
                    sb.Append((dr["bid"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append(dr["lname"] + ", " + dr["fname"]);
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["company"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["bname"]));
                    sb.Append("</td>");
                    sb.Append("<td align='justify'>");
                    sb.Append((dr["bsize"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    if (dr["btype"].ToString() == "s")
                    {
                        sb.Append("Sell");
                    }
                    else if (dr["btype"].ToString() == "r")
                    {
                        sb.Append("Rental");
                    }
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["status"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["created_date"]));
                    sb.Append("</td>");
                    if (dr["status"].ToString() == "IN PROGRESS")
                    {
                       
                        sb.Append("<td align='center'>");
                        sb.Append("<a href='BuildingApprove.aspx?type=approve&bid=" + dr["bid"].ToString() + "' id='bapprove' class='btn-warning btn-xs approvecls' style='text-decoration:none'><font color='green'>Approve</font>/<font color='red'>Reject</font></a>");
                        sb.Append("</td>");   
                    }
                    else
                    {
                        sb.Append("<td align='center'>");
                        sb.Append("<a href='BuildingApprove.aspx?type=view&bid=" + dr["bid"].ToString() + "' id='bview' class='btn-warning btn-xs viewcls' style='text-decoration:none'>View</a>");
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();

    }
}