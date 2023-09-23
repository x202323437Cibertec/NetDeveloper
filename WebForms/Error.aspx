<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebForms.Error" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Lo sentimos, se presentó un Error dentro del sistema.</h1>
    <br />
    <div class="row">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
</asp:Content>