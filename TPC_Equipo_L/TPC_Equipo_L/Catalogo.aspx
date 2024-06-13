<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_Equipo_L.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .img-thumbnail {
            width: 100%;
            height: 300px;
        }

        .custom-card-size {
            width: 250px; /* Tamaño fijo para la tarjeta */
            height: 600px; /* Ajusta el tamaño según tus necesidades */
        }
    </style>

    <figure class="text-center">
        <h1>CATALOGO</h1>
    </figure>

    <div class="row row-cols-1 row-cols-md-4 g-4">

        <%  
            negocio.ImagenNegocio negocio = new negocio.ImagenNegocio();
            List<string> lista = new List<string>();
            foreach (dominio.Producto producto in ListaProductos)
            {
                lista = negocio.listarImgPorArticulo(producto);
        %>
        <div class="col">
            <div class="card custom-card-size">
                <% if(!(lista.Count == 0))
                   { %>
                       <img src="<%:lista[0] %>" class="img-thumbnail"  onerror="this.src='https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg';" />
                <% } %>
                <div class="card-body">
                    <h5 class="card-title" style="color: black; text-align: center;"><b><%: producto.Nombre %></b> </h5>
                    <p class="card-text" style="color: black; text-align: center;"><%: producto.Marca %></p>
                    <p class="card-text" style="color: black; text-align: center;"><%:"Stock: " + producto.Stock %></p>
                    <p class="card-text" style="color: black; text-align: center;"><%:"$" + producto.Precio %></p>
                    <div class="d-grid gap-2">
                        <a href="detalleProducto.aspx?id=<%: producto.CodigoProducto %>" class="btn btn-outline-success">Ver detalle</a>
                        <a href="carritoCompra.aspx?id=<%: producto.CodigoProducto %>"  class="btn btn-success">Agregar al carrito</a>
                        <div class="input-group">
                        <asp:Button class="btn btn-success" runat="server" type="button" Text="-"/>
                        <asp:TextBox ID="productQuantity" runat="server" CssClass="form-control text-center" Text="1" ReadOnly="true" />
                        <asp:Button class="btn btn-success" runat="server" type="button" Text="+"/> 
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%  } %>
    </div>

</asp:Content>