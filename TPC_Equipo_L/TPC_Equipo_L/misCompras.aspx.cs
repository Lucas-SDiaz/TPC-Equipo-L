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
                List<Venta> venta = (List<Venta>)Session["venta"];
                VentaNegocio ventaNegocio = new VentaNegocio();
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["usuario"];
                venta = ventaNegocio.listarConSp(usuario.Cod_Usuario);
                dgvCompras.DataSource = venta;
                dgvCompras.DataBind();
            }
        }

        
    }
}