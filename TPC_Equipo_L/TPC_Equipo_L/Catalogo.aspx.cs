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


            if (!IsPostBack) { 
            if (Request.QueryString["Cat"] != null)
            {
                string cat = Request.QueryString["Cat"].ToString();

                ProductoNegocio negocio = new ProductoNegocio();
                ListaProductos = negocio.listarCategorias(cat);
                Session.Add("ListaProductosCategoria", ListaProductos);
                repRepetidor.DataSource = ListaProductos;
                repRepetidor.DataBind();
            }
            else {
                ProductoNegocio negocio = new ProductoNegocio();
                ListaProductos = negocio.listarConSp();
                Session.Add("ListaProductos", ListaProductos);
                repRepetidor.DataSource = ListaProductos;
                repRepetidor.DataBind();
            }
            }


        }

        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {
            var boton = (Button)sender;
            Producto prod = new Producto();
            var item = (RepeaterItem)boton.NamingContainer;
            var txtCantidad = (TextBox)item.FindControl("txtCantidad");

            if (txtCantidad != null)
            {
                int cant = int.Parse(txtCantidad.Text);
                if (e.CommandName == "Quitar" && cant > 1)
                {
                    txtCantidad.Text = (cant - 1).ToString();
                }
                else if (e.CommandName == "Agregar")
                {
                    txtCantidad.Text = (cant + 1).ToString();
                }
            }

        }

    }
}
