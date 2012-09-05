<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="MvcApplication2.WebForms.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%: Styles.Render("~/Content/css") %>
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/jquery") %>
        <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>              
    <script type="text/javascript" src="<%: ResolveUrl("~/Scripts/EFSpatialGoogleMaps.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset><legend>Create New Attraction</legend>
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>
        <asp:FormView runat="server" ID="attractionsForm" RenderOuterTable="false"
            ItemType="MvcApplication2.Models.TouristAttraction"
            DefaultMode="Insert"
            InsertMethod="attractionsForm_InsertItem"
            OnItemInserted="attractionsForm_ItemInserted"
            OnItemCommand="attractionsForm_ItemCommand">
            <InsertItemTemplate>
                <ol>
                    <li>
                        <label>Name:</label>
                        <asp:DynamicControl runat="server" ID="name" DataField="Name" Mode="Insert" />
                    </li>
                    <li>
                        <label>Location:</label>
                        <asp:DynamicControl runat="server" ID="description" DataField="Location" Mode="Insert" />
                    </li>
                </ol>
                <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Save" />
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
            </InsertItemTemplate>
        </asp:FormView>
        </fieldset>
    </div>
    </form>
</body>
</html>
