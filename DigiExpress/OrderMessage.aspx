<%@ Page Title="Thank you for ordering" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderMessage.aspx.cs" Inherits="DigiExpress.OrderMessage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="shop-form-main">
        <br/>
        <br/>
        <h3>Thank you! We have received your order</h3>
        <br/>
        <asp:Button ID="OrdersHistory" runat="server" Text="Go To Orders History" onclick="RedirectToOrdersHistory" CssClass="btn btn-default"/>

    </div>
</asp:Content>