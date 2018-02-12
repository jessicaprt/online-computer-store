<%@ Page Title="Location" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Location.aspx.cs" Inherits="DigiExpress.Location" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="location-title">DigiExpress Store Location</h2>
    <div class="row container location-main">
        <div class="col-md-6">
            <img src="./images/map.jpg" style="width: 400px;" alt="map-view"/>
        </div>
        
        <div class="col-md-6">
            <div class="location-details">
                42 Wallaby Way<br />
                Sydney, Australia<br />
                <abbr title="Phone"><strong>Phone: </strong></abbr>
                425.555.0100
            </div>

            <div class="location-details">
                <strong>Support:</strong>   <a href="mailto:Support@digiexpress.com">Support@example.com</a><br />
                <strong>Marketing:</strong> <a href="mailto:Marketing@digiexpress.com">Marketing@example.com</a>
            </div>
        </div>
    </div>
    
</asp:Content>
