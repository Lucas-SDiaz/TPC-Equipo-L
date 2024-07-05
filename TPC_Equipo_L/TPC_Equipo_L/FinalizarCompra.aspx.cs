using dominio;
using negocio;
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
            Session["precioTotal"] = precioTotal;
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {

            EmailService emailService = new EmailService();
            Usuario usuario = (Usuario)Session["usuario"];
            VentaNegocio negocio = new VentaNegocio();
            string metodoEntrega = rblDeliveryMethod.SelectedValue;
            string metodoPago = rblPaymentMethod.SelectedValue;
            Session["metodoEntrega"] = metodoEntrega;
            Session["metodoPago"] = metodoPago;
            if (metodoEntrega == "Retirar en local")
            {
                emailService.armarCorreoRetiro(usuario.Correo, "Felicitaciones por tu compra", usuario);
                emailService.enviarMail();
            }
            else
            {
                emailService.armarCorreoEnvio(usuario.Correo, "Felicitaciones por tu compra", usuario);
                emailService.enviarMail();
            }
            Venta venta = new Venta();
            venta.FechaVenta = DateTime.Now;
            venta.Usuario = usuario;
           
            venta.Localidad = 1;

            SqlMoney precioTotal = (SqlMoney)Session["precioTotal"];
            venta.MontoFinal = precioTotal;
            negocio.agregar(venta, usuario);

            Session["carrito"] = null;
            Response.Redirect("CompraExitosa.aspx");
        }
    }
}