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
            Session.Add("listaCategoria", negocio.listarConSp());
            dgvCategoria.DataSource = Session["listaCategoria"];
            dgvCategoria.DataBind();
        }

        protected void dgvCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codC = dgvCategoria.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarCategoria.aspx?codC=" + codC);
        }

        protected void dgvCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                var codP = dgvCategoria.DataKeys[e.RowIndex].Value.ToString();
                if (negocio.eliminar(codP))
                {
                    lblMensaje.Text = "¡Se Eliminó correctamente!";
                    lblMensaje.CssClass = "alert alert-success";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                    "setTimeout(function() { window.location.replace('listarCategoria.aspx') }, 3000);", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}