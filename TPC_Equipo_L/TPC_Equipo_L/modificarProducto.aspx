<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="modificarProducto.aspx.cs" Inherits="TPC_Equipo_L.actualizarProducto" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center p-2">Actualizar</h2>

    <div class="mx-auto p-2" style="width: 600px">
        <div class="card" style="width: 38rem;">
            <div class="card-body">
                <div class="mb-2">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-2">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server" />
                </div>
                <div class="mb-2">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <div class="input-group mb-3">
                        <span class="input-group-text">$</span>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
                        <span class="input-group-text">.00</span>
                    </div>
                </div>
                <div class="mb-2">
                    <label for="txtSstock" class="form-label">Stock</label>
                    <asp:TextBox ID="txtStock" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-2">
                    <label for="txtImagen" class="form-label">Imagen</label>
                    <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server" />
                </div>
                <div class="container-fluid text-center p-2">
                    <div class="row align-items-start">
                        <div class="col">
                            <asp:DropDownList CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlCategoria" runat="server" />
                        </div>
                        <div class="col">
                            <asp:DropDownList CssClass="btn btn-outline-dark dropdown-toggle dropdown-toggle-split" ID="ddlMarca" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="mb-2 text-center">
                    <asp:Button Text="Modificar" ID="btnAgregar" OnClick="btnModificar_Click" CssClass="btn btn-outline-success" runat="server" />
                </div>
            </div>
        </div>

    </div>
    <div class="text-end p-4">
        <asp:Label Text="" ID="lblMensaje" runat="server" />
    </div>
</asp:Content>
