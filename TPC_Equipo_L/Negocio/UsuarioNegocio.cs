using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
                while (datos.Lector.Read())
                {
                    usuario.Cod_Usuario = datos.Lector["Cod_Usuario"].ToString();
                    usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser_U"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
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

        public string registrarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spRegister");
                datos.setearParametros("@Correo_U", usuario.Correo);
                datos.setearParametros("@Contrasenia_U", usuario.Contrasenia);
                datos.setearParametros("@Nombre_U", usuario.Nombre);
                datos.setearParametros("@Apellido_U", usuario.Apellido);
                datos.setearParametros("@TipoUser_U", 1);
                datos.setearParametros("@Telefono_U", usuario.Telefono);
                datos.setearParametros("Estado_U", true);
                return datos.ejecutarAccionScalar();
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
        public void cargarDDL(DropDownList list, string query, string text, string value, string value2 = "")
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

        public void cargarDDLLocalidades(DropDownList list, int idProvincia)
        {
            cargarDDL(list, "SELECT * FROM LOCALIDADES WHERE ID_Provincia = '" + idProvincia + "'", "Localidad", "ID", "ID_Provincia");
            list.Items.Insert(0, new ListItem("-Localidades-", "0"));

        }


        public List<Localidad> listarLocalidades(int prov)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            List<Localidad> localidades = new List<Localidad>();
            try
            {
                datos.setearConsulta("SELECT L.Localidad, L.ID FROM Localidades L WHERE L.ID_Provincia = @ID_Provincia");
                datos.setearParametros("@ID_Provincia", prov);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Localidad localidad = new Localidad();
                    localidad.localidad = (string)datos.Lector["Localidad"];
                    localidad.Id = (int)datos.Lector["ID"];
                    localidades.Add(localidad);
                }

                return localidades;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar las localidades: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario BuscarUsuario(string cod)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            try
            {
                datos.setearConsulta("SELECT usu.NombreUsuario_U, usu.Nombre_U, usu.Apellido_U, usu.Correo_U, usu.Contrasenia_U, usu.ImgURL_U, usu.TipoUser_U, usu.Telefono_U " +
                    "FROM USUARIOS AS usu " +
                    "WHERE usu.Cod_Usuario = @Cod_Usuario");
                datos.setearParametros("@Cod_Usuario", cod);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Cod_Usuario = cod;
                    usuario.NombreUsuario = datos.Lector["NombreUsuario_U"] != DBNull.Value ? (string)datos.Lector["NombreUsuario_U"] : null;
                    usuario.Nombre = datos.Lector["Nombre_U"] != DBNull.Value ? (string)datos.Lector["Nombre_U"] : null;
                    usuario.Apellido = datos.Lector["Apellido_U"] != DBNull.Value ? (string)datos.Lector["Apellido_U"] : null;
                    usuario.Correo = datos.Lector["Correo_U"] != DBNull.Value ? (string)datos.Lector["Correo_U"] : null;
                    usuario.Contrasenia = datos.Lector["Contrasenia_U"] != DBNull.Value ? (string)datos.Lector["Contrasenia_U"] : null;
                    usuario.ImagenURL = datos.Lector["ImgURL_U"] != DBNull.Value ? (string)datos.Lector["ImgURL_U"] : null;
                    usuario.TipoUsuario = datos.Lector["TipoUser_U"] != DBNull.Value ? (TipoUsuario)datos.Lector["TipoUser_U"] : TipoUsuario.NORMAL;
                    usuario.Telefono = datos.Lector["Telefono_U"] != DBNull.Value ? (int)datos.Lector["Telefono_U"] : 0;
                    usuario.Estado = true;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuario: " + ex.Message);
            }
        }


        public bool ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (usuario != null)
                {
                    datos.setearConsulta("UPDATE Usuarios SET NombreUsuario_U = @NombreUsuario_U, Nombre_U = @Nombre_U, Apellido_U = @Apellido_U, Correo_U = @Correo_U, Contrasenia_U = @Contrasenia_U, ImgURL_U = @ImgURL_U, Estado_U = @Estado_U, TipoUser_U = @TipoUser_U, Telefono_U = @Telefono_U WHERE Cod_Usuario = @Cod_Usuario");
                    datos.setearParametros("@Cod_Usuario", usuario.Cod_Usuario);
                    datos.setearParametros("@NombreUsuario_U", usuario.NombreUsuario);
                    datos.setearParametros("@Nombre_U", usuario.Nombre);
                    datos.setearParametros("@Apellido_U", usuario.Apellido);
                    datos.setearParametros("@Correo_U", usuario.Correo);
                    datos.setearParametros("@Contrasenia_U", usuario.Contrasenia);
                   // datos.setearParametros("@Cod_Localidad_U", usuario.Localidad.Id);
                    datos.setearParametros("@ImgURL_U", usuario.ImagenURL);
                    datos.setearParametros("@Estado_U", true);
                    datos.setearParametros("@Telefono_U", usuario.Telefono);
                    if (usuario.TipoUsuario == TipoUsuario.ADMIN)
                    {
                        datos.setearParametros("@TipoUser_U", 2);
                    }
                    else
                    {
                        datos.setearParametros("@TipoUser_U", 1);
                    }
                    datos.ejecutarAccion();
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

        public List<Venta> listarClientesConSp()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearProcedimiento("ListarClientes");
                datos.setearConsulta("SELECT Nombre_U, Apellido_U, Correo_U as 'Email', Telefono_U, COUNT(Cod_Venta) AS 'Cantidad de compras' FROM Usuarios INNER JOIN Ventas ON Cod_Usuario_V = Cod_Usuario WHERE Baja_V = 1 GROUP BY Nombre_U, Apellido_U, Correo_U, Telefono_U ORDER BY Apellido_U ASC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    Usuario usuario = new Usuario();

                    aux.Usuario = new Usuario();

                    aux.Usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    aux.Usuario.Apellido = (string)datos.Lector["Apellido_U"];
                    aux.Usuario.Correo = (string)datos.Lector["Email"];
                    aux.Usuario.Telefono = (int)datos.Lector["Telefono_U"]; 
                    aux.Cod_Venta = (int)(datos.Lector["Cantidad de compras"]);
                    lista.Add(aux);
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
