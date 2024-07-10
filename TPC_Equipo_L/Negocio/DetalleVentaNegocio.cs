using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DetalleVentaNegocio
    {
        public DetalleVentaNegocio() { }

        public void agregar(DetalleVenta venta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert Detalle_Ventas (Cod_Venta_DV,Cod_Producto_DV,PUnitario_DV,Cantidad_DV,Baja_DV) values(@codVenta,@codProd,@precio,@cantidad,1)");
                datos.setearParametros("@codVenta", venta.Cod_Venta);
                datos.setearParametros("@codProd", venta.Cod_Prod);
                datos.setearParametros("@precio", venta.PrecioUni);
                datos.setearParametros("@cantidad", venta.Cantidad);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<DetalleVenta> Listar(string codVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DetalleVenta> lista = new List<DetalleVenta>();

            try
            {
                datos.setearConsulta("select Cod_Venta_DV,Nombre_P,PUnitario_DV,Cantidad_DV,Cod_Producto_DV from Detalle_Ventas inner join Productos on Cod_Producto_DV = Cod_Producto where Cod_Venta_DV = @codventa");
                datos.setearParametros("@codVenta", int.Parse(codVenta));
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta();

                    aux.Cod_Venta = (int)datos.Lector["Cod_Venta_DV"];
                    aux.Cod_Prod = (string)datos.Lector["Cod_Producto_DV"];
                    aux.Nombre = (string)datos.Lector["Nombre_P"];
                    aux.Cantidad = (int)datos.Lector["Cantidad_DV"];
                    aux.PrecioUni = (decimal)datos.Lector["PUnitario_DV"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }



    }
}
