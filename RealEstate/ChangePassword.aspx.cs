using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string newpassword = TextBox1.Text;
        string cpassword = TextBox2.Text;
        bool pass = newpassword.Equals(cpassword);

        if (newpassword.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter new password' )</script>", false);

        }

        else if (cpassword.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please eEnter confirm Password' )</script>", false);

        }

        else if (pass.Equals(false))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('The two passwords do not match' )</script>", false);

        }
        else
        {
            string username = Convert.ToString(Session["username"]);

            DAL obj = new DAL();
            int res = obj.ChangePassword(username, newpassword);

            if (res > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Your password has been changed');window.location='ChangePassword.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                Response.Redirect(ResolveUrl("ChangePassword.aspx"));
            }
        }
    }
}