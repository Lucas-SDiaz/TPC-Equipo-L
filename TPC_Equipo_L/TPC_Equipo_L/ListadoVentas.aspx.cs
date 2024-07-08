﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class ListadoVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Venta> venta = (List<Venta>)Session["venta"];
            VentaNegocio ventaNegocio = new VentaNegocio();
            venta = ventaNegocio.listarAdminConSp();
            dgvVentas.DataSource = venta;
            dgvVentas.DataBind();

        }
    }
}