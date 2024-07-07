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
        public int IdDireccion { get; set; }
        public string Direccion { get; set; }
        public SqlMoney MontoFinal { get; set; }
        public string MetodoEnvio { get; set; }
        public string MetodoPago { get; set; }
        public string EstadoVenta { get; set; }
        public string NumSeguimiento { get; set; }
        public string IdPago { get; set; }


        //Constructor
        public Venta() {
            this.Usuario = new Usuario();
        }
        //Constructor con Parámetros
        public Venta(/*int cod_Venta,*/ DateTime fechaVenta, Usuario usuario, int direccion, SqlMoney montoFinal)
        {
            //Cod_Venta = cod_Venta;
            FechaVenta = fechaVenta;
            Usuario = usuario;
            IdDireccion = direccion;
            MontoFinal = montoFinal;
        }

        //Override ToString
        public override string ToString()
        {
            return "Código: " + Cod_Venta + "Fecha: " + FechaVenta + "Usuario: " + Usuario + "Direccion: " + Direccion + "Monto Final: " + MontoFinal;
        }
    }
}
