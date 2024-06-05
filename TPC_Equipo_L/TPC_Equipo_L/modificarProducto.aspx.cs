using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class actualizarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codP;
            ProductoNegocio negocio = new ProductoNegocio();
            if (!IsPostBack)
            {
                if (Request.QueryString["codP"] != null)
                {
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    negocio.cargarDDLMarcas(ddlMarca);
                    negocio.cargarDDLCategorias(ddlCategoria);
                    codP = Request.QueryString["codP"].ToString();
                    List<Producto> temp = (List<Producto>)Session["listaProductos"];
                    Producto selected = temp.Find(x => x.CodigoProducto == codP);
                    selected.Imagen = new Imagen();
                    selected.CodigoProducto = codP;
                    txtNombre.Text = selected.Nombre;
                    txtDescripcion.Text = selected.Descripcion;
                    txtPrecio.Text = selected.Precio.ToString();
                    txtStock.Text = selected.Stock.ToString();
                    txtImagen.Text = negocio.buscarImagen(selected);
                    ddlCategoria.SelectedValue = selected.Categoria.Cod_Categoria;
                    ddlMarca.SelectedValue = selected.Marca.Cod_Marca;
                }
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto producto = new Producto();
                producto.Categoria = new Categoria();
                producto.Marca = new Marca();
                producto.Imagen = new Imagen();


                if (producto != null && ddlCategoria.SelectedValue != null && ddlMarca.SelectedValue != null && txtNombre.Text.Trim() != string.Empty && txtDescripcion.Text.Trim() != string.Empty && txtPrecio.Text.Trim() != string.Empty && txtStock.Text.Trim() != string.Empty && txtImagen.Text.Trim() != string.Empty)
                {
                    producto.CodigoProducto = Request.QueryString["codP"].ToString();
                    producto.Categoria.Cod_Categoria = ddlCategoria.SelectedValue;
                    producto.Marca.Cod_Marca = ddlMarca.SelectedValue;
                    producto.Nombre = txtNombre.Text.Trim();
                    producto.Descripcion = txtDescripcion.Text.Trim();
                    producto.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                    producto.Stock = Convert.ToInt32(txtStock.Text.Trim());
                    producto.Imagen.Url = txtImagen.Text.Trim();

                    negocio.modificar(producto);
                    producto.CodigoProducto = negocio.buscarProd(producto);
                    negocio.agregarImagen(producto.CodigoProducto, producto.Imagen.Url);

                    lblMensaje.Text = "Se modificó el producto exitosamente.";
                    lblMensaje.CssClass = "alert alert-success";

                    txtImagen.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    txtStock.Text = string.Empty;
                    negocio.cargarDDLMarcas(ddlMarca);
                    negocio.cargarDDLCategorias(ddlCategoria);

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                    "setTimeout(function() { window.location.replace('listarProducto.aspx') }, 3000);", true);

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