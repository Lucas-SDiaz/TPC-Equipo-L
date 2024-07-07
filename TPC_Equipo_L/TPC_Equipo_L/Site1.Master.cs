using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Usuario usuario = (Usuario)Session["usuario"];
            //if (usuario != null)
            //{
            //    lblMensaje.Text = "Hola " + usuario.Nombre.ToString().Trim();
            //    lblMensaje.CssClass = "text-primary";
            //}
          
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            //Session["usuario"] = null;
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Session["Busqueda"] = txtBuscar.Text.Trim();
            Response.Redirect("Catalogo.aspx", false);
            txtBuscar.Text = string.Empty;
        }

        
    }
}