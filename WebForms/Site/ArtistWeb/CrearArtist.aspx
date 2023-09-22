<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.Master" AutoEventWireup="true" CodeBehind="CrearArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.CrearArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="ListaArtist.aspx">
        <span class="glyphicon glyphicon-hand-left"></span>Regresar
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <h2>Crear nuevo artista</h2>
    <div class="row">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-submit" Text="Crear" OnClick="btnCrear_Click" />
        </div>
    </div>
</asp:Content>
