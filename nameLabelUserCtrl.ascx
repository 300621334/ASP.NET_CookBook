<%@ Control ClassName="nameLabelUserCtrl" Language="C#" AutoEventWireup="true"  %>
<%--ClassName is for implicitly generated C# class for in-line script, bcoz there's NO .cs class (i deleted that)--%>


<script runat="server">
    //create a property for class "nameLabelUserCtrl". Without runat="" C# will not be recognised
    public String ucProp
    {
        get
        {
            return TextBox1.Text;
        }
        
        /*prop can be be "set"/invoked in 2 ways: 
         (1)From within the tag assign value to property as: ucProp="txtToDisplayOnLbl"
         (2)From C# script assign value to prop as: idOfTag.ucProp = "..." */

        set
        {
            Label1.Text = value;
        }
    }
</script>

<asp:Label ID="Label1" runat="server" ></asp:Label>
<asp:TextBox ID="TextBox1" MaxLength="30" Width="200" runat="server"></asp:TextBox><br />
<asp:Label ID="ucError" runat="server" ></asp:Label>