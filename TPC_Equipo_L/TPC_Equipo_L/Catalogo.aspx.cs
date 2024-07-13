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
            if (!IsPostBack)
            {

                if (Session["Busqueda"] != null && Session["Busqueda"].ToString() != string.Empty)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.Buscador(Session["Busqueda"].ToString());
                }

                else if (Request.QueryString["Cat"] != null)
                {
                    string cat = Request.QueryString["Cat"].ToString();
                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.listarCategorias(cat);
                }

                else if (Request.QueryString["Mar"] != null)
                {
                    string mar = Request.QueryString["Mar"].ToString();
                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.listarMarcas(mar);
                }

                else
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    ListaProductos = negocio.listarConSp();
                }

                ProductoNegocio negocio1 = new ProductoNegocio();
                negocio1.cargarDDLCategorias(ddlCategoria);
                negocio1.cargarDDLMarcas(ddlMarca);

                Session["ListaProductos"] = ListaProductos;


                repRepetidor.DataSource = ListaProductos;
                repRepetidor.DataBind();
            }
        }
        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {
            var boton = (Button)sender;
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

                var productId = ((HiddenField)item.FindControl("hdnProductId")).Value;
                var cantidades = Session["Cantidades"] as Dictionary<string, int> ?? new Dictionary<string, int>();
                cantidades[productId] = int.Parse(txtCantidad.Text);
                Session["Cantidades"] = cantidades;
            }
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var producto = (Producto)e.Item.DataItem;
                var negocioImagen = new ImagenNegocio();
                var listaImagenes = negocioImagen.listarImgPorProducto(producto);

                var imgProducto = (Image)e.Item.FindControl("imgProducto");
                if (listaImagenes != null && listaImagenes.Count > 0)
                {
                    imgProducto.ImageUrl = listaImagenes[0];
                }
                else
                {
                    imgProducto.ImageUrl = "https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg";
                }

                var txtCantidad = (TextBox)e.Item.FindControl("txtCantidad");
                var hdnProductId = (HiddenField)e.Item.FindControl("hdnProductId");
                hdnProductId.Value = producto.CodigoProducto;

                var cantidades = Session["Cantidades"] as Dictionary<string, int>;
                if (cantidades != null && cantidades.ContainsKey(producto.CodigoProducto))
                {
                    txtCantidad.Text = cantidades[producto.CodigoProducto].ToString();
                }
                else
                {
                    txtCantidad.Text = "1";
                }
            }
        }

        protected void agregar(object sender, CommandEventArgs e)
        {
            var carrito = Session["carrito"] as List<Producto> ?? new List<Producto>();

            var id = e.CommandArgument.ToString();
            int cant = 1;

            var cantidades = Session["Cantidades"] as Dictionary<string, int>;
            if (cantidades != null && cantidades.ContainsKey(id))
            {
                cant = cantidades[id];
            }

            var listaOriginal = Session["ListaProductos"] as List<Producto>;
            var seleccionado = listaOriginal?.FirstOrDefault(p => p.CodigoProducto == id);

            if (seleccionado != null)
            {

                var productoEnCarrito = carrito.FirstOrDefault(p => p.CodigoProducto == seleccionado.CodigoProducto);
                if (productoEnCarrito != null)
                {
                    productoEnCarrito.Cantidad += cant;
                }
                else
                {

                    seleccionado.Cantidad = cant;
                    carrito.Add(seleccionado);
                }

                Session["carrito"] = carrito;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoria = ddlCategoria.SelectedValue;
            string marca = ddlMarca.SelectedValue;
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProductos = negocio.listarConFiltros(marca, categoria);
            Session["ListaProductos"] = ListaProductos;


            repRepetidor.DataSource = ListaProductos;
            repRepetidor.DataBind();
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoria = ddlCategoria.SelectedValue;
            string marca = ddlMarca.SelectedValue;
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProductos = negocio.listarConFiltros(marca, categoria);
            Session["ListaProductos"] = ListaProductos;


            repRepetidor.DataSource = ListaProductos;
            repRepetidor.DataBind();
        }
        protected void btnResetFiltros_Click(object sender, EventArgs e)
        {

            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
            string categoria = ddlCategoria.SelectedValue;
            string marca = ddlMarca.SelectedValue;
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProductos = negocio.listarConFiltros(marca, categoria);
            Session["ListaProductos"] = ListaProductos;


            repRepetidor.DataSource = ListaProductos;
            repRepetidor.DataBind();

        }
    }

}

