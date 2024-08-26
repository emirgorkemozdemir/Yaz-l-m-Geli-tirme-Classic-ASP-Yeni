using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
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


        if (commandRegister.ExecuteNonQuery()==1)
        {
            Response.Write("Kayıt başarılı, ana sayfaya yönlendiriliyorsunuz.");
            Thread.Sleep(3000);

            // Birisi tarayıcıdan sizin web sitenize girdiğinde onun için otomatik olarak bir 
            // session açılır. Bu session içerisinde kullanıcıyla veya yaptığı işlemlerle ilgili
            // verileri tutabilirsiniz.
            Session["LoggedUserName"] = tboxUsername.Text;
            Session["IsUserLogged"] = true;

            // Başka bir sayfaya yönlendirme yapar.
            Response.Redirect("Main.aspx");
        }
    }
}