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
        public List<Producto> ListaProductos;

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
                    ListaProductos = (List<Producto>)Session["listaProductos"];
                    List<Imagen> tImagen = (List<Imagen>)Session["listaImagenes"];
                    Producto selected = temp.Find(x => x.CodigoProducto == codP);                    
                    selected.Imagen = new Imagen();
                    selected.CodigoProducto = codP;
                    txtNombre.Text = selected.Nombre;
                    txtDescripcion.Text = selected.Descripcion;
                    txtPrecio.Text = selected.Precio.ToString();
                    txtStock.Text = selected.Stock.ToString();
                    lblId.Text = codP;

                    url = txtImagen.Text;
                    ddlCategoria.SelectedValue = selected.Categoria.Cod_Categoria;
                    ddlMarca.SelectedValue = selected.Marca.Cod_Marca;

                    List<Imagen> lista = negocio.buscarImagenes(selected);
                    if (lista != null && lista.Count > 0)
                    {
                        txtImagen.Text = lista[0].Url; // Asignar la primera imagen del carrusel
                        url = txtImagen.Text; // Actualizar la variable url
                    }
                    else
                    {
                        txtImagen.Text = string.Empty; // O asignar un valor predeterminado si no hay imágenes
                        url = string.Empty; // Actualizar la variable url en caso de no haber imagen
                    }
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
                    producto.Estado = true;

                    negocio.modificar(producto);
                    negocio.modificarImagen(producto);

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
        public static string url { get; set; }
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
            url = txtImagen.Text;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("listarProducto.aspx");
        }

        
    }
}