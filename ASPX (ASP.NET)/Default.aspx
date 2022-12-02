<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <div class="container">
        <h2>
            <asp:Label ID="Label1" runat="server" Text="CPF: "></asp:Label>
        </h2>
            <input style="width: 100%;" id="CpfBusca" alt="Digite o CPF para buscar uma pessoa" type="text" required="required" style="width: 100%;" />
            <input style="background-color: black; color: white;" id="Button1" formmethod="get" type="button" value="Buscar" class="btn" /><br />
            <a href="AddPessoa.aspx"><input style="background-color: black; color: white;" id="Button2" type="button" value="Adicionar pessoa" class="btn" /></a><br />
&nbsp;<asp:Table ID="Table1" runat="server" Height="50%" HorizontalAlign="Center" Width="100%" CssClass="table">
            <asp:TableRow ID="Teste" runat="server">
                <asp:TableCell runat="server">Nome</asp:TableCell>
                <asp:TableCell runat="server">CPF</asp:TableCell>
                <asp:TableCell runat="server">Logradouro</asp:TableCell>
                <asp:TableCell runat="server">Número</asp:TableCell>
                <asp:TableCell runat="server">CEP</asp:TableCell>
                <asp:TableCell runat="server">Bairro</asp:TableCell>
                <asp:TableCell runat="server">Cidade</asp:TableCell>
                <asp:TableCell runat="server">Estado</asp:TableCell>
                <asp:TableCell runat="server">Telefone</asp:TableCell>
                <asp:TableCell runat="server">Tipo do telefone</asp:TableCell>
                <asp:TableCell runat="server">Editar</asp:TableCell>
                <asp:TableCell runat="server">Deletar</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Matheus</asp:TableCell>
                <asp:TableCell runat="server">123.456.789-00</asp:TableCell>
                <asp:TableCell runat="server">Avenida teste</asp:TableCell>
                <asp:TableCell runat="server">00</asp:TableCell>
                <asp:TableCell runat="server">11000000</asp:TableCell>
                <asp:TableCell runat="server">Rua teste</asp:TableCell>
                <asp:TableCell runat="server">Santos</asp:TableCell>
                <asp:TableCell runat="server">SP</asp:TableCell>
                <asp:TableCell runat="server">(13) 99999-9999</asp:TableCell>
                <asp:TableCell runat="server">Residêncial</asp:TableCell>
                <asp:TableCell runat="server"><a href="ChangePessoa.aspx"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
  <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
  <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
</svg></a></asp:TableCell>
                <asp:TableCell runat="server"><a href="DeletePessoa.aspx"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
  <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
  <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
</svg></a></asp:TableCell>

            </asp:TableRow>
        </asp:Table>
    </div>
    </div>

    </asp:Content>
