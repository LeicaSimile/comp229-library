using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_details : System.Web.UI.Page
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
            GetDetails();
        }
    }

    private void GetDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand comm = new SqlCommand("select * from Books where Id = @Id", conn);
        comm.Parameters.AddWithValue("@Id", Request.QueryString["id"]);

        try
        {
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            string title = reader["Title"].ToString();
            string authors = reader["Authors"].ToString();
            string isbn = reader["Isbn"].ToString();
            string pages = reader["Pages"].ToString();
            string genre = reader["Genre"].ToString();
            string borrower = reader["Borrower"].ToString();
            string comments = reader["Comments"].ToString();

            reader.Close();

            this.Title = title;
            lblTitle.Text = title;
            lblAuthors.Text = authors;
            lblIsbn.Text = isbn;
            lblPages.Text = pages;
            lblGenre.Text = genre;
            lblBorrower.Text = borrower;
            lblComments.Text = comments;
        }
        finally
        {
            conn.Close();
        }
    }
}