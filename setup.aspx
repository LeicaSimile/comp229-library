<%-- Angelica Catalan, 300846458 --%>
<%@ Page Title="Setup - Library" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeFile="setup.aspx.cs" Inherits="setup" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="headerContent" Runat="Server">
    <h1>Setup</h1>
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" Runat="Server">
    Theme:
    <asp:radiobutton ID="radLight" runat="server" Text="Light" GroupName="grpTheme" Checked="True"></asp:radiobutton>
    <asp:radiobutton ID="radDark" runat="server" Text="Dark" GroupName="grpTheme"></asp:radiobutton>
    <br />
    <asp:button ID="btnSave" runat="server" text="Save" OnClick="btnSave_Click" />
</asp:Content>
<%-- Angelica Catalan, 300846458 --%>