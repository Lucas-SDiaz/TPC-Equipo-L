<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PerfilAdmin.aspx.cs" Inherits="TPC_Equipo_L.PerfilAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center p-2">Mi Perfil</h1>

    <div class="container-fluid" style="max-width: 28rem;">
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
    </div>

</asp:Content>
