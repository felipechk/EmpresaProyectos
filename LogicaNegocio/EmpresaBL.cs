using AccesodeDatos;
using System;
using System.Data.SqlClient;

namespace LogicaNegocio
{
    public class EmpresaBL
    {
        // Creamos una instancia de la capa de acceso a datos
        private EmpresaDB proyectoDAL = new EmpresaDB();

        // Método para validar y agregar un proyecto
        public void AgregarProyecto(string nombre, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            // Verificamos que los datos sean válidos antes de intentar agregar el proyecto
            if (!string.IsNullOrEmpty(nombre) && fechaInicio <= fechaFin && !string.IsNullOrEmpty(estado))
            {
                // Si los datos son válidos, llamamos al método DAL para agregar el proyecto
                proyectoDAL.AgregarProyecto(nombre, fechaInicio, fechaFin, estado);
            }
            else
            {
                // Si los datos son inválidos, lanzamos una excepción
                throw new Exception("Los datos del proyecto son inválidos.");
            }
        }

        // Método para obtener la lista de proyectos
        public SqlDataReader ObtenerProyectos()
        {
            // Llamamos al método DAL para obtener la lista de proyectos
            return proyectoDAL.ObtenerProyectos();
        }
    }
}

