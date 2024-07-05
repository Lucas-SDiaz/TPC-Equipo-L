using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class CompraExitosa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            List<Producto> carrito;
            carrito = (List<Producto>)Session["carrito"];
            Session["carrito"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}