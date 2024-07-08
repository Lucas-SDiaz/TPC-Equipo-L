using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
                ActualizarPrecioTotal();
            }
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // Lógica para finalizar la compra y guardar en la base de datos
            EmailService emailService = new EmailService();
            Usuario usuario = (Usuario)Session["usuario"];
            VentaNegocio negocio = new VentaNegocio();
            DireccionNegocio direccionNegocio = new DireccionNegocio();

            string metodoEntrega = rblDeliveryMethod.SelectedValue;
            string metodoPago = rblPaymentMethod.SelectedValue;
            Session["metodoEntrega"] = metodoEntrega;
            Session["metodoPago"] = metodoPago;

            // Enviar correo electrónico
            if (metodoEntrega == "Retiro en el local")
            {
                emailService.armarCorreoRetiro(usuario.Correo, "Felicitaciones por tu compra", usuario);
            }
            else
            {
                emailService.armarCorreoEnvio(usuario.Correo, "Felicitaciones por tu compra", usuario);
            }
            emailService.enviarMail();

            // Crear objeto Venta y guardar en la base de datos
            Venta venta = new Venta();
            Direccion direccion = new Direccion();

            if (metodoEntrega != "Retiro en el local")
            {
                direccion.Calle = txtCalle.Text;
                direccion.Nro = int.Parse(txtNro.Text);
                direccion.CP = int.Parse(txtCP.Text);
                if (txtPiso.Text != "")
                {
                    direccion.Piso = int.Parse(txtPiso.Text);

                }
                if (txtDepto.Text != "")
                {
                    direccion.Depto = txtDepto.Text;

                }
                else
                {
                    direccion.Depto = "";

                }
            }
            else
            {
             
                    direccion.Calle = "Calle Falsa";
                    direccion.Nro = 123;
                    direccion.CP = 12345;
                    direccion.Piso = 0;
                    direccion.Depto = "";

            }
            venta.IdDireccion = direccionNegocio.Agregar(direccion,usuario);
            venta.FechaVenta = DateTime.Now;
            venta.Usuario = usuario;
            
            venta.MetodoPago = metodoPago;
            venta.MetodoEnvio = metodoEntrega;

            if(metodoPago== "Efectivo")
            {
                venta.IdPago = "-";
            }
            if(metodoEntrega== "Retiro en el local")
            {
                venta.NumSeguimiento = "-";
            }
            SqlMoney precioTotal = (SqlMoney)Session["precioTotal"];
            venta.MontoFinal = precioTotal;

            negocio.agregar(venta, usuario);

            // Redirigir a la página de compra exitosa
            Response.Redirect("CompraExitosa.aspx");
        }

        protected void rblDeliveryMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecioTotal();
        }

        protected void rblPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecioTotal();
        }

        private void CargarCarrito()
        {
            List<Producto> carrito = Session["carrito"] as List<Producto>;
            if (carrito == null)
            {
                carrito = new List<Producto>();
                Session["carrito"] = carrito;
            }

            dgvFinalizarCompra.DataSource = carrito;
            dgvFinalizarCompra.DataBind();
        }

        private void ActualizarPrecioTotal()
        {
            List<Producto> carrito = Session["carrito"] as List<Producto>;
            if (carrito == null)
            {
                carrito = new List<Producto>();
            }

            SqlMoney precioTotal = 0;
            foreach (Producto producto in carrito)
            {
                precioTotal += (producto.Precio) * (producto.Cantidad);
            }

            if (rblDeliveryMethod.SelectedValue == "Envio a domicilio.")
            {
                precioTotal += 2500;
            }

            lblPrecioFinal.Text = "Precio Total: $" + precioTotal.ToString();
            Session["precioTotal"] = precioTotal;
        }
       
    }
}
