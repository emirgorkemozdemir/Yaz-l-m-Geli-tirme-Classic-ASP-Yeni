using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Convert.ToBoolean(Session["IsUserLogged"]) != true)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            MyConnection.CheckConnection();
            SqlCommand command_get_users = new SqlCommand("SELECT * FROM TableUser",MyConnection.connection);
            SqlDataReader dataReader = command_get_users.ExecuteReader();

            ListView1.DataSource = dataReader;
            ListView1.DataBind();
            dataReader.Close();
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }

    protected void tboxFilter_TextChanged(object sender, EventArgs e)
    {
        MyConnection.CheckConnection();
        SqlCommand command_get_users = new SqlCommand("SELECT * FROM TableUser WHERE UserName LIKE @pname", MyConnection.connection);
        command_get_users.Parameters.AddWithValue("@pname","%"+tboxFilter.Text+"%");
        SqlDataReader dataReader = command_get_users.ExecuteReader();

        ListView1.DataSource = dataReader;
        ListView1.DataBind();
        dataReader.Close();
    }
}