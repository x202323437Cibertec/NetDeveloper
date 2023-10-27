<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.Master" AutoEventWireup="true" CodeBehind="CrearArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.CrearArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="ListaArtist.aspx">
        <span class="glyphicon glyphicon-hand-left"></span>Regresar
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <h2>Crear nuevo artista</h2>
<%--
    <div class="row">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-submit" Text="Crear" OnClick="btnCrear_Click" />
        </div>
    </div>
--%>
    <div id="success" class="alert alert-success" role="alert">
        <strong>Success!</strong> Registro creado.
    </div>
    <div id="error" class="alert alert-success" role="alert">
        <strong>Error!</strong> No se pudo crear el registro.
    </div>
    <div class="row">
        <div>
            <label>Nombre artista:" </label>
            <input type="text" required="required" id="itName" />
        </div>
    </div>
    <div class="row">
        <div><button class="btn btn-submit" onclick="f_InsertArtist(); return false;">Crear artista</button></div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('.alert').hide();
        });
        function f_InsertArtist() {
            console.log("A");
            $('.alert').hide();
            console.log("B");
            var name = document.getElementById('itName').value;
            console.log("C");
            $.ajax({
                type: "POST",
                url: 'CrearArtist.aspx/InsertArtist',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: "{ 'pName':'" + name + "' }",
                success: function (data, status, xhr) {
                    console.log("D");
                    if (data.d == true) {
                        $('#success').show();
                        document.getElementById('itName').value = '';
                    }
                },
                error: function (xhr, status, error) {
                    console.log("E");
                    $('#error').show();
                }
            });
        }
    </script>
</asp:Content>
