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
using System.Web.UI.WebControls;
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

        public void cargarDDL(DropDownList list, string query, string text, string value)
        {
            AccesoDatos datos = new AccesoDatos();
            list.DataSource = datos.cargarControl(query);
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataBind();
        }

        public void cargarDDLMarcas(DropDownList list)
        {
            cargarDDL(list, "SELECT * FROM Marcas", "Nombre_M", "Cod_Marca");
            list.Items.Insert(0, new ListItem("-Marcas-", "0"));
        }

        public void cargarDDLCategorias(DropDownList list)
        {
            cargarDDL(list, "SELECT * FROM Categorias", "Nombre_C", "Cod_Categoria");
            list.Items.Insert(0, new ListItem("-Categorias-", "0"));
        }

        public void agregar(Producto pro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spAgregarProducto");
                datos.setearParametros("@Cod_Categoria_P", pro.Categoria.Cod_Categoria);
                datos.setearParametros("@Cod_Marca_P", pro.Marca.Cod_Marca);
                datos.setearParametros("@Nombre_P", pro.Nombre);
                datos.setearParametros("@Descripcion_P", pro.Descripcion);
                datos.setearParametros("@PUnitario_P", pro.Precio);
                datos.setearParametros("@Stock_P", pro.Stock);
                datos.setearParametros("@Estado_P", true);

                datos.ejecutarAccion();
                datos.cerrarConexion();





            }
            catch (Exception)
            {

                throw;
            }
        }

        public string buscarProd(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spListarProductos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    producto.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                }
                datos.cerrarConexion();
                return producto.CodigoProducto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void agregarImagen(string cod, string url) 
        {
            AccesoDatos datos = new AccesoDatos();
            {
                datos.setearProcedimiento("spAgregarImagen");
                datos.setearParametros("@Cod_Producto", cod);
                datos.setearParametros("@ImagenURL" , url);
                datos.ejecutarAccion();
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
