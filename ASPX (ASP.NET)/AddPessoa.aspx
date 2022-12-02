<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AddPessoa.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h2>
            <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
        </h2>
        <input id="Nome" name="Nome" type="text"  style="width: 100%;"   required/><br />
        <h2>
            <asp:Label ID="Label2" runat="server" Text="CPF: "></asp:Label>
        </h2>
        <input id="Cpf" name="Cpf" type="text"  style="width: 100%;"  required/><br />
        <h2>
            <asp:Label ID="Label3" runat="server" Text="Logradouro: "></asp:Label>
        </h2>
        <input id="Logradouro" name="Logradouro" type="text"  style="width: 100%;"  required/><br />
        <h2>
            <asp:Label ID="Label4" runat="server" Text="Número: "></asp:Label>
        </h2>
        <input id="Numero" name="Numero" type="number"  style="width: 100%;"  required/><br />
        <h2>
            <asp:Label ID="Label5" runat="server" Text="CEP: "></asp:Label>
        </h2>
        <input id="Cep" name="Cep" type="text"  style="width: 100%;" required/><br />
        <h2>
            <asp:Label ID="Label6" runat="server" Text="Bairro: "></asp:Label>
        </h2>
        <input id="Bairro" name="Bairro" type="text"  style="width: 100%;"  required/><br />
        <h2>
            <asp:Label ID="Label7" runat="server" Text="Cidade: "></asp:Label>
        </h2>
        <input id="Cidade" name="Cidade" type="text"  style="width: 100%;"  required/><br />
        <h2>
            <asp:Label ID="Label8" runat="server" Text="Estado: "></asp:Label>
        </h2>
        <input id="Estado" name="Estado" type="text" " style="width: 100%;"  required/><br />
        <h2>
            <asp:Label ID="Label9" runat="server" Text="Telefone: "></asp:Label>
        </h2>
        <input id="Telefone" name="Telefone" type="text" style="width: 100%;"  required/><br />
        <h2>
            <asp:Label ID="Label10" runat="server" Text="Tipo do telefone: "></asp:Label>
        </h2>
        <center>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Selected="True" Value="1">Residêncial</asp:ListItem>
            <asp:ListItem Value="0">Comercial</asp:ListItem>
        </asp:RadioButtonList>
        </center><br /><br />

        <input id="Submit1" class="btn btn-default" formmethod="post" type="submit" value="Adicionar pessoa" /></div>
</asp:Content>
