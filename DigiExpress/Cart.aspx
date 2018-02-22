<%@ Page Title="Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Cart.aspx.cs" Inherits="DigiExpress.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-title {
            padding: 30px 0;
        }
    </style>
    <div>
        <div class="form-title"><h3>Your Shopping Cart</h3></div>
        <hr />
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" >
            <EditItemTemplate>
                <span style="">
                <br />
                ComputerName:
                <asp:TextBox ID="ComputerNameTextBox" runat="server" Text='<%# Bind("ComputerName") %>' />
                <br />
                Screen Size:
                <asp:TextBox ID="Part1TextBox" runat="server" Text='<%# Bind("Part1") %>' />
                <br />
                Processor:
                <asp:TextBox ID="Part2TextBox" runat="server" Text='<%# Bind("Part2") %>' />
                <br />
                Ram Size:
                <asp:TextBox ID="Part3TextBox" runat="server" Text='<%# Bind("Part3") %>' />
                <br />
                SSD Capacity:
                <asp:TextBox ID="Part4TextBox" runat="server" Text='<%# Bind("Part4") %>' />
                <br />
                Operating System:
                <asp:TextBox ID="Part5TextBox" runat="server" Text='<%# Bind("Part5") %>' />
                <br />
                Price:
                <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                <br /><br /></span>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <span>Your cart is empty</span>
            </EmptyDataTemplate>
        
            <ItemTemplate>
                <span style="">
                    <div class="row">
                        <div class="col-md-4"><img src="<%# Eval("ImageUrl") %>" style="width:20vw"/></div>
                        <div class="col-md-8">
                            <h3>
                            <asp:Label ID="ComputerNameLabel" runat="server" Text='<%# Eval("ComputerName") %>' />
                            </h3>
                            <br />
                            <strong>Screen Size:</strong>
                            <asp:Label ID="Part1Label" runat="server" Text='<%# Eval("Part1") %>' />
                            <br />
                            <strong>Processor:</strong>
                            <asp:Label ID="Part2Label" runat="server" Text='<%# Eval("Part2") %>' />
                            <br />
                            <strong>Ram Size:</strong>
                            <asp:Label ID="Part3Label" runat="server" Text='<%# Eval("Part3") %>' />
                            <br />
                            <strong>SSD Capacity:</strong>
                            <asp:Label ID="Part4Label" runat="server" Text='<%# Eval("Part4") %>' />
                            <br />
                            <strong>Operating System:</strong>
                            <asp:Label ID="Part5Label" runat="server" Text='<%# Eval("Part5") %>' />
                            <br /><h3>
                            <strong>Price: </strong>
                            $<asp:Label ID="PriceLabel" runat="server" Text='<%#Eval("Price")%>' />.00</h3>
                            <br /><br />
                            <asp:Button ID="OrderButton" runat="server" Text="Confirm Order" OnCommand="ConfirmOrder" CommandArgument='<%# Eval("ComputerIdType")%>' CssClass="btn btn-default"/>
                            <br /><br />
                            <asp:Button ID="DeleteButton" runat="server" Text="Remove From Cart" OnCommand="RemoveFromCart" CommandArgument='<%# Eval("ComputerIdType") %>' CssClass="btn btn-default"/>
                            <br />
                        </div>
                    </div>

                </span>
                <hr />
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="RenderCartItems" TypeName="DigiExpress.Controllers.RenderItemController">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="username" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
</asp:Content>
