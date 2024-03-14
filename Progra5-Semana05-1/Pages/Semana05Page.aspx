<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Semana05Page.aspx.cs" Inherits="Progra5_Semana05_1.Pages.Semana05Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <a href="UsuarioAgregarPage.aspx" class="btn btn-default">Agregar Nuevo Usuario</a>
    </div>

    <div class="primary-container">

        <asp:GridView ID="GvListaUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
            <Columns>

                <asp:BoundField DataField="UsuarioID" HeaderText="Código Usuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Usuario" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="DescripcionRol" HeaderText="Rol de Usuario" />
                <asp:BoundField DataField="Email" HeaderText="Correo Electrónico" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="UsuarioModificarPage.aspx?id=<%# Eval("UsuarioID") %>">Modificar</a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>
    <

</asp:Content>
