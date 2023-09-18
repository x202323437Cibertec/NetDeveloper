﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.Master" AutoEventWireup="true" CodeBehind="ListaArtist.aspx.cs" Inherits="WebFormTest.Site.ArtistWeb.ListaArtist" %>
<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="CrearArtist.aspx">
        <span class="glyphicon glyphicon-plus"></span>Crear Artista
    </a>
    <br />
    <div>
        Buscar Artista
        <asp:TextBox ID="txtBuscar_Nombre" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </div>
</asp:Content>
<asp:Content ID="ListContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="row">
        <h3>Listado de artistas</h3>
    </div>
    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
        ConnectionString="<%$ConnectionStrings:ChinookCnx%>" 
        SelectCommand="GetListaArtista" SelectCommandType="StoredProcedure"
        DeleteCommand="DeleteArtist" DeleteCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="ArtistId" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <div>
        <br />
        <asp:GridView ID="ArtistGridView" runat="server"
            CssClass="table table-striped table-bordered"
            AllowPaging="true" 
            AllowSorting="true" 
            AutoGenerateColumns="true" 
            AutoGenerateDeleteButton="true" 
            DataKeyNames="ArtistId"
            AutoGenerateEditButton="true"
            PageSize="12"
            OnPageIndexChanging="ArtistGridView_PageIndexChanging"
        >
            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnFirst" runat="server" Text="Primer registro" OnClick="btnFirst_Click" />
        <asp:Button ID="btnLast" runat="server" Text="Último registro" OnClick="btnLast_Click" />
    </div>
</asp:Content>
