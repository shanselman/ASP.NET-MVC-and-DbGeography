<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="MvcApplication2.WebForms.Details"
    
     %>

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
    Details
        <asp:FormView runat="server" ItemType="MvcApplication2.Models.TouristAttraction" ID="attractionDetails"
            SelectMethod="attractionDetails_GetItem">
            <ItemTemplate>  
                <asp:DynamicControl DataField="name" runat="server" />
                <br />
                <asp:DynamicControl DataField="location" runat="server" />
            </ItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
