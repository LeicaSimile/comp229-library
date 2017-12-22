using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            BindSearchOptions();
        }
    }

    private void BindSearchOptions()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand commGenres = new SqlCommand("select Id, Genre from Genres", conn);
        SqlCommand commBorrower = new SqlCommand("select Id, Borrower from Books where Borrower is not null", conn);

        try
        {
            conn.Open();
            SqlDataReader reader = commGenres.ExecuteReader();

            ddlGenre.DataSource = reader;
            ddlGenre.DataValueField = "Id";
            ddlGenre.DataTextField = "Genre";
            ddlGenre.DataBind();
            reader.Close();
            ddlGenre.Items.Insert(0, new ListItem("All", "0"));

            reader = commBorrower.ExecuteReader();
            ddlBorrower.DataSource = reader;
            ddlBorrower.DataValueField = "Id";
            ddlBorrower.DataTextField = "Borrower";
            ddlBorrower.DataBind();
            reader.Close();
            ddlBorrower.Items.Insert(0, new ListItem("All", "0"));
        }
        finally
        {
            conn.Close();
        }
    }

    protected void rptBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Response.Redirect(String.Format("book-details.aspx?id={0}", e.CommandArgument));
    }
}