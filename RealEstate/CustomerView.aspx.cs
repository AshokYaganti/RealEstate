﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
public partial class CustomerView : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
    string bid = string.Empty;
    string username = string.Empty;
    string type = string.Empty;
    SqlCommand cmd;
    public string bidtxtValue = String.Empty;
    public string busernametxtValue = String.Empty;
    public string usernametxtValue = String.Empty;
    public string bcosttxtValue = String.Empty;
    public string brentalcosttxtValue = String.Empty;
    public string cashboxtxtValue = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();
            DAL obj = new DAL();
            bid = Request.QueryString["bid"];
            username = Convert.ToString(Session["username"]);
            cashboxtxtValue =Convert.ToString(obj.CheckBoxAmount(username));
            usernametxtValue = username;
            bidtxtValue = bid;
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
            string busername = string.Empty;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    busername = ds.Tables[0].Rows[0]["username"].ToString();
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
            }
            busernametxtValue = busername;
            bcosttxtValue = bcost;
            brentalcosttxtValue = roomcost;
            Label8.Text = bname;
            if (btype == "s")
            {
                Label9.Text = "Sell";
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("<input type='button' id='buy' style='background-color:green;' value='Buy Propery'>");
                sb.Append("</td>");
                sb.Append("</tr>");
                ltData.Text = sb.ToString();
            }
            else
            {
                Label9.Text = "Rental";
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("Begin Date:");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<input id='fromdate' name='fromdate'>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("Total Months:");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<input type='text' id='months' name='months'>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("<input type='button' id='rental' style='background-color:orange;' value='Book for Rental'>");
                sb.Append("</td>");
                sb.Append("</tr>");
                ltData.Text = sb.ToString();
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
            displayImage();
        }
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
   
 }