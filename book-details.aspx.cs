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

    protected void dtlDetails_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            dtlDetails.EditItemIndex = e.Item.ItemIndex;
            GetDetails();
        }
    }
}
// Angelica Catalan, 300846458