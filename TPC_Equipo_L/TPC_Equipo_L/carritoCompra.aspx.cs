using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class carritoCompra : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
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

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();
                SqlMoney precioTotal = 0;
                foreach (Producto producto in carrito)
                {
                    precioTotal += (producto.Precio)* (producto.Cantidad);
                }

                lblPrecioTotal.Text = "Precio Total: $" + precioTotal.ToString();
            }

        
        }
        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var id = dgvCarrito.SelectedDataKey.Value.ToString();

            List<Producto> carrito;
            carrito = (List<Producto>)Session["carrito"];
            Session.Add("carrito", carrito);
            Producto seleccionado = carrito.Find(x => x.CodigoProducto == id);
            carrito.Remove(seleccionado);
            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();
            SqlMoney precioTotal = 0;
            foreach (Producto producto in carrito)
            {
                precioTotal += producto.Precio * producto.Cantidad;
            }

            lblPrecioTotal.Text = "Precio Total: $" + precioTotal.ToString();
    
        }

        protected void RestarCantidad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = int.Parse(btn.CommandArgument);

            List<Producto> carrito = (List<Producto>)Session["carrito"];
            Producto producto = carrito[rowIndex];

            if (producto.Cantidad > 1)
            {
                producto.Cantidad--;
                Session["carrito"] = carrito; 
                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();

                RecalcularPrecioTotal(carrito);
            }
        }

        protected void SumarCantidad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = int.Parse(btn.CommandArgument);

            List<Producto> carrito = (List<Producto>)Session["carrito"];
            Producto producto = carrito[rowIndex];

            producto.Cantidad++;
            Session["carrito"] = carrito; 
            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();

            RecalcularPrecioTotal(carrito);
        }

        private void RecalcularPrecioTotal(List<Producto> carrito)
        {
            SqlMoney precioTotal = 0;
            foreach (Producto producto in carrito)
            {
                precioTotal += (producto.Precio) * (producto.Cantidad);
            }

            lblPrecioTotal.Text = "Precio Total: $" + precioTotal.ToString();
        }
    }
}