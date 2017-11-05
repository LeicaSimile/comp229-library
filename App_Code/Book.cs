using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{
    private int pages;
    
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public string Genre { get; set; }
    public string Friend { get; set; }
    public string Comments { get; set; }

    public int Pages
    {
        get { return pages; }
        set
        {
            // Minimum number of pages is 1.
            if (value <= 0)
            {
                pages = 1;
            }
            else
            {
                pages = value;
            }
        }
    }

    public Book(string title, string author, string genre, int pages,
        string isbn="", string friend="", string comments="")
    {
        this.Title = title;
        this.Author = author;
        this.Genre = genre;
        this.Pages = pages;
        this.Isbn = isbn;
        this.Friend = friend;
        this.Comments = comments;
    }
}