using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class CustomerHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadAllData();
        updateBuildingStatus();
    }
    public void loadAllData()
    {
        DataSet ds3 = new DataSet();
        DAL obj1 = new DAL();
        ds3 = obj1.getAllBuildingDetail();
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
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append((dr["created_date"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='CustomerView.aspx?bid=" + dr["bid"].ToString() + "' id='bview' class='btn-warning btn-xs viewcls' style='text-decoration:none'>View</a>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }    
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DAL da=new DAL();
        ds = da.getCityState();
        if (DropDownList1.SelectedValue == "category")
        {
            Dictionary<string, string> category = new Dictionary<string, string>();
            category.Add("0", "--- Select Category ---");
            category.Add("s", "For Sale");
            category.Add("r", "For Rental");
            DropDownList2.Items.Clear();
            foreach (var row in category)
            {
                DropDownList2.Items.Add(new ListItem(row.Value.ToString(), row.Key));
            }
        }
        if (DropDownList1.SelectedValue == "state")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("--- Select State ----","0"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList2.Items.Add(new ListItem(ds.Tables[0].Rows[i]["state"].ToString(), ds.Tables[0].Rows[i]["state"].ToString()));
            }
           
        }
        if (DropDownList1.SelectedValue == "city")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("--- Select City ----","0"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList2.Items.Add(new ListItem(ds.Tables[0].Rows[i]["city"].ToString(), ds.Tables[0].Rows[i]["city"].ToString()));
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string item1 = DropDownList1.SelectedValue;
        string item2 = DropDownList2.SelectedValue;
        if (item1 == "0")
        {

        }
        else if ((item1 != "0") && (item2 == "0"))
        {

        }
        else
        {
            
            DataSet ds1 = new DataSet();
            ds1.Clear();
            DAL obj = new DAL();
            ds1 = obj.getBuildingSearchDetails(item1,item2);
            loadData(ds1);
        }

    }

    public void loadData(DataSet ds2)
    {
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds2.Tables[0];
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
                    sb.Append("</td>");                   
                    sb.Append("<td align='center'>");
                    sb.Append((dr["created_date"]));
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append("<a href='CustomerView.aspx?bid=" + dr["bid"].ToString() + "' id='bview' class='btn-warning btn-xs viewcls' style='text-decoration:none'>View</a>");
                    sb.Append("</td>");                   
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }

     public void updateBuildingStatus()
     {
         DAL obj123 = new DAL();
         obj123.updateStatus();
     }
}