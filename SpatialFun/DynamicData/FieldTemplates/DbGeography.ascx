<%@ Control Language="C#" CodeBehind="DbGeography.ascx.cs" Inherits="MvcApplication2.DynamicData.FieldTemplates.DbGeography" %>
ReadOnly

<script>
    $(function () {        
        maps.markerToSet = new google.maps.LatLng(<%: this.geo.Latitude %>, <%: this.geo.Longitude %>) ;
        
    });
    </script>
<asp:TextBox runat="server" ID="location" Text="<%# FieldValueString %>" />
<div id="map_canvas" data-textboxid="location" style="width:400px; height:400px"></div>
