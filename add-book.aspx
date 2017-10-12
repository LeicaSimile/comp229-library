<%@ Page Title="" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="add-book.aspx.cs" Inherits="add_book" Theme="default" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Add Book</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
    Title: <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    Author(s): <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
    ISBN: <asp:TextBox ID="txtIsbn" runat="server"></asp:TextBox>
    <br />
    Genre: <asp:DropDownList ID="ddlGenre" runat="server"></asp:DropDownList>
    Number of pages: <asp:TextBox ID="txtPages" runat="server" TextMode="Number"></asp:TextBox>
    <br />
    Landed to a friend:
    <asp:RadioButton ID="radLandedYes" runat="server" GroupName="grpLanded" Text="Yes" />
    <asp:RadioButton ID="radLandedNo" runat="server" Text="No" GroupName="grpLanded" />
    <br />
    Name of a friend: <asp:TextBox ID="txtFriendName" runat="server"></asp:TextBox>
    <br />
    Comments:
    <br />
    <asp:TextBox ID="txtComments" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</asp:Content>

