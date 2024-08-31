using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageNumSetter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["IsUserLogged"]) != true)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            int pnum =Convert.ToInt32(Request.QueryString["pagenum"]);
            Session["PageNum"] = pnum;
            Response.Redirect("Main.aspx");
        }
    }
}