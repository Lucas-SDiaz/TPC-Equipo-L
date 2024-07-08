using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class modificarVenta : System.Web.UI.Page
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
                        txtComprobante.Text = selected.IdPago;
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
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

                if (selected != null && !string.IsNullOrWhiteSpace(txtComprobante.Text))
                {
                    try
                    {
                        VentaNegocio negocio = new VentaNegocio();
                        selected.IdPago = txtComprobante.Text.Trim();
                        negocio.modificarPago(selected);

                        lblMensaje.Text = "Se actualizó el número de pago exitosamente.";
                        lblMensaje.CssClass = "alert alert-success";

                        // Redireccionar después de un pequeño retraso para permitir que el mensaje sea visible
                        ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", "setTimeout(function(){ window.location.href = 'misCompras.aspx'; }, 2000);", true);
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
            Response.Redirect("misCompras.aspx");
        }
    }
}
