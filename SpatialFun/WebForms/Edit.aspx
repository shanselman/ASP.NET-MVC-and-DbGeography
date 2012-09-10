<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MvcApplication2.WebForms.Edit" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Modify this template to jump-start your ASP.NET WebForm application.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <fieldset>
      <h2>Edit</h2>
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
  </asp:Content>
