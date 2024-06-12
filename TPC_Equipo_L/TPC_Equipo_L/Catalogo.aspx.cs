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
        public List<Producto> ListaProductosCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListaProductos"] != null || Session["ListaProductosCategoria"] != null)
            {
                ListaProductos = (List<Producto>)Session["ListaProductos"];
                ListaProductosCategoria = (List<Producto>) Session["ListaProductosCategoria"];
            }
            else if(!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                ListaProductos = negocio.listarConSp();
                Session.Add("ListaProductos", ListaProductos);
            }
            else
            {
                string cat = Request.QueryString["Cat"].ToString();
                ProductoNegocio negocio = new ProductoNegocio();
                ListaProductos = negocio.listarCategorias(cat);
                Session.Add("ListaProductosCategoria", ListaProductos);
            }
        }
    }
}