<%@ Page Title="Location" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Location.aspx.cs" Inherits="DigiExpress.Location" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="location-title color-primary">DigiExpress Store Location</h2>
    <div class="row container location-main">
        <div class="col-md-6">
            <img src="./images/map.jpg" style="width: 400px;" alt="map-view"/>
        </div>
        
        <div class="col-md-6">
            <div class="location-details">
                42 Wallaby Way<br />
                Sydney, Australia<br />
                <strong>Phone: </strong>
                555-55-55
            </div>

            <div class="location-details">
                <strong>Support:</strong>info@degiexpress.com<br />
            </div>
        </div>
    </div>
    
</asp:Content>
