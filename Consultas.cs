using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    public class Consultas
    {
        // Método para consultar todos los registros de la tabla Clientes y devolverlos como un DataTable.
        public DataTable ConsultarClientes()
        {
            try
            {
                // Consulta SQL para seleccionar todos los registros de la tabla Clientes.
                string query = "SELECT * FROM Clientes";

                // Crea una instancia de la clase Conexion para ejecutar la consulta.
                Conexion obj = new Conexion();

                // Usamos RegresaValores ya que no necesitamos parámetros para esta consulta.
                return obj.RegresaValores(query); // Devuelve los resultados como un DataTable.
            }
            catch (Exception)
            {
                // Propaga cualquier excepción al llamador del método.
                throw;
            }
        }

        // Método para agregar un cliente a la base de datos.
        public bool AgregarCliente(string idCliente, string nombre, string direccion, long telefono, string rfc)
        {
            try
            {
                // Validación básica para asegurarse de que ID_Cliente y Nombre no sean nulos o vacíos.
                if (string.IsNullOrEmpty(idCliente) || string.IsNullOrEmpty(nombre))
                {
                    throw new ArgumentException("El ID y el nombre del cliente son obligatorios.");
                }

                // Consulta SQL para insertar un nuevo cliente en la tabla Clientes.
                string query = "INSERT INTO Clientes (ID_Cliente, Nombre, Direccion, Telefono, RFC) VALUES (@ID_Cliente, @Nombre, @Direccion, @Telefono, @RFC)";

                // Define los parámetros que se usarán en la consulta.
                SqlParameter[] parametros = new SqlParameter[]
                {
                // Parámetro para el ID del cliente.
                new SqlParameter("@ID_Cliente", SqlDbType.VarChar) { Value = idCliente },
                // Parámetro para el nombre del cliente.
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = nombre },
                // Parámetro para la dirección del cliente. Si es null, usa DBNull.Value.
                new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = direccion ?? (object)DBNull.Value },
                // Parámetro para el teléfono del cliente.
                new SqlParameter("@Telefono", SqlDbType.BigInt) { Value = telefono },
                // Parámetro para el RFC del cliente. Si es null, usa DBNull.Value.
                new SqlParameter("@RFC", SqlDbType.VarChar) { Value = rfc ?? (object)DBNull.Value }
                };

                // Crea una instancia de la clase Conexion para ejecutar la consulta.
                Conexion obj = new Conexion();

                // Ejecuta la consulta con los parámetros proporcionados y devuelve true si fue exitosa.
                return obj.EjecutarConParametros(query, parametros);
            }
            catch (Exception)
            {
                // Propaga cualquier excepción al llamador del método.
                throw;
            }
        }

        // Método para buscar clientes por nombre, devolviendo los resultados como un DataTable.
        public DataTable BuscarClientePorNombre(string nombreCliente)
        {
            try
            {
                // Validación básica para asegurarse de que el nombre de búsqueda no sea nulo o vacío.
                if (string.IsNullOrEmpty(nombreCliente))
                {
                    throw new ArgumentException("El nombre de búsqueda no puede estar vacío.");
                }

                // Consulta SQL para buscar clientes cuyo nombre contenga el texto proporcionado.
                string query = "SELECT * FROM Clientes WHERE Nombre LIKE @NombreCliente";

                // Define el parámetro para la búsqueda por nombre.
                SqlParameter[] parametros = new SqlParameter[]
                {
            // Parámetro para el nombre del cliente, utilizando un patrón con % para el operador LIKE.
            new SqlParameter("@NombreCliente", SqlDbType.VarChar) { Value = $"%{nombreCliente}%" }
                };

                // Crea una instancia de la clase Conexion para ejecutar la consulta.
                Conexion obj = new Conexion();

                // Ejecuta la consulta con parámetros y devuelve los resultados como un DataTable.
                return obj.RegresaValoresConParametros(query, parametros);
            }
            catch (Exception)
            {
                // Propaga cualquier excepción al llamador del método.
                throw;
            }
        }

        // Método para eliminar un cliente de la base de datos.
        public bool EliminarCliente(string idCliente)
        {
            try
            {
                // Validación básica para asegurarse de que el ID del cliente no sea nulo o vacío.
                if (string.IsNullOrEmpty(idCliente))
                {
                    throw new ArgumentException("El ID del cliente es obligatorio.");
                }

                // Consulta SQL para eliminar un cliente por su ID.
                string query = "DELETE FROM Clientes WHERE ID_Cliente = @ID_Cliente";

                // Define el parámetro para el ID del cliente.
                SqlParameter[] parametros = new SqlParameter[]
                {
            // Parámetro para el ID del cliente.
            new SqlParameter("@ID_Cliente", SqlDbType.VarChar) { Value = idCliente }
                };

                // Crea una instancia de la clase Conexion para ejecutar la consulta.
                Conexion obj = new Conexion();

                // Ejecuta la consulta con parámetros y devuelve true si fue exitosa.
                return obj.EjecutarConParametros(query, parametros);
            }
            catch (Exception)
            {
                // Propaga cualquier excepción al llamador del método.
                throw;
            }
        }
    }
}
