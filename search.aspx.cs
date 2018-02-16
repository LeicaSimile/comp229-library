// Angelica Catalan, 300846458
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
    // Angelica Catalan, 300846458
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindResults();
    }

    protected void rptBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Response.Redirect(String.Format("book-details.aspx?id={0}", e.CommandArgument));
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

    private void BindResults()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        string author = txtAuthor.Text.Trim();
        string genre = ddlGenre.SelectedItem.Text;
        string borrower = ddlBorrower.SelectedItem.Text;
        bool hasAddedWhere = false;

        SqlCommand comm = new SqlCommand("select Id, Title, Authors, Isbn from Books", conn);
        if (!string.IsNullOrEmpty(author))
        {
            hasAddedWhere = true;
            comm.CommandText += " where Authors like @Authors";
            comm.Parameters.AddWithValue("@Authors", string.Format("%{0}%", author));
        }

        if (ddlGenre.SelectedIndex != 0)
        {
            if (!hasAddedWhere)
            {
                comm.CommandText += " where ";
                hasAddedWhere = true;
            }
            else
                comm.CommandText += " and ";
            comm.CommandText += " Genre = @Genre";
            comm.Parameters.AddWithValue("@Genre", genre);
        }

        if (ddlBorrower.SelectedIndex != 0)
        {
            if (!hasAddedWhere)
                comm.CommandText += " where ";
            else
                comm.CommandText += " and ";
            comm.CommandText += " Borrower = @Borrower";
            comm.Parameters.AddWithValue("@Borrower", borrower);
        }

        try
        {
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            rptBooks.DataSource = reader;
            rptBooks.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }
}
// Angelica Catalan, 300846458