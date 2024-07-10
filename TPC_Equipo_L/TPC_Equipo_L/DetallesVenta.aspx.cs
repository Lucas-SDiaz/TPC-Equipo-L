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
    public partial class DetallesVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {

                    string codVenta = Request.QueryString["Cod_Venta"];

                    DetalleVentaNegocio detalleVentaNegocio = new DetalleVentaNegocio();
                    List<DetalleVenta> detallesVenta = detalleVentaNegocio.Listar(codVenta);

                    dgvDetalleVenta.DataSource = detallesVenta;
                    dgvDetalleVenta.DataBind();

                }
            }
        }
    }
}