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
            List<Venta> venta = (List<Venta>)Session["venta"];
            VentaNegocio ventaNegocio = new VentaNegocio();
            Session.Add("venta", ventaNegocio.listarAdminConSp());
            dgvVentas.DataSource = Session["venta"];
            dgvVentas.DataBind();

        }

        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codV = dgvVentas.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarVentaS.aspx?codV=" + codV);
        }

        protected void dgvVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el valor del MetodoPago de la fila actual
                string metodoEnvio = DataBinder.Eval(e.Row.DataItem, "MetodoEnvio").ToString();

                // Encontrar el LinkButton de selección (CARGAR) y deshabilitarlo si el MetodoPago no es "transferencia bancaria"
                if (metodoEnvio != "Envio a domicilio.")
                {
                    LinkButton selectButton = (LinkButton)e.Row.Cells[10].Controls[0];
                    selectButton.Enabled = false;
                    selectButton.CssClass = " disabled"; // Añadir clase CSS para estilo deshabilitado si es necesario
                    selectButton.Text = "-";
                }
            }
        }
    }
}