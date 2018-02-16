// Angelica Catalan, 300846458
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
            try
            {
                GetDetails();
                if (User.Identity.Name != "manager")
                {
                    ToggleEditPrivileges(false);
                }
                else
                {
                    ToggleEditPrivileges(true);
                }
            }
            catch (SqlException)
            {
                lblTitle.Text = "Uh oh. Something went wrong!";
                lblError.Text = "We couldn't find that book :c";
                pnlDetails.Visible = false;
                return;
            }

            lblError.Text = "";
            pnlDetails.Visible = true;
        }
    }
    // Angelica Catalan, 300846458
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand comm = new SqlCommand("delete from Books where Id = @Id", conn);
        comm.Parameters.AddWithValue("@Id", Request.QueryString["id"]);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }

        Response.Redirect("books.aspx");
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
            dtlDetails.DataSource = reader;
            dtlDetails.DataBind();

            reader.Close();

            reader = comm.ExecuteReader();
            reader.Read();
            string title = reader["Title"].ToString();

            this.Title = title;
            lblTitle.Text = title;
        }
        finally
        {
            conn.Close();
        }
    }

    private void GetGenres()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand comm = new SqlCommand("select * from Genres", conn);

        try
        {
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            DropDownList ddlGenre = dtlDetails.Items[0].FindControl("ddlGenre") as DropDownList;
            ddlGenre.DataSource = reader;
            ddlGenre.DataValueField = "Id";
            ddlGenre.DataTextField = "Genre";
            ddlGenre.DataBind();

            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void dtlDetails_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            dtlDetails.EditItemIndex = e.Item.ItemIndex;
            GetDetails();
            GetGenres();
        }
        else if (e.CommandName == "CancelEditing")
        {
            dtlDetails.EditItemIndex = -1;
            GetDetails();
        }
        else if (e.CommandName == "UpdateItem")
        {
            int bookId = Convert.ToInt32(e.CommandArgument);
            TextBox txtTitle = e.Item.FindControl("txtTitle") as TextBox;
            TextBox txtAuthors = e.Item.FindControl("txtAuthors") as TextBox;
            TextBox txtIsbn = e.Item.FindControl("txtIsbn") as TextBox;
            TextBox txtPages = e.Item.FindControl("txtPages") as TextBox;
            DropDownList ddlGenre = e.Item.FindControl("ddlGenre") as DropDownList;
            TextBox txtBorrower = e.Item.FindControl("txtBorrower") as TextBox;
            TextBox txtComments = e.Item.FindControl("txtComments") as TextBox;

            string title = txtTitle.Text;
            string authors = txtAuthors.Text;
            string isbn = txtIsbn.Text;
            int pages = Int32.Parse(txtPages.Text);
            string genre = ddlGenre.SelectedItem.Text;
            string borrower = txtBorrower.Text;
            string comments = txtComments.Text;

            UpdateBook(bookId, title, authors, isbn, pages, genre, borrower, comments);

            dtlDetails.EditItemIndex = -1;
            GetDetails();
        }
        else if (e.CommandName == "AddGenre")
        {
            TextBox txtNewGenre = e.Item.FindControl("txtNewGenre") as TextBox;
            string newGenre = txtNewGenre.Text;

            if (!string.IsNullOrEmpty(newGenre))
            {
                AddGenre(newGenre);
                GetGenres();
            }
        }
    }

    private void ToggleEditPrivileges(bool isEnabled)
    {
        LinkButton lnkEdit = dtlDetails.Items[0].FindControl("lnkEdit") as LinkButton;
        lnkEdit.Visible = isEnabled;
        btnDelete.Visible = isEnabled;
    }

    private void UpdateBook(int bookId, string title, string authors, string isbn, int pages, string genre, string borrower, string comments)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand comm = new SqlCommand("update books set Title=@Title, Authors=@Authors, Isbn=@Isbn, Pages=@Pages, Genre=@Genre, Borrower=@Borrower, Comments=@Comments where Id = @Id", conn);

        comm.Parameters.AddWithValue("@Id", bookId);
        comm.Parameters.AddWithValue("@Title", title);
        comm.Parameters.AddWithValue("@Authors", authors);
        comm.Parameters.AddWithValue("@Isbn", isbn);
        comm.Parameters.AddWithValue("@Pages", pages);
        comm.Parameters.AddWithValue("@Genre", genre);
        comm.Parameters.AddWithValue("@Borrower", borrower);
        comm.Parameters.AddWithValue("@Comments", comments);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
    }

    private void AddGenre(string genre)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand comm = new SqlCommand("insert into Genres (Genre) values (@Genre)", conn);
        comm.Parameters.AddWithValue("@Genre", genre);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
    }
}
// Angelica Catalan, 300846458