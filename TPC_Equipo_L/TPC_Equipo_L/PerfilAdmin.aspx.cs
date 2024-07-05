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
    public partial class PerfilAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || ((Usuario)Session["Usuario"]).TipoUsuario == TipoUsuario.NORMAL)
            {
                Session.Add("error", "Error! Usted No tiene permisos para acceder");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                string cod = usuario.Cod_Usuario;
                usuario = negocio.BuscarUsuario(cod);
                txtEmail.Text = usuario.Correo;
                txtPass.Text = usuario.Contrasenia;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                
            }
        }
    }
}