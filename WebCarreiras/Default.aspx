<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCarreiras._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Web Carreiras</h1>
        <p class="lead">Informe o seu usuário</p>        
    </div>

    <div class="row">
        <div class="col-md-4">
            <p>Usuário:
            </p>
            <asp:TextBox runat="server" ID="txt1"></asp:TextBox>
            
        </div>
        <div class="col-md-4">
            <p>Senha:</p>
            <asp:TextBox runat="server" TextMode="Password" ID="txt2"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <br />
            <asp:Button runat="server" ID="btn1" Text="OK" OnClick="btn1_Click"></asp:Button>
        </div>
    </div>

</asp:Content>
