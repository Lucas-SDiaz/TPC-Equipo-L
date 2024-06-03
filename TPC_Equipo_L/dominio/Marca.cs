using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string Cod_Marca { get; set; }
        public string Nombre { get; set; }
        public string ImagenURL { get; set; }
        public bool Estado {  get; set; }
        public Marca() { }
        public Marca(int Id, string Nombre, bool estado, string imagenURL, string cod_Marca)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            Estado = estado;
            ImagenURL = imagenURL;
            Cod_Marca = cod_Marca;
        }
        public override string ToString()
        {
            return Nombre;
        }

    }
}
