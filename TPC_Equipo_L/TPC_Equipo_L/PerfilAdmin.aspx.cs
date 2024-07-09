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
                    Usuario usuario = (Usuario)Session["Usuario"];
                    usuario.Provincia = new Provincia();
                    usuario.Localidad = new Localidad();
                    usuario.Direccion = new Direccion();

                    if (direccionNegocio.GetDireccion(usuario.Direccion, usuario.Cod_Usuario) != null)
                    {
                        txtCalle.Text = usuario.Direccion.Calle;
                        txtNro.Text = Convert.ToString(usuario.Direccion.Nro);
                        txtCP.Text = Convert.ToString(usuario.Direccion.CP);
                        txtPiso.Text = Convert.ToString(usuario.Direccion.Piso);
                        txtDepto.Text = usuario.Direccion.Depto;
                    }
                    //usuario.Provincia.Nombre = ddlProvincia.SelectedItem.Text;
                    //usuario.Provincia.Id = int.Parse(ddlProvincia.SelectedItem.Value);
                    //usuario.Localidad.Nombre = ddlLocalidad.Text.ToString();
                    //usuario.Localidad.Id = ddlLocalidad.SelectedIndex;
                    string cod = usuario.Cod_Usuario;
                    Session["Cod_Usuario"] = cod;
                    usuario = negocio.BuscarUsuario(cod);
                    ddlLocalidad.SelectedValue = usuario.Localidad.Id.ToString();
                    ddlProvincia.SelectedValue = usuario.Provincia.Id.ToString();
                    negocio.cargarDDLProvincias(ddlProvincia);
                    negocio.cargarDDLLocalidades(ddlLocalidad, usuario.Provincia.Id);
                    txtEmail.Text = usuario.Correo;
                    txtPass.Text = usuario.Contrasenia;
                    txtNombre.Text = usuario.Nombre;
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    txtImagen.Text = usuario.ImagenURL;
                    txtApellido.Text = usuario.Apellido;
                    Session["TipoUsuario"] = usuario.TipoUsuario;
                }

            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            int prov = int.Parse(ddlProvincia.SelectedItem.Value);
            List<Localidad> Localidades = negocio.listarLocalidades(prov);
            ddlLocalidad.DataSource = Localidades;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("-Localidades-", "0"));
        }

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
                usuario.Localidad.Id = ddlLocalidad.SelectedIndex;
                usuario.Provincia.Id = ddlProvincia.SelectedIndex;
                usuario.TipoUsuario = (TipoUsuario)Session["TipoUsuario"];
                if (direccionNegocio.GetDireccion(usuario.Direccion, usuario.Cod_Usuario) != null)
                {
                    usuario.Direccion.Calle = txtCalle.Text;
                    usuario.Direccion.Nro = int.Parse(txtNro.Text);
                    usuario.Direccion.CP = int.Parse(txtCP.Text);
                    usuario.Direccion.Piso = int.Parse(txtPiso.Text);
                    usuario.Direccion.Depto = txtDepto.Text;
                    direccionNegocio.Modificar(usuario.Direccion, usuario);
                }
                else
                {
                    usuario.Direccion.Calle = txtCalle.Text;
                    usuario.Direccion.Nro = int.Parse(txtNro.Text);
                    usuario.Direccion.CP = int.Parse(txtCP.Text);
                    usuario.Direccion.Piso = int.Parse(txtPiso.Text);
                    usuario.Direccion.Depto = txtDepto.Text;
                    usuario.Direccion.ID = direccionNegocio.Agregar(usuario.Direccion, usuario);
                }
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
            catch (Exception)
            {

                throw;
            }

        }
    }
}