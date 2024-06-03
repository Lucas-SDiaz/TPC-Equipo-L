using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        private int id;
        private string codProducto;
        private string nombre;
        private string descripcion;
        private SqlMoney precio;
        private int stock;


        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Imagen Imagen { get; set; }

        public List<Imagen> Imagenes { get; set; }
        public SqlMoney Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
        public Producto() { }
        public Producto(int Id, string CodigoArticulo, string Nombre, string Descripcion, Marca Marca, Categoria Categoria, Imagen imagen, SqlMoney Precio,int stock, bool estado)
        {
            this.Id = Id;
            this.CodigoProducto = CodigoArticulo;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Marca = Marca;
            this.Categoria = Categoria;
            this.Imagen = imagen;
            this.Precio = (SqlMoney)Precio;
            this.Stock = stock;
            this.Estado = estado;
        }


        public override string ToString()
        {
            return "Codigo: " + codProducto + " Nombre: " + nombre + " Descripcion: " + descripcion + " Marca: " + Marca.ToString() + " Categoria :" + Categoria.ToString() + " Precio: " + precio;
        }

    }
}
