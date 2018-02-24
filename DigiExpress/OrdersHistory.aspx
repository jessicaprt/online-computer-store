<%@ Page Title="OrdersHistory" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OrdersHistory.aspx.cs" Inherits="DigiExpress.OrdersHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-title {
            padding: 30px 0;
        }
    </style>
    <div>
        <div class="form-title color-primary"><h3>Orders History</h3></div>
        <hr />
        <asp:ListView ID="OrdersListView" runat="server" DataSourceID="ObjectDataSource1"  >
            
            <EmptyDataTemplate>
                <div class="shop-form-main">You have no order history.</div>
            </EmptyDataTemplate>
        
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-4"><img src="<%# Eval("ImageUrl") %>" style="width:20vw"/></div>
                    <div class="col-md-8">
                        <h3>
                        <asp:Label ID="ComputerNameLabel" runat="server" Text='<%# Eval("ComputerName") %>' />
                        </h3>
                        <br />
                        <asp:Label ID="Part1Label" runat="server" Text='<%# Eval("Part1") %>' />
                        <br />
                        <asp:Label ID="Part2Label" runat="server" Text='<%# Eval("Part2") %>' />
                        <br />
                        <asp:Label ID="Part3Label" runat="server" Text='<%# Eval("Part3") %>' />
                        <br />
                        <asp:Label ID="Part4Label" runat="server" Text='<%# Eval("Part4") %>' />
                        <br />
                        <asp:Label ID="Part5Label" runat="server" Text='<%# Eval("Part5") %>' />
                        <br />
                        <h3>
                        <strong>Price:</strong>
                        $<asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />.00
                        </h3>
                        <br />
                        <br />

                    </div>
                </div>
                
                <hr/>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="RenderOrderItems" TypeName="DigiExpress.Controllers.RenderItemController" OnSelecting="ObjectDataSource1_Selecting">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="username" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
</asp:Content>
