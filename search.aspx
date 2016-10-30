<%@ Page MasterPageFile="MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>
<%@ Register TagPrefix="uc" TagName="nameLbl" Src="nameLabelUserCtrl.ascx" %>
<script runat="server">
    
   
</script>


<%--Create a "Content" to show in ContentPlaceHolder (PH) on Master. and direct to ID for PH--%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="search" runat="server" >

    <%--For radio btn to fire OnCheckedChanged, must have AutoPostBack="true"--%>
    Search by Recipe Name:
    <asp:RadioButton AutoPostBack="true"   GroupName="searchCriteria" ID="radSearchRcpName" runat="server" OnCheckedChanged="rad_CheckedChanged" /><br />
    Search by Person Name:
    <asp:RadioButton  AutoPostBack="true" OnCheckedChanged="rad_CheckedChanged" GroupName="searchCriteria" ID="radSearchSubmitBy" runat="server" /><br />
    <br />    <br />
    <uc:nameLbl  Visible="false" ID="searchBy" runat="server"  />
    <br />
    
    Search in Public Recipes: <asp:CheckBox ID="CheckBox1" runat="server" />

    <br />    <br />


    <asp:Button ID="searchBtn" runat="server" Text="Search" />


</asp:Content>

























<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>
