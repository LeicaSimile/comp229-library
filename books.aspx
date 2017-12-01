<%-- Angelica Catalan, 300846458 --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="books.aspx.cs" Inherits="books" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Books</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
<%-- Angelica Catalan, 300846458 --%>
    <asp:repeater runat="server" id="rptBooks">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><asp:LinkButton ID="lbtnBook" runat="server" Text=<%# DataBinder.Eval(Container.DataItem, "Title") %> />
                by <%# DataBinder.Eval(Container.DataItem, "Author") %> 
                (ISBN: <%# DataBinder.Eval(Container.DataItem, "Isbn") %>)
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:repeater>
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>
