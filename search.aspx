<%-- Angelica Catalan, 300846458 --%>
<%@ Page Title="Search - Library" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Search</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:dropdownlist runat="server" ID="ddlGenre"></asp:dropdownlist>
    <asp:dropdownlist runat="server" ID="ddlBorrower"></asp:dropdownlist>
    <asp:button runat="server" ID="btnSearch" text="Search" />
<%-- Angelica Catalan, 300846458 --%>
    <asp:panel runat="server" ID="pnlResults">
        Results:<br />
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
    </asp:panel>
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>