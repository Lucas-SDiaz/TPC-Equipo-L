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
    public partial class detalleProducto : System.Web.UI.Page
    {
        public List<Producto> ListaProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProductos = negocio.listarConSp();
            string id = Request.QueryString["id"];
            lblId.Text = id;


        }
    }
}