<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Cart.aspx.cs" Inherits="DigiExpress.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Your Shopping Cart</h3>
    
    <asp:ListView ID="ListView1" runat="server" DataSourceID="CartItemDataSource" >
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
<br /></span>
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
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            <br /><br /></span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">UserName:
            <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
            <br />TypeName:
            <asp:TextBox ID="TypeNameTextBox" runat="server" Text='<%# Bind("TypeName") %>' />
            <br />ComputerId:
            <asp:TextBox ID="ComputerIdTextBox" runat="server" Text='<%# Bind("ComputerId") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            <br /><br /></span>
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
<br /></span>
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
<br /></span>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="CartItemDataSource" runat="server" SelectMethod="GetCartItems" TypeName="DigiExpress.Controllers.CartController">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="username" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
