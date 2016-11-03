<%@ Page MasterPageFile="MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="add" %>

<%--Register the custom-made user-ctrl--%>
<%@ Register TagPrefix="uc" TagName="nameLbl" Src="nameLabelUserCtrl.ascx" %>

<%--Create a "Content" to show in ContentPlaceHolder (PH) on Master. and direct to ID for PH--%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="add" runat="server">

    <div id="alignAddPageFields">
        <uc:nameLbl ID="recipeName" ucProp="Recipe Name: " runat="server" />
        <uc:nameLbl ID="submitBy" ucProp="Submitted By: " runat="server" />
<%--        <asp:DropDownList ID="submitByList" runat="server" /><br />--%>
        <uc:nameLbl ID="cookTime" ucProp="Cooking Time: " runat="server" />
        <uc:nameLbl ID="portions" ucProp="Portions: " runat="server" />

    </div>
    <%--divEnd for alignAddPageFields --%>

    <div id="alignAddPageDropDownLists">
        
            Select Category: 
        <asp:DropDownList ID="category" runat="server">
            <asp:ListItem Text="category-1" />
            <asp:ListItem Text="category-2" />
            <asp:ListItem Text="category-3" />
            <asp:ListItem Text="category-4" />
            <asp:ListItem Text="category-5" />
            <asp:ListItem Text="category-6" />
            <asp:ListItem Text="category-7" />
        </asp:DropDownList>
        

        <p></p>
        <p>
            Select Cuisine: 
        <asp:DropDownList ID="cuisine" runat="server">
            <asp:ListItem Text="cuisine-1" />
            <asp:ListItem Text="cuisine-2" />
            <asp:ListItem Text="cuisine-3" />
            <asp:ListItem Text="cuisine-4" />
            <asp:ListItem Text="cuisine-5" />
            <asp:ListItem Text="cuisine-6" />
            <asp:ListItem Text="cuisine-7" />
        </asp:DropDownList>
        </p>



        <p>
            Mark as private: 
        <asp:CheckBox ID="CheckBox1" runat="server" />
        </p>
    </div>
    <%--divEnd for alignAddPageDropDownLists--%>


    <p>
        Description:
        <br />
        <asp:TextBox CssClass="desc" TextMode="MultiLine" Columns="130" Rows="10" ID="desc" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Button OnClick="saveRecipe" ID="submitBtn" runat="server" Text="Save Recipe" />
    </p>


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
