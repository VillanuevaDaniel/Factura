using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura
{
    public class Conexion
    {
        // Cadena de conexión a la base de datos.
        private string StrCnx = @"Data Source=DESKTOP-Q5DKAJ1\SQLSERVER_STD14;Initial Catalog=Proyecto;Integrated Security=True";

        // Constructor de la clase (actualmente vacío).
        public Conexion()
        {
        }

        // Método para ejecutar una consulta SQL con parámetros. Devuelve un valor booleano que indica si la ejecución fue exitosa.
        public bool EjecutarConParametros(string query, SqlParameter[] parametros)
        {
            // Crea una nueva conexión con la base de datos utilizando la cadena de conexión.
            using (SqlConnection ObjCnx = new SqlConnection(StrCnx))
            {
                try
                {
                    // Abre la conexión con la base de datos.
                    ObjCnx.Open();

                    // Crea un comando SQL con la consulta proporcionada y la conexión abierta.
                    using (SqlCommand ObjSqlCmd = new SqlCommand(query, ObjCnx))
                    {
                        // Si hay parámetros, se agregan al comando SQL.
                        if (parametros != null)
                        {
                            ObjSqlCmd.Parameters.AddRange(parametros); // Agrega los parámetros al comando.
                        }

                        // Ejecuta la consulta SQL (sin devolver resultados, por ejemplo, para INSERT, UPDATE o DELETE).
                        ObjSqlCmd.ExecuteNonQuery();
                    }

                    // Devuelve true si la consulta se ejecutó correctamente.
                    return true;
                }
                catch (Exception ex)
                {
                    // Muestra el mensaje de error en la consola si ocurre una excepción.
                    Console.WriteLine("Error: " + ex.Message);
                    return false; // Devuelve false en caso de error.
                }
            }
        }

        // Método para ejecutar una consulta SQL que devuelve un conjunto de resultados como un DataTable.
        public DataTable RegresaValores(string query)
        {
            // Crea una nueva conexión con la base de datos.
            using (SqlConnection ObjCnx = new SqlConnection(StrCnx))
            {
                // Inicializa un DataTable para almacenar los resultados.
                DataTable dt = new DataTable();
                try
                {
                    // Abre la conexión con la base de datos.
                    ObjCnx.Open();

                    // Crea un comando SQL con la consulta proporcionada y la conexión abierta.
                    using (SqlCommand ObjSqlCmd = new SqlCommand(query, ObjCnx))

                    // Crea un adaptador para llenar el DataTable con los resultados de la consulta.
                    using (SqlDataAdapter da = new SqlDataAdapter(ObjSqlCmd))
                    {
                        da.Fill(dt); // Llena el DataTable con los resultados de la consulta.
                    }

                    // Devuelve el DataTable con los resultados.
                    return dt;
                }
                catch (Exception ex)
                {
                    // Muestra el mensaje de error en la consola si ocurre una excepción.
                    Console.WriteLine("Error: " + ex.Message);
                    return null; // Devuelve null en caso de error.
                }
            }
        }

        // Método para ejecutar una consulta SQL con parámetros que devuelve un conjunto de resultados como un DataTable.
        public DataTable RegresaValoresConParametros(string query, SqlParameter[] parametros)
        {
            // Crea una nueva conexión con la base de datos.
            using (SqlConnection ObjCnx = new SqlConnection(StrCnx))
            {
                // Inicializa un DataTable para almacenar los resultados.
                DataTable dt = new DataTable();
                try
                {
                    // Abre la conexión con la base de datos.
                    ObjCnx.Open();

                    // Crea un comando SQL con la consulta proporcionada y la conexión abierta.
                    using (SqlCommand ObjSqlCmd = new SqlCommand(query, ObjCnx))
                    {
                        // Si hay parámetros, se agregan al comando SQL.
                        if (parametros != null)
                        {
                            ObjSqlCmd.Parameters.AddRange(parametros); // Agrega los parámetros al comando.
                        }

                        // Crea un adaptador para llenar el DataTable con los resultados de la consulta.
                        using (SqlDataAdapter da = new SqlDataAdapter(ObjSqlCmd))
                        {
                            da.Fill(dt); // Llena el DataTable con los resultados de la consulta.
                        }
                    }

                    // Devuelve el DataTable con los resultados.
                    return dt;
                }
                catch (Exception ex)
                {
                    // Muestra el mensaje de error en la consola si ocurre una excepción.
                    Console.WriteLine("Error: " + ex.Message);
                    return null; // Devuelve null en caso de error.
                }
            }
        }
    }

}
