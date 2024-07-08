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
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                negocio.cargarDDLProvincias(ddlProvincia);
                if (Session["Usuario"] == null || ((Usuario)Session["Usuario"]).TipoUsuario == TipoUsuario.NORMAL)
                {
                    Session.Add("error", "Error! Usted No tiene permisos para acceder");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    Provincia provincia = new Provincia();
                    Localidad localidad = new Localidad();
                    usuario.Direccion = new Direccion();

                    usuario.Direccion.Calle = txtCalle.Text;
                    usuario.Direccion.Nro = int.Parse(txtNro.Text);
                    usuario.Direccion.CP = int.Parse(txtCP.Text);
                    usuario.Direccion.Piso = int.Parse(txtPiso.Text);
                    usuario.Direccion.Depto = txtDepto.Text;
                    provincia.Nombre = ddlProvincia.SelectedItem.Text;
                    provincia.Id = int.Parse(ddlProvincia.SelectedItem.Value);
                    localidad.Nombre = ddlLocalidad.Text.ToString();
                    localidad.Id = ddlLocalidad.SelectedIndex;
                    usuario.Provincia = provincia;
                    usuario.Localidad = localidad;
                    string cod = usuario.Cod_Usuario;
                    Session["Cod_Usuario"] = cod;
                    usuario = negocio.BuscarUsuario(cod);
                    txtEmail.Text = usuario.Correo;
                    txtPass.Text = usuario.Contrasenia;
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;

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
            Usuario usuario = new Usuario();
            usuario.Localidad = new Localidad();
            usuario.Direccion = new Direccion();
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
            usuario.Direccion.Calle = txtCalle.Text;
            usuario.Direccion.Nro = int.Parse(txtNro.Text);
            usuario.Direccion.CP = int.Parse(txtCP.Text);
            usuario.Direccion.Piso = int.Parse(txtPiso.Text);
            usuario.Direccion.Depto = txtDepto.Text;

            //usuarioNegocio.ModificarUsuario(usuario);
            //direccionNegocio.Modificar(usuario.Direccion);
        }
    }
}