using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
public partial class BuilderHome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
    SqlCommand cmd;
    byte[] raw;
    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<string, string> states = new Dictionary<string, string>();
        states.Add("0", "--- Select state ---");
        states.Add("AL", "Alabama");
        states.Add("AK", "Alaska");
        states.Add("AZ", "Arizona");
        states.Add("AR", "Arkansas");
        states.Add("CA", "California");
        states.Add("CO", "Colorado");
        states.Add("CT", "Connecticut");
        states.Add("DE", "Delaware");
        states.Add("DC", "District of Columbia");
        states.Add("FL", "Florida");
        states.Add("GA", "Georgia");
        states.Add("HI", "Hawaii");
        states.Add("ID", "Idaho");
        states.Add("IL", "Illinois");
        states.Add("IN", "Indiana");
        states.Add("IA", "Iowa");
        states.Add("KS", "Kansas");
        states.Add("KY", "Kentucky");
        states.Add("LA", "Louisiana");
        states.Add("ME", "Maine");
        states.Add("MD", "Maryland");
        states.Add("MA", "Massachusetts");
        states.Add("MI", "Michigan");
        states.Add("MN", "Minnesota");
        states.Add("MS", "Mississippi");
        states.Add("MO", "Missouri");
        states.Add("MT", "Montana");
        states.Add("NE", "Nebraska");
        states.Add("NV", "Nevada");
        states.Add("NH", "New Hampshire");
        states.Add("NJ", "New Jersey");
        states.Add("NM", "New Mexico");
        states.Add("NY", "New York");
        states.Add("NC", "North Carolina");
        states.Add("ND", "North Dakota");
        states.Add("OH", "Ohio");
        states.Add("OK", "Oklahoma");
        states.Add("OR", "Oregon");
        states.Add("PA", "Pennsylvania");
        states.Add("RI", "Rhode Island");
        states.Add("SC", "South Carolina");
        states.Add("SD", "South Dakota");
        states.Add("TN", "Tennessee");
        states.Add("TX", "Texas");
        states.Add("UT", "Utah");
        states.Add("VT", "Vermont");
        states.Add("VA", "Virginia");
        states.Add("WA", "Washington");
        states.Add("WV", "West Virginia");
        states.Add("WI", "Wisconsin");
        states.Add("WY", "Wyoming");

        foreach (var row in states)
        {
            DropDownList3.Items.Add(new ListItem(row.Value.ToString(), row.Key));
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        int bid = 0;
        string bname = TextBox4.Text;
        string bsize = TextBox5.Text;
        string btype = Request.Form["BuildingType"];
        string bcost = string.Empty;
        string rooms = string.Empty;
        string roomcost = string.Empty;
        if (btype == "s")
        {
            bcost = TextBox6.Text;
            rooms = "N/A";
            roomcost = "N/A";
        }
        if (btype == "r")
        {
            rooms = TextBox7.Text;
            roomcost = TextBox8.Text;
            bcost = "N/A";
        }

        string baddress = TextBox9.Text;
        string city = TextBox10.Text;
        string state = DropDownList3.SelectedValue;
        string zip = TextBox12.Text;
        string filename = FileUpload0.PostedFile.FileName;
        string username = Convert.ToString(Session["username"]);

        var regexItem = new Regex("^[0-9 ]*$");

        if (bname.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter building name' )</script>", false);

        }
        else if (bsize.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter building size' )</script>", false);

        }
        else if (!regexItem.IsMatch(bsize))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Building Size should be numerics' )</script>", false);
        }
        else if (btype == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select building type' )</script>", false);

        }
        else if ((btype == "s") && (bcost.Length == 0))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter cost of building' )</script>", false);

        }
        else if ((btype == "s") && (!regexItem.IsMatch(bcost)))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Cost of building sholud be numeric' )</script>", false);

        }
        else if ((btype == "r") && (rooms.Length == 0))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter number of rooms available' )</script>", false);

        }
        else if ((btype == "r") && (!regexItem.IsMatch(rooms)))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Rooms should be numeric values' )</script>", false);

        }
        else if ((btype == "r") && (roomcost.Length == 0))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter number of rooms available' )</script>", false);

        }
        else if ((btype == "r") && (!regexItem.IsMatch(roomcost)))
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
        else if (filename == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select at least one image' )</script>", false);
        }
        else
        {
            DAL obj = new DAL();
            bid = obj.BuildingRequest(username, bname, bsize, btype, bcost, rooms, roomcost, baddress, city, state, zip);

            if (bid > 0)
            {
                try
                {

                    string fileName = Path.GetFileName(FileUpload0.PostedFile.FileName);
                    FileUpload0.PostedFile.SaveAs(Server.MapPath("~/bimages/") + fileName);
                    FileStream fs = new FileStream(Server.MapPath("~/bimages/") + fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
                    raw = new byte[fs.Length];
                    fs.Read(raw, 0, Convert.ToInt32(fs.Length));
                    cmd = new SqlCommand("sp_buildingimage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bid", bid);
                    cmd.Parameters.AddWithValue("@photo", raw);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rows > 0)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Your building request has been created successfully');window.location='BuilderHome.aspx';", true);
                    }
                    else
                    {
                        string script = "<script>alert('Request has been created but Something went wrong while uploading images')</script>";
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", script);
                    }
                }

                catch (Exception e1)
                {
                }
            }
        }

    }

}