using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        //Atributos
        public int Cod_Venta { get; set; }
        public DateTime FechaVenta { get; set; }
        public Usuario Usuario { get; set; }
        public Localidad Localidad { get; set; }
        public SqlMoney MontoFinal { get; set; }

        //Constructor
        public Venta() { }
        //Constructor con Parámetros
        public Venta(int cod_Venta, DateTime fechaVenta, Usuario usuario, Localidad localidad, SqlMoney montoFinal)
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
