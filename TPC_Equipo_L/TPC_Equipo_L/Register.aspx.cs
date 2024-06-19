using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_L
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;                
                negocio.cargarDDLProvincias(ddlProvincia);
                
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string nombreUsuario = txtNombreUsuario.Text;
            string email = txtEmail.Text;
            string emailRep = txtEmailRep.Text;
            string provincia = ddlProvincia.SelectedValue;
            string localidad = ddlLocalidad.SelectedValue;
            string contrasenia = txtPass.Text;



           
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            int prov = int.Parse(ddlProvincia.SelectedItem.Value);
            List<string> Localidades = negocio.listarLocalidades(prov);
            ddlLocalidad.DataSource = Localidades;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("-Localidades-", "0"));

        }
    }
}