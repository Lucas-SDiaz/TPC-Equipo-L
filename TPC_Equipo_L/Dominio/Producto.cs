using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Producto
    {
        //Atributos
        private string Cod_Producto { get; set; }
        private Categoria Categoria { get; set; }
        private Marca Marca { get; set; }
        private string Nombre { get; set; }
        private string Descripcion { get; set; }
        private SqlMoney PrecioUnitario { get; set; }
        private int Stock {  get; set; }
        private bool Estado { get; set; }

        //Constructor
        public Producto() { }
        //Constructor con Parámetros
        public Producto(string cod_Producto, Categoria categoria, Marca marca, string nombre, string descripcion, SqlMoney precioUnitario, int stock, bool estado)
        {
            Cod_Producto = cod_Producto;
            Categoria = categoria;
            Marca = marca;
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioUnitario = precioUnitario;
            Stock = stock;
            Estado = estado;
        }

        //Override ToString
        public override string ToString()
        {
            return "Código: " + Cod_Producto + "Categoria: " + Categoria.ToString() + "Marca: " + Marca.ToString() + "Nombre: " + Nombre + "Descripción: " + Descripcion + "Precio Unitario: " + PrecioUnitario + "Estado: " + Estado;
        }
    }
}
