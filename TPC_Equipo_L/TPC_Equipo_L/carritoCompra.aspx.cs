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
            /*
             * List<Producto> carrito;
            carrito = Session["carrito"] != null ? (List<Producto>)Session["carrito"] : new List<Producto>();
            Session.Add("carrito", carrito);
            int id = -1;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = int.Parse(Request.QueryString["id"]);
                    List<Producto> listaOriginal = (List<Producto>)Session["listaProductos"];
                    Producto seleccionado = listaOriginal.Find(x => x.Id == id);
                    if (!carrito.Exists(a => a.Id == seleccionado.Id))
                    {
                        carrito.Add(seleccionado);
                    }
                    else
                    {
                        //Solucionado problema de referencia con ScriptManager.
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El artículo ya está en el carrito. Realice una nueva compra o aguarde una actualizacion de sistema. Disculpe las molestias');", true);
                    }
                }

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();
                SqlMoney precioTotal = 0;
                foreach (Producto producto in carrito)
                {
                    precioTotal += (producto.Precio);
                }

                lblPrecioTotal.Text = "Precio Total: $" + precioTotal.ToString();
            }

            */
        }
        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            var id = dgvCarrito.SelectedDataKey.Value.ToString();

            List<Producto> carrito;
            carrito = (List<Producto>)Session["carrito"];
            Session.Add("carrito", carrito);
            Producto seleccionado = carrito.Find(x => x.Id == int.Parse(id));
            carrito.Remove(seleccionado);
            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();
            sqlm precioTotal = 0;
            foreach (Producto producto in carrito)
            {
                precioTotal += producto.Precio;
            }

            lblPrecioTotal.Text = "Precio Total: $" + precioTotal.ToString();
       */
        }
    }
}