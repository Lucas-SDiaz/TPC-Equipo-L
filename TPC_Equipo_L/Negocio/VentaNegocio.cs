using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                datos.setearParametros("@Fecha_V", venta.FechaVenta);
                datos.setearParametros("@User", usuario.Correo);
                datos.setearParametros("@Pass", usuario.Contrasenia);
                datos.setearParametros("@Cod_Localidad_V", venta.Localidad);
                datos.setearParametros("@MontoFinal_V", venta.MontoFinal);

                datos.ejecutarAccion();
                datos.cerrarConexion();





            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Venta> listarConSp(Usuario usuario)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ListarVentas");
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
