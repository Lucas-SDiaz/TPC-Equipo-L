using dominio;
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
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario nuevo = new Usuario();
            Direccion direccion = new Direccion();
            Provincia prov = new Provincia();   
            Localidad localidad = new Localidad();   
            EmailService emailService = new EmailService();
            nuevo.Correo = txtEmail.Text;
            nuevo.Contrasenia = txtPass.Text;
            nuevo.Nombre = txtNombre.Text;
            nuevo.Apellido = txtApellido.Text;
            direccion.Calle = txtCalle.Text;
            direccion.Nro = txtNro.Text;
            direccion.CP = txtCP.Text;
            prov.Nombre = ddlProvincia.SelectedItem.ToString();
            prov.Id = int.Parse(ddlProvincia.Text);
            localidad.Nombre = ddlLocalidad.Text.ToString();
            localidad.Id = ddlLocalidad.SelectedIndex; 
            nuevo.Provincia = prov;
            nuevo.Localidad = localidad;
            nuevo.Direccion = direccion;
            //string nombreUsuario = txtNombreUsuario.Text;

            negocio.registrarUsuario(nuevo);

            try
            {
                if(txtNombre.Text.Trim() == string.Empty)
                {
                    lblMensaje.Text = "Tiene que escribir un nombre";
                    lblMensaje.CssClass = "alert alert-danger";
                }else if(txtApellido.Text.Trim() == string.Empty)
                {
                    lblMensaje.Text = "Tiene que escribir un apellido";
                    lblMensaje.CssClass = "alert alert-danger";
                }else if(txtEmail.Text.Trim() == string.Empty)
                {
                    lblMensaje.Text = "Tiene que escribir un Email";
                    lblMensaje.CssClass = "alert alert-danger";
                }
                else if(txtEmailRep.Text.Trim() == string.Empty)
                {
                    lblMensaje.Text = "Tiene que repetir el Email";
                    lblMensaje.CssClass = "alert alert-danger";
                }else if(txtPass.Text.Trim() == string.Empty)
                {
                    lblMensaje.Text = "Tiene que escribir una contraseña";
                    lblMensaje.CssClass = "alert alert-danger";
                }
                else if(txtPassRep.Text.Trim() == string.Empty)
                {
                    lblMensaje.Text = "Tiene que repetir la contraseña";
                    lblMensaje.CssClass = "alert alert-danger";
                }
                else if(txtEmail.Text == txtEmailRep.Text && txtPass.Text == txtPassRep.Text)
                {
                    //nuevo.Cod_Usuario = negocio.registrarUsuario(nuevo);
                    emailService.armarCorreo(nuevo.Correo,"Bienvenido a Supermercado", nuevo);
                    emailService.enviarMail();
                    Session["usuario"] = nuevo;
                    Response.Redirect("Default.aspx", false);
                }

            }
            catch (Exception)
            {

                throw;
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
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void txtEmailRep_TextChanged(object sender, EventArgs e)
        {
            if (txtEmailRep.Text.Trim() != txtEmail.Text.Trim())
            {
                lblErrorMail.Text = "No coinciden los Mails";
                lblErrorMail.CssClass = "text-danger";
            }
            else
            {
                lblErrorMail.Text = string.Empty; lblErrorMail.CssClass = string.Empty;
            }
        }

        protected void txtPassRep_TextChanged(object sender, EventArgs e)
        {
            if(txtPass.Text.Trim() != txtPassRep.Text.Trim())
            {
                lblErrorPass.Text = "No coinciden las contraseñas";
                lblErrorPass.CssClass = "text-danger";
            }
            else
            {
                lblErrorPass.Text = string.Empty; lblErrorPass.CssClass = string.Empty;
            }
        }



    }

}