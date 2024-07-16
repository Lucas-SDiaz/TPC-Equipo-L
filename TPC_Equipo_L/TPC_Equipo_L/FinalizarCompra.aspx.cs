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

                if (ddlDireccion.SelectedIndex > 0)
                {
                    CargarDatosDireccionSeleccionada();
                    BloquearCamposDireccion(true);
                }
                else
                {
                    LimpiarCamposDireccion();
                    BloquearCamposDireccion(false);
                }
            }
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
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

            Venta venta = new Venta();
            Direccion direccion = new Direccion();
            if (metodoEntrega == "Envio a domicilio." && CamposDireccionVacios())
            {
                lblMensajeError.Text = "Debe completar la calle, número y código postal.";
                lblMensajeError.Visible = true;
                return;
            }
            else
            {
                if (ddlDireccion.SelectedIndex == 0 && !CamposDireccionVacios())
                {
                    direccion.Calle = txtCalle.Text;
                    direccion.Nro = int.Parse(txtNro.Text);
                    direccion.CP = int.Parse(txtCP.Text);
                    if (!string.IsNullOrEmpty(txtPiso.Text))
                    {
                        direccion.Piso = int.Parse(txtPiso.Text);
                    }
                    else
                    {
                        direccion.Piso = 0;
                    }
                    if (!string.IsNullOrEmpty(txtDepto.Text))
                    {
                        direccion.Depto = txtDepto.Text;
                    }
                    else
                    {
                        direccion.Depto = "";
                    }

                    venta.IdDireccion = direccionNegocio.Agregar(direccion, usuario);
                }
                else if(metodoEntrega == "Envio a domicilio.")
                {
                    direccion = ObtenerDireccionSeleccionada();
                    venta.IdDireccion = direccion.ID;
                }
                else
                {
                    venta.IdDireccion = 0;
                }
            }

            

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

            List<Producto> carrito = (List<Producto>)Session["carrito"];
            ProductoNegocio productoNegocio = new ProductoNegocio();
            DetalleVentaNegocio detalleVentaNegocio = new DetalleVentaNegocio();

            foreach (Producto producto in carrito)
            {
                DetalleVenta detalleVenta = new DetalleVenta();

                detalleVenta.Cod_Prod = producto.CodigoProducto;
                detalleVenta.Cod_Venta = venta.Cod_Venta;
                detalleVenta.Cantidad = producto.Cantidad;
                detalleVenta.PrecioUni = producto.Precio;

                detalleVentaNegocio.agregar(detalleVenta);
                productoNegocio.ModificarStock(producto);
            }

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

        private void CargarDatosDireccionSeleccionada()
        {
            DireccionNegocio direccionNegocio = new DireccionNegocio();
            Usuario usuario = (Usuario)Session["usuario"];
            List<Direccion> direcciones = direccionNegocio.listarDirecciones(usuario);
            int ID = int.Parse(ddlDireccion.SelectedItem.Value);
            Direccion direccion = direcciones.Find(x => x.ID == ID);

            Session["IDDireccion"] = direccion.ID;
            txtCalle.Text = direccion.Calle;
            txtNro.Text = Convert.ToString(direccion.Nro);
            txtCP.Text = Convert.ToString(direccion.CP);
            txtPiso.Text = Convert.ToString(direccion.Piso);
            txtDepto.Text = direccion.Depto;
        }

        private void LimpiarCamposDireccion()
        {
            txtCalle.Text = string.Empty;
            txtNro.Text = string.Empty;
            txtCP.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtDepto.Text = string.Empty;
        }

        private void BloquearCamposDireccion(bool bloquear)
        {
            txtCalle.Enabled = !bloquear;
            txtNro.Enabled = !bloquear;
            txtCP.Enabled = !bloquear;
            txtPiso.Enabled = !bloquear;
            txtDepto.Enabled = !bloquear;
        }

        protected void ddDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDireccion.SelectedIndex > 0)
            {
                CargarDatosDireccionSeleccionada();
                BloquearCamposDireccion(true);
            }
            else
            {
                LimpiarCamposDireccion();
                BloquearCamposDireccion(false);
            }
        }
        private bool CamposDireccionVacios()
        {
            return string.IsNullOrEmpty(txtCalle.Text)
                && string.IsNullOrEmpty(txtNro.Text)
                && string.IsNullOrEmpty(txtCP.Text)
                && string.IsNullOrEmpty(txtPiso.Text)
                && string.IsNullOrEmpty(txtDepto.Text);
        }
        private bool CamposDireccionValidos()
        {
            // Validar que calle, número y código postal no estén vacíos
            return !string.IsNullOrEmpty(txtCalle.Text.Trim())
                && !string.IsNullOrEmpty(txtNro.Text.Trim())
                && !string.IsNullOrEmpty(txtCP.Text.Trim());
        }

        private Direccion ObtenerDireccionSeleccionada()
        {
            DireccionNegocio direccionNegocio = new DireccionNegocio();
            Usuario usuario = (Usuario)Session["usuario"];
            List<Direccion> direcciones = direccionNegocio.listarDirecciones(usuario);
            int ID = int.Parse(ddlDireccion.SelectedItem.Value);
            return direcciones.Find(x => x.ID == ID);
        }

    }
}
