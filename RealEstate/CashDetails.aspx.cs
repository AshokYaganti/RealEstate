using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class CashDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadCreditDetails();
    }

    public void loadCreditDetails()
    {
         DataSet ds3 = new DataSet();
         DAL obj1 = new DAL();
         string username = Convert.ToString(Session["username"]);
        ds3 = obj1.getCreditDetails(username);
        string totalAmount = obj1.getTotalAmount(username);
        Label1.Text = totalAmount;
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
                    sb.Append((dr["bname"]));
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
                    sb.Append("</tr>");
                }

               ltData.Text = sb.ToString();
    
    }
}