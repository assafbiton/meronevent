<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="float:right;">
    <div class="login">
        <asp:Login ID="Login2" runat="server" OnAuthenticate="Login1_Authenticate1"></asp:Login>
</div>
    </div>
</asp:Content>

