using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class ImagenesProd
    {
        //Atributos
        private int Id { get; set; }
        private string Cod_Producto { get; set; }
        private string ImagenURL { get; set; }

        //Constructor
        public ImagenesProd() { }
        //Constructor con Parámetros
        public ImagenesProd(int id, string cod_Producto, string imagenURL)
        {
            Id = id;
            Cod_Producto = cod_Producto;
            ImagenURL = imagenURL;
        }

        //Override ToString
        public override string ToString()
        {
            return "Id: " + Id + "Código: " + Cod_Producto + "Imagen URL: " + ImagenURL; 
        }
    }
}
