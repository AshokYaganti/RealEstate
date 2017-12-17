using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class BuildingDelete : System.Web.UI.Page
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

        Label8.Text = bname;
        if (btype == "s")
        {
            Label9.Text = "Sell";
        }
        else
        {
            Label9.Text = "Rental";
        }
        Label10.Text = bsize;
        Label11.Text = bcost;
        Label12.Text = rooms;
        Label13.Text = roomcost;
        Label14.Text = baddress;
        Label15.Text = city;
        Label16.Text = state;
        Label17.Text = zip;
        Label18.Text = created_date;
        Label19.Text = status;
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
        DAL obj = new DAL();
        int result = obj.DeleteBuilding(bid);
        if (result > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Your request has been succeeded');window.location='MyRequests.aspx';", true);
        }
        else
        {
            string script = "<script>alert('Request has been created but Something went wrong with this request. Please try again later')</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", script);
        }
    }
}