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
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public Categoria() { }
        public Categoria(int id, string nombre, bool estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            Estado = estado;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
