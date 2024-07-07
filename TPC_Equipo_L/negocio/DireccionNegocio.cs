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

        public int agregar(Direccion direccion, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int idDireccion = 0;

            try
            {
                datos.setearConsulta("insert into Direcciones (Cod_Usuario, Calle, Numero, Cod_Postal) values (@usuario, @calle, @nro, @cp); SELECT SCOPE_IDENTITY();");
                datos.setearParametros("@usuario", usuario.Cod_Usuario);
                datos.setearParametros("@calle", direccion.Calle);
                datos.setearParametros("@nro", direccion.Nro);
                datos.setearParametros("@cp", direccion.CP);

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
    }
}
