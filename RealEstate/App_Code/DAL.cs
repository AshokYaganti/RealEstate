using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
    // Database connection string. It establishes the connection with the database.
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
    DataSet ds = new DataSet();

    // This method get the list of registered users to validate the new users.
    // Created by : Fawaz Alotaiby
    public DataSet getUsename()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_username", con);
        cmd.CommandText = "sp_username";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method insert the new user details in the database.
    // Created by : Fawaz Alotaiby
    public int registrationDetails(string fname, string lname, string username, string password, string email, string role,string company, string address, string state, string city, string zip, string phone)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_registrations", con);
        cmd.CommandText = "sp_registrations";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@fname", fname);
        cmd.Parameters.AddWithValue("@lname", lname);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@role", role);
        cmd.Parameters.AddWithValue("@company", company);
        cmd.Parameters.AddWithValue("@address", address);
        cmd.Parameters.AddWithValue("@state", state);
        cmd.Parameters.AddWithValue("@city", city);
        cmd.Parameters.AddWithValue("@zip", zip);
        cmd.Parameters.AddWithValue("@phone", phone);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;

    }

    // This method gets the user credentials to validate the authentication.
    // Created by : Fahad Alajmi
    public DataSet getLoginDetails(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_logindetails", con);
        cmd.CommandText = "sp_logindetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method inserts the building details in the database.
    // Created by : Fahad Alajmi
    public int BuildingRequest(string username, string bname, string bsize, string btype, string bcost, string rooms, string roomcost, string baddress, string city, string state, string zip)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_buildingrequest", con);
        cmd.CommandText = "sp_buildingrequest";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@bid", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@bname", bname);
        cmd.Parameters.AddWithValue("@bsize", bsize);
        cmd.Parameters.AddWithValue("@btype", btype);
        cmd.Parameters.AddWithValue("@bcost", bcost);
        cmd.Parameters.AddWithValue("@rooms", rooms);
        cmd.Parameters.AddWithValue("@roomcost", roomcost);
        cmd.Parameters.AddWithValue("@baddress", baddress);
        cmd.Parameters.AddWithValue("@state", state);
        cmd.Parameters.AddWithValue("@city", city);
        cmd.Parameters.AddWithValue("@zip", zip);
        cmd.Parameters.AddWithValue("@status", "IN PROGRESS");
        cmd.ExecuteNonQuery();
        string building_num = cmd.Parameters["@bid"].Value.ToString();
        int bid = Convert.ToInt32(building_num);
        con.Close();
        return bid;
    }

    // This method gets the agent building details by username.
    // Created by : Fahad Alajmi
    public DataSet GetBuildingRequests(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM buildingrequests where username=@username", con);
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method gets the agent building details by username.
    // Created by : Fawaz Alotaiby
    public DataSet GetBuildingDetails(string bid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM buildingrequests where bid=@bid", con);
        cmd.Parameters.AddWithValue("@bid", bid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method gets the agent building details by building id.
    // Created by : Fawaz Alotaiby
    public int DeleteBuilding(string bid)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_deletebuilding", con);
        cmd.CommandText = "sp_deletebuilding";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bid", bid);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    // This method used to update the building details in the database.
    // Created by : Fahad Alajmi
    public int updateBuildingRequest(string bid, string bname, string bcost, string rooms, string roomcost, string baddress, string city, string state, string zip)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_updatebuildingrequest", con);
        cmd.CommandText = "sp_updatebuildingrequest";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bid", bid);
        cmd.Parameters.AddWithValue("@bname", bname);
        cmd.Parameters.AddWithValue("@bcost", bcost);
        cmd.Parameters.AddWithValue("@rooms", rooms);
        cmd.Parameters.AddWithValue("@roomcost", roomcost);
        cmd.Parameters.AddWithValue("@baddress", baddress);
        cmd.Parameters.AddWithValue("@state", state);
        cmd.Parameters.AddWithValue("@city", city);
        cmd.Parameters.AddWithValue("@zip", zip);
        int result = cmd.ExecuteNonQuery();
        con.Close();

        return result;
    }

    // This method used to get the building details from the database for approve/reject the requests.
    // Created by : Fawaz Alotaiby
    public DataSet GetAdminBuildingRequests()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_adminbuldingrequests", con);
        cmd.CommandText = "sp_adminbuldingrequests";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method updated the building status to "APPROOVED".
    // Created by : Fawaz Alotaiby
    public int ApproveBuilding(string bid)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_approvebuilding", con);
        cmd.CommandText = "sp_approvebuilding";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bid", bid);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }
    // This method updated the building status to "REJECTED".
    // Created by : Fawaz Alotaiby
    public int RejectBuilding(string bid)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_rejectbuilding", con);
        cmd.CommandText = "sp_rejectbuilding";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bid", bid);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    // This method gets the web administrator details except login administrator.
    // Created by : Fahad Alajmi
    public DataSet GetAdministrators(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM administration where username!=@username", con);
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method gets all usernames to vaildate the new administrator unique usename.
    // Created by : Fahad Alajmi
    public DataSet getallUsenames()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_getallusernames", con);
        cmd.CommandText = "sp_getallusernames";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method insert the new administrator details in the database.
    // Created by : Fahad Alajmi
    public int addAdministrator(string fname, string lname, string username, string email, string password)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_addAdministrator", con);
        cmd.CommandText = "sp_addAdministrator";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@fname", fname);
        cmd.Parameters.AddWithValue("@lname", lname);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    // This method retrieves the administrator details from the database.
    // Created by : Fahad Alajmi
    public DataSet getAdminDetails(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM administration where username=@username", con);
        cmd.Parameters.AddWithValue("@username", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }


    // This method updates the administrator details.
    // Created by : Fawaz Alotaiby
    public int updateAdministrator(string fname, string lname, string username, string email)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_updateadministrator", con);
        cmd.CommandText = "sp_updateadministrator";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@fname", fname);
        cmd.Parameters.AddWithValue("@lname", lname);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@email", email);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }


    // This method deletes the administrator record.
    // Created by : Fawaz Alotaiby
    public int deleteAdministrator(string username)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_deleteadmin", con);
        cmd.CommandText = "sp_deleteadmin";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }


    // This method used to change the administrator password.
    // Created by : Fahad Alajmi
    public int ChangePassword(string username, string password)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("update administration set password=@password where username=@username", con);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    // This method used to get all registered agents/customer details.
    // Created by : Fahad Alajmi
    public DataSet GetRegisteredUsers()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT fname,lname,username,email,role,address,state,city,zip,phone FROM registrations", con);        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method used to insert the login log details.
    // Created by : Fawaz Alotaiby
    public int LoginLog(string username, string fname,string lname,string role)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_loginlog", con);
        cmd.CommandText = "sp_loginlog";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@fname", fname);
        cmd.Parameters.AddWithValue("@lname", lname);
        cmd.Parameters.AddWithValue("@role", role);       
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    // This method used to get the login log details.
    // Created by : Fawaz Alotaiby
    public DataSet GetLog()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT fname,lname,username,role,log from loginlog order by log DESC", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method used to manage the customer account details.
    // Created by : Fahad Alajmi
    public double CheckBoxAmount(string username)
    {
        DataSet ds = new DataSet();
        double tamount = 0.0;
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_CashBoxAmount", con);
        cmd.CommandText = "sp_CashBoxAmount";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter username1 = cmd.Parameters.Add("@username", SqlDbType.VarChar, 100);
        username1.Value = username;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (reader[0] != DBNull.Value)
            {
                tamount = Convert.ToDouble(reader[0]);
            }
            else
            {
                tamount = 0.0;
            }

        }

        con.Close();

        return tamount;
    }

    // This method deposits the money in customer account .
    // Created by : Fahad Alajmi
    public int InsertCashBox(string username, string amount, DateTime tdate)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_CashBox", con);
        cmd.CommandText = "sp_CashBox";
        cmd.CommandType = CommandType.StoredProcedure;


        SqlParameter username1 = cmd.Parameters.Add("@username", SqlDbType.VarChar, 100);
        SqlParameter amount1 = cmd.Parameters.Add("@amount", SqlDbType.VarChar, 100);
        SqlParameter tdate1 = cmd.Parameters.Add("@tdate", SqlDbType.DateTime);

        username1.Value = username;
        amount1.Value = amount;
        tdate1.Value = tdate;

        int result = cmd.ExecuteNonQuery();

        con.Close();
        return result;
    }

    // This method retrieves the builiding details by city and state .
    // Created by : Fawaz Alotaiby
    public DataSet getCityState()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT city,state from buildingrequests", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method retrieves the builiding details based on search criteria.
    // Created by : Fawaz Alotaiby
    public DataSet getBuildingSearchDetails(string item1,string item2)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_buildingsearchdetails", con);
        cmd.CommandText = "sp_buildingsearchdetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@item1", item1);
        cmd.Parameters.AddWithValue("@item2", item2);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method retrieves all the builiding details.
    // Created by : Fawaz Alotaiby
    public DataSet getAllBuildingDetail()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_buildingAlldetails", con);
        cmd.CommandText = "sp_buildingAlldetails";
        cmd.CommandType = CommandType.StoredProcedure;        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }


    // This method is for buying the building and update the status to "BOUGHT".
    // Created by : Fahad Alajmi
    public int buyOwnerBuilding(string bid, string bowner, string customer, double cost)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_propertyaction", con);
        cmd.CommandText = "sp_propertyaction";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bid",bid );
        cmd.Parameters.AddWithValue("@bowner", bowner);
        cmd.Parameters.AddWithValue("@customer", customer);
        cmd.Parameters.AddWithValue("@cost", cost);
        cmd.Parameters.AddWithValue("@fromdate", DateTime.Now);
        cmd.Parameters.AddWithValue("@todate", "N/A");
        cmd.Parameters.AddWithValue("@type", "sale");
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    // This method is for renting the building and update the status to "BOOKED".
    // Created by : Fahad Alajmi
    public int rentOwnerBuilding(string bid, string bowner, string customer, double cost,string fromdate, string todate)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_propertyaction", con);
        cmd.CommandText = "sp_propertyaction";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bid", bid);
        cmd.Parameters.AddWithValue("@bowner", bowner);
        cmd.Parameters.AddWithValue("@customer", customer);
        cmd.Parameters.AddWithValue("@cost", cost);
        cmd.Parameters.AddWithValue("@fromdate", fromdate);
        cmd.Parameters.AddWithValue("@todate", todate);
        cmd.Parameters.AddWithValue("@type", "rental");
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    // This method is for retrieving the customer property details.
    // Created by : Fawaz Alotaiby
    public DataSet getCustomerPropertyDetails(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_customerproperydetails", con);
        cmd.CommandText = "sp_customerproperydetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@customer", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method is for retrieving the agent amount details.
    // Created by : Fawaz Alotaiby
    public DataSet getCreditDetails(string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_agentcreditdetails", con);
        cmd.CommandText = "sp_agentcreditdetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@owner", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method is for retrieving the agent total credited amount.
    // Created by : Fawaz Alotaiby
    public string getTotalAmount(string username)
    {
        string tamount = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_totalamount", con);
        cmd.CommandText = "sp_totalamount";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@owner", username);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (reader[0] != DBNull.Value)
            {
                tamount = Convert.ToString(reader[0]);
            }
            else
            {
                tamount = "0";
            }

        }

        con.Close();

        return tamount;
    }


    // This method is for generating the registration documents for customer.
    // Created by : Fahad Alajmi
    public DataSet propertyPDFDetails(string bid, string username)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_propertypdf", con);
        cmd.CommandText = "sp_propertypdf";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bid", bid);
        cmd.Parameters.AddWithValue("@customer", username);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    // This method used to update the building status from "BOOKED" to "APPROVED" after lease has been over.
    // Created by : Fahad Alajmi
    public void updateStatus()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_updatebuildingstatus", con);
        cmd.CommandText = "sp_updatebuildingstatus";
        cmd.CommandType = CommandType.StoredProcedure;       
        int result = cmd.ExecuteNonQuery();
        con.Close();
    }
}