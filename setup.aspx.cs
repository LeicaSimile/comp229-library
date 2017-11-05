using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class setup : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            if ("dark" == Page.Theme)
            {
                radDark.Checked = true;
            }
            else
            {
                radLight.Checked = true;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (radDark.Checked)
        {
            Session["theme"] = "dark";
        }
        else
        {
            Session["theme"] = "light";
        }
        Server.Transfer(Request.FilePath);
    }
}