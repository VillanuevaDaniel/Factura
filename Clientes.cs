using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    public partial class Clientes : Form
    {
        // Constructor del formulario Clientes.
        public Clientes()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        // Evento que se ejecuta al cargar el formulario.
        private void Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                // Crea una instancia de la clase Consultas.
                Consultas dt = new Consultas();

                // Llama al método ConsultarClientes para obtener los datos de los clientes.
                DataTable data = dt.ConsultarClientes();

                // Si los datos no están vacíos, los asigna como fuente de datos al DataGridView.
                if (data != null && data.Rows.Count > 0)
                {
                    dgvCliente.DataSource = data; // Asigna el DataTable al DataGridView.
                }
                else
                {
                    // Muestra un mensaje si no hay datos disponibles.
                    MessageBox.Show("No hay datos disponibles para mostrar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción.
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para recargar los datos de clientes en el DataGridView.
        private void CargarDatosClientes()
        {
            try
            {
                // Crea una instancia de la clase Consultas.
                Consultas consultas = new Consultas();

                // Llama al método ConsultarClientes para obtener los datos de los clientes.
                DataTable data = consultas.ConsultarClientes();

                // Si los datos no están vacíos, los asigna como fuente de datos al DataGridView.
                if (data != null && data.Rows.Count > 0)
                {
                    dgvCliente.DataSource = data; // Asigna el DataTable al DataGridView.
                }
                else
                {
                    // Muestra un mensaje si no hay datos disponibles.
                    MessageBox.Show("No hay datos disponibles para mostrar", "Información",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción.
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para agregar un cliente.
        private void Btncargar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene los valores de los TextBoxes correspondientes.
                string idCliente = txtIdCliente.Text; // ID del cliente.
                string nombre = txtNombreCliente.Text; // Nombre del cliente.
                string direccion = txtDireccionCliente.Text; // Dirección del cliente.
                long telefono = long.TryParse(txtTelefonoCliente.Text, out long result) ? result : 0; // Teléfono del cliente, asegurando que sea un número.
                string rfc = txtRFCCliente.Text; // RFC del cliente.

                // Crea una instancia de la clase Consultas.
                Consultas consultas = new Consultas();

                // Llama al método AgregarCliente para insertar el cliente en la base de datos.
                if (consultas.AgregarCliente(idCliente, nombre, direccion, telefono, rfc))
                {
                    // Muestra un mensaje de éxito.
                    MessageBox.Show("Cliente insertado correctamente.");
                    CargarDatosClientes(); // Recarga los datos en el DataGridView.
                }
            }
            catch (ArgumentException ex)
            {
                // Muestra un mensaje de advertencia si hay un error de validación.
                MessageBox.Show(ex.Message, "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción.
                MessageBox.Show("Error al agregar el cliente: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para buscar clientes por nombre.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene el nombre del cliente a buscar desde el TextBox correspondiente.
                string nombreCliente = txtNombreCliente.Text;

                // Crea una instancia de la clase Consultas.
                Consultas consultas = new Consultas();

                // Llama al método BuscarClientePorNombre para buscar en la base de datos.
                DataTable resultados = consultas.BuscarClientePorNombre(nombreCliente);

                // Si hay resultados, los muestra en el DataGridView.
                if (resultados.Rows.Count > 0)
                {
                    dgvCliente.DataSource = resultados;
                }
                else
                {
                    // Muestra un mensaje si no se encontraron clientes.
                    MessageBox.Show("No se encontraron clientes con ese nombre.");
                }
            }
            catch (ArgumentException ex)
            {
                // Muestra un mensaje de advertencia si hay un error de validación.
                MessageBox.Show(ex.Message, "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción.
                MessageBox.Show("Error al buscar clientes: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para eliminar un cliente por ID.
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene el ID del cliente a eliminar desde el TextBox correspondiente.
                string idCliente = txtIdCliente.Text;

                // Crea una instancia de la clase Consultas.
                Consultas consultas = new Consultas();

                // Llama al método EliminarCliente para eliminar el cliente de la base de datos.
                if (consultas.EliminarCliente(idCliente))
                {
                    // Muestra un mensaje de éxito.
                    MessageBox.Show($"Cliente con ID {idCliente} eliminado correctamente.");
                    CargarDatosClientes(); // Recarga los datos en el DataGridView.
                }
            }
            catch (ArgumentException ex)
            {
                // Muestra un mensaje de advertencia si hay un error de validación.
                MessageBox.Show(ex.Message, "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción.
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
