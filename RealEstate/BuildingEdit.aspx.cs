using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class BuildingEdit : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
    string bid = string.Empty;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DAL obj = new DAL();
        bid = Request.QueryString["bid"];
        ds = obj.GetBuildingDetails(bid);
        string bname = string.Empty;
        string btype = string.Empty;
        string bsize = string.Empty;
        string bcost = string.Empty;
        string rooms = string.Empty;
        string roomcost = string.Empty;
        string baddress = string.Empty;
        string city = string.Empty;
        string state = string.Empty;
        string zip = string.Empty;
        string created_date = string.Empty;
        string status = string.Empty;
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            bname = ds.Tables[0].Rows[0]["bname"].ToString();
            btype = ds.Tables[0].Rows[0]["btype"].ToString();
            bsize = ds.Tables[0].Rows[0]["bsize"].ToString();
            bcost = ds.Tables[0].Rows[0]["bcost"].ToString();
            rooms = ds.Tables[0].Rows[0]["rooms"].ToString();
            roomcost = ds.Tables[0].Rows[0]["roomcost"].ToString();
            baddress = ds.Tables[0].Rows[0]["baddress"].ToString();
            city = ds.Tables[0].Rows[0]["city"].ToString();
            state = ds.Tables[0].Rows[0]["state"].ToString();
            zip = ds.Tables[0].Rows[0]["zip"].ToString();
            created_date = ds.Tables[0].Rows[0]["created_date"].ToString();
            status = ds.Tables[0].Rows[0]["status"].ToString();
        }

        TextBox1.Text = bname;
        if (btype == "s")
        {
            TextBox3.Text = "Sell";
            TextBox5.Enabled=false;
            TextBox6.Enabled=false;

        }
        else
        {
            TextBox3.Text = "Rental";
            TextBox4.Enabled = false;
        }
        TextBox2.Text = bsize;
        TextBox4.Text = bcost;
        TextBox5.Text = rooms;
        TextBox6.Text = roomcost;
        TextBox7.Text = baddress;
        TextBox8.Text = city;
        TextBox9.Text = state;
        TextBox10.Text = zip;
        TextBox11.Text = created_date;
        TextBox12.Text = status;
        displayImage();
    }

    public void displayImage()
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("Select photo from bimage where bid=@id", con);
            cmd.Parameters.AddWithValue("@id", bid);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                Image1.ImageUrl = "~/Handler1.ashx?id=" + bid;
            }
            con.Close();
        }
        catch (Exception e1)
        {
        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string bname = TextBox1.Text;
        string bcost = TextBox4.Text;
        string rooms = TextBox5.Text;
        string roomcost = TextBox6.Text;
        string baddress = TextBox7.Text;
        string city = TextBox8.Text;
        string state = TextBox9.Text;
        string zip = TextBox10.Text;
        var regexItem = new Regex("^[0-9 ]*$");
        if (bname.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter building name' )</script>", false);

        }
       
        else if(bcost.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter cost of building' )</script>", false);

        }
        else if (!regexItem.IsMatch(bcost))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Cost of building sholud be numeric' )</script>", false);

        }
        else if (rooms.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter number of rooms available' )</script>", false);

        }
        else if (!regexItem.IsMatch(rooms))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Rooms should be numeric values' )</script>", false);

        }
        else if (roomcost.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter number of rooms available' )</script>", false);

        }
        else if (!regexItem.IsMatch(roomcost))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Room cost should be numeric values' )</script>", false);

        }
        else if (baddress.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter building size' )</script>", false);

        }

        else if (city.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter building size' )</script>", false);

        }
        else if (state == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter building size' )</script>", false);

        }
        else if (zip.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter ZIP Code' )</script>", false);
        }
        else if (!(regexItem.IsMatch(zip)))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('ZIP code should be numeric' )</script>", false);
        }
        else
        {
            DAL da = new DAL();
          int result= da.updateBuildingRequest(bid,bname,bcost,rooms,roomcost,baddress,city,state,zip);
          if (result > 0)
          {
              ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Your building request has been updated successfully');window.location='BuilderHome.aspx';", true);
          }
          else
          {
              string script = "<script>alert('Something went wrong with request. Pleae tryagian later.')</script>";
              Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", script);
          }
        }
      
    }
}