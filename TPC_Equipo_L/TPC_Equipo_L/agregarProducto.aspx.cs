using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_Equipo_L
{
    public partial class agregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            if(!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                negocio.cargarDDLMarcas(ddlMarca);
                negocio.cargarDDLCategorias(ddlCategoria);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto producto = new Producto();
                producto.Categoria = new Categoria();
                producto.Marca = new Marca();
                producto.Imagen = new Imagen();
                if (producto != null && ddlCategoria.SelectedValue != null && ddlMarca.SelectedValue != null && txtNombre.Text.Trim() != string.Empty && txtDescripcion.Text.Trim() != string.Empty && txtPrecio.Text.Trim() != string.Empty && txtStock.Text.Trim() != string.Empty)
                {
                    producto.Categoria.Cod_Categoria = ddlCategoria.SelectedValue;
                    producto.Marca.Cod_Marca = ddlMarca.SelectedValue;
                    producto.Nombre = txtNombre.Text.Trim();
                    producto.Descripcion = txtDescripcion.Text.Trim();
                    producto.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                    producto.Stock = Convert.ToInt32(txtStock.Text.Trim());
                    producto.Imagen.Url = txtImagen.Text.Trim();

                    negocio.agregar(producto);
                    producto.CodigoProducto = negocio.buscarProd(producto);
                    negocio.agregarImagen(producto.CodigoProducto, producto.Imagen.Url);

                    lblMensaje.Text = "Se agregó el producto exitosamente.";
                    lblMensaje.CssClass = "alert alert-success";

                    txtImagen.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    txtStock.Text = string.Empty;
                    negocio.cargarDDLMarcas(ddlMarca);
                    negocio.cargarDDLCategorias(ddlCategoria);

                }
                else
                {
                    lblMensaje.Text = "Tiene que llenar todos los campos";
                    lblMensaje.CssClass = "alert alert-danger";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}