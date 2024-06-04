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
    public partial class listarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaProductos"] == null)
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Session.Add("listaProductos", productoNegocio.listarConSp());
            }
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            var codP = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarProducto.aspx?codP=" + codP);

        }
    }
}