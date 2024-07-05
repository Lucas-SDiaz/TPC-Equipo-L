<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PerfilAdmin.aspx.cs" Inherits="TPC_Equipo_L.PerfilAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center p-2">Mi Perfil</h1>

    <%--    <div class="container-fluid" style="max-width: 28rem;">
        <div class="card mb-3">
            <div class="card-body">
                <div class="mb-3">
                    <asp:Label ID="lblEmail" CssClass="fs-5" Text="Email" runat="server" />
                    <asp:TextBox type="email" CssClass="form-control" ID="txtEmail" placeholder="Email@Ejemplo.com" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblContrasenia" CssClass="fs-5" Text="Contraseña" runat="server" />
                    <asp:TextBox type="password" CssClass="form-control" ID="txtPass" placeholder="Contraseña" runat="server" />
                </div>
                <div class="text-end">

                </div>
            </div>
        </div>
    </div>--%>

    <div class="card mb-3">
        <div class="card-body">
            <div class="container overflow-hidden text-center">
                <div class="row">
                    <div class="col-6">
                        <div class="p-3">
                            <asp:Label ID="lblNombre" CssClass="fs-5" Text="Nombre" runat="server" />
                            <asp:TextBox ID="txtNombre" onkeydown="return (event.keyCode >= 65 && event.keyCode <= 90 || event.keyCode >= 97 && event.keyCode <= 122 || event.keyCode == 08 || event.keyCode == 9)" CssClass="form-control" placeholder="Nombre" runat="server" />
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="p-3">
                            <asp:Label ID="lblApellido" CssClass="fs-5" Text="Apellido" runat="server" />
                            <asp:TextBox ID="txtApellido" onkeydown="return (event.keyCode >= 65 && event.keyCode <= 90 || event.keyCode >= 97 && event.keyCode <= 122 || event.keyCode == 08 || event.keyCode == 9)" CssClass="form-control" placeholder="Apellido" runat="server" />
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="p-3">
                            <asp:Label ID="Label1" CssClass="fs-5" Text="Email" runat="server" />
                            <asp:TextBox type="email" CssClass="form-control" ID="txtEmail" placeholder="Email@Ejemplo.com" runat="server" />
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="p-3">
                            <asp:Label ID="Label2" CssClass="fs-5" Text="Contraseña" runat="server" />
                            <asp:TextBox type="password" CssClass="form-control" ID="txtPass" placeholder="Contraseña" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>



</asp:Content>
