<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="agregarProducto.aspx.cs" Inherits="TPC_Equipo_L.agregarProducto"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <h1 class="text-center">Agregar Producto</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="mx-auto p-2" style="width: 600px">
                <div class="card" style="width: 38rem;">
                    <div class="card-body">
                        <div class="mb-2">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" onkeydown = "return (event.keyCode >= 65 && event.keyCode <= 90 || event.keyCode >= 97 && event.keyCode <= 122 || event.keyCode == 08 || event.keyCode == 9)" ID="txtNombre" CssClass="form-control" runat="server"/>
                            <asp:Label ID="txtInvNombre" Text="" runat="server"></asp:Label>
                        </div>
                        <div class="mb-2">
                            <label for="txtDescripcion" class="form-label">Descripción</label>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="txtDescripcion_TextChanged" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server" />
                            <asp:Label ID="txtInvDescripcion" Text="" runat="server"></asp:Label>
                        </div>
                        <div class="mb-2">
                            <label for="txtPrecio" class="form-label">Precio</label>
                            <div class="input-group mb-3">
                                <span class="input-group-text">$</span>
                                <asp:TextBox AutoPostBack="true" OnTextChanged="txtPrecio_TextChanged" onkeydown = "return (event.keyCode >= 48 && event.keyCode <= 57 || event.keyCode == 08 || event.keyCode == 9)" ID="txtPrecio" CssClass="form-control" runat="server" />
                                <span class="input-group-text">.00</span>
                                <asp:Label ID="txtInvPrecio" Text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="mb-2">
                            <label for="txtStock" class="form-label">Stock</label>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="txtStock_TextChanged" onkeydown = "return (event.keyCode >= 48 && event.keyCode <= 57 || event.keyCode == 08 || event.keyCode == 9)" ID="txtStock" CssClass="form-control" runat="server" />
                                <asp:Label ID="txtInvStock" Text="" runat="server"></asp:Label>
                        </div>
                        <div class="mb-2">
                            <label for="txtImagen" class="form-label">Imagen</label>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" ID="txtImagen" CssClass="form-control" runat="server" />
                                <asp:Label ID="txtInvImagen" Text="" runat="server"></asp:Label>
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

                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="mb-2 text-center">
        <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-outline-success" runat="server" />
    </div>

    <div class="text-end p-4">
        <asp:Label Text="" ID="lblMensaje" runat="server" />
    </div>

</asp:Content>
