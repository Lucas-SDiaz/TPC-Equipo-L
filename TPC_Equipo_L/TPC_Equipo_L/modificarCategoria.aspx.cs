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
    public partial class modificarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codC;
            CategoriaNegocio negocio = new CategoriaNegocio();
            if (!IsPostBack)
            {
                if (Request.QueryString["codC"] != null)
                {
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    codC = Request.QueryString["codC"].ToString();
                    List<Categoria> temp = (List<Categoria>)Session["listaCategoria"];
                    Categoria selected = temp.Find(x => x.Cod_Categoria == codC);
                    txtNombre.Text = selected.Nombre;
                    txtImagen.Text = selected.ImagenURL;

                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio negocio = new CategoriaNegocio();

            if (txtNombre.Text.Trim() != string.Empty && txtImagen.Text.Trim() != string.Empty)
            {
                categoria.Cod_Categoria = Request.QueryString["codC"].ToString();
                categoria.Nombre = txtNombre.Text.Trim();
                categoria.ImagenURL = txtImagen.Text.Trim();
                categoria.Estado = true;
                negocio.modificar(categoria);
                lblMensaje.Text = "Se modificó la Categoria exitosamente.";
                lblMensaje.CssClass = "alert alert-success";

                txtImagen.Text = string.Empty;
                txtNombre.Text = string.Empty;

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                "setTimeout(function() { window.location.replace('listarCategoria.aspx') }, 3000);", true);
            }
            else
            {
                lblMensaje.Text = "Tiene que llenar todos los campos.";
                lblMensaje.CssClass = "alert alert-success";
            }
        }

    }
}
