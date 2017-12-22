<%-- Angelica Catalan, 300846458 --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="book-details.aspx.cs" Inherits="book_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    <h1><asp:Label ID="lblTitle" runat="server" /></h1>
    Author(s): <asp:Label ID="lblAuthors" runat="server" /><br />
    ISBN: <asp:Label ID="lblIsbn" runat="server" /><br />
    Pages: <asp:Label ID="lblPages" runat="server" /><br />
    Genre: <asp:Label ID="lblGenre" runat="server" /><br />
    Borrower: <asp:Label ID="lblBorrower" runat="server" /><br />
    Comments: <asp:Label ID="lblComments" runat="server" /><br />

    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>