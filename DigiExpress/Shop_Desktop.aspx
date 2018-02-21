<%@ Page Title="Shop Desktop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop_Desktop.aspx.cs" Inherits="DigiExpress.ShopDesktop" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
                    <p>Video Card:</p>
                    <p>
                        <asp:DropDownList ID="VideoCard" runat="server" 
                                          CssClass="shop-dropdown"
                                          OnSelectedIndexChanged="CalculateTotal"
                                          AutoPostBack="True">
                        </asp:DropDownList>
                    </p>
                    <p>Part2:</p>
                    <p>
                        <asp:DropDownList ID="Processor" runat="server"
                                          CssClass="shop-dropdown"
                                          OnSelectedIndexChanged="CalculateTotal"
                                          AutoPostBack="True">
                        </asp:DropDownList>
                    </p>
                    <p>
                        RAM size:</p>
                    <p>
                        <asp:DropDownList ID="RamSize" runat="server"
                                          CssClass="shop-dropdown"
                                          OnSelectedIndexChanged="CalculateTotal"
                                          AutoPostBack="True">
                        </asp:DropDownList>
                    </p>
                    <p>
                        SSD capacity:</p>
                    <p>
                        <asp:DropDownList ID="SsdCapacity" runat="server"
                                          CssClass="shop-dropdown"
                                          OnSelectedIndexChanged="CalculateTotal"
                                          AutoPostBack="True">
                        </asp:DropDownList>
                    </p>
                    <p>
                        Operating System:</p>
                    <p>
                        <asp:DropDownList ID="OperatingSystem" runat="server"
                                          CssClass="shop-dropdown"
                                          OnSelectedIndexChanged="CalculateTotal"
                                          AutoPostBack="True">
                        </asp:DropDownList>
                    </p>
                    <p>
                        <asp:Button ID="SubmitButton" runat="server" Text="Add To Cart" onclick="AddToCart" CssClass="btn btn-default"/>
                    </p>
                </div>
                <div class="col-md-4">
                    <h3>Total:
                    </h3>
                    <asp:label id="TotalPrice"
                               runat="server">
                    </asp:label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
