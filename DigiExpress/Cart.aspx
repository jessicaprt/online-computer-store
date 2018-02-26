<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="DigiExpress.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <h3>Your cart:</h3>
    <div class="row cart-main">
        <hr/><br/>
        <div class="col-md-4"><asp:Label runat="server" ID="Image"></asp:Label></div>
        <div class="col-md-8 cart-details">
            <asp:Label runat="server" ID="Part1"></asp:Label><br/>
            <asp:Label runat="server" ID="Part2"></asp:Label><br/>
            <asp:Label runat="server" ID="Part3"></asp:Label><br/>
            <asp:Label runat="server" ID="Part4"></asp:Label><br/>
            <asp:Label runat="server" ID="Part5"></asp:Label>
        </div>
    </div>
</asp:Content>
