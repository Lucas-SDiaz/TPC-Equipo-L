using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public UsuarioNegocio() { }
        public bool Logear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Cod_Usuario, Nombre_U, TipoUser_U From USUARIOS Where Correo_U = @user AND Contrasenia_U = @pass");
                datos.setearParametros("@user", usuario.Correo);
                datos.setearParametros("@pass", usuario.Contrasenia);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.Cod_Usuario = (string)datos.Lector["Cod_Usuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    //usuario.TipoUsuario = (int)(datos.Lector["TipoUser_U"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // public void registrarUsuario(Usuario usuario)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearConsulta();
        //        datos.setearParametros();
        //        datos.setearParametros();
        //        datos.setearParametros();
        //        datos.setearParametros();
        //        datos.setearParametros();
        //        datos.setearParametros();
        //        datos.ejecutarAccion();
        //        datos.cerrarConexion();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally 
        //    { 
        //        datos.cerrarConexion();
        //    }
        //}
        public void cargarDDL(DropDownList list, string query, string text, string value)
        {
            AccesoDatos datos = new AccesoDatos();
            list.DataSource = datos.cargarControl(query);
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataBind();
        }
        public void cargarDDLProvincias(DropDownList list)
        {
            cargarDDL(list, "SELECT * FROM PROVINCIAS", "Provincia", "ID");
            list.Items.Insert(0, new ListItem("-Provincias-", "0"));
        }


        public List<string> listarLocalidades(int prov)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT L.Localidad FROM Localidades L WHERE L.ID_Provincia = @ID_Provincia");
                datos.setearParametros("@ID_Provincia", prov);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    string localidad = (string)datos.Lector["Localidad"];
                    lista.Add(localidad);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
