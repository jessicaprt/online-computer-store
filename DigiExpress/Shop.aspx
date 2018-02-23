<%@ Page Title="Shop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="DigiExpress.Shop" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h3>Customize your own computer:</h3>--%>
    <div class="row shop-main">
        <div class="col-md-6 shop-page-sec">
            <a href="Shop_Laptop.aspx"><div class="shop-box">
                <div class="shop-box">
                    <div class="shop-page-image" id="laptop-shop-page"></div>
                    <div class="shop-box-details">
                        <h3 class="color-primary">WinBook Laptops</h3>
                    </div>
                </div>
            </div></a>
        </div>

        <div class="col-md-6 shop-page-sec">
            <a href="Shop_Desktop.aspx"><div class="shop-box">
                <div class="shop-page-image" id="desktop-shop-page">
                </div>
                <div class="shop-box-details">
                    <h3 class="color-primary">WinBox Computers</h3>
                </div>
            </div></a>
        </div>
    </div>
</asp:Content>
