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

        public void agregar(Venta venta, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("InsertarVenta");
                datos.agregarParametro("@FechaVenta", venta.FechaVenta);
                datos.agregarParametro("@User", usuario.Correo);
                datos.agregarParametro("@Pass", usuario.Contrasenia);
                datos.agregarParametro("@CodLocalidad", venta.Localidad);
                datos.agregarParametro("@MontoFinal", venta.MontoFinal);
              

                datos.ejecutarAccion();
                datos.cerrarConexion();





            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Venta> listarConSp(string User, string contra)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ListarVentas");

                datos.agregarParametro("@User", User);
                datos.agregarParametro("@Pass", contra);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();

                    aux.Cod_Venta = (int)datos.Lector["Cod_Venta"];
                    aux.FechaVenta = (DateTime)datos.Lector["Fecha_V"];
                    aux.MontoFinal = (decimal)datos.Lector["MontoFinal_V"];
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
