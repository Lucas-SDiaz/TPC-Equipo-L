using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Ventas
    {
        //Atributos
        private int Cod_Venta { get; set; }
        private DateTime FechaVenta { get; set; }
        private Usuario Usuario { get; set; }
        private Localidad Localidad { get; set; }
        private SqlMoney MontoFinal { get; set; }

        //Constructor
        public Ventas() { }
        //Constructor con Parámetros
        public Ventas(int cod_Venta, DateTime fechaVenta, Usuario usuario, Localidad localidad, SqlMoney montoFinal)
        {
            Cod_Venta = cod_Venta;
            FechaVenta = fechaVenta;
            Usuario = usuario;
            Localidad = localidad;
            MontoFinal = montoFinal;
        }

        //Override ToString
        public override string ToString()
        {
            return "Código: " + Cod_Venta + "Fecha: " + FechaVenta + "Usuario: " + Usuario + "Localidad: " + Localidad + "Monto Final: " + MontoFinal;
        }
    }
}
