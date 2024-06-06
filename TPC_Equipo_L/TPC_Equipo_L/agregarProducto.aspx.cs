using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            if (!IsPostBack)
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

                if (ddlCategoria.SelectedValue == "0")
                {
                    lblMensaje.Text = "Tiene que seleccionar una Categoria";
                    lblMensaje.CssClass = "alert alert-danger";
                }
                else if (ddlMarca.SelectedValue == "0")
                {
                    lblMensaje.Text = "Tiene que seleccionar una Marca";
                    lblMensaje.CssClass = "alert alert-danger";
                }
                else if(producto != null && ddlCategoria.SelectedValue != null && ddlMarca.SelectedValue != null && txtNombre.Text.Trim() != string.Empty && txtDescripcion.Text.Trim() != string.Empty && txtPrecio.Text.Trim() != string.Empty && txtStock.Text.Trim() != string.Empty && txtImagen.Text.Trim() != string.Empty)
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

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                    "setTimeout(function() { window.location.replace('agregarProducto.aspx') }, 3000);", true);

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

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == string.Empty)
            {
                txtNombre.CssClass = "form-control is-invalid";
                txtInvNombre.Text = "¡Tiene que definir un Nombre!";
                txtInvNombre.CssClass = "invalid-feedback";
            }
            else
            {
                txtNombre.CssClass = "form-control is-valid";
                txtInvNombre.Text = "";
                txtInvNombre.CssClass = "";
            }
        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Trim() == string.Empty)
            {
                txtDescripcion.CssClass = "form-control is-invalid";
                txtInvDescripcion.Text = "¡Tiene que definir una Descripción!";
                txtInvDescripcion.CssClass = "invalid-feedback";
            }
            else
            {
                txtDescripcion.CssClass = "form-control is-valid";
                txtInvDescripcion.Text = "";
                txtInvDescripcion.CssClass = "";
            }
        }

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio.Text.Trim() == string.Empty)
            {
                txtPrecio.CssClass = "form-control is-invalid";
                txtInvPrecio.Text = "¡Tiene que definir un Precio numérico!";
                txtInvPrecio.CssClass = "invalid-feedback";
            }
            else
            {
                txtPrecio.CssClass = "form-control is-valid";
                txtInvPrecio.Text = "";
                txtInvPrecio.CssClass = "";
            }
        }

        protected void txtStock_TextChanged(object sender, EventArgs e)
        {
            if (txtStock.Text.Trim() == string.Empty)
            {
                txtStock.CssClass = "form-control is-invalid";
                txtInvStock.Text = "¡Tiene que definir un Stock!";
                txtInvStock.CssClass = "invalid-feedback";
            }
            else
            {
                txtStock.CssClass = "form-control is-valid";
                txtInvStock.Text = "";
                txtInvStock.CssClass = "";
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            if (txtImagen.Text.Trim() == string.Empty)
            {
                txtImagen.CssClass = "form-control is-invalid";
                txtInvImagen.Text = "¡Tiene que definir una Imagen!";
                txtInvImagen.CssClass = "invalid-feedback";
            }
            else
            {
                txtImagen.CssClass = "form-control is-valid";
                txtInvImagen.Text = "";
                txtInvImagen.CssClass = "";
            }
        }

    }
}