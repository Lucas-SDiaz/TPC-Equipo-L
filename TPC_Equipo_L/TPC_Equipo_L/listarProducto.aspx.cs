﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_Equipo_L
{
    public partial class listarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Session.Add("listaProductos", negocio.listarConSp());
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codP = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("modificarProducto.aspx?codP=" + codP);
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataBind();
        }

        protected void dgvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                var codP = dgvProductos.DataKeys[e.RowIndex].Value.ToString();
                if (negocio.eliminar(codP))
                {
                    lblMensaje.Text = "¡Se Eliminó correctamente!";
                    lblMensaje.CssClass = "alert alert-success";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                    "setTimeout(function() { window.location.replace('listarProducto.aspx') }, 3000);", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}