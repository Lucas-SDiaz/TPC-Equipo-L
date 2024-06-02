using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarConSp()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spListarProductos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Descripcion = (string)datos.Lector["Descripcion_P"];
                    /// aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    // aux.Categoria.Id = (int)datos.Lector["Id"];
                    //aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    //aux.Marca.Id = (int)datos.Lector["Id"];
                    aux.Precio = (decimal)datos.Lector["PUnitario_P"];
                    aux.Stock = (int)datos.Lector["Stock_P"];
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

        /*
        public void agregar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES( @codigo,@nombre,@descripcion, @idMarca ,@idCategoria ,@idPrecio) ");
                datos.setearParametros("@codigo", art.CodigoArticulo);
                datos.setearParametros("@nombre", art.Nombre);
                datos.setearParametros("@descripcion", art.Descripcion);
                datos.setearParametros("@idMarca", art.Marca.Id);
                datos.setearParametros("@idCategoria", art.Categoria.Id);
                datos.setearParametros("@idPrecio", art.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally 
            { 
                datos.cerrarConexion(); 
            }
        }

        public void MaxId(Articulo art) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT MAX(Id) AS Id FROM ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    art.Id = (int)datos.Lector["Id"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}
        }

        public void agregarImagen(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES(IdArticulo, ImagenUrl) VALUES(@IdArticulo, @ImagenUrl)");
                datos.setearParametros("@IdArticulo", art.Id);
                datos.setearParametros("@ImagenUrl", art.Imagen.Url);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}
        }

        public void eliminar(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id =@id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally 
            { 
                datos.cerrarConexion(); 
            }

        }
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.setearParametros("@Codigo", articulo.CodigoArticulo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Descripcion", articulo.Descripcion);
                datos.setearParametros("@IdMarca", articulo.Marca.Id);
                datos.setearParametros("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametros("@Precio", articulo.Precio);
                datos.setearParametros("@Id", articulo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally { datos.cerrarConexion(); }
        }
        */
    }
}
