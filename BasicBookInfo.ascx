<%-- Angelica Catalan, 300846458 --%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BasicBookInfo.ascx.cs" Inherits="BasicBookInfo" %>

Title: <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
<asp:requiredfieldvalidator runat="server" errormessage="Title required" ID="rfvTitle" ControlToValidate="txtTitle" ForeColor="Red"></asp:requiredfieldvalidator>
<br />
Author(s): <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
<asp:requiredfieldvalidator runat="server" errormessage="Author required" ID="rfvAuthor" ControlToValidate="txtAuthor" ForeColor="Red"></asp:requiredfieldvalidator>
<br />
ISBN: <asp:TextBox ID="txtIsbn" runat="server"></asp:TextBox>
<%-- Angelica Catalan, 300846458 --%>