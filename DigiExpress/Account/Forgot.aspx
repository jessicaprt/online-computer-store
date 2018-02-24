<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="DigiExpress.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="row shop-form-main">
                <div class="col-md-12 color-primary shop-title">
                    <h4>Forgot your password?</h4>
                </div>
                <div class="col-md-8">
                    <asp:PlaceHolder id="loginForm" runat="server">
                        <div class="form-horizontal">
                            <hr />
                            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                <p class="text-danger">
                                    <asp:Literal runat="server" ID="FailureText" />
                                </p>
                            </asp:PlaceHolder>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Username" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                        CssClass="text-danger" ErrorMessage="The email field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="forgotBtn" OnClick="Forgot" Text="Get My Password" Enabled="True" CssClass="btn btn-default" />
                                    <div class="password">
                                        <asp:Label runat="server" ID="DisplayPassword1"></asp:Label><br/>
                                        <h4><asp:Label runat="server" ID="DisplayPasswordText"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="forgotBtn" EventName="Click"/> 
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
