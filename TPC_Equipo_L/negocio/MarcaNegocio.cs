using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listarConSp()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spListarMarcas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Cod_Marca = (string)datos.Lector["Cod_Marca"];
                    aux.Nombre = (string)datos.Lector["Nombre_M"];
                    aux.ImagenURL = (string)datos.Lector["ImgURL_M"];

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
        public void agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (marca != null)
                {
                    datos.setearProcedimiento("spAgregarMarca");
                    datos.setearParametros("@Nombre_M", marca.Nombre);
                    datos.setearParametros("@ImgURL_M", marca.ImagenURL);
                    datos.setearParametros("@Estado_M", true);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (marca != null)
                {
                    datos.setearProcedimiento("spActualizarMarca");
                    datos.setearParametros("@Cod_Marca", marca.Cod_Marca);
                    datos.setearParametros("@Nombre_M", marca.Nombre);
                    datos.setearParametros("@ImgURL_M", marca.ImagenURL);
                    datos.setearParametros("@Estado_M", true);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminar(string cod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spEliminarMarca");
                datos.setearParametros("@Cod_Marca", cod);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { datos.cerrarConexion(); }
        }

    }
}
