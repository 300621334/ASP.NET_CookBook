<%@ Page MasterPageFile="MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="rcp.aspx.cs" Inherits="rcp" %>

<asp:Content ID="rcp" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="srcForGrid" runat="server" ConnectionString="<%$ ConnectionStrings:cookbookConnectionString %>" ProviderName="<%$ ConnectionStrings:cookbookConnectionString.ProviderName %>" SelectCommand="SELECT [recipeName], [fromName], [cookingTime], [category] FROM [recipes]" DeleteCommand="DELETE FROM [recipes] WHERE [recipeName] = ?" InsertCommand="INSERT INTO [recipes] ([recipeName], [fromName], [cookingTime], [category]) VALUES (?, ?, ?, ?)" UpdateCommand="UPDATE [recipes] SET [fromName] = ?, [cookingTime] = ?, [category] = ? WHERE [recipeName] = ?">
        <DeleteParameters>
            <asp:Parameter Name="recipeName" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="recipeName" Type="String" />
            <asp:Parameter Name="fromName" Type="String" />
            <asp:Parameter Name="cookingTime" Type="String" />
            <asp:Parameter Name="category" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="fromName" Type="String" />
            <asp:Parameter Name="cookingTime" Type="String" />
            <asp:Parameter Name="category" Type="String" />
            <asp:Parameter Name="recipeName" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:GridView DataKeyNames="recipeName" HeaderStyle-CssClass="grighead" RowStyle-CssClass="gridrow" CssClass="grid"  ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="srcForGrid" AutoGenerateColumns="False">
        <Columns>
             
            <asp:CommandField ShowSelectButton="True" />


            <asp:BoundField DataField="recipeName" HeaderText="Name" SortExpression="recipeName" ReadOnly="True" />
            <asp:BoundField DataField="fromName" HeaderText="User" SortExpression="fromName" />
            <asp:BoundField DataField="cookingTime" HeaderText="Time" SortExpression="cookingTime" />
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />

            
        </Columns>

<HeaderStyle CssClass="grighead"></HeaderStyle>

<RowStyle CssClass="gridrow"></RowStyle>
    </asp:GridView><br /><br />

    
        <asp:SqlDataSource ID="srcForDetailsView" runat="server" ConnectionString="<%$ ConnectionStrings:cookbookConnectionString %>" ProviderName="<%$ ConnectionStrings:cookbookConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [recipes] WHERE ([recipeName] = ?)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="recipeName" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
    </asp:SqlDataSource>
        <asp:DetailsView AutoGenerateRows="False" CssClass="detailview" runat="server" Height="50px" Width="125px" DataSourceID="srcForDetailsView">
            <Fields>
                <%--ShowHeader="false" so that col heading will not create a cell--%>
                <asp:BoundField ShowHeader="false" DataField="description" HeaderText="description" SortExpression="description" />
                
            </Fields>

            <HeaderTemplate>
                <%# Eval("recipeName") + " : Detail recipe" %>
            </HeaderTemplate>

        </asp:DetailsView>




</asp:Content>