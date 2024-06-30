using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Direccion
    {
        public  int ID;
        public string Calle;
        public string Nro;
        public string CP;

        public Direccion() { }
        public Direccion(int ID, string Calle, string Nro, string CP) 
        {
            this.ID = ID;
            this.Calle = Calle; 
            this.Nro = Nro; 
            this.CP = CP;
        }
        public override string ToString()
        {
            return "Calle: " + Calle + " Nro° " + Nro; 
        }
    }

}
