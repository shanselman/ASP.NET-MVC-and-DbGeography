<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MvcApplication2.WebForms.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>
        <asp:FormView runat="server" ID="attractionsForm" RenderOuterTable="false"
            ItemType="MvcApplication2.Models.TouristAttraction"
            SelectMethod="attractionsForm_GetItem"
            DefaultMode="Edit"
            UpdateMethod="attractionsForm_UpdateItem"
            OnItemUpdated="attractionsForm_ItemUpdated"
            OnItemCommand="attractionsForm_ItemCommand"
            >
            <EditItemTemplate>
                <ol>
                    <li>
                        <label>Name:</label>
                        <asp:DynamicControl runat="server" ID="name" DataField="Name" Mode="Edit" />
                    </li>
                    <li>
                        <label>Location:</label>
                        <asp:DynamicControl runat="server" ID="Location" DataField="Location" Mode="Edit" />
                    </li>
                </ol>
                <asp:Button ID="Button1" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
            </EditItemTemplate>
        </asp:FormView>
        </fieldset>
    </div>
    </form>
</body>
</html>

