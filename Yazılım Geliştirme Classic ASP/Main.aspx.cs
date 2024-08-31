using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    public void GetUsersByPageNumber(int pagenum=1)
    {
        int upper_limit = pagenum * 5;
        int lower_limit = (pagenum - 1)*5;
      
        MyConnection.CheckConnection();
        SqlCommand command_get_users = new SqlCommand("WITH NumberedRows AS ( SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum FROM TableUser ) SELECT * FROM NumberedRows WHERE RowNum BETWEEN @plower AND @pupper;", MyConnection.connection);
        command_get_users.Parameters.AddWithValue("@plower", lower_limit);
        command_get_users.Parameters.AddWithValue("@pupper", upper_limit);
        SqlDataReader dataReader = command_get_users.ExecuteReader();

        ListView1.DataSource = dataReader;
        ListView1.DataBind();
        dataReader.Close();
    }

    private void LoadUsers()
    {
        lblPages.Text = "";

        // Buradaki amaç kullanıcı sayısını tespit etmek. Ne kadar veri
        // geldiğini bulup ona göre kaç sayfa yapacağımızı hesaplamak için 
        // user_count'u kullanacağız.
        int user_count = 0;
        MyConnection.CheckConnection();
        SqlCommand command_get_users = new SqlCommand("SELECT * FROM TableUser", MyConnection.connection);
        SqlDataReader dataReader = command_get_users.ExecuteReader();

        while (dataReader.Read())
        {
            user_count++;
        }
        dataReader.Close();


        int page_num = 0;
        if (user_count % 5 == 0)
        {
            page_num = user_count / 5;
        }
        else
        {
            page_num = (user_count / 5) + 1;
        }

        for (int i = 1; i <= page_num; i++)
        {
            lblPages.Text += $"<a href='PageNumSetter.aspx?pagenum={i}'>{i}</a>";
            lblPages.Text += $"<span>  </span>";
        }

        if (Convert.ToInt32(Session["PageNum"]) == 1)
        {
            GetUsersByPageNumber(1);
        }
        else
        {
            GetUsersByPageNumber(Convert.ToInt32(Session["PageNum"]));
        }
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Convert.ToBoolean(Session["IsUserLogged"]) != true)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            LoadUsers();


        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }

    protected void tboxFilter_TextChanged(object sender, EventArgs e)
    {
        if (tboxFilter.Text=="")
        {
            LoadUsers();
        }
        else
        {
            MyConnection.CheckConnection();
            SqlCommand command_get_users = new SqlCommand("SELECT * FROM TableUser WHERE UserName LIKE @pname", MyConnection.connection);
            command_get_users.Parameters.AddWithValue("@pname", "%" + tboxFilter.Text + "%");
            SqlDataReader dataReader = command_get_users.ExecuteReader();

            ListView1.DataSource = dataReader;
            ListView1.DataBind();
            dataReader.Close();
        }
    }
}