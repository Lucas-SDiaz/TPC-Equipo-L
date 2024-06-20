using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class listarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Session.Add("listaMarca", negocio.listarConSp());
            dgvMarca.DataSource = Session["listaMarca"];
            dgvMarca.DataBind();
        }

        protected void dgvMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codM = dgvMarca.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarMarca.aspx?codM=" + codM);
        }

        protected void dgvMarca_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                var codP = dgvMarca.DataKeys[e.RowIndex].Value.ToString();
                if (negocio.eliminar(codP))
                {
                    lblMensaje.Text = "¡Se Eliminó correctamente!";
                    lblMensaje.CssClass = "alert alert-success";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                    "setTimeout(function() { window.location.replace('listarMarca.aspx') }, 3000);", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}