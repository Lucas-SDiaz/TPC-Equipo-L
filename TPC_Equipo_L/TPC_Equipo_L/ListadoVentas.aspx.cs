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


            string estadoFiltrado = ddlEstadoFiltro.SelectedValue;
            string metodoPagoFiltrado = ddlMetodoPagoFiltro.SelectedValue;

            VentaNegocio ventaNegocio = new VentaNegocio();
            List<Venta> ventas = ventaNegocio.listarAdminFiltros(estadoFiltrado, metodoPagoFiltrado);
            Session["venta"] = ventas;
            dgvVentas.DataSource = ventas;
            dgvVentas.DataBind();

        }

        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
   
            int codVenta = Convert.ToInt32(dgvVentas.SelectedDataKey.Value);

            
            Response.Redirect("modificarVentaS.aspx?codV=" + codVenta);
        }

        protected void dgvVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
     
                DropDownList ddlEstadoCompra = (DropDownList)e.Row.FindControl("ddlEstadoCompra");

               
                string estadoActual = DataBinder.Eval(e.Row.DataItem, "EstadoVenta").ToString();

         
                ddlEstadoCompra.SelectedValue = estadoActual;


                string metodoPago = DataBinder.Eval(e.Row.DataItem, "MetodoPago").ToString();

                string metodoEnvio = DataBinder.Eval(e.Row.DataItem, "MetodoEnvio").ToString();

       
                if (metodoEnvio != "Envio a domicilio.")
                {
                    LinkButton selectButton = (LinkButton)e.Row.Cells[10].Controls[0]; 
                    selectButton.Enabled = false;
                    selectButton.CssClass = " disabled"; 
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



        protected void ddlEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosGrid();
        }

        protected void ddlMetodoPagoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosGrid();
        }
    }
}