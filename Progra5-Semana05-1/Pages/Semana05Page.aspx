<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Semana05Page.aspx.cs" Inherits="Progra5_Semana05_1.Pages.Semana05Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <a href="UsuarioAgregarPage.aspx" class="btn btn-default">Agregar Nuevo Usuario</a>
    </div>

    <div class="primary-container">

        <asp:GridView ID="GvListaUsuarios" runat="server" AutoGenerateColumns="true" CssClass="table table-striped">
        </asp:GridView>

    </div><

</asp:Content>
