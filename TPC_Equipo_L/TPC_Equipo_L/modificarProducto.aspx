<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="modificarProducto.aspx.cs" Inherits="TPC_Equipo_L.actualizarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label>

    <h1 class="text-center p-2">Modificar Producto</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row m-4" style="display: flex; justify-content: space-between;">

                <div class="card col" style="max-width: 30rem;">
                    <div class="card-body">
                        <div class="mb-2">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" onkeydown="return (event.keyCode >= 65 && event.keyCode <= 90 || event.keyCode >= 97 && event.keyCode <= 122 || event.keyCode == 08 || event.keyCode == 9)" ID="txtNombre" CssClass="form-control" runat="server" />
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
                                <asp:TextBox AutoPostBack="true" OnTextChanged="txtPrecio_TextChanged" onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57 || event.keyCode == 08 || event.keyCode == 9)" ID="txtPrecio" CssClass="form-control" runat="server" />
                                <span class="input-group-text">.00</span>
                                <asp:Label ID="txtInvPrecio" Text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="mb-2">
                            <label for="txtStock" class="form-label">Stock</label>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="txtStock_TextChanged" onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57 || event.keyCode == 08 || event.keyCode == 9)" ID="txtStock" CssClass="form-control" runat="server" />
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

                <div class="card m-4 col" style="max-width: 70rem;">
                    <div id="carouselExample" class="carousel slide">
                        <div class="carousel-inner">
                            <% if(ListaProductos != null) { 
                                negocio.ImagenNegocio negocio = new negocio.ImagenNegocio();
                                List<string> lista = new List<string>();
                                foreach (dominio.Producto producto in ListaProductos)
                                {
                                    if (lblId.Text == producto.CodigoProducto.ToString())
                                    {
                                        lista = negocio.listarImgPorProducto(producto);
                                        int c = lista.Count();
                                        for (int i = 0; i < c; i++)
                                        {
                                            string itemClass = (i == 0) ? "carousel-item active" : "carousel-item";
                            %>
                            <div class="<%= itemClass %>">
                                <img src="<%= lista[i] %>" class="rounded mx-auto d-block custom-carousel-img-size" alt="..." onerror="this.src='https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg'">
                            </div>
                            <% 
                                        }
                                        break; // Si encontramos el producto, salimos del bucle
                                    }
                                }
                                }
                            %>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                            <span class="badge text-bg-secondary p-3" aria-hidden="true">&lt;</span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                            <span class="badge text-bg-secondary p-3" aria-hidden="true">&gt;</span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="mb-2 text-center">
        <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-outline-secondary" OnClick="btnVolver_Click" runat="server" />
        <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-outline-success" runat="server" />
    </div>

    <div class="text-end p-4">
        <asp:Label Text="" ID="lblMensaje" runat="server" />
    </div>
    	<style>
		.custom-carousel-img-size {
			width: auto;
			height: 300px;
		}
	</style>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        // Manejar el evento slid.bs.carousel para actualizar txtImagen.Text
        $('#carouselExample').on('slid.bs.carousel', function () {
            var activeSlide = $(this).find('.carousel-item.active img');
            var imageUrl = activeSlide.attr('src');
            $('#<%= txtImagen.ClientID %>').val(imageUrl); // Actualizar el valor del campo txtImagen
        });
    });
</script>
</asp:Content>

