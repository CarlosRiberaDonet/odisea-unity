namespace DAM_M07_T01_ACT01_Carlos_Ribera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbExtensionesValidas.Enabled = false; // Desactivo el ComboBox al inicio

        }

        private void crearTareaButton_Click(object sender, EventArgs e)
        {
            // Llamo a la funci�n ValidarDatos
            string mensajeError = ValidarDatos();

            // Si hay algun error, muestro un mensage y detengo el proceso
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si todo est� bien, muestro mensaje de �xito
            MessageBox.Show("Tarea creada con �xito", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // M�todo para validar los datos del formulario
        private string ValidarDatos()
        {
            // Validar que el nombre de la tarea no est� vac�o
            if (string.IsNullOrWhiteSpace(txtNombreTarea.Text))
                return "Por favor, ingrese un nombre para la tarea.";

            // Validar que la descripci�n de la tarea no est� vac�a
            if (string.IsNullOrWhiteSpace(txtDescripcionTarea.Text))
                return "Por favor, ingrese una descripci�n para la tarea.";

            // Validar que la fecha de entrega sea posterior a la actual
            if (fechaEntrega.Value <= DateTime.Now)
                return "La fecha de entrega debe ser posterior a la actual.";

            // Validar que el usuario haya seleccionado un tipo de entrega
            if (cmbTipoEntrega.SelectedItem == null)
                return "Por favor, seleccione un tipo de entrega.";

            // Si el tipo de entrega es "Subir Fichero", validar que se haya seleccionado una opci�n en comboBoxExtensionesValidas
            if (cmbTipoEntrega.SelectedItem.ToString() == "Subir Fichero" && cmbExtensionesValidas.SelectedItem == null)
                return "Por favor, seleccione un tipo de extensi�n de archivo para la entrega.";

            // Si todo est� bien, devuelve cadena vac�a
            return string.Empty;
        }

        // M�todo para comprobar el tipo de entrega seleccionado por el USR
        private void cmbTipoEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si no hay selecci�n, salir
            if (cmbTipoEntrega.SelectedIndex < 0) return;

            // Variable que almacena el tipo de entrega seleccionado como texto
            string tipoEntrega = cmbTipoEntrega.SelectedItem.ToString();

            // Activar/desactivar ComboBox de extensiones
            cmbExtensionesValidas.Enabled = (tipoEntrega == "Subir Fichero");
            if (!cmbExtensionesValidas.Enabled)
            {
                cmbExtensionesValidas.SelectedIndex = -1; // Limpiar selecci�n
            }
        }
    }
}
