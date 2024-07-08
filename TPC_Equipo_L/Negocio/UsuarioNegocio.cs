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

        public void cargarDDLLocalidades(DropDownList list)
        {
            cargarDDL(list, "SELECT * FROM LOCALIDADES", "Localidad", "ID");
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
                while(datos.Lector.Read())
                {
                    string loc = (string)datos.Lector["Localidad"];
                    int id = (int)datos.Lector["ID"];
                    Localidad localidad = new Localidad();
                    localidad.Nombre = loc;
                    localidad.Id = id;
                    localidades.Add(localidad);
                }

                return localidades;
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

        public Usuario BuscarUsuario(string cod)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            usuario.Localidad = new Localidad();
            usuario.Direccion = new Direccion();
            usuario.Provincia = new Provincia();
            try
            {
                datos.setearConsulta("SELECT usu.NombreUsuario_U, usu.Nombre_U, usu.Apellido_U, usu.Correo_U, usu.Contrasenia_U, usu.Cod_Localidad_U, usu.ImgURL_U, usu.TipoUser_U, pro.ID " +
                    "FROM USUARIOS AS usu " +
                    "INNER JOIN Localidades AS loc ON Cod_Localidad_U = loc.ID " +
                    "INNER JOIN Provincias AS pro ON loc.ID_Provincia = pro.ID " +
                    "WHERE Cod_Usuario = @Cod_Usuario");
                datos.setearParametros("@Cod_Usuario", cod);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.Cod_Usuario = cod;
                    usuario.NombreUsuario = (string)datos.Lector["NombreUsuario_U"];
                    usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    usuario.Apellido = (string)datos.Lector["Apellido_U"];
                    usuario.Correo = (string)datos.Lector["Correo_U"];
                    usuario.Contrasenia = (string)datos.Lector["Contrasenia_U"];
                    usuario.Localidad.Id = (int)datos.Lector["Cod_Localidad_U"];
                    usuario.ImagenURL = (string)datos.Lector["ImgURL_U"];
                    usuario.TipoUsuario = (TipoUsuario)datos.Lector["TipoUser_U"];
                    usuario.Provincia.Id = (int)datos.Lector["ID"];
                    usuario.Estado = true;
                }
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (usuario != null)
                {
                    datos.setearProcedimiento("spActualizarUsuario");
                    datos.setearParametros("@Cod_Usuario", usuario.Cod_Usuario);
                    datos.setearParametros("@NombreUsuario_U", usuario.NombreUsuario);
                    datos.setearParametros("@Nombre_U", usuario.Nombre);
                    datos.setearParametros("@Apellido_U", usuario.Apellido);
                    datos.setearParametros("@Correo_U", usuario.Correo);
                    datos.setearParametros("@Contrasenia_U", usuario.Contrasenia);
                    datos.setearParametros("@Cod_Localidad_U", usuario.Localidad.Id);
                    datos.setearParametros("@ImgURL_U", usuario.ImagenURL);
                    datos.setearParametros("@Estado_U", true);
                    datos.setearParametros("@TipoUser_U", usuario.TipoUsuario);
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
                datos.setearConsulta("SELECT Nombre_U, Apellido_U, Correo_U as 'Email', COUNT(Cod_Venta) AS 'Cantidad de compras' FROM Usuarios" +
                                     " INNER JOIN Ventas ON Cod_Usuario_V = Cod_Usuario WHERE Baja_V = 1" +
                                     "GROUP BY Nombre_U, Apellido_U, Correo_U ORDER BY Apellido_U ASC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    Usuario usuario = new Usuario();

                    aux.Usuario = new Usuario();

                    aux.Usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    aux.Usuario.Apellido = (string)datos.Lector["Apellido_U"];
                    aux.Usuario.Correo = (string)datos.Lector["Email"];
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
