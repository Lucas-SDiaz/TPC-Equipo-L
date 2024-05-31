using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Usuario
    {
        //Atributos
        private string Cod_Usuario {  get; set; }
        private string NombreUsuario { get; set; }
        private string Nombre {  get; set; }
        private string Apellido { get; set; }
        private string Correo { get; set; }
        private string Contrasenia { get; set; }
        private string Direccion {  get; set; }
        private Localidad Localidad { get; set; }
        private string ImagenURL { get; set; }
        private bool Estado {  get; set; }

        //Constructor
        public Usuario() { }
        //Constructor con Parámetros
        public Usuario (string cod_Usuario, string nombreUsuario, string nombre, string apellido, string correo, string contrasenia, string direccion, Localidad localidad, string imagenURL, bool estado)
        {
            Cod_Usuario = cod_Usuario;
            NombreUsuario = nombreUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Contrasenia = contrasenia;
            Direccion = direccion;
            Localidad = localidad;
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
