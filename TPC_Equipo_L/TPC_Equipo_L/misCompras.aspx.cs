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
    public partial class misCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] != null)
            {

                VentaNegocio ventaNegocio = new VentaNegocio();
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["usuario"];
                Session.Add("venta", ventaNegocio.listarConSp(usuario.Cod_Usuario));
                dgvCompras.DataSource = Session["venta"];
                dgvCompras.DataBind();

            }
        }

        protected void dgvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codV = dgvCompras.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarVenta.aspx?codV=" + codV);
        }

        protected void dgvCompras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el valor del MetodoPago de la fila actual
                string metodoPago = DataBinder.Eval(e.Row.DataItem, "MetodoPago").ToString();

                // Encontrar el LinkButton de selección (CARGAR) y deshabilitarlo si el MetodoPago no es "transferencia bancaria"
                if (metodoPago != "Transferencia Bancaria")
                {
                    LinkButton selectButton = (LinkButton)e.Row.Cells[8].Controls[0]; // Asumiendo que la columna CommandField es la octava columna (index 7)
                    selectButton.Enabled = false;
                    selectButton.CssClass = " disabled"; // Añadir clase CSS para estilo deshabilitado si es necesario
                    selectButton.Text = "-";
                }
            }
        }
    }
}