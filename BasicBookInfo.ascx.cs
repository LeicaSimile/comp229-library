using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BasicBookInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public TextBox Title
    {
        get { return this.txtTitle; }
    }

    public TextBox Author
    {
        get { return this.txtAuthor; }
    }

    public TextBox Isbn
    {
        get { return this.txtIsbn; }
    }
}