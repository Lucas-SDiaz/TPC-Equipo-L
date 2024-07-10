using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetalleVenta
    {
        public int Cod_Venta { get; set; }
        public string Cod_Prod { get; set; }
        public string Nombre { get; set; }
        public SqlMoney PrecioUni { get; set; }
        public int Cantidad { get; set; }

        public DetalleVenta() { }
        public DetalleVenta(int cod_Venta, string cod_Prod, SqlMoney precioUni, int cantidad)
        {
            Cod_Venta = cod_Venta;
            Cod_Prod = cod_Prod;
            PrecioUni = precioUni;
            Cantidad = cantidad;
        }
    }
}
