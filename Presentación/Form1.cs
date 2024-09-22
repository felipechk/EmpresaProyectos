using LogicaNegocio;
using System.Data.SqlClient;

namespace Presentación
{
    public partial class Form1 : Form
    {
        // Instancia de la capa lógica de negocios (BLL)
        EmpresaBL proyectoBLL = new EmpresaBL();

        // Constructor del formulario
        public Form1()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta cuando se hace clic en el botón para agregar un proyecto
        private void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtenemos los valores de los controles del formulario
                string nombre = txtNombre.Text;
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;
                string estado = cmbEstado.SelectedItem.ToString();

                // Llamamos al método BLL para agregar el proyecto
                proyectoBLL.AgregarProyecto(nombre, fechaInicio, fechaFin, estado);

                // Mostramos un mensaje de éxito
                MessageBox.Show("Proyecto agregado con éxito.");

                // Actualizamos la lista de proyectos en el DataGridView
                CargarProyectos();
            }
            catch (Exception ex)
            {
                // Si ocurre un error, mostramos el mensaje de la excepción
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Método para cargar la lista de proyectos en el DataGridView
        private void CargarProyectos()
        {
            try
            {
                // Obtenemos la lista de proyectos
                SqlDataReader reader = proyectoBLL.ObtenerProyectos();

                // Limpiamos las filas actuales en el DataGridView
                dgvProyectos.Rows.Clear();

                // Recorremos cada fila del resultado y la añadimos al DataGridView
                while (reader.Read())
                {
                    dgvProyectos.Rows.Add(reader["Nombre"], reader["FechaInicio"], reader["FechaFin"], reader["Estado"]);
                }

                // Cerramos el lector de datos
                reader.Close();
            }
            catch (Exception ex)
            {
                // Si ocurre un error, mostramos el mensaje de la excepción
                MessageBox.Show("Error al cargar proyectos: " + ex.Message);
            }
        }

        // Evento que se ejecuta cuando el formulario se carga
        private void FormProyectos_Load(object sender, EventArgs e)
        {
            // Cargamos los proyectos cuando el formulario se inicia
            CargarProyectos();
        }
    }
}
