using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Localidad
    {
        //Atributos
        public int Id { get; set; }
        public Provincia Provincia { get; set; }
        public string Nombre { get; set; }

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
            return Nombre;
        }
    }
}
