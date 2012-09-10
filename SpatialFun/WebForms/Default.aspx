<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MvcApplication2.WebForms.Default" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>

                    <h2>Modify this template to jump-start your WebForm application.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p>
            <a href="<%: GetRouteUrl("TouristAttractionNew", null) %>">Create New </a>
        </p>
        <asp:GridView runat="server" ID="displayAttractions" AutoGenerateColumns="false"
            ItemType="MvcApplication2.Models.TouristAttraction" SelectMethod="displayAttractions_GetData">
            <Columns>
                <asp:DynamicField DataField="Name" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a id="A1" runat="server"
                            href='<%# GetRouteUrl("TouristAttractionEdit", new { id = Item.TouristAttractionId }) %>'>Edit</a>
                        |<a id="A2" runat="server"
                            href='<%# GetRouteUrl("TouristAttractionDelete", new { id = Item.TouristAttractionId }) %>'>Delete</a>
                        |<a id="A3" runat="server"
                            href='<%# GetRouteUrl("TouristAttractionDetails", new { id = Item.TouristAttractionId }) %>'>Details</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    </div>
</asp:Content>
