using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("error", "Para continuar debe iniciar sesión");
                Response.Redirect("Error.aspx", false);
            }
            List<Producto> carrito;
            carrito = Session["carrito"] != null ? (List<Producto>)Session["carrito"] : new List<Producto>();
            Session.Add("carrito", carrito);
            string id;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Request.QueryString["id"].ToString();
                    int cant = int.Parse((string)Session["cantidad"]);
                    List<Producto> listaOriginal = (List<Producto>)Session["listaProductos"];
                    Producto seleccionado = listaOriginal.Find(x => x.CodigoProducto == id);
                    seleccionado.Cantidad = cant;
                    if (!carrito.Exists(a => a.CodigoProducto == seleccionado.CodigoProducto))
                    {
                        carrito.Add(seleccionado);
                    }
                    else
                    {
                        Producto productoEnCarrito = carrito.Find(p => p.CodigoProducto == seleccionado.CodigoProducto);
                        productoEnCarrito.Cantidad += cant;

                    }
                }

                dgvFinalizarCompra.DataSource = carrito;
                dgvFinalizarCompra.DataBind();
                SqlMoney precioTotal = 0;
                foreach (Producto producto in carrito)
                {
                    precioTotal += (producto.Precio) * (producto.Cantidad);
                }

                lblPrecioFinal.Text = "Precio Total: $" + precioTotal.ToString();
            }
        }

        protected void dgvFinalizarCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvFinalizarCompra.SelectedDataKey.Value.ToString();

            List<Producto> carrito;
            carrito = (List<Producto>)Session["carrito"];
            Session.Add("carrito", carrito);
            Producto seleccionado = carrito.Find(x => x.CodigoProducto == id);
            carrito.Remove(seleccionado);
            dgvFinalizarCompra.DataSource = carrito;
            dgvFinalizarCompra.DataBind();
            SqlMoney precioTotal = 0;
            foreach (Producto producto in carrito)
            {
                precioTotal += producto.Precio * producto.Cantidad;
            }

            lblPrecioFinal.Text = "Precio Total: $" + precioTotal.ToString();
        }
    }
}