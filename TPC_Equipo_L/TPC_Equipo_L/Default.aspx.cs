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
    public partial class Default : System.Web.UI.Page
    {
        public List<Categoria> listaCategoria { get; set; }
        public List<Marca> listaMarca { get; set; }

        public List<Venta> listaVenta { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            listaCategoria = negocio.listarConSp();
            repCategorias.DataSource = listaCategoria;
            repCategorias.DataBind();

            MarcaNegocio negocio1 = new MarcaNegocio();
            listaMarca = negocio1.listarConSp();
            repMarcas.DataSource = listaMarca;
            repMarcas.DataBind();
           

        }
    }
}