<%@ Page Title="" Language="C#" MasterPageFile="~/LogReg.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TPC_Equipo_L.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center p-2">Registrate</h1>

    <div class="container-fluid" style="max-width: 28rem;">
        <div class="card mb-2">
            <div class="card-body">
                <div class="mb-3">
                    <asp:Label ID="lblNombre" CssClass="fs-5" Text="Nombre" runat="server" />
                    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblApellido" CssClass="fs-5" Text="Apellido" runat="server" />
                    <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="Apellido" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblDireccion" CssClass="fs-5" Text="Dirección" runat="server" />
                    <asp:TextBox ID="txtDireccion" CssClass="form-control" placeholder="Dirección" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombreUsuario" CssClass="fs-5" Text="Nombre de Usuario" runat="server" />
                    <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" placeholder="Nombre de Usuario" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblEmail" CssClass="fs-5" Text="Email" runat="server" />
                    <asp:TextBox type="email" CssClass="form-control" ID="txtEmail" placeholder="Email@Ejemplo.com" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblEmailRep" CssClass="fs-5" Text="Repetir Email" runat="server" />
                    <asp:TextBox ID="txtEmailRep" CssClass="form-control" placeholder="Email@Ejemplo.com" runat="server" />
                </div>
                <div class="dropdown mb-3">
                    <asp:DropDownList CssClass="dropdown-menu dropdown-menu-dark" ID="ddlProvicia" runat="server" />
                    <asp:DropDownList CssClass="dropdown-menu dropdown-menu-dark" ID="ddlLocalidad" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblContrasenia" CssClass="fs-5" Text="Contraseña" runat="server" />
                    <asp:TextBox type="password" CssClass="form-control" ID="txtPass" placeholder="Contraseña" runat="server" />
                </div>

                <div class="text-end">
                    <asp:Button ID="btnRegistrar" CssClass="btn btn-outline-primary" Text="Registrar" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
