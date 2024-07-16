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
    public partial class modificarMarca : System.Web.UI.Page
    {
        public string url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string codM;
            MarcaNegocio negocio = new MarcaNegocio();
            if (!IsPostBack)
            {
                if (Request.QueryString["codM"] != null)
                {
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    codM = Request.QueryString["codM"].ToString();
                    List<Marca> temp = (List<Marca>)Session["listaMarca"];
                    Marca selected = temp.Find(x => x.Cod_Marca == codM);
                    txtNombre.Text = selected.Nombre;
                    txtImagen.Text = selected.ImagenURL;
                    url = selected.ImagenURL;
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            MarcaNegocio negocio = new MarcaNegocio();

            if (txtNombre.Text.Trim() != string.Empty && txtImagen.Text.Trim() != string.Empty)
            {
                marca.Cod_Marca = Request.QueryString["codM"].ToString();
                marca.Nombre = txtNombre.Text.Trim();
                marca.ImagenURL = txtImagen.Text.Trim();
                marca.Estado = true;
                negocio.modificar(marca);
                lblMensaje.Text = "Se modificó la Marca exitosamente.";
                lblMensaje.CssClass = "alert alert-success";

                txtImagen.Text = string.Empty;
                txtNombre.Text = string.Empty;

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                "setTimeout(function() { window.location.replace('listarMarca.aspx') }, 3000);", true);
            }
            else
            {
                lblMensaje.Text = "Tiene que llenar todos los campos.";
                lblMensaje.CssClass = "alert alert-success";
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("listarMarca.aspx");
        }
    }
}