using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace negocio
{
    public class DireccionNegocio
    {

        public int Agregar(Direccion direccion, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int idDireccion = 0;

            try
            {
                datos.setearConsulta("insert into Direcciones (Cod_Usuario, Calle, Numero, Cod_Postal, Piso, Depto) values (@usuario, @calle, @nro, @cp, @piso, @depto); SELECT SCOPE_IDENTITY();");
                datos.setearParametros("@usuario", usuario.Cod_Usuario);
                datos.setearParametros("@calle", direccion.Calle);
                datos.setearParametros("@nro", direccion.Nro);
                datos.setearParametros("@cp", direccion.CP);
                datos.setearParametros("@piso", direccion.Piso);
                datos.setearParametros("@depto", direccion.Depto);

                // Ejecutar la consulta de inserción y obtener el ID insertado
                string resultado = datos.ejecutarAccionScalar();

                // Convertir el resultado a int
                if (!string.IsNullOrEmpty(resultado))
                {
                    idDireccion = Convert.ToInt32(resultado);
                }

                datos.cerrarConexion();

                return idDireccion; // Retornar el ID de la dirección insertada
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Direccion GetDireccion(Direccion direccion, string cod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, Cod_Usuario, Calle, Numero, Cod_Postal, Piso, Depto FROM Direcciones WHERE Cod_Usuario = '" + cod + "'");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    direccion.ID = (int)datos.Lector["ID"];
                    direccion.Cod_Usuario = (string)datos.Lector["Cod_Usuario"];
                    direccion.Calle = (string)datos.Lector["Calle"];
                    direccion.Nro = (int)datos.Lector["Numero"];
                    direccion.CP = (int)datos.Lector["Cod_Postal"];
                    direccion.Piso = (int)datos.Lector["Piso"];
                    direccion.Depto = (string)datos.Lector["Depto"];
                }
                return direccion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(Direccion direccion, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (direccion != null && usuario != null)
                {
                    datos.setearProcedimiento("spActualizarDireccion");
                    datos.setearParametros("@Cod_Usuario", usuario.Cod_Usuario);
                    datos.setearParametros("@ID", direccion.ID);
                    datos.setearParametros("@Calle", direccion.Calle);
                    datos.setearParametros("@Numero", direccion.Nro);
                    datos.setearParametros("@Cod_Postal", direccion.CP);
                    datos.setearParametros("@Piso", direccion.Piso);
                    datos.setearParametros("@Depto", direccion.Depto);
                    datos.ejecutarAccion();
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
    }
}
