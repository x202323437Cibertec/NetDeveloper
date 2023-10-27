<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="frmEnviar.aspx.cs" Inherits="WebForms.Site.Pruebas.frmEnviar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <input type="text" id="itDato" placeholder="Ingresa algo" />
    <input type="button" id="ibEnviar" value="Enviar" onclick="fEnviarDatos()"  />
    <script type="text/javascript">

        function fEnviarDatos()
        {
            console.log("A");
            var strDato = document.getElementById("itDato").value;
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "frmRecibir.aspx", true);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.send("dato=" + strDato);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    location.href = "frmRecibir.aspx";
                }
            }
        }

    </script>
</asp:Content>
