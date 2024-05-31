using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Localidad
    {
        //Atributos
        private int Id {  get; set; }
        private Provincia Provincia { get; set; }
        private string Nombre { get; set; }

        //Constructor
        public Localidad() { }
        //Constructor con Parámetros
        public Localidad(int id, Provincia provincia, string nombre)
        {
            Id = id;
            Provincia = provincia;
            Nombre = nombre;
        }

        //Override ToString
        public override string ToString()
        {
            return "Id: " + Id + "Provincia: " + Provincia + "Nombre: " + Nombre;
        }
    }
}
