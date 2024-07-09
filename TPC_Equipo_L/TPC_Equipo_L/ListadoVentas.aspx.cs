using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class ListadoVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || ((Usuario)Session["Usuario"]).TipoUsuario == TipoUsuario.NORMAL)
            {
                Session.Add("error", "Error! Usted No tiene permisos para acceder");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                CargarDatosGrid();
            }
        }

        private void CargarDatosGrid()
        {
            VentaNegocio ventaNegocio = new VentaNegocio();
            List<Venta> ventas = ventaNegocio.listarAdminConSp();
            Session["venta"] = ventas;
            dgvVentas.DataSource = ventas;
            dgvVentas.DataBind();
        }

        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el código de venta seleccionado
            int codVenta = Convert.ToInt32(dgvVentas.SelectedDataKey.Value);

            // Redireccionar a la página para modificar la venta
            Response.Redirect("modificarVentaS.aspx?codV=" + codVenta);
        }

        protected void dgvVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el DropDownList de Estado Compra de la fila actual
                DropDownList ddlEstadoCompra = (DropDownList)e.Row.FindControl("ddlEstadoCompra");

                // Obtener el valor actual del estado desde los datos
                string estadoActual = DataBinder.Eval(e.Row.DataItem, "EstadoVenta").ToString();

                // Establecer el valor seleccionado en el DropDownList
                ddlEstadoCompra.SelectedValue = estadoActual;


                // Obtener el valor del MetodoPago de la fila actual
                string metodoPago = DataBinder.Eval(e.Row.DataItem, "MetodoPago").ToString();

                string metodoEnvio = DataBinder.Eval(e.Row.DataItem, "MetodoEnvio").ToString();

                // Encontrar el LinkButton de selección (CARGAR) y deshabilitarlo si el MetodoPago no es "transferencia bancaria"
                if (metodoPago != "Transferencia Bancaria")
                {
                    LinkButton selectButton = (LinkButton)e.Row.Cells[10].Controls[0]; // Asumiendo que la columna CommandField es la octava columna (index 7)
                    selectButton.Enabled = false;
                    selectButton.CssClass = " disabled"; // Añadir clase CSS para estilo deshabilitado si es necesario
                    selectButton.Text = "-";
                }
                if (metodoPago == "Efectivo" && metodoEnvio == "Envio a domicilio.")
                {
                    ddlEstadoCompra.Items.Add(new ListItem("Solicitado", "Solicitado"));
                    ddlEstadoCompra.Items.Add(new ListItem("En Camino", "En Camino"));
                    //ddlEstadoCompra.Items.Add(new ListItem("Disponible Retiro", "Disponible Retiro"));
                    ddlEstadoCompra.Items.Add(new ListItem("Entregado", "Entregado"));
                    //ddlEstadoCompra.Items.Add(new ListItem("Pendiente Pago", "Pendiente Pago"));
                }
                if (metodoPago == "Efectivo" && metodoEnvio == "Retiro en el local")
                {
                    ddlEstadoCompra.Items.Add(new ListItem("Solicitado", "Solicitado"));
                    //ddlEstadoCompra.Items.Add(new ListItem("En Camino", "En Camino"));
                    ddlEstadoCompra.Items.Add(new ListItem("Disponible Retiro", "Disponible Retiro"));
                    ddlEstadoCompra.Items.Add(new ListItem("Entregado", "Entregado"));

                    //ddlEstadoCompra.Items.Add(new ListItem("Pendiente Pago", "Pendiente Pago"));
                }
                if (metodoPago == "Transferencia Bancaria" && metodoEnvio == "Retiro en el local")
                {
                    ddlEstadoCompra.Items.Add(new ListItem("Solicitado", "Solicitado"));

                    ddlEstadoCompra.Items.Add(new ListItem("Pendiente Pago", "Pendiente Pago"));
                    //ddlEstadoCompra.Items.Add(new ListItem("En Camino", "En Camino"));
                    ddlEstadoCompra.Items.Add(new ListItem("Disponible Retiro", "Disponible Retiro"));
                    ddlEstadoCompra.Items.Add(new ListItem("Entregado", "Entregado"));

                }
                if (metodoPago == "Transferencia Bancaria" && metodoEnvio == "Envio a domicilio.")
                {
                    ddlEstadoCompra.Items.Add(new ListItem("Solicitado", "Solicitado"));

                    ddlEstadoCompra.Items.Add(new ListItem("Pendiente Pago", "Pendiente Pago"));
                    ddlEstadoCompra.Items.Add(new ListItem("En Camino", "En Camino"));
                    //ddlEstadoCompra.Items.Add(new ListItem("Disponible Retiro", "Disponible Retiro"));
                    ddlEstadoCompra.Items.Add(new ListItem("Entregado", "Entregado"));

                }
                estadoActual = DataBinder.Eval(e.Row.DataItem, "EstadoVenta").ToString();
                ddlEstadoCompra.SelectedValue = estadoActual;



            }
        }

        protected void ddlEstadoCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEstadoCompra = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstadoCompra.NamingContainer;
            List<Venta> temp = (List<Venta>)Session["venta"];
            int codVenta = Convert.ToInt32(dgvVentas.DataKeys[row.RowIndex].Value);
            Venta selected = temp.Find(x => x.Cod_Venta == codVenta);


            string nuevoEstado = ddlEstadoCompra.SelectedValue;

            VentaNegocio ventaNegocio = new VentaNegocio();
            ventaNegocio.ActualizarEstadoVenta(selected, nuevoEstado);
            CargarDatosGrid();
        }
    }
}