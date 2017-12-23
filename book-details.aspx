<%-- Angelica Catalan, 300846458 --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="book-details.aspx.cs" Inherits="book_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Book Details</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    <%-- Angelica Catalan, 300846458 --%>
    <h2><asp:Label ID="lblTitle" runat="server" /></h2>
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <asp:Panel ID="pnlDetails" runat="server">
        Author(s): <asp:Label ID="lblAuthors" runat="server" /><br />
        ISBN: <asp:Label ID="lblIsbn" runat="server" /><br />
        Pages: <asp:Label ID="lblPages" runat="server" /><br />
        Genre: <asp:Label ID="lblGenre" runat="server" /><br />
        Borrower: <asp:Label ID="lblBorrower" runat="server" /><br />
        Comments: <asp:Label ID="lblComments" runat="server" /><br />

        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    </asp:Panel>
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>