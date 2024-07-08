using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace negocio
{
    public class VentaNegocio
    {
        public VentaNegocio() { }

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
        public void agregar(Venta venta, Usuario usuario)
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


                datos.ejecutarAccion();
                datos.cerrarConexion();





            }
            catch (Exception)
            {

                throw;
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
                        aux.NumSeguimiento = ""; // o null, según sea necesario
                    }


                    if (!DBNull.Value.Equals(datos.Lector["ID_Pago_V"]))
                    {
                        aux.IdPago = Convert.ToString(datos.Lector["ID_Pago_V"]);
                    }
                    else
                    {
                        aux.IdPago = ""; // o null, según sea necesario
                    }

                    if (!DBNull.Value.Equals(datos.Lector["Direccion"]))
                    {
                        aux.Direccion = Convert.ToString(datos.Lector["Direccion"]);
                    }
                    else
                    {
                        aux.Direccion = ""; // o null, según sea necesario
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
                        aux.NumSeguimiento = ""; // o null, según sea necesario
                    }


                    if (!DBNull.Value.Equals(datos.Lector["ID_Pago_V"]))
                    {
                        aux.IdPago = Convert.ToString(datos.Lector["ID_Pago_V"]);
                    }
                    else
                    {
                        aux.IdPago = ""; // o null, según sea necesario
                    }

                    if (!DBNull.Value.Equals(datos.Lector["Direccion"]))
                    {
                        aux.Direccion = Convert.ToString(datos.Lector["Direccion"]);
                    }
                    else
                    {
                        aux.Direccion = ""; // o null, según sea necesario
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
