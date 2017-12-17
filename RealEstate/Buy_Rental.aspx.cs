using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
public partial class Buy_Rental : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string BuyBuilding(string bid, string bowner, string customer, double bcost)
    {
        DAL obj = new DAL();        
        int result = obj.buyOwnerBuilding(bid, bowner, customer, bcost);
        string msg = string.Empty;
        if (result > 0)
        {
            msg = "success";
        }
        else
        {
            msg = "failure";
        }
        return msg;
    }

    [WebMethod]
    public static string rentalBuilding(string bid, string bowner, string customer, double brentalcost, DateTime fromdate, int months)
    {
        DAL obj = new DAL();

        double cost = brentalcost * months;
        DateTime todate = fromdate.AddMonths(months);
        string fromdate1 = fromdate.ToString();
        string todate1 = todate.ToString();
        int result = obj.rentOwnerBuilding(bid, bowner, customer, cost, fromdate1, todate1);
        string msg = string.Empty;
        if (result > 0)
        {
            msg = "success";
        }
        else
        {
            msg = "failure";
        }
        return msg;
    }
}