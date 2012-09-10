<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="MvcApplication2.WebForms.Delete" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Modify this template to jump-start your WebForm application.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <fieldset>
                <h2>Delete</h2>
                
                <asp:FormView runat="server" ID="attractionsForm" RenderOuterTable="false"
                    ItemType="MvcApplication2.Models.TouristAttraction"
                    SelectMethod="attractionsForm_GetItem"
                    DefaultMode="ReadOnly"
                    DeleteMethod="attractionsForm_DeleteItem"
                    OnItemDeleted="attractionsForm_ItemDeleted"
                    OnItemCommand="attractionsForm_ItemCommand">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete" OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                        <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
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
                    </ItemTemplate>
                </asp:FormView>
            </fieldset>
        </div>
  </asp:Content>
