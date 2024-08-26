using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        MyConnection.CheckConnection();
        SqlCommand commandLogin = new SqlCommand("SELECT * FROM TableUser WHERE UserName = @puser AND UserPassword=@ppass", MyConnection.connection);
        commandLogin.Parameters.AddWithValue("@puser", tboxUsername.Text);
        commandLogin.Parameters.AddWithValue("@ppass", ShaHash.ComputeSha256Hash(tboxPassword.Text));
        SqlDataReader dataReader = commandLogin.ExecuteReader();

        if (dataReader.HasRows)
        {
            Session["LoggedUserName"] = tboxUsername.Text;
            Session["IsUserLogged"] = true;
            dataReader.Close();
            Response.Redirect("Main.aspx");
        }
        else
        {
            dataReader.Close();
            Response.Write("Giriş Başarısız");
        }
    }
}