<%-- Angelica Catalan, 300846458 --%>
<%@ Page Title="Add Book - Library" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="add-book.aspx.cs" Inherits="add_book" %>
<%@ Register TagPrefix="field" TagName="BasicBookInfo" Src="~/BasicBookInfo.ascx" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Add Book</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
    <field:BasicBookInfo ID="bbiEntry" runat="server" />
    <br />
    Genre: <asp:DropDownList ID="ddlGenre" runat="server" />
<%-- Angelica Catalan, 300846458 --%>
    <br />
    Number of pages: <asp:TextBox ID="txtPages" runat="server" TextMode="Number"></asp:TextBox>
    <asp:requiredfieldvalidator runat="server" errormessage="Number of pages required" ID="rfvPages" ControlToValidate="txtPages" ForeColor="Red"></asp:requiredfieldvalidator>
    <asp:rangevalidator runat="server" errormessage="Book must have at least 1 page." ID="rvPages" ControlToValidate="txtPages" MinimumValue="1" MaximumValue="99999" ForeColor="Red"></asp:rangevalidator>
    <br />
    Lended to a friend:
    <asp:RadioButton ID="radLendedYes" runat="server" GroupName="grpLended" Text="Yes" />
    <asp:RadioButton ID="radLendedNo" runat="server" Text="No" GroupName="grpLended" Checked="True" />
    <br />
    Name of friend: <asp:TextBox ID="txtFriendName" runat="server"></asp:TextBox>
    <asp:CustomValidator ID="vldFriendName" runat="server" OnServerValidate="CheckFriendName" ErrorMessage="Name of friend required" ControlToValidate="txtFriendName" ValidateEmptyText="True" ForeColor="Red"></asp:CustomValidator>
    <br />
    <br />
    Comments:
    <br />
    <asp:TextBox ID="txtComments" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <input type="reset" id="btnCancel" value="Cancel" />
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>
