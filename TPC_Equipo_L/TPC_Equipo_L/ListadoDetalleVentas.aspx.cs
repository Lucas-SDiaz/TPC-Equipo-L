using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class ListadoDetalleVentas : System.Web.UI.Page
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
            

            dgvDetalleVentas.DataSource = ventas;
            dgvDetalleVentas.DataBind();
        }

        protected void dgvDetalleVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvDetalleVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalleVenta")
            {
                int codVenta = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"DetallesCompra.aspx?Cod_Venta={codVenta}");
            }
        }
    }
}