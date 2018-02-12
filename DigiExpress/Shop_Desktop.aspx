<%@ Page Title="Shop Laptop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop_Desktop.aspx.cs" Inherits="DigiExpress.Shop_Desktop" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="shop-form-main row">
        <div class="col-md-12">
            <h3>choose your desktop:</h3>
        </div>
        
        <div class="col-md-4">
            <p>
                <asp:Image ID="Image1" runat="server" Width="80%" ImageUrl="~/images/winbook_desktop.png" CssClass="shop-disp-image"/>
            </p>
        </div>
        
        <div class="col-md-4">
            <p>Processor:</p>
            <p>
                <asp:DropDownList ID="Processor" runat="server" CssClass="shop-dropdown">
                </asp:DropDownList>
            </p>
            <p>
                RAM size:</p>
            <p>
                <asp:DropDownList ID="RamSize" runat="server" CssClass="shop-dropdown">
                </asp:DropDownList>
            </p>
            <p>
                SSD capacity:</p>
            <p>
                <asp:DropDownList ID="SsdCapacity" runat="server" CssClass="shop-dropdown">
                </asp:DropDownList>
            </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="btn btn-default"/>
            </p>
        </div>
        <div class="col-md-4">
            <h3>Total:</h3>
            <p id="final-price">$ 0,000.00</p>
        </div>
    </div>
</asp:Content>
