using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
public partial class Registration : System.Web.UI.Page
{
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
            DropDownList2.Items.Add(new ListItem(row.Value.ToString(), row.Key));
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DAL obj = new DAL();
        DataSet ds = new DataSet();
        List<string> username11 = new List<string>();

        ds = obj.getUsename();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            username11.Add(ds.Tables[0].Rows[i][0].ToString());
        }

        string fname = TextBox1.Text;
        string lname = TextBox2.Text;
        string username = TextBox3.Text;
        string password = TextBox4.Text;
        string cpassword = TextBox5.Text;
        string email = TextBox6.Text;
        string role = Request.Form["DropDownList1"];
        string company = string.Empty;
        if (role == "u")
        {
            company = "N/A";           
        }
        if (role == "b")
        {
            company = TextBox11.Text;             
        }
        string address = TextBox7.Text;
        string state =  DropDownList2.SelectedValue;
        string city = TextBox8.Text;
        string zip = TextBox9.Text;
        string phone = TextBox10.Text;

        var regexItem = new Regex("^[0-9 ]*$");
        bool pass = password.Equals(cpassword);

        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);

        if (fname.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter First Name' )</script>", false);

        }
        else if (regexItem.IsMatch(fname))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter Alphabets only' )</script>", false);
        }
        else if (lname.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter Last Name' )</script>", false);

        }
        else if (regexItem.IsMatch(lname))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter Alphabets only' )</script>", false);
        }
        else if (username.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter User name' )</script>", false);

        }

        else if (username11.Contains(username))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('User ID Already Exists' )</script>", false);

        }
        else if (password.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter Password' )</script>", false);

        }

        else if (cpassword.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter confirm Password' )</script>", false);

        }

        else if (pass.Equals(false))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Check Confirm Password' )</script>", false);

        }
        else if (email.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter email address' )</script>", false);
        }
        else if (!(match.Success))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Email Address was not in correct Format' )</script>", false);
        }
        else if (role == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Select the Role' )</script>", false);
        }
        else if (company.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter company name' )</script>", false);
        }
        else if (address.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter Street address' )</script>", false);
        }
        else if (state == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Select State' )</script>", false);
        }
        else if (city.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter City' )</script>", false);
        }       
        else if (zip.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter ZIP Code' )</script>", false);
        }
        else if (!(regexItem.IsMatch(zip)))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('ZIP Code should be Numeric' )</script>", false);
        }
        else if (phone.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter Phone Number' )</script>", false);
        }
        else if (!(regexItem.IsMatch(phone)))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Phone Number Should be Numeric' )</script>", false);
        }
        else
        {
             int res= obj.registrationDetails(fname, lname, username, password, email, role,company,address, state, city, zip, phone);
             if (res > 0)
             {
                 
                 string to123 = email;
                 string from123 = "developertest2020@gmail.com";
                 string subject = "Registration confirmation: Modern Real Estate";
                 string body = "Your account has been created.Please login and checkout the details.";
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
                 ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Your account has been created');window.location='LoginPage.aspx';", true);
             }
             else
             {
                 ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                 Response.Redirect(ResolveUrl("registration.aspx"));
             }

        }
    }
}