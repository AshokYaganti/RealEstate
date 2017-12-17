using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class MyProperty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadPropertyDetails();
    }

    public void loadPropertyDetails()
    {
         DataSet ds3 = new DataSet();
         DAL obj1 = new DAL();
         string username = Convert.ToString(Session["username"]);
        ds3 = obj1.getCustomerPropertyDetails(username);
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds3.Tables[0];
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
                        sb.Append("Sale");
                    }
                    else if (dr["btype"].ToString() == "r")
                    {
                        sb.Append("Rental");
                    }
                    sb.Append("<td align='center'>");
                    sb.Append((dr["cost"]));
                    sb.Append("</td>");
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["fromdate"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["todate"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='PropertyPDF.aspx?bid=" + dr["bid"].ToString() + "' id='bview' class='btn-warning btn-xs viewcls' style='text-decoration:none'>Generate PDF</a>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }

               ltData.Text = sb.ToString();
    }
}