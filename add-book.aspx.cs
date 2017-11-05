using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add_book : System.Web.UI.Page
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
    }

    protected void CheckFriendName(object sender, ServerValidateEventArgs e)
    {
        if (radLandedYes.Checked && string.IsNullOrEmpty(txtFriendName.Text))
        {
            e.IsValid = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            List<Book> books = Application["books"] as List<Book>;
            string title, author, isbn, genre, friend, comments;
            int numPages;
            Book newBook;

            title = bbiEntry.Title.Text;
            author = bbiEntry.Author.Text;
            isbn = bbiEntry.Isbn.Text;
            genre = ddlGenre.SelectedValue;
            friend = txtFriendName.Text;
            comments = txtComments.Text;

            if (!Int32.TryParse(txtPages.Text, out numPages))
            {
                numPages = 1;
            }

            newBook = new Book(title, author, genre, numPages, isbn, friend, comments);
            books.Add(newBook);
            Application["books"] = books;
        }
    }
}