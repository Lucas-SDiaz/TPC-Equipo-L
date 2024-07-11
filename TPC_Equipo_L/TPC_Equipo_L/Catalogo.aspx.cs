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
        //public List<Producto> ListaProductosCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Session["Busqueda"] != null && Session["Busqueda"].ToString() != string.Empty)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.Buscador(Session["Busqueda"].ToString());
                    Session.Add("ListaProductos", ListaProductos);
                    repRepetidor.DataSource = ListaProductos;
                    repRepetidor.DataBind();
                    Session["Busqueda"] = null;
                }
                else if (Request.QueryString["Cat"] != null)
                {
                    string cat = Request.QueryString["Cat"].ToString();

                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.listarCategorias(cat);
                    Session.Add("ListaProductos", ListaProductos);
                    repRepetidor.DataSource = ListaProductos;
                    repRepetidor.DataBind();
                }
                else if (Request.QueryString["Mar"] != null)
                {
                    string mar = Request.QueryString["Mar"].ToString();

                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.listarMarcas(mar);
                    Session.Add("ListaProductos", ListaProductos);
                    repRepetidor.DataSource = ListaProductos;
                    repRepetidor.DataBind();
                }
                else
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.listarConSp();
                    Session.Add("ListaProductos", ListaProductos);
                    repRepetidor.DataSource = ListaProductos;
                    repRepetidor.DataBind();
                    Session.Add("cantidad", "1");

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
                Session.Add("cantidad", txtCantidad.Text);
            }


        }
        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                dominio.Producto producto = (dominio.Producto)e.Item.DataItem;

                negocio.ImagenNegocio negocioImagen = new negocio.ImagenNegocio();
                List<string> listaImagenes = negocioImagen.listarImgPorProducto(producto);

                Image imgProducto = (Image)e.Item.FindControl("imgProducto");

                if (listaImagenes != null && listaImagenes.Count > 0)
                {
                    imgProducto.ImageUrl = listaImagenes[0];
                }
                else
                {
                    imgProducto.ImageUrl = "https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg";
                }
            }
        }
        protected void agregar(object sender, CommandEventArgs e)
        {
            List<Producto> carrito = Session["carrito"] as List<Producto> ?? new List<Producto>();

            string id = e.CommandArgument.ToString();

            int cant = 1;
            if (Session["cantidad"] != null)
            {
                cant = Convert.ToInt32(Session["cantidad"]);
            }

            List<Producto> listaOriginal = Session["ListaProductos"] as List<Producto>;

            Producto seleccionado = listaOriginal.FirstOrDefault(p => p.CodigoProducto == id);

            if (seleccionado != null)
            {
                seleccionado.Cantidad = cant;

                Producto productoEnCarrito = carrito.FirstOrDefault(p => p.CodigoProducto == seleccionado.CodigoProducto);
                if (productoEnCarrito != null)
                {
                    productoEnCarrito.Cantidad += cant;
                }
                else
                {
                    carrito.Add(seleccionado);
                }

                Session["carrito"] = carrito;
            }
        }


    }
}
