<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="wfFormulario.aspx.cs" Inherits="WebForms.Site.PlaylistWeb.wfFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="wfListado.aspx">
        <span class="glyphicon glyphicon-hand-left"></span>Regresar
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <h2>Mantenimiento</h2>
    <div class="row">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Playlist:"></asp:Label>
            <asp:Label ID="lblPlaylist" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="hfPlaylistId" runat="server" />
        </div>
    </div>
    <br />
    <div class="row">
        <div>
            Tracks:
            <asp:DropDownList ID="ddlTrack" runat="server"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnQuitar" runat="server" CssClass="btn btn-submit" Text="Quitar" OnClick="btnQuitar_Click" />
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
    </div>
</asp:Content>
