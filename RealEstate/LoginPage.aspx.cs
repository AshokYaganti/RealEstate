using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DAL obj=new DAL();
        string username = TextBox1.Text;
        string password = TextBox2.Text;

        string username11 = string.Empty;
        string password11 = string.Empty;
        string role = string.Empty;
        string fname = string.Empty;
        string lname = string.Empty;

        if (username.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter User Name')</script>", false);
        }
        else if (password.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter Password')</script>", false);
        }
        else
        {
           DataSet ds= obj.getLoginDetails(username);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                username11 = ds.Tables[0].Rows[0]["username"].ToString();
                password11 = ds.Tables[0].Rows[0]["password"].ToString();
                role = ds.Tables[0].Rows[0]["role"].ToString();
                fname = ds.Tables[0].Rows[0]["fname"].ToString();
                lname = ds.Tables[0].Rows[0]["lname"].ToString();
            }

            if ((username == username11) && (password == password11) && (role=="u"))
            {
                Session["username"] = username;
                Session["role"] = role;
                Session["fname"] = fname;
                Session["lname"] = lname;
                Session["loggedin"] = "created";
                DAL da = new DAL();
                obj.LoginLog(username,fname,lname,role);
                Response.Redirect("CustomerHome.aspx");
            }
            else if ((username == username11) && (password == password11)&& (role=="b"))
            {
                Session["username"] = username;
                Session["role"] = role;
                Session["fname"] = fname;
                Session["lname"] = lname;
                Session["loggedin"] = "created";
                DAL da = new DAL();
                obj.LoginLog(username, fname, lname, role);
                Response.Redirect("BuilderHome.aspx");
            }
            else if ((username == username11) && (password == password11) && (role == "a"))
            {
                Session["username"] = username;
                Session["role"] = role;
                Session["fname"] = fname;
                Session["lname"] = lname;
                Session["loggedin"] = "created";
                DAL da = new DAL();
                obj.LoginLog(username, fname, lname, role);
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('User Name or Password incorrect')</script>", false);
            }

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}