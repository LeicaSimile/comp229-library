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
        <asp:DataList ID="dtlDetails" runat="server" OnItemCommand="dtlDetails_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument=<%# Eval("Id") %> CommandName="EditItem">Edit</asp:LinkButton><br />
                Author(s): <%# Eval("Authors") %><br />
                ISBN: <%# Eval("Isbn") %><br />
                Pages: <%# Eval("Pages") %><br />
                Genre: <%# Eval("Genre") %><br />
                Borrower: <%# Eval("Borrower") %><br />
                Comments: <%# Eval("Comments") %><br />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkUpdate" runat="server" CommandArgument=<%# Eval("Id") %> CommandName="UpdateItem">Edit</asp:LinkButton><br />
                Title: <asp:TextBox ID="txtTitle" runat="server" Text=<%# Eval("Title") %>/><br />
                Author(s): <asp:TextBox ID="txtAuthors" runat="server" Text=<%# Eval("Authors") %>/><br />
                ISBN: <asp:TextBox ID="txtIsbn" runat="server" Text=<%# Eval("Isbn") %>/><br />
                Pages: <asp:TextBox ID="txtPages" runat="server" Text=<%# Eval("Pages") %> TextMode="Number" /><br />
                Genre: <asp:DropDownList ID="ddlGenre" runat="server" /><br />
                Borrower: <asp:TextBox ID="txtBorrower" runat="server" Text=<%# Eval("Borrower") %>/><br />
                Comments: <asp:TextBox ID="txtComments" runat="server" Text=<%# Eval("Comments") %> TextMode="MultiLine" /><br />
            </EditItemTemplate>
        </asp:DataList>

        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    </asp:Panel>
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>