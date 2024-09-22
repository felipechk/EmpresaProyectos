using System;
using System.Data.SqlClient;
using System.Configuration;

namespace AccesodeDatos
{
    public class EmpresaDB
    {
        // Obtener la cadena de conexión desde las propiedades de configuración del proyecto
        string conexion = Properties.Settings.Default.MiCadena;
        // Método para agregar un proyecto a la base de datos
        public void AgregarProyecto(string nombre, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            // Usamos un bloque using para asegurar que la conexión se cierre automáticamente después de ser usada
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                // Abrimos la conexión con la base de datos
                conn.Open();

                // Definimos la consulta SQL para insertar un nuevo proyecto
                string query = "INSERT INTO Proyectos (Nombre, FechaInicio, FechaFin, Estado) VALUES (@Nombre, @FechaInicio, @FechaFin, @Estado)";

                // Creamos el comando SQL para ejecutar la consulta
                SqlCommand cmd = new SqlCommand(query, conn);

                // Asignamos los valores a los parámetros de la consulta
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@Estado", estado);

                // Ejecutamos la consulta para insertar el proyecto
                cmd.ExecuteNonQuery();
            }  // Al salir del bloque using, la conexión se cierra automáticamente
        }

        // Método para obtener la lista de proyectos desde la base de datos
        public SqlDataReader ObtenerProyectos()
        {
            // Creamos una nueva conexión a la base de datos
            SqlConnection conn = new SqlConnection(conexion);

            // Abrimos la conexión
            conn.Open();

            // Definimos la consulta SQL para obtener todos los proyectos
            string query = "SELECT * FROM Proyectos";

            // Creamos el comando SQL
            SqlCommand cmd = new SqlCommand(query, conn);

            // Ejecutamos la consulta y devolvemos un SqlDataReader con los resultados
            return cmd.ExecuteReader();
        }
    }
}
