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
    public partial class modificarVentaS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["codV"] != null)
                {
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    string codV = Request.QueryString["codV"].ToString();
                    List<Venta> temp = (List<Venta>)Session["venta"];
                    Venta selected = temp.Find(x => x.Cod_Venta == int.Parse(codV));

                    if (selected != null)
                    {
                        txtSeguimiento.Text = selected.NumSeguimiento;
                    }
                }
                else
                {
                    Response.Redirect("Dashboard.aspx");
                }

            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["codV"] != null)
            {
                string codV = Request.QueryString["codV"].ToString();
                List<Venta> temp = (List<Venta>)Session["venta"];
                Venta selected = temp.Find(x => x.Cod_Venta == int.Parse(codV));

                if (selected != null && !string.IsNullOrWhiteSpace(txtSeguimiento.Text))
                {
                    try
                    {
                        VentaNegocio negocio = new VentaNegocio();
                        selected.NumSeguimiento = txtSeguimiento.Text.Trim();
                        negocio.modificarNumSeguimiento(selected);

                        lblMensaje.Text = "Se actualizó el número de seguimiento exitosamente.";
                        lblMensaje.CssClass = "alert alert-success";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", "setTimeout(function(){ window.location.href = 'ListadoVentas.aspx'; }, 2000);", true);
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Ocurrió un error al actualizar: " + ex.Message;
                        lblMensaje.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    lblMensaje.Text = "Tiene que llenar todos los campos";
                    lblMensaje.CssClass = "alert alert-danger";
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoVentas.aspx");
        }
    }
}