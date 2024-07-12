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
            UsuarioNegocio negocio = new UsuarioNegocio();
            DireccionNegocio direccionNegocio = new DireccionNegocio();
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

                if (Session["Usuario"] == null || ((Usuario)Session["Usuario"]).TipoUsuario == TipoUsuario.NORMAL)
                {
                    Session.Add("error", "Error! Usted No tiene permisos para acceder");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {


                    // Busca el usuario usando el código proporcionado
                    Usuario usuarioBase = (Usuario)Session["Usuario"];

                    Usuario usuario = negocio.BuscarUsuario(usuarioBase.Cod_Usuario);
                    if (usuario == null)
                    {
                        Session.Add("error", "Error! Usuario no encontrado");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }

                    //ddlLocalidad.SelectedValue = usuario.Localidad.Id.ToString();
                    //ddlProvincia.SelectedValue = usuario.Provincia.Id.ToString();

                    txtEmail.Text = usuario.Correo;
                    txtPass.Text = usuario.Contrasenia;
                    txtNombre.Text = usuario.Nombre;
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    txtImagen.Text = usuario.ImagenURL;
                    txtApellido.Text = usuario.Apellido;

                    Session["Cod_Usuario"] = usuarioBase.Cod_Usuario;
                    Session["TipoUsuario"] = usuario.TipoUsuario;
                }
            }
        }

        //protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    UsuarioNegocio negocio = new UsuarioNegocio();
        //    int prov = int.Parse(ddlProvincia.SelectedItem.Value);
        //    List<Localidad> Localidades = negocio.listarLocalidades(prov);
        //    ddlLocalidad.DataSource = Localidades;
        //    ddlLocalidad.DataBind();
        //    ddlLocalidad.Items.Insert(0, new ListItem("-Localidades-", "0"));
        //}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Localidad = new Localidad();
                usuario.Direccion = new Direccion();
                usuario.Provincia = new Provincia();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                DireccionNegocio direccionNegocio = new DireccionNegocio();
                usuario.Cod_Usuario = Session["Cod_Usuario"].ToString();
                usuario.Correo = txtEmail.Text;
                usuario.Contrasenia = txtPass.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.NombreUsuario = txtNombreUsuario.Text;
                usuario.ImagenURL = txtImagen.Text;
                //usuario.Localidad.Id = ddlLocalidad.SelectedIndex;
                //usuario.Provincia.Id = ddlProvincia.SelectedIndex;
                usuario.TipoUsuario = (TipoUsuario)Session["TipoUsuario"];
                
                if (usuarioNegocio.ModificarUsuario(usuario))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                    "setTimeout(function() { window.location.replace('Dashboard.aspx') }, 3000);", true);
                    lblM.Text = "¡Se modifico con Exito!";
                    lblM.CssClass = "alert alert-success";
                }
                else
                {
                    lblM.Text = "Hubo un problema, contacte a soporte.";
                    lblM.CssClass = "alert alert-danger";
                }

            }
            catch (Exception ex)
            {
                // Manejar la excepción apropiadamente
                lblM.Text = "Ocurrió un error: " + ex.Message;
                lblM.CssClass = "alert alert-danger";
            }

        }
    }
}
