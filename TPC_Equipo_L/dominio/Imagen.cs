using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int Id { get; set; }

        public string CodigoProducto { get; set; }

        public string Url { get; set; }
        public bool Estado {  get; set; }
        public Imagen() { }
        public Imagen(int Id, string Url, string codigoArticulo,bool estado )
        {
            this.Id = Id;
            this.Url = Url;
            this.CodigoProducto = codigoArticulo;    
            this.Estado = estado;
        }
        public override string ToString()
        {
            return Url;
        }

    }
}
