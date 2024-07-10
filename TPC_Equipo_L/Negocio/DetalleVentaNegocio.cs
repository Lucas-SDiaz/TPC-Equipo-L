using dominio;
using System;
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
    }
}
