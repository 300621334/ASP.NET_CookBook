<%@ Page MasterPageFile="MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%--Create a "Content" to show in ContentPlaceHolder (PH) on Master. and direct to ID for PH--%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="default" runat="server" >
   
    


    <img id="chefimg" src="images/clipart.jpg" />
    <br /> <br />
    Welcome to MY COOK BOOK!
    <br /> <br />
    You can search through our already added collection to find the recipe you are looking for. Just click on the SEARCH tab.
    <br /> <br />
    To see a list of all the recipes in store, go to RECIPES link.
    <br /> <br />
    You can also add recipes to our collection. Just click ADD button to your left and enter the details.
    <br />
   
      
        <asp:Label CssClass="appStateCounter" ID="appStateCounter" runat="server" Text="Total visits to this site by all users: "></asp:Label><br />

</asp:Content>























<%--Remove all except for Page directive--%>
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
