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
    public partial class agregarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();
            try
            {
                if(categoria != null && txtNombre.Text.Trim() != string.Empty && txtImagen.Text.Trim() != string.Empty)
                {
                    categoria.Nombre = txtNombre.Text.Trim();
                    categoria.ImagenURL = txtImagen.Text.Trim();
                    negocio.agregar(categoria);

                    lblMensaje.Text = "Se agregó la categoria exitosamente.";
                    lblMensaje.CssClass = "alert alert-success";

                    txtImagen.Text = string.Empty;
                    txtNombre.Text = string.Empty;
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