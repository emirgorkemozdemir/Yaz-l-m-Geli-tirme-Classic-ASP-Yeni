using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["IsUserLogged"]) != true)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            int selected_user_id = Convert.ToInt32(Request.QueryString["userid"]);

            MyConnection.CheckConnection();

            SqlCommand command_delete = new SqlCommand("DELETE FROM TableUser WHERE UserID=@pid", MyConnection.connection);
            command_delete.Parameters.AddWithValue("@pid", selected_user_id);
            command_delete.ExecuteNonQuery();
            Response.Redirect("Main.aspx");
        }
    }
}