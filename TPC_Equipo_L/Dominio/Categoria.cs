using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Categoria
    {
        //Atributos
        private string Cod_Categoria { get; set; }
        private string Nombre { get; set; }
        private string ImagenURL { get; set; }
        private bool Estado { get; set; }

        //Constructor
        public Categoria() { }
        //Constructor con Parámetros
        public Categoria (string cod_Categoria, string nombre, string imagenURL, bool estado)
        {
            Cod_Categoria = cod_Categoria;
            Nombre = nombre;
            ImagenURL = imagenURL;
            Estado = estado;
        }

        //Override ToString
        public override string ToString()
        {
            return "Código: " + Cod_Categoria + "Nombre: " + Nombre + "Imagen URL: " + ImagenURL + "Estado: " + Estado;
        }
    }
}
