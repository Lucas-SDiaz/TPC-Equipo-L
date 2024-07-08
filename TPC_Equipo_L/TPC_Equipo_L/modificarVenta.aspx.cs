using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class modificarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codV;
            VentaNegocio negocio = new VentaNegocio();
            if (!IsPostBack)
            {
                if (Request.QueryString["codV"] != null)
                {
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                    codV = Request.QueryString["codV"].ToString();
                    List<Venta> temp = (List<Venta>)Session["venta"];
                    Venta selected = temp.Find(x => x.Cod_Venta == int.Parse(codV));

                    selected.Cod_Venta = int.Parse(codV);
                    txtComprobante.Text = selected.IdPago;

                }
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string codV;
            try
            {
                VentaNegocio negocio = new VentaNegocio();
                codV = Request.QueryString["codV"].ToString();
                List<Venta> temp = (List<Venta>)Session["venta"];
                Venta selected = temp.Find(x => x.Cod_Venta == int.Parse(codV));



                if (selected != null &&  txtComprobante.Text.Trim() != string.Empty )
                {
                    selected.IdPago = txtComprobante.Text.Trim();
                    negocio.modificarPago(selected);

                    lblMensaje.Text = "Se actualizo el nro de pago exitosamente.";
                    lblMensaje.CssClass = "alert alert-success";

                    Response.Redirect("misCompras.aspx");

                }
                else
                {
                    lblMensaje.Text = "Tiene que llenar todos los campos";
                    lblMensaje.CssClass = "alert alert-danger";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("misCompras.aspx");
        }
    }
}