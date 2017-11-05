<%@ Page Title="" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="books.aspx.cs" Inherits="books" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Books</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:repeater runat="server" id="rptBooks">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><i><%# DataBinder.Eval(Container.DataItem, "Title") %></i>
                by <%# DataBinder.Eval(Container.DataItem, "Author") %> 
                (ISBN: <%# DataBinder.Eval(Container.DataItem, "Isbn") %>)
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:repeater>
</asp:Content>

