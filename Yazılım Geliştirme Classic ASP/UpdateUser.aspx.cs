using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateUser : System.Web.UI.Page
{
    int user_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["IsUserLogged"]) != true)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Page.IsPostBack)
            {
                // Sayfa post olduğunda yani veri girilip butona basıldığında ve bu sebepten
                // sayfa yenilendiğinde postback işlemi çalışıyor. Yani sayfa veri girilmesi
                // sebebiyle yenilenmiş.

                // Post sonucu yenilendiği için tekrardan linkten gelen kullanıcı adını almamam lazım.
            }
            else
            {

                string username = Request.QueryString["username"].ToString();
                tboxUserName.Text = username;
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        user_id = Convert.ToInt32(Request.QueryString["userid"]);
        MyConnection.CheckConnection();
        SqlCommand commandUpdate = new SqlCommand("UPDATE TableUser SET UserName=@pusername WHERE UserID=@pid",MyConnection.connection);
        commandUpdate.Parameters.AddWithValue("@pusername",tboxUserName.Text);
        commandUpdate.Parameters.AddWithValue("@pid", user_id);
        commandUpdate.ExecuteNonQuery();
        Response.Redirect("Main.aspx");
    }
}