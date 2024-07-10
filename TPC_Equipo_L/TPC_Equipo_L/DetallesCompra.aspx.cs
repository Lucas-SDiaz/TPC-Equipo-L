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
    public partial class DetallesCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {

                    // Obtener el codVenta de la URL
                    string codVenta = Request.QueryString["Cod_Venta"];

                    // Aquí puedes utilizar el codVenta como necesites
                    // Por ejemplo, cargar detalles de la venta basados en codVenta
                    DetalleVentaNegocio detalleVentaNegocio = new DetalleVentaNegocio();
                    List<DetalleVenta> detallesVenta = detalleVentaNegocio.Listar(codVenta);

                    // Asignar los detalles al GridView dgvDetalle
                    dgvDetalle.DataSource = detallesVenta;
                    dgvDetalle.DataBind();

                }
            }
        }

    }
}