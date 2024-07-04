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
            //if (Session["Usuario"] == null)
            //{
            //    Session.Add("error", "Para continuar debe iniciar sesión");
            //    Response.Redirect("Error.aspx", false);
            //}
            List<Producto> carrito;
            carrito = Session["carrito"] != null ? (List<Producto>)Session["carrito"] : new List<Producto>();
            Session.Add("carrito", carrito);

            dgvFinalizarCompra.DataSource = carrito;
            dgvFinalizarCompra.DataBind();
            SqlMoney precioTotal = 0;
            foreach (Producto producto in carrito)
            {
                precioTotal += (producto.Precio) * (producto.Cantidad);
            }
            lblPrecioFinal.Text = "Precio Total: $" + precioTotal.ToString();  
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            string metodoEntrega = rblDeliveryMethod.SelectedValue;
            string metodoPago = rblPaymentMethod.SelectedValue;
            Session["metodoEntrega"] = metodoEntrega;
            Session["metodoPago"] = metodoPago;           
            Response.Redirect("CompraExitosa.aspx");
        }
    }
}