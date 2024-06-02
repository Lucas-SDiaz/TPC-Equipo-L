using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPC_Equipo_L
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Producto> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListaProductos"] != null)
            {
                ListaProductos = (List<Producto>)Session["ListaProductos"];
            }
            else
            {

                ProductoNegocio negocio = new ProductoNegocio();
                ListaProductos = negocio.listarConSp();
                Session.Add("ListaProductos", ListaProductos);
            }
        }
    }
}