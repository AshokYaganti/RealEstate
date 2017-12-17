using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class adminedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DAL obj = new DAL();
        DataSet ds = new DataSet();
        string username1=Request.QueryString["username"];
        ds = obj.getAdminDetails(username1);
                

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            TextBox3.Text = ds.Tables[0].Rows[0]["username"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["fname"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["lname"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["email"].ToString();         
            
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        DAL obj = new DAL();
        DataSet ds = new DataSet();
        List<string> username11 = new List<string>();

        ds = obj.getallUsenames();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            username11.Add(ds.Tables[0].Rows[i][0].ToString());
        }

        string fname = TextBox1.Text;
        string lname = TextBox2.Text;
        string username = TextBox3.Text;
        string email = TextBox4.Text;

        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);

        var regexItem = new Regex("^[0-9 ]*$");

        if (fname.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter first name' )</script>", false);

        }
        else if (regexItem.IsMatch(fname))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter alphabets only' )</script>", false);
        }
        else if (lname.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter last name' )</script>", false);

        }
        else if (regexItem.IsMatch(lname))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter alphabets only' )</script>", false);
        }
        else if (username.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter user name' )</script>", false);

        }

        else if (username11.Contains(username))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('User name already exists' )</script>", false);

        }
        else if (email.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter email address' )</script>", false);
        }
        else if (!(match.Success))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Email address was not in correct Format' )</script>", false);
        }

        else
        {
            
            int result = obj.updateAdministrator(fname, lname, username, email);

            if (result > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Administrator has been updated successfully');window.location='AddAdministrator.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                Response.Redirect(ResolveUrl("AddAdministrator.aspx"));
            }

        }
    }
}