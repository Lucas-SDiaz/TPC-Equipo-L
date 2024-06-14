using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                datos.setearParametros("@user", usuario.User);
                datos.setearParametros("@pass", usuario.Password);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.Cod_Usuario = (string)datos.Lector["Cod_Usuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser_U"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
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
    }
}
