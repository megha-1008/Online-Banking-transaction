﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Online_Bank_Transaction_
{
    public class Common
    {
        public static string GetConnectionsString()
        {
            return ConfigurationManager.ConnectionStrings["BankTransactionDBConnectionString"].ConnectionString;
        }
    }
    public class Utils
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public int accountBalance(int userId)
        {
            int balanceAmount = 0;
            try
            {
                con = new SqlConnection(Common.GetConnectionsString());
                cmd = new SqlCommand("@Select Amount from Account where AccountId = @AccountId" ,con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                balanceAmount = Convert.ToInt32(dt.Rows[0]["Amount"]) == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["Amount"]);
            }
            catch(Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('Error - '" + ex.Message + ")<script>");
            }
            return balanceAmount;
        }
    }
}