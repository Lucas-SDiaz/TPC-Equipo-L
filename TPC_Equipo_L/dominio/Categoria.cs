using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Cod_Categoria { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public string ImagenURL { get; set; }
        public Categoria() { }
        public Categoria(int id, string nombre, bool estado, string imagenURL, string cod_Categoria)
        {
            this.Id = id;
            this.Nombre = nombre;
            Estado = estado;
            ImagenURL = imagenURL;
            Cod_Categoria = cod_Categoria;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
