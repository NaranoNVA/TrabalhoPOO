<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrabalhoPOO_ASPNET.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlLogin" Visible="true">
        <div class="container mt-5 p-5 bg-light rounded">
            <div class="form-group">
            <label>Login: </label>
            <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control dinheiro" placeholder="Login"></asp:TextBox>
            </div>
            <div class="form-group">      
            <label>Senha: </label>
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtSenha" placeholder="Senha" aria-label="Senha" aria-describedby="txtSenha"></asp:TextBox>
            </div>
            <div class="form-row d-flex justify-content-center mt-2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-default btn-primary" OnClick="btnLogin_Click"/>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
