using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Session.Add("listaProductos", negocio.listarStock());
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();

        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codP = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarProducto.aspx?codP=" + codP);
        }

        protected void dgvProductos_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}