using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Marca
    {
        //Atributos
        private string Cod_Marca {  get; set; }
        private string Nombre {  get; set; }
        private string ImagenURL { get; set; }
        private bool Estado { get; set; }

        //Constructor Vacio
        public Marca() { }
        //Contructor con Parámetros
        public Marca (string cod_Marca, string nombre, string imagenURL, bool estado)
        {
            Cod_Marca = cod_Marca;
            Nombre = nombre;
            ImagenURL = imagenURL;
            Estado = estado;
        }

        //Override ToString
        public override string ToString()
        {
            return "Código: " + Cod_Marca + "Nombre: " + Nombre + "Imagen URL: " + ImagenURL + "Estado: " + Estado;
        }
    }
}
