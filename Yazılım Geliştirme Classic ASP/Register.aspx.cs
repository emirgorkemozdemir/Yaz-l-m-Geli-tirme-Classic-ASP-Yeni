using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        MyConnection.CheckConnection();
        SqlCommand commandRegister = new SqlCommand("INSERT INTO TableUser (UserName,UserPassword) VALUES (@pname,@ppass)",MyConnection.connection);
        commandRegister.Parameters.AddWithValue("@pname",tboxUsername.Text);
        commandRegister.Parameters.AddWithValue("@ppass",ShaHash.ComputeSha256Hash(tboxPassword.Text));
        commandRegister.ExecuteNonQuery();

    }
}