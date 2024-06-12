using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public string Cod_Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Direccion { get; set; }
        public Provincia Provincia { get; set; }
        public Localidad Localidad { get; set; }
        public string ImagenURL { get; set; }
        public bool Estado { get; set; }

        //Constructor
        public Usuario() { }
        //Constructor con Parámetros
        public Usuario(string cod_Usuario, string nombreUsuario, string nombre, string apellido, string correo, string contrasenia, string direccion, Localidad localidad, Provincia provincia, string imagenURL, bool estado)
        {
            Cod_Usuario = cod_Usuario;
            NombreUsuario = nombreUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Contrasenia = contrasenia;
            Direccion = direccion;
            Localidad = localidad;
            Provincia = provincia;
            ImagenURL = imagenURL;
            Estado = estado;
        }

        //Override ToString
        public override string ToString()
        {
            return "Código: " + Cod_Usuario + "Nombre Usuario: " + NombreUsuario + "Nombre: " + Nombre + "Apellido: " + Apellido + "Correo: " + Correo + "Contrasenia: " + Contrasenia + "Dirección: " + Direccion + "Localidad: " + Localidad + "Imagen URL: " + ImagenURL + "Estado: " + Estado;
        }
    }
}
