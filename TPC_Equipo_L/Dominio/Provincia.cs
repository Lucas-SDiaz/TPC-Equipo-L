using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Provincia
    {
        //Atributos
        private int Id {  get; set; }
        private string Nombre { get; set; }

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
