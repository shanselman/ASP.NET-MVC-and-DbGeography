<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="MvcApplication2.WebForms.Create" MasterPageFile="~/Views/Shared/Site.Master" %>
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
    <fieldset><legend>Create New Attraction</legend>
        
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
<%--                        <asp:TextBox ID="location" runat="server" Text="<%# BindItem.Location %>"></asp:TextBox>--%>
                        <asp:DynamicControl runat="server" ID="Location" DataField="Location" Mode="Insert" />
                    </li>
                </ol>
                <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Save" />
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
            </InsertItemTemplate>
        </asp:FormView>
        </fieldset>
    </div>
</asp:Content>