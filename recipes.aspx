<%@ Page MasterPageFile="MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="recipes.aspx.cs" Inherits="recipes" %>
<%--MaintainScrollPositionOnPostback="true" indise page directive keeps scroll position BUT page flickers very badly--%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="recipes">
    <asp:Button ID="openDbFile" runat="server" Text="Open Database File" OnClick="openDbFile_Click" />
    <br />
    ALL the  Recipes added so far:

    <%--<asp:DataGrid ID="displayRecipes" runat="server"></asp:DataGrid>--%>
    <%--DataList iterates thru ALL records that reader read & for every record it used following templates to display. #Eval(column name) from record that reader just read --%>
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

