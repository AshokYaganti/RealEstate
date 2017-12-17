using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Text;
using System.IO;
using iTextSharp.text.html.simpleparser;  
public partial class PropertyPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
     {    DAL obj=new DAL();
         string bid = string.Empty;
         string username = string.Empty; 
          bid = Request.QueryString["bid"];
          username = Convert.ToString(Session["username"]);
         DataSet ds = obj.propertyPDFDetails(bid,username);
         string fname = string.Empty;
         string lname = string.Empty;
         string company = string.Empty;
         string bname = string.Empty;
         string bsize = string.Empty;
         string btype = string.Empty;
         string badress = string.Empty;
         string city = string.Empty;
         string state = string.Empty;
         string zip = string.Empty;
         string cost = string.Empty;
         string fromdate = string.Empty;
         string todate = string.Empty;
         if (ds != null && ds.Tables[0].Rows.Count > 0)
         {
                         
             fname = ds.Tables[0].Rows[0]["fname"].ToString();
             lname = ds.Tables[0].Rows[0]["lname"].ToString();
             company = ds.Tables[0].Rows[0]["company"].ToString();
             bname = ds.Tables[0].Rows[0]["bname"].ToString();
             bsize = ds.Tables[0].Rows[0]["bsize"].ToString();
             btype = ds.Tables[0].Rows[0]["btype"].ToString();
             badress = ds.Tables[0].Rows[0]["baddress"].ToString();
             city = ds.Tables[0].Rows[0]["city"].ToString();
             state = ds.Tables[0].Rows[0]["state"].ToString();
             zip = ds.Tables[0].Rows[0]["zip"].ToString();
             cost = ds.Tables[0].Rows[0]["cost"].ToString();
             fromdate = ds.Tables[0].Rows[0]["fromdate"].ToString();
             todate = ds.Tables[0].Rows[0]["todate"].ToString();             
         }
        string strHTML=string.Empty;
        Document pdfDoc = new Document();
        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
        pdfDoc.Open();
        if (btype == "s")
        {
            strHTML = @"<!DOCTYPE html>  
                        <html xmlns='http://www.w3.org/1999/xhtml'>  
                        <head>  
                            <title></title>  
                        </head>  
                        <body>  
                            <div align = 'center'><h1>Building Agreement</b></h1></div><br/>"+  
                             "<p>This is certify that "+ 
                              ""+Convert.ToString(Session["fname"])+ " " + Convert.ToString(Session["lname"])+" "+
                              "has bought"+" "+
                             ""+fname + " " +lname + " "+
                              "aparment on"+" "+
                              ""+fromdate+"."+
                              "Please find the building details below.</p>"+
                             "<br/>"+
                             "<p>Building Name :" + bname + "</p>"+
                             "<p>Owner :" + fname + "," + lname + "</p>"+
                             "<p>Company Name :" +company +"</p>"+
                             "<p>Building Address:"+badress+"</p>"+
                             "<p>City :" +city+"</p>"+
                             "<p>State :"+state+"</p>"+
                             "<p>Zipcode :" +zip+"</p>"+
                             "<p>Amount :"+cost+ "</p>"+
                             "<p>Start date :" +fromdate+"</p>"+
                             "<p>End date :"+todate+"</p>"+
                             "<p>Customer:" + username +"</p>"+
                            "<br/>"+
                          "<div align = 'center'><h3>Modern Real Estate</b></h3></div>"+  
                          "<div align = 'center'><h4>fawaz          </b></h3></div>"+  
                          "</body>" + 
                          "</html>";
        }

        if (btype == "r")
        {
            strHTML = @"<!DOCTYPE html>  
                        <html xmlns='http://www.w3.org/1999/xhtml'>  
                        <head>  
                            <title></title>  
                        </head>  
                        <body>  
                            <div align = 'center'><h1>Rental Agreement</b></h1></div><br/>"+  
                             "<p>This is certify that "+
                              "" + Convert.ToString(Session["fname"]) + " " + Convert.ToString(Session["lname"]) + " " +
                              "has bought"+" "+
                             ""+fname + " " +lname + " "+
                              "aparment on"+" "+
                              ""+fromdate+"."+
                              "Please find the building details below.</p>"+
                             "<br/>"+
                              "<p>Building Name :" + bname + "</p>" +
                             "<p>Owner :" + fname + "," + lname + "</p>" +
                             "<p>Company Name :" + company + "</p>" +
                             "<p>Building Address:" + badress + "</p>" +
                             "<p>City :" + city + "</p>" +
                             "<p>State :" + state + "</p>" +
                             "<p>Zipcode :" + zip + "</p>" +
                             "<p>Amount :" + cost + "</p>" +
                             "<p>Start date :" + fromdate + "</p>" +
                             "<p>End date :" + todate + "</p>" +
                             "<p>Customer:" + username + "</p>" +
                            "<br/>" +
                          "<div align = 'center'><h3>Modern Real Estate</b></h3></div>" +
                          "<div align = 'center'><h4>fawaz          </b></h3></div>" +
                          "</body>" +
                          "</html>";
        }
        HTMLWorker htmlWorker = new HTMLWorker(pdfDoc);
        htmlWorker.Parse(new StringReader(strHTML));
        pdfWriter.CloseStream = false;
        pdfDoc.Close();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Agreement.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.Flush();
        Response.End();  
    }
}