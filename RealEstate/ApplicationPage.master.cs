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
public partial class ApplicationPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
    SqlCommand cmd;
    byte[] raw;
    protected void Page_Load(object sender, EventArgs e)
    {
        string fname=Convert.ToString(Session["fname"]);
        string lname = Convert.ToString(Session["lname"]);
        Label1.Text = fname + " " + lname;
        displayimage();
    }

    protected void change_click(object sender, EventArgs e)
    {       
        FileUpload1.Visible = true;
        Button3.Visible = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            if ((FileUpload1.FileName != ""))
            {
                FileUpload1.Visible = false;
                Button3.Visible = false;
                //to allow only jpg gif and png files to be uploaded.
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (((extension == ".jpg") || ((extension == ".gif") || (extension == ".png"))))
                {
                    string id = Convert.ToString(Session["username"]);

                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/pics/") + fileName);

                    FileStream fs = new FileStream(Server.MapPath("~/pics/") + fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);


                    raw = new byte[fs.Length];
                    fs.Read(raw, 0, Convert.ToInt32(fs.Length));

                    cmd = new SqlCommand("sp_userimage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@photo", raw);
                    cmd.Parameters.AddWithValue("@date1", DateTime.Now);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rows > 0)
                    {
                        Label7.Visible = false;
                        displayimage();


                    }
                    else
                    {
                        string script = "<script>alert('Something went wrong')</script>";
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", script);
                    }
                }
                else
                {
                    Label7.Text = "Only Jpg,gif or Png files are permitted";
                    Label7.Visible = true;
                }
            }
            else
            {
                Label7.Text = "Kindly Select a File.....";
                Label7.Visible = true;
            }
        }
        catch (Exception e1)
        {
        }
    }
    public void displayimage()
    {
        try
        {
            Label7.Visible = false;
            string id = Convert.ToString(Session["username"]);

            con.Open();
            cmd = new SqlCommand("Select photo from userimage where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                Image1.ImageUrl = "~/Handler.ashx?id=" + id;
            }
            con.Close();
        }
        catch (Exception e1)
        {
        }

    }
}
