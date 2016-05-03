<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCarreira.aspx.cs" Inherits="WebCarreiras.CadastroCarreira" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div>
        <asp:Label runat="server" ID="lb1" Text="Informe a descrição da Carreira:"></asp:Label>
        <br>
        <asp:TextBox runat="server" ID="txtCarreira"></asp:TextBox>
        <br>
        <asp:Label runat="server" ID="Label1" Text="Informe o código da Carreira para Alterar (Deixar vazio para novo registro):"></asp:Label>
        <br>
        <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
        <br>
        <asp:Button runat="server" ID="btnSalvarCarreira" OnClick="btnSalvarCarreira_Click" Text="Salvar Carreira" />
        <br>
    </div>

    <div>
        <asp:GridView ID="gridView1" runat="server" OnLoad="Unnamed_Load"></asp:GridView>
    </div>
    <div>
        <asp:Label runat="server" ID="Label2" Text="Para excluir informe o código da Carreira"></asp:Label>
        <br>
        <asp:Button runat="server" ID="btnExcluir" OnClick="btnExcluir_Click" Text="Excluir" />

    </div>
    <br />
    <br />
    <br />
    <div>

        <div>
            <asp:GridView ID="gridView2" runat="server"></asp:GridView>
        </div>

        <asp:Label runat="server" ID="Label3" Text="Dar Nota"></asp:Label>
        <asp:Label runat="server" ID="Label4" Text="Informe o código da Carreira e a Nota"></asp:Label>
        <br>
        <asp:TextBox runat="server" ID="txtNota"></asp:TextBox>
        <br>
        <asp:Button runat="server" ID="btnNota" OnClick="btnNota_Click" Text="Gravar Nota" />
        
        <asp:Label runat="server" ID="Label5" Text="Informe o código e a nota"></asp:Label>
        <br>
        <br>
        <asp:Label runat="server" ID="Label6" Text="Informe o Id da Nota para alterar ou Excluir"></asp:Label>
        <br>
        <asp:TextBox runat="server" ID="txtIdentificadorNota"></asp:TextBox>
        <br>
        <asp:Button runat="server" ID="btnEditarNota" OnClick="btnEditarNota_Click" Text="Editar Nota" />
        <br>
        <asp:Button runat="server" ID="btnExcluirNota" OnClick="btnExcluirNota_Click" Text="Excluir Nota" />
        <br>

    </div>

</asp:Content>

