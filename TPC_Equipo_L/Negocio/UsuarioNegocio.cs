﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public UsuarioNegocio() { }
        public bool Logear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Cod_Usuario, Nombre_U, TipoUser_U From USUARIOS Where Correo_U = @user AND Contrasenia_U = @pass");
                datos.setearParametros("@user", usuario.Correo);
                datos.setearParametros("@pass", usuario.Contrasenia);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.Cod_Usuario = (string)datos.Lector["Cod_Usuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre_U"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser_U"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public string registrarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spRegister");
                datos.setearParametros("@Correo_U", usuario.Correo);
                datos.setearParametros("@Contrasenia_U", usuario.Contrasenia);
                datos.setearParametros("@Nombre_U", usuario.Nombre);
                datos.setearParametros("@Apellido_U", usuario.Apellido);
                datos.setearParametros("@TipoUser_U", 1);
                datos.setearParametros("Estado_U", true);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void cargarDDL(DropDownList list, string query, string text, string value)
        {
            AccesoDatos datos = new AccesoDatos();
            list.DataSource = datos.cargarControl(query);
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataBind();
        }
        public void cargarDDLProvincias(DropDownList list)
        {
            cargarDDL(list, "SELECT * FROM PROVINCIAS", "Provincia", "ID");
            list.Items.Insert(0, new ListItem("-Provincias-", "0"));
        }

       
        public List<Localidad> listarLocalidades(int prov)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            List<Localidad> localidades = new List<Localidad>();
            try
            {
                datos.setearConsulta("SELECT L.Localidad, L.ID FROM Localidades L WHERE L.ID_Provincia = @ID_Provincia");
                datos.setearParametros("@ID_Provincia", prov);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    string loc = (string)datos.Lector["Localidad"];
                    int id = (int)datos.Lector["ID"];
                    Localidad localidad = new Localidad();
                    localidad.Nombre = loc;
                    localidad.Id = id;
                    localidades.Add(localidad);
                }

                return localidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
