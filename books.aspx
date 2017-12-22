<%-- Angelica Catalan, 300846458 --%>
<%@ Page Title="Books - Library" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="books.aspx.cs" Inherits="books" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Books</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
<%-- Angelica Catalan, 300846458 --%>
    <asp:repeater runat="server" id="rptBooks" OnItemCommand="rptBooks_ItemCommand">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><asp:LinkButton ID="lbtnBook" runat="server" Text=<%# Eval("Title") %> CommandArgument=<%# Eval("Id") %> />
                by <%# Eval("Authors") %> 
                (ISBN: <%# Eval("Isbn") %>)
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:repeater>
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>
