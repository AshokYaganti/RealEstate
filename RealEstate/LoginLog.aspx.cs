using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class LoginLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadAdTableData();
    }

    private void loadAdTableData()
    {
        DataSet ds = new DataSet();
        DAL obj = new DAL();
        string username = Convert.ToString(Session["username"]);

        ds = obj.GetLog();

        StringBuilder sb = new StringBuilder();
        DataTable dt = ds.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<tr class='tabledata'>");
                    sb.Append("<td align='justify'>");
                    sb.Append((dr["username"]));
                    sb.Append("</td>");                   
                    sb.Append("<td>");
                    sb.Append(dr["lname"] + ", " + dr["fname"]);
                    sb.Append("</td>");                   
                    sb.Append("<td align='center'>");
                    if (dr["role"].ToString() == "b")
                    {
                        sb.Append("Agent");
                    }
                    else if (dr["role"].ToString() == "u")
                    {
                        sb.Append("Customer");
                    }
                    else if (dr["role"].ToString() == "a")
                    {
                        sb.Append("Administrator");
                    }
                    sb.Append("</td>");                   
                    sb.Append("<td align='center'>");
                    sb.Append((dr["log"]));
                    sb.Append("</td>");                  
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();

    }
}