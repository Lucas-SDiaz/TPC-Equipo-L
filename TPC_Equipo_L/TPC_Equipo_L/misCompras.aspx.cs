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
            if (!IsPostBack)
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
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in dgvCompras.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation(row.UniqueID + "$ctl00");
                }
            }

            base.RenderControl(writer);
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
                LinkButton selectButton = e.Row.FindControl("btnCargarComprobante") as LinkButton; // Suponiendo que el ID de tu LinkButton es "lnkSelect"

                if (selectButton != null)
                {
                    if (metodoPago != "Transferencia Bancaria")
                    {
                        selectButton.Enabled = false;
                       selectButton.Text = "-";
                    }
                    else
                    {
                  
                    }
                }
            }
        }

        protected void dgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                // Obtener el valor de Cod_Venta del CommandArgument
                string codVenta = e.CommandArgument.ToString();

                // Lógica para manejar la visualización de los detalles
                // Redirigir a una página de detalles, mostrar un modal, etc.
                Response.Redirect($"DetallesCompra.aspx?Cod_Venta={codVenta}");
            }
            if (e.CommandName == "CargarComprobante")
            {
                // Obtener el valor de Cod_Venta del CommandArgument
                string codVenta = e.CommandArgument.ToString();

                // Lógica para manejar la visualización de los detalles
                // Redirigir a una página de detalles, mostrar un modal, etc.
                Response.Redirect($"modificarVenta.aspx?codV={codVenta}");
            }

        }
    }
}