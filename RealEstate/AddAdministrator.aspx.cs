using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
public partial class AddAdministrator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            string password = fname.Substring(0, 1) + lname.Substring(0, 1) + lname.Substring(lname.Length - 1) + fname.Substring(fname.Length - 1) + username.Substring(username.Length - 3);
                       
            int result = obj.addAdministrator(fname,lname,username,email,password);

            if (result > 0)
            {
                string to123 = email;
                string from123 = "developertest2020@gmail.com";
                string subject = "Admin Registration confirmation: Modern Real Estate";
                string body = "Your administrator account has been created.Your credentials are Username: " +username+ " and password: " + password;
                using (MailMessage mm = new MailMessage(from123, to123))
                {
                    mm.Subject = subject;
                    mm.Body = body;
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(from123, "test@1234");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);

                }
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Administrator has been added successfully');window.location='AddAdministrator.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                Response.Redirect(ResolveUrl("AddAdministrator.aspx"));
            }
            
        }
    }
}