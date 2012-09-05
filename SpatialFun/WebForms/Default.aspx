<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MvcApplication2.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="displayAttractions" AutoGenerateColumns="false"
            ItemType="MvcApplication2.Models.TouristAttraction" SelectMethod="displayAttractions_GetData">
            <Columns>
                    <asp:DynamicField DataField="Name" />                  
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a id="A1" runat="server" 
                                href='<%# GetRouteUrl("TouristAttractionEdit", new { id = Item.TouristAttractionId }) %>'>edit</a>
                            <a id="A2" runat="server"
                                 href='<%# GetRouteUrl("TouristAttractionDelete", new { id = Item.TouristAttractionId }) %>'>delete</a>
                            <a id="A3" runat="server"
                                 href='<%# GetRouteUrl("TouristAttractionDetails", new { id = Item.TouristAttractionId }) %>'>details</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
        </asp:GridView>
        <p>
        <a href="<%: GetRouteUrl("TouristAttractionNew", null) %>">Create New Tourist Attraction</a>
    </p>
    </div>
    </form>
</body>
</html>
