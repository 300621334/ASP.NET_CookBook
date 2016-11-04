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


    <asp:Button OnClick="searchBtn_Click" ID="searchBtn" runat="server" Text="Search" />
    <br /><br />
<%--================================================================================--%>
    
    
    <asp:GridView ID="searchGridView" runat="server"></asp:GridView>


<%--================================================================================--%>
    <asp:DataList ID="displayRecipes" runat="server" OnItemCommand="displayRecipes_ItemCommand">
        
        <ItemTemplate>
            <%# "Recipe:" + Eval("recipeName") %>

            <%--EnableViewState="false" inside Literal would erase itself & showDetal btn doesn't show anything--%>
            <asp:Literal ID="byLit" runat="server"        Text=<%# "<br />Sumbitted By: " + Eval("fromName")    +"<br />" %>        Visible="false"     />
            <asp:Literal ID="timeLit" runat="server"      Text=<%# "Cooking time: " +  Eval("cookingTime") +"<br />" %>   Visible="false"     />
            <asp:Literal ID="portionLit" runat="server"   Text=<%# "For " +  Eval("portions") + " persons"   +"<br />" %>       Visible="false"     />
            <asp:Literal ID="categoryLit" runat="server"  Text=<%# "Category: " +  Eval("category")    +"<br />" %>      Visible="false"     />
            <asp:Literal ID="cuisineLit" runat="server"   Text=<%#  "Cuisine: " + Eval("cuisine")     +"<br />" %>       Visible="false"     />
            <asp:Literal ID="descLit" runat="server"      Text=<%# "Instructions: <br/>" +  Eval("description") +"<br />" %>   Visible="false"     />
            
            <%--ctrls encloded inside Templates cannot be accessed by C# code. Template itself can fire event then we compare 'CommandName' att of ctrl to find which particular item, out of the whole list, fired. 'CommandArgument' is sent to event handler as arg--%>
            <%--if there r more btns then ea will have unique CommandName & will be ID using that--%>
            <asp:Button ID="showMore" runat="server" Text=<%# "Details of "+ Eval("recipeName") %> CommandName="showMore" CommandArgument=<%# Eval("recipeName") %> />
            

        </ItemTemplate>

        
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>

    </asp:DataList>



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
