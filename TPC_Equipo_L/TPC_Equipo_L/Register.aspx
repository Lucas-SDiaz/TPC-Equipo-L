<%@ Page Title="" Language="C#" MasterPageFile="~/LogReg.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TPC_Equipo_L.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center p-2">Registrate</h1>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />


    <div class="container-fluid" style="max-width: 50%;">
        <div class="card mb-2">
            <div class="card-body">

                <%--                <div class="container-fluid text-center p-2">
                    <div class="row align-items-start">
                        <div class="col">
                            <asp:Label ID="Label1" CssClass="fs-5" Text="Provincia" runat="server" />
                            <asp:DropDownList AutoPostBack="true" CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlProvincia" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" />
                        </div>
                        <div class="col">
                            <asp:Label ID="Label2" CssClass="fs-5" Text="Localidad" runat="server" />
                            <asp:DropDownList CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlLocalidad" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblDireccion" CssClass="fs-5" Text="Dirección" runat="server" />
                    <asp:TextBox ID="txtDireccion" CssClass="form-control" placeholder="Dirección" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombreUsuario" CssClass="fs-5" Text="Nombre de Usuario" runat="server" />
                    <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" placeholder="Nombre de Usuario" runat="server" />
                </div>--%>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
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
                                        <asp:Label ID="lblEmail" CssClass="fs-5" Text="Email" runat="server" />
                                        <asp:TextBox type="email" CssClass="form-control" ID="txtEmail" placeholder="Email@Ejemplo.com" runat="server" />
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="p-3">
                                        <asp:Label ID="lblEmailRep" CssClass="fs-5" Text="Repetir Email" runat="server" />
                                        <asp:TextBox AutoPostBack="true" ID="txtEmailRep" CssClass="form-control" OnTextChanged="txtEmailRep_TextChanged" placeholder="Email@Ejemplo.com" runat="server" />
                                    </div>
                                    <asp:Label ID="lblErrorMail" runat="server" />
                                </div>

                                <div class="col-6">
                                    <div class="p-3">
                                        <asp:Label ID="lblContrasenia" CssClass="fs-5" Text="Contraseña" runat="server" />
                                        <asp:TextBox type="password" CssClass="form-control" ID="txtPass" placeholder="Contraseña" runat="server" />
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="p-3">
                                        <asp:Label ID="lblPassRep" CssClass="fs-5" Text="Repetir Contraseña" runat="server" />
                                        <asp:TextBox AutoPostBack="true" type="password" ID="txtPassRep" placeholder="Contraseña" CssClass="form-control" OnTextChanged="txtPassRep_TextChanged" runat="server" />
                                    </div>
                                    <asp:Label ID="lblErrorPass" Text="" runat="server" />
                                </div>

                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="text-end p-4">
        <asp:Label ID="lblMensaje" Text="" runat="server" />

    </div>
  <%--  <div class="container-fluid" style="max-width: 50%;">
    <div class="card mb-2">
        <div class="card-body">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="container overflow-hidden text-center">
                        <div class="row">
                            <div class="col-6">
                                <div class="p-3">
                                    <asp:Label ID="lblCalle" CssClass="fs-5" Text="Calle" runat="server" />
                                    <asp:TextBox ID="txtCalle" CssClass="form-control" placeholder="Calle" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="p-3">
                                    <asp:Label ID="lblNro" CssClass="fs-5" Text="Numero" runat="server" />
                                    <asp:TextBox ID="txtNro" CssClass="form-control" placeholder="Nro" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="p-3">
                                    <asp:Label ID="lblCP" CssClass="fs-5" Text="Codigo Postal" runat="server" />
                                    <asp:TextBox  CssClass="form-control" ID="txtCP" placeholder="CP" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="p-3">
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="p-3">
                                    <asp:Label ID="lblProvincia" CssClass="fs-5" Text="Provincia" runat="server" />
                                    <asp:DropDownList AutoPostBack="true" CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlProvincia" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"/>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="p-3">
                                    <asp:Label ID="lblLocalidad" CssClass="fs-5" Text="Localidad" runat="server" />
                                    <asp:DropDownList CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlLocalidad" runat="server" />
                                </div>
                                <asp:Label ID="Label5" runat="server" />
                            </div>

                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>--%>
            <div class="text-center m-2">
                <asp:Button Text="Volver" ID="Button1" CssClass="btn btn-outline-secondary" OnClick="btnVolver_Click" runat="server" />
                <asp:Button ID="Button2" CssClass="btn btn-outline-primary" Text="Registrar" runat="server" OnClick="btnRegistrar_Click" />
            </div>
        </div>
    </div>
</div>
<div class="text-end p-4">
    <asp:Label ID="Label9" Text="" runat="server" />

</div>

</asp:Content>
