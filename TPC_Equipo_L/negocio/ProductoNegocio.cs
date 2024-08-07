﻿using System;
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
using System.Web.Security;
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
                    aux.Imagen = new Imagen();
                    aux.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Descripcion = (string)datos.Lector["Descripcion_P"];
                    aux.Categoria.Cod_Categoria = (string)datos.Lector["Cod_Categoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Nombre_C"];
                    aux.Marca.Cod_Marca = (string)datos.Lector["Cod_Marca"];
                    aux.Marca.Nombre = (string)datos.Lector["Nombre_M"];
                    //aux.Imagen.Url = (string)datos.Lector["ImagenURL"];
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

        public List<Producto> listarConFiltros(string marca, string categoria)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string query = "SELECT pro.Cod_Producto, cat.Cod_Categoria, cat.Nombre_C, mar.Cod_Marca, mar.Nombre_M, pro.Nombre_P, pro.Descripcion_P, pro.PUnitario_P, pro.Stock_P FROM Productos AS pro INNER JOIN Categorias AS cat ON pro.Cod_Categoria_P = cat.Cod_Categoria INNER JOIN Marcas AS mar ON pro.Cod_Marcas_P = mar.Cod_Marca WHERE pro.Estado_P = 1";
                if (!string.IsNullOrEmpty(marca))
                {
                    query += " AND mar.Cod_Marca = @marca";
                    datos.setearParametros("@marca", marca);
                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    query += " AND cat.Cod_Categoria = @categoria";
                    datos.setearParametros("@categoria", categoria);
                }

                datos.setearConsulta(query);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagen = new Imagen();
                    aux.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Descripcion = (string)datos.Lector["Descripcion_P"];
                    aux.Categoria.Cod_Categoria = (string)datos.Lector["Cod_Categoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Nombre_C"];
                    aux.Marca.Cod_Marca = (string)datos.Lector["Cod_Marca"];
                    aux.Marca.Nombre = (string)datos.Lector["Nombre_M"];
                    //aux.Imagen.Url = (string)datos.Lector["ImagenURL"];
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


        public List<Producto> listarCategorias(string cat)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT pro.Cod_Producto, c.Nombre_C, c.Cod_Categoria, m.Cod_Marca, m.Nombre_M, pro.Nombre_P, pro.Descripcion_P, pro.PUnitario_P, pro.Stock_P FROM Productos AS pro inner join Marcas m on m.Cod_Marca = pro.Cod_Marcas_P inner join Categorias c on c.Cod_Categoria = pro.Cod_Categoria_P WHERE pro.Estado_P = 1 AND pro.Cod_Categoria_P ='" + cat + "'");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagen = new Imagen();
                    aux.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    aux.Categoria.Cod_Categoria = (string)datos.Lector["Cod_Categoria"];
                    aux.Marca.Cod_Marca = (string)datos.Lector["Cod_Marca"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Descripcion = (string)datos.Lector["Descripcion_P"];
                    aux.Categoria.Nombre = (string)datos.Lector["Nombre_c"];
                    aux.Marca.Nombre = (string)datos.Lector["Nombre_m"];
                    //aux.Imagen.Url = (string)datos.Lector["ImagenURL"];
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


        public List<Producto> listarStock()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT pro.Cod_Producto, c.Nombre_C, m.Nombre_M, pro.Nombre_P, pro.Descripcion_P, pro.PUnitario_P, pro.Stock_P FROM Productos AS pro inner join Marcas m on m.Cod_Marca = pro.Cod_Marcas_P inner join Categorias c on c.Cod_Categoria = pro.Cod_Categoria_P WHERE pro.Stock_P < 10");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagen = new Imagen();
                    aux.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    //aux.Categoria.Cod_Categoria = (string)datos.Lector["Cod_Categoria_P"];
                    //  aux.Marca.Cod_Marca = (string)datos.Lector["Cod_Marcas_P"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Descripcion = (string)datos.Lector["Descripcion_P"];
                    aux.Categoria.Nombre = (string)datos.Lector["Nombre_c"];
                    aux.Marca.Nombre = (string)datos.Lector["Nombre_m"];
                    //aux.Imagen.Url = (string)datos.Lector["ImagenURL"];
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

        public List<Producto> listarMarcas(string mar)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT pro.Cod_Producto, c.Nombre_C, c.Cod_Categoria, m.Cod_Marca, m.Nombre_M, pro.Nombre_P, pro.Descripcion_P, pro.PUnitario_P, pro.Stock_P FROM Productos AS pro inner join Marcas m on m.Cod_Marca = pro.Cod_Marcas_P inner join Categorias c on c.Cod_Categoria = pro.Cod_Categoria_P WHERE pro.Estado_P = 1 AND pro.Cod_Marcas_P ='" + mar + "'");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagen = new Imagen();
                    aux.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    aux.Categoria.Cod_Categoria = (string)datos.Lector["Cod_Categoria"];
                    aux.Marca.Cod_Marca = (string)datos.Lector["Cod_Marca"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Descripcion = (string)datos.Lector["Descripcion_P"];
                    aux.Categoria.Nombre = (string)datos.Lector["Nombre_c"];
                    aux.Marca.Nombre = (string)datos.Lector["Nombre_m"];
                    //aux.Imagen.Url = (string)datos.Lector["ImagenURL"];
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
            list.Items.Insert(0, new ListItem("Marcas", ""));
        }

        public void cargarDDLCategorias(DropDownList list)
        {
            cargarDDL(list, "SELECT * FROM Categorias", "Nombre_C", "Cod_Categoria");
            list.Items.Insert(0, new ListItem("Categorias", ""));
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
        public void modificar(Producto pro)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (pro != null)
                {
                    datos.setearProcedimiento("spActualizarProducto");
                    datos.setearParametros("@Cod_Producto", pro.CodigoProducto);
                    datos.setearParametros("@Cod_Categoria_P", pro.Categoria.Cod_Categoria);
                    datos.setearParametros("@Cod_Marca_P", pro.Marca.Cod_Marca);
                    datos.setearParametros("@Nombre_P", pro.Nombre);
                    datos.setearParametros("@Descripcion_P", pro.Descripcion);
                    datos.setearParametros("@PUnitario_P", pro.Precio);
                    datos.setearParametros("@Stock_P", pro.Stock);
                    datos.setearParametros("@Estado_P", pro.Estado);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Imagen> buscarImagenes(Producto producto)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT i.ID, i.Cod_Producto, i.ImagenURL FROM ImagenesProd AS i WHERE i.Cod_Producto = '" + producto.CodigoProducto + "'");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)datos.Lector["ID"];
                    imagen.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    imagen.Url = (string)datos.Lector["ImagenURL"];
                    lista.Add(imagen);
                }
                datos.cerrarConexion();
                return lista;

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

        public void modificarImagen(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spActualizarImagen");
                datos.setearParametros("@ID", producto.Imagen.Id);
                datos.setearParametros("@Cod_Producto", producto.CodigoProducto);
                datos.setearParametros("@ImagenURL", producto.Imagen.Url);
                datos.ejecutarAccion();
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
        public void ModificarStock(Producto producto)
        {
            producto.Stock -= producto.Cantidad;
            producto.Estado = true;
            modificar(producto);
        }

        public void agregarImagen(string cod, string url)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spAgregarImagen");
                datos.setearParametros("@Cod_Producto", cod);
                datos.setearParametros("@ImagenURL", url);
                datos.ejecutarAccion();
                datos.cerrarConexion();
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

        public bool eliminar(string cod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spEliminarProducto");
                datos.setearParametros("@Cod_Producto", cod);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { datos.cerrarConexion(); }
        }
        public List<Producto> Buscador(string name)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT pro.Cod_Producto, pro.Nombre_P, pro.Descripcion_P, pro.PUnitario_P, pro.Stock_P, cat.Nombre_C, mar.Nombre_M FROM Productos AS pro INNER JOIN Categorias AS cat ON pro.Cod_Categoria_P = cat.Cod_Categoria INNER JOIN Marcas AS mar ON pro.Cod_Marcas_P = mar.Cod_Marca WHERE Nombre_P LIKE '%" + name + "%'");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagen = new Imagen();
                    aux.CodigoProducto = (string)datos.Lector["Cod_Producto"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Descripcion = (string)datos.Lector["Descripcion_P"];
                    //aux.Categoria.Cod_Categoria = (string)datos.Lector["Cod_Categoria_P"];
                    aux.Categoria.Nombre = (string)datos.Lector["Nombre_C"];
                    //aux.Marca.Cod_Marca = (string)datos.Lector["Cod_Marca_P"];
                    aux.Marca.Nombre = (string)datos.Lector["Nombre_M"];
                    //aux.Imagen.Url = (string)datos.Lector["ImagenURL"];
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

    }
}
