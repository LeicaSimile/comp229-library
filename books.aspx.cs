using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class books : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        string theme;
        theme = (string)Session["theme"];

        if (!string.IsNullOrEmpty(theme))
        {
            Page.Theme = theme;
        }
        else
        {
            Page.Theme = "light";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["books"] == null)
        {
            Application["books"] = new List<Book>();
        }

        rptBooks.DataSource = Application["books"] as List<Book>;
        rptBooks.DataBind();
    }
}