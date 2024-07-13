<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPC_Equipo_L.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="max-width: 50%;">
        <div class="card m-2">
            <div class="card-body">
                <div class="mb-3">
                    <asp:Label ID="lblNombre" CssClass="fs-5" Text="Nombre" runat="server" />
                    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblApellido" CssClass="fs-5" Text="Apellido" runat="server" />
                    <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="Apellido" runat="server" />
                </div>
                <%--<div class="container-fluid text-center p-2">
                    <div class="row align-items-start">
                        <div class="col">
                            <asp:Label ID="lblProvincia" CssClass="fs-5" Text="Provincia" runat="server" />
                            <asp:DropDownList AutoPostBack="true" CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlProvincia" runat="server" />
                        </div>
                        <div class="col">
                            <asp:Label ID="lblLocalidad" CssClass="fs-5" Text="Localidad" runat="server" />
                            <asp:DropDownList CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlLocalidad" runat="server" />
                        </div>
                    </div>
                </div>--%>
                <div class="container-fluid text-center p-2">
                    <div class="row align-items-start">
                        <div class="col">
                            <asp:Label ID="lblDirecciones" CssClass="fs-5" Text="Direcciones" runat="server" />
                        </div>
                        <div class="col">
                            
                            <!-- Button trigger modal -->
                            <button type="button" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                Agregar
                            </button>

                            <!-- Modal -->
                            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header bg-primary text-white">
                                            <h1 class="modal-title fs-5" id="exampleModalLabel">Dirección nueva</h1>
                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="container-fluid text-center p-2">
                                                <div class="row align-items-start">
                                                    <div class="col">
                                                        <asp:Label ID="lblCalle" CssClass="fs-5" Text="Calle" runat="server" />
                                                        <asp:TextBox ID="txtCalle" CssClass="form-control" runat="server" />
                                                    </div>                                                    
                                                    <div class="col">
                                                        <asp:Label ID="lblNumero" CssClass="fs-5" Text="Numero" runat="server" />
                                                        <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" />
                                                    </div>                                                    
                                                    <div class="col">
                                                        <asp:Label ID="lblCodPostal" CssClass="fs-5" Text="Código Postal" runat="server" />
                                                        <asp:TextBox ID="txtCodPostal" CssClass="form-control" runat="server" />
                                                    </div>                                                    
                                                </div>
                                                <div class="row align-items-start">
                                                    <div class="col">
                                                        <asp:Label ID="lblPiso" CssClass="fs-5" Text="Piso" runat="server" />
                                                        <asp:TextBox ID="txtPiso" CssClass="form-control" runat="server" />
                                                    </div>                                                    
                                                    <div class="col">
                                                        <asp:Label ID="lblDepto" CssClass="fs-5" Text="Departamento" runat="server" />
                                                        <asp:TextBox ID="txtDepto" CssClass="form-control" runat="server" />
                                                    </div>  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">Close</button>
                                             <asp:Button ID="btnAgregarDireccion" CssClass="btn btn-outline-success" OnClick="btnAgregarDireccion_Click" Text="Agregar" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <asp:Button ID="btnModificarDireccion" CssClass="btn btn-outline-warning" OnClick="btnModificarDireccion_Click" Text="Modificar" runat="server" />
                        </div>
                        <div class="col">
                            <asp:Label ID="lblResultado" Text="⚪" runat="server" />
                        </div>
                    </div>
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
                    <asp:Label ID="lblContrasenia" CssClass="fs-5" Text="Contraseña" runat="server" />
                    <asp:TextBox type="password" CssClass="form-control" ID="txtPass" placeholder="Contraseña" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblTelefono" CssClass="fs-5" Text="Teléfono" runat="server" />
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Número de Teléfono" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblImagen" CssClass="fs-5" Text="Imagen" runat="server" />
                    <asp:TextBox ID="txtImagen" CssClass="form-control" placeholder="URL de Imagen" runat="server" />
                </div>
                <div class="text-end">
                    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-outline-secondary" OnClick="btnVolver_Click" runat="server" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-outline-primary" Text="Guardar" runat="server" OnClick="btnGuardar_Click" />
                </div>
            </div>
            <asp:Label ID="lblM" Text="" runat="server" />
        </div>
    </div>


</asp:Content>
