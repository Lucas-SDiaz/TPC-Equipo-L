using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class DetalleVenta
    {
        //Atributos
        private int Cod_Venta {  get; set; }
        private Producto Producto { get; set; }
        private SqlMoney PrecioUnitario { get; set; }
        private int Cantidad { get; set; }

        //Constructor
        public DetalleVenta() { }
        //Constructor con Parámetros
        public DetalleVenta(int cod_Venta, Producto producto, SqlMoney precioUnitario, int cantidad)
        {
            Cod_Venta = cod_Venta;
            Producto = producto;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }

        //Override ToString
        public override string ToString()
        {
            return "Código: " + Cod_Venta + "Produco: " + Producto.ToString() + "Precio Unitario: " + PrecioUnitario + "Cantidad: " + Cantidad;
        }
    }
}
