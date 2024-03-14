<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioModificarPage.aspx.cs" Inherits="Progra5_Semana05_1.Pages.UsuarioModificarPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Modificar Usuario</h2>

    <div>
        <div>
            <span>Código Usuario</span>
            <asp:TextBox ID="TxtUsuarioID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div>
            <span>Nombre Usuario</span>
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Correo Electrónico</span>
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Teléfono</span>
            <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Contraseña (Opcional)</span>
            <asp:TextBox ID="TxtContrasennia" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BtnModificar" runat="server" Text="MODIFICAR USUARIO" CssClass="btn btn-primary" OnClick="BtnModificar_Click" />
            <asp:Button ID="BtnEliminar" runat="server" Text="ELIMINAR USUARIO" CssClass="btn btn-primary" OnClick="BtnEliminar_Click" />
        </div>
        <div>
            <a href="Semana05Page.aspx" class="btn btn-primary">Cancelar</a>
        </div>

    </div>

</asp:Content>
