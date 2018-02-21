﻿<%@ Page Title="OrdersHistory" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OrdersHistory.aspx.cs" Inherits="DigiExpress.OrdersHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-title {
            padding: 30px 0;
        }
    </style>
    <div>
        <div class="form-title"><h3>Your Shopping Cart</h3></div>
        <hr />
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1"  >
            <AlternatingItemTemplate>
                <span style="">UserName:
                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                <br />
                TypeName:
                <asp:Label ID="TypeNameLabel" runat="server" Text='<%# Eval("TypeName") %>' />
                <br />
                ComputerId:
                <asp:Label ID="ComputerIdLabel" runat="server" Text='<%# Eval("ComputerId") %>' />
                <br />
                Price:
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                <br />
                <br />
                </span>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <span style="">UserName:
                <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                <br />
                TypeName:
                <asp:TextBox ID="TypeNameTextBox" runat="server" Text='<%# Bind("TypeName") %>' />
                <br />
                ComputerId:
                <asp:TextBox ID="ComputerIdTextBox" runat="server" Text='<%# Bind("ComputerId") %>' />
                <br />
                Price:
                <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                <br />
                <br />
                </span>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>
        
            <InsertItemTemplate>
                <span style="">UserName:
                <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                <br />
                TypeName:
                <asp:TextBox ID="TypeNameTextBox" runat="server" Text='<%# Bind("TypeName") %>' />
                <br />
                ComputerId:
                <asp:TextBox ID="ComputerIdTextBox" runat="server" Text='<%# Bind("ComputerId") %>' />
                <br />
                Price:
                <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                <br />
                <br />
                </span>
            </InsertItemTemplate>
        
            <ItemTemplate>
                <span style="">UserName:
                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                <br />
                TypeName:
                <asp:Label ID="TypeNameLabel" runat="server" Text='<%# Eval("TypeName") %>' />
                <br />
                ComputerId:
                <asp:Label ID="ComputerIdLabel" runat="server" Text='<%# Eval("ComputerId") %>' />
                <br />
                Price:
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                <br />
                <br />
                </span>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <span style="">UserName:
                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                <br />
                TypeName:
                <asp:Label ID="TypeNameLabel" runat="server" Text='<%# Eval("TypeName") %>' />
                <br />
                ComputerId:
                <asp:Label ID="ComputerIdLabel" runat="server" Text='<%# Eval("ComputerId") %>' />
                <br />
                Price:
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                <br />
                <br />
                </span>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetOrderItems" TypeName="DigiExpress.Controllers.OrderController" OnSelecting="ObjectDataSource1_Selecting">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="username" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
</asp:Content>
