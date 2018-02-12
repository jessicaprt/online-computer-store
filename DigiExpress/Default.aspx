<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DigiExpress._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron default-jumbotron">
    </div>
    
    <div class="row">

    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="box-img" id="laptop-img"></div>
            <div class="box-txt">
                <h2>WinBook laptops</h2>
                <p>
                    WinBook premium laptops are the best on the market! Modify your parts and get the laptop that's perfect for you!
                <p>
                    <a class="btn btn-default" href="./Shop_Laptop">Shop laptops &raquo;</a>
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box-img" id="desktop-img"></div>
            <div class="box-txt">
                <h2>WinBox computers</h2>
                <p>
                    This WinBox desktop computer is the perfect touch for your office needs. This sleek look compliments any desks and is
                    perfect for any of your workload!
                </p>
                <p>
                    <a class="btn btn-default" href="./Shop_Desktop">Shop desktops &raquo;</a>
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box-img" id="map-img"></div>
            <div class="box-txt">
                <h2>Store Location</h2>
                <p>
                    Don't want to shop online? Check out our store location so that you can see a WinBook product yourself! You can also go to the store for any servicing needs.
                </p>
                <p>
                    <a class="btn btn-default" href="./Location">Store locator &raquo;</a>
                </p>
            </div>
        </div>
    </div>
   
</asp:Content>
