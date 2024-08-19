using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyConnection
/// </summary>
public class MyConnection
{
    public static SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=StockSystemDB;Integrated Security=True;TrustServerCertificate=True");

    public static void CheckConnection()
    {
        if (connection.State == System.Data.ConnectionState.Closed)
        {
            connection.Open();
        }
    }
}