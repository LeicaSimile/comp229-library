<%@ Page Title="" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="add-book.aspx.cs" Inherits="add_book" Theme="default" %>
<%@ Register TagPrefix="field" TagName="BasicBookInfo" Src="~/BasicBookInfo.ascx" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Add Book</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
    <field:BasicBookInfo ID="bbiEntry" runat="server" />
    <br />
    Genre: <asp:DropDownList ID="ddlGenre" runat="server">
        <asp:ListItem>Action/adventure</asp:ListItem>
        <asp:ListItem>Drama</asp:ListItem>
        <asp:ListItem>Fantasy</asp:ListItem>
        <asp:ListItem>Horror</asp:ListItem>
        <asp:ListItem>Mystery</asp:ListItem>
        <asp:ListItem>Romance</asp:ListItem>
        <asp:ListItem>Satire</asp:ListItem>
        <asp:ListItem>Sci-fi</asp:ListItem>
        <asp:ListItem>Other</asp:ListItem>
    </asp:DropDownList>
    Number of pages: <asp:TextBox ID="txtPages" runat="server" TextMode="Number"></asp:TextBox>
    <asp:requiredfieldvalidator runat="server" errormessage="Number of pages required" ID="rfvPages" ControlToValidate="txtPages"></asp:requiredfieldvalidator>
    <asp:rangevalidator runat="server" errormessage="Book must have at least 1 page." ID="rvPages" ControlToValidate="txtPages" MinimumValue="1" MaximumValue="99999"></asp:rangevalidator>
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

