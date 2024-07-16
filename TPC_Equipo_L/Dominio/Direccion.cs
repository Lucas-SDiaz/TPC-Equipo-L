using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Direccion
    {
        public int ID { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public int CP { get; set; }
        public int Piso { get; set; }
        public string Depto { get; set; }
        public string Cod_Usuario { get; set;}

        public Direccion() { }
        public Direccion(int ID, string Calle, int Nro, int CP, int Piso, string Depto, string Cod_Usuario) 
        {
            this.ID = ID;
            this.Calle = Calle; 
            this.Nro = Nro; 
            this.CP = CP;
            this.Piso = Piso;
            this.Depto = Depto;
            this.Cod_Usuario = Cod_Usuario;
        }

        //public Direccion(int ID, string Calle, string Nro, string CP, int piso,string depto)
        //{
        //    this.ID = ID;
        //    this.Calle = Calle;
        //    this.Nro = Nro;
        //    this.CP = CP;
        //    this.Depto = depto;
        //    this.Piso = piso;
        //}
        //+ "Cod_Usuario: " + Cod_Usuario + " Numero: " + Nro + " Cod_Postal: " + CP + " Piso: " + Piso + " Depto: " + Depto
        //public override string ToString()
        //{
        //    return "Calle: " + Calle + " " + Nro;
        //}

        public override string ToString()
        {
            return Convert.ToString(ID);
        }

    }

}
