﻿using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace negocio
{
    public class VentaNegocio
    {
        public VentaNegocio() { }

        public void ActualizarEstadoVenta(Venta ven, string estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (ven != null)
                {
                    datos.setearConsulta("update Ventas set Estado_Venta_V = @estadoVenta where Cod_Venta = @codVenta");
                    datos.setearParametros("@codVenta", ven.Cod_Venta);
                    datos.setearParametros("@estadoVenta", estado);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void modificarPago(Venta ven)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (ven != null)
                {
                    datos.setearConsulta("update Ventas set ID_Pago_V = @idPago where Cod_Venta = @codVenta");
                    datos.setearParametros("@codVenta", ven.Cod_Venta);
                    datos.setearParametros("@idPago", ven.IdPago);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void modificarNumSeguimiento(Venta ven)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (ven != null)
                {
                    datos.setearConsulta("update Ventas set Num_Seguimiento_V = @idSeguimiento where Cod_Venta = @codVenta");
                    datos.setearParametros("@codVenta", ven.Cod_Venta);
                    datos.setearParametros("@idSeguimiento", ven.NumSeguimiento);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string agregarScalar(Venta venta, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("InsertarVenta");
                datos.agregarParametro("@FechaVenta", venta.FechaVenta);
                datos.agregarParametro("@CodUsuario", usuario.Cod_Usuario);
                datos.agregarParametro("@ID_Direccion", venta.IdDireccion);
                datos.agregarParametro("@MontoFinal", venta.MontoFinal);
                datos.agregarParametro("@Metodo_Pago", venta.MetodoPago);
                datos.agregarParametro("@Metodo_Envio", venta.MetodoEnvio);


                return datos.ejecutarAccionScalar();
            





            }
            catch (Exception)
            {

                throw;
            }
            finally {
                datos.cerrarConexion();
            }
        }

        public List<Venta> listarConSp(string Cod_Usuario)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ListarVentas");
                datos.setearParametros("@CodUsuario", Cod_Usuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();

                    aux.Cod_Venta = (int)datos.Lector["Cod_Venta"];
                    aux.FechaVenta = (DateTime)datos.Lector["Fecha_V"];
                    aux.MontoFinal = (decimal)datos.Lector["MontoFinal_V"];
                    aux.EstadoVenta = (string)datos.Lector["Estado_Venta_V"];

                    aux.MetodoEnvio = (string)datos.Lector["Metodo_Envio_V"];

                    aux.MetodoPago = (string)datos.Lector["Metodo_Pago_V"];


                    if (!DBNull.Value.Equals(datos.Lector["Num_Seguimiento_V"]))
                    {
                        aux.NumSeguimiento = Convert.ToString(datos.Lector["Num_Seguimiento_V"]);
                    }
                    else
                    {
                        aux.NumSeguimiento = "";
                    }


                    if (!DBNull.Value.Equals(datos.Lector["ID_Pago_V"]))
                    {
                        aux.IdPago = Convert.ToString(datos.Lector["ID_Pago_V"]);
                    }
                    else
                    {
                        aux.IdPago = "";
                    }

                    if (!DBNull.Value.Equals(datos.Lector["Direccion"]))
                    {
                        aux.Direccion = Convert.ToString(datos.Lector["Direccion"]);
                    }
                    else
                    {
                        aux.Direccion = "";
                    }

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

        public List<Venta> listarAdminFiltros(string estado, string metodoPago)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = "select u.Nombre_U, u.Apellido_U, v.Cod_Venta, v.Fecha_V, v.MontoFinal_V, v.Num_Seguimiento_V, v.ID_Pago_V, v.Metodo_Envio_V, v.Metodo_Pago_V, v.Estado_Venta_V, CONCAT(d.Calle, ' ' , d.Numero )AS Direccion, d.Cod_Postal,concat(d.Piso , ', ' , d.Depto) AS Departamento, v.Baja_V from Ventas v inner join Usuarios u on u.Cod_Usuario = v.Cod_Usuario_V inner join Direcciones d on d.Cod_Usuario = v.Cod_Usuario_V AND d.ID = v.ID_Direccion_V WHERE 1 = 1";
                

                if (!string.IsNullOrEmpty(estado))
                {
                    query += " AND v.Estado_Venta_V = @Estado";
                    datos.setearParametros("@Estado", estado);
                }

                if (!string.IsNullOrEmpty(metodoPago))
                {
                    query += " AND v.Metodo_Pago_V = @MetodoPago";
                    datos.setearParametros("@MetodoPago", metodoPago);
                }

                datos.setearConsulta(query);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.Usuario = new Usuario();

                    aux.Usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    aux.Cod_Venta = (int)datos.Lector["Cod_Venta"];

                    aux.Usuario.Apellido = (string)datos.Lector["Apellido_U"];
                    aux.FechaVenta = (DateTime)datos.Lector["Fecha_V"];
                    aux.MontoFinal = (decimal)datos.Lector["MontoFinal_V"];
                    aux.EstadoVenta = (string)datos.Lector["Estado_Venta_V"];

                    aux.MetodoEnvio = (string)datos.Lector["Metodo_Envio_V"];

                    aux.MetodoPago = (string)datos.Lector["Metodo_Pago_V"];


                    if (!DBNull.Value.Equals(datos.Lector["Num_Seguimiento_V"]))
                    {
                        aux.NumSeguimiento = Convert.ToString(datos.Lector["Num_Seguimiento_V"]);
                    }
                    else
                    {
                        aux.NumSeguimiento = "";
                    }


                    if (!DBNull.Value.Equals(datos.Lector["ID_Pago_V"]))
                    {
                        aux.IdPago = Convert.ToString(datos.Lector["ID_Pago_V"]);
                    }
                    else
                    {
                        aux.IdPago = "";
                    }

                    if (!DBNull.Value.Equals(datos.Lector["Direccion"]))
                    {
                        aux.Direccion = Convert.ToString(datos.Lector["Direccion"]);
                    }
                    else
                    {
                        aux.Direccion = "";
                    }


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

        


        public List<Venta> listarAdminConSp()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ListarVentasAdmin");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.Usuario = new Usuario();

                    aux.Usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    aux.Cod_Venta = (int)datos.Lector["Cod_Venta"];

                    aux.Usuario.Apellido = (string)datos.Lector["Apellido_U"];
                    aux.FechaVenta = (DateTime)datos.Lector["Fecha_V"];
                    aux.MontoFinal = (decimal)datos.Lector["MontoFinal_V"];
                    aux.EstadoVenta = (string)datos.Lector["Estado_Venta_V"];

                    aux.MetodoEnvio = (string)datos.Lector["Metodo_Envio_V"];

                    aux.MetodoPago = (string)datos.Lector["Metodo_Pago_V"];


                    if (!DBNull.Value.Equals(datos.Lector["Num_Seguimiento_V"]))
                    {
                        aux.NumSeguimiento = Convert.ToString(datos.Lector["Num_Seguimiento_V"]);
                    }
                    else
                    {
                        aux.NumSeguimiento = "";
                    }


                    if (!DBNull.Value.Equals(datos.Lector["ID_Pago_V"]))
                    {
                        aux.IdPago = Convert.ToString(datos.Lector["ID_Pago_V"]);
                    }
                    else
                    {
                        aux.IdPago = "";
                    }

                    if (!DBNull.Value.Equals(datos.Lector["Direccion"]))
                    {
                        aux.Direccion = Convert.ToString(datos.Lector["Direccion"]);
                    }
                    else
                    {
                        aux.Direccion = "";
                    }


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
