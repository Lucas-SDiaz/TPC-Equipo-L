using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Constructor
        public Provincia() { }
        //Constructor con Parámetros
        public Provincia(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        //Override ToString
        public override string ToString()
        {
            return "Id: " + Id + "Nombre: " + Nombre;
        }
    }
}
