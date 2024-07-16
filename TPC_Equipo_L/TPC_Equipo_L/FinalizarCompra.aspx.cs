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
            if (!IsPostBack)
            {

                Usuario usuario = (Usuario)Session["usuario"];
                DireccionNegocio direccionNegocio = new DireccionNegocio();
                if (usuario != null)
                {
                    direccionNegocio.cargarDDLDireccionesCompra(ddlDireccion, usuario);

                }


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
            venta.IdDireccion = direccionNegocio.Agregar(direccion, usuario);
            venta.FechaVenta = DateTime.Now;
            venta.Usuario = usuario;
            venta.MetodoPago = metodoPago;
            venta.MetodoEnvio = metodoEntrega;

            if (metodoPago == "Efectivo")
            {
                venta.IdPago = "-";
            }
            if (metodoEntrega == "Retiro en el local")
            {
                venta.NumSeguimiento = "-";
            }
            SqlMoney precioTotal = (SqlMoney)Session["precioTotal"];
            venta.MontoFinal = precioTotal;

            venta.Cod_Venta = int.Parse(negocio.agregarScalar(venta, usuario));

            // Guardar detalles de la venta en la base de datos
            List<Producto> carrito = (List<Producto>)Session["carrito"];
            ProductoNegocio productoNegocio = new ProductoNegocio();
            DetalleVentaNegocio detalleVentaNegocio = new DetalleVentaNegocio();

            foreach (Producto producto in carrito)
            {
                DetalleVenta detalleVenta = new DetalleVenta();

                detalleVenta.Cod_Prod = producto.CodigoProducto;
                detalleVenta.Cod_Venta = venta.Cod_Venta;
                // detalleVenta.Nombre = producto.Nombre;
                detalleVenta.Cantidad = producto.Cantidad;
                detalleVenta.PrecioUni = producto.Precio;

                detalleVentaNegocio.agregar(detalleVenta);
                productoNegocio.ModificarStock(producto);
            }

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

        protected void ddDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DireccionNegocio direccionNegocio = new DireccionNegocio();
            Usuario usuario = (Usuario)Session["Usuario"];
            List<Direccion> direccions = direccionNegocio.listarDirecciones(usuario);
            int ID = int.Parse(ddlDireccion.SelectedItem.Value);
            Direccion direccion = direccions.Find(x => x.ID == ID);

            Session["IDDireccion"] = direccion.ID;
            txtCalle.Text = direccion.Calle;
            txtNro.Text = Convert.ToString(direccion.Nro);
            txtCP.Text = Convert.ToString(direccion.CP);
            txtPiso.Text = Convert.ToString(direccion.Piso);
            txtDepto.Text = direccion.Depto;
        }
        protected bool IsDireccionCero()
        {
            if (ddlDireccion.SelectedItem != null && ddlDireccion.SelectedItem.Value == "0")
            {
                return true;
            }
            return false;
        }
    }
}
