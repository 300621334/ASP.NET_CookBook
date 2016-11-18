<%@ Page ViewStateMode="Disabled" MasterPageFile="MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="add" %>

<%--Register the custom-made user-ctrl--%>
<%@ Register TagPrefix="uc" TagName="nameLbl" Src="nameLabelUserCtrl.ascx" %>

<%--Create a "Content" to show in ContentPlaceHolder (PH) on Master. and direct to ID for PH--%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="add" runat="server">
    <p style="color:red; font-weight:400;">Required fields are marked by '*'</p>
    <div id="alignAddPageFields">
        <span style="color:red; font-weight:400;">*</span>
        <uc:nameLbl ID="recipeName" ucProp="Recipe Name: " runat="server" />
        <%--to validate a component of custom made user ctrl, do this: ucID$componentCtrlID, separated by dollar sign::  http://stackoverflow.com/questions/359422/web-user-controls-and-validation--%>
        <asp:RequiredFieldValidator SetFocusOnError="true" ID="rcpNameValidator" runat="server" ErrorMessage="Name cannot be empty!" ControlToValidate="recipeName$TextBox1" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

        <span style="color:red; font-weight:400;">*</span>
        <uc:nameLbl ID="submitBy" ucProp="Submitted By: " runat="server" />
<%--<asp:DropDownList ID="submitByList" runat="server" /><br />--%>
        <asp:RequiredFieldValidator SetFocusOnError="true" Display="None" ID="sumbitByValidator" runat="server" ErrorMessage="Please enter your name." ControlToValidate="submitBy$TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>

        <uc:nameLbl ID="cookTime" ucProp="Cooking Time: " runat="server" />
        <asp:CompareValidator ControlToValidate="cookTime$TextBox1" Type="Integer" Operator="GreaterThan" ValueToCompare="0" ID="cookTimeValidator" runat="server" Display="None" ErrorMessage="Cook time must be a number & greater than 0"></asp:CompareValidator>
        
        <uc:nameLbl ID="portions" ucProp="Portions: " runat="server" />
        <asp:CompareValidator ControlToValidate="portions$TextBox1" Type="Integer"  Operator="GreaterThan" ValueToCompare="0" ID="portionsValidator" runat="server" Display="None" ErrorMessage="Portions must be a number & greater than 0"></asp:CompareValidator>
    
    </div>
    
    <%--divEnd for alignAddPageFields --%>

    
    <div id="alignAddPageDropDownLists">
        
            Select Category: 
        <asp:DropDownList ID="category" runat="server">
 <%--i'm populating categories thru C# code hence following ListItems r overridden when webpage launches--%>
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
        <span style="color:red; font-weight:400;">*</span>
        Description:
        <br />
        <asp:TextBox CssClass="desc" TextMode="MultiLine" Columns="130" Rows="10" ID="desc" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="desc" ID="descValidator" runat="server" ErrorMessage="Please write the recipe instructions."></asp:RequiredFieldValidator>
    </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

    <p>
        <asp:Button OnClick="saveRecipe" OnClientClick="" ID="submitBtn" runat="server" Text="Save Recipe" />
        <input type="reset" value="Clear Form" />
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
