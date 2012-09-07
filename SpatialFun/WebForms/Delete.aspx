<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="MvcApplication2.WebForms.Delete" %>

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
            <fieldset>
                <legend>Create New Attraction</legend>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                    <Scripts>
                        <asp:ScriptReference Name="jquery" />
                    </Scripts>
                </asp:ScriptManager>
                <asp:FormView runat="server" ID="attractionsForm" RenderOuterTable="false"
                    ItemType="MvcApplication2.Models.TouristAttraction"
                    SelectMethod="attractionsForm_GetItem"
                    DefaultMode="ReadOnly"
                    DeleteMethod="attractionsForm_DeleteItem"
                    OnItemDeleted="attractionsForm_ItemDeleted"
                    OnItemCommand="attractionsForm_ItemCommand">
                    <ItemTemplate>
                        <ol>
                            <li>
                                <label>Name:</label>
                                <asp:DynamicControl runat="server" ID="name" DataField="Name" Mode="ReadOnly" />
                            </li>
                            <li>
                                <label>Location:</label>
                                <asp:DynamicControl runat="server" ID="Location" DataField="Location" Mode="ReadOnly" />
                            </li>
                        </ol>
                        <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete" OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                        <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                    </ItemTemplate>
                </asp:FormView>
            </fieldset>
        </div>
    </form>
</body>
</html>

