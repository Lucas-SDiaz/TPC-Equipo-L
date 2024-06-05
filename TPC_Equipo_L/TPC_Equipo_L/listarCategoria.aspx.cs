using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class listarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Session.Add("listaCategoria", negocio.listarConSP());
            dgvCategoria.DataSource = Session["listaCategoria"];
            dgvCategoria.DataBind();
        }

        protected void dgvCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codC = dgvCategoria.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarCategoria.aspx?codC=" + codC);
        }

    }
}