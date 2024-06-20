using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> listarConSp()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spListarCategorias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Cod_Categoria = (string)datos.Lector["Cod_Categoria"];
                    aux.Nombre = (string)datos.Lector["Nombre_C"];
                    aux.ImagenURL = (string)datos.Lector["ImgURL_C"];

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

        public void agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if(categoria != null)
                {
                    datos.setearProcedimiento("spAgregarCategoria");
                    datos.setearParametros("@Nombre_C", categoria.Nombre);
                    datos.setearParametros("@ImgURL_C", categoria.ImagenURL);
                    datos.setearParametros("@Estado_C", true);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (categoria != null)
                {
                    datos.setearProcedimiento("spActualizarCategoria");
                    datos.setearParametros("@Cod_Categoria", categoria.Cod_Categoria);
                    datos.setearParametros("@Nombre_C", categoria.Nombre);
                    datos.setearParametros("@ImgURL_C", categoria.ImagenURL);
                    datos.setearParametros("@Estado_C", true);
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
                datos.setearProcedimiento("spEliminarCategoria");
                datos.setearParametros("@Cod_Categoria", cod);
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

