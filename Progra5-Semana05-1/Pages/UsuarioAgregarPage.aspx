<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioAgregarPage.aspx.cs" Inherits="Progra5_Semana05_1.Pages.UsuarioAgregarPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>CREAR USUARIO</h2>

    <div>

        <div>
            <span>Nombre de Usuario</span>
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div>
            <span>Email</span>
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div>
            <span>Teléfono</span>
            <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div>
            <span>Contraseña</span>
            <asp:TextBox ID="TxtContrasennia" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div>
            <span>Rol De Usuario</span>
            <asp:DropDownList ID="DropDownList1" runat="server" Enabled="false" ></asp:DropDownList>
        </div>

        <div>
            <asp:Button ID="BtnAgregar" runat="server" 
                Text="AGREGAR USUARIO" BackColor="#006600"  
                ForeColor="White" CssClass="btn btn-primary" 
                OnClick="BtnAgregar_Click" />
        </div>

        <div>
            <a href="Semana05Page.aspx" class="btn btn-default">Regresar a Lista</a>
        </div>


    </div>


</asp:Content>
