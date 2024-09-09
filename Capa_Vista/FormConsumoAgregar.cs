using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormConsumoAgregar : Form
    {
        public FormConsumoAgregar()
        {
            InitializeComponent();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonHideLeftSidePanel_Click(object sender, EventArgs e)
        {
            if (panelDiagramas.Visible)
            {
                panelDiagramas.Visible = false;
<<<<<<< Updated upstream
            } else { panelDiagramas.Visible = true; }
=======
            }
            else { panelDiagramas.Visible = true; }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ActualizarlistaConsumo();
        }

        private void FormConsumoAgregar_Load_1(object sender, EventArgs e)
        {
            comboBoxSelectCamara.Items.AddRange(generalItems.getCams().ToArray());
            comboBoxSelectCamara.SelectedIndex = 0;
        }

        private void FormConsumoAgregar_Leave(object sender, EventArgs e)
        {

        }

        private void FormConsumoAgregar_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            generalItems.closeCam();
        }
        void autocompletar()
        {
            try
            {
                // Crear una colección de cadenas para las coincidencias de autocompletado
                AutoCompleteStringCollection coincidencias = new AutoCompleteStringCollection();

                // Obtener la lista de consumos
                List<Empleado> listaEmpleado = new ListarEmpleado().Listar();

                // Agregar los números de documento de los empleados a las coincidencias
                foreach (Empleado item in listaEmpleado)
                {
                    coincidencias.Add(item.NumeroDocumento);
                }

                // Configurar el TextBox para usar autocompletado
                textBoxCedula.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  // Modo de sugerencia y completar
                textBoxCedula.AutoCompleteSource = AutoCompleteSource.CustomSource;  // Fuente personalizada
                textBoxCedula.AutoCompleteCustomSource = coincidencias;  // Asignar las coincidencias
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar el autocompletado: " + ex.Message);
            }
        }
        private void iconButtonAprobar_Click(object sender, EventArgs e)
        {
            if (comboBoxConsumo.SelectedIndex == 0)
            {
                generalItems.Confirmacion(textBoxCedula.Text);
                ActualizarlistaConsumo();
            }
            else
            {
                generalItems.insertarempleadoconfirmadoM(textBoxCedula.Text, comboBoxConsumo.Text,dateTimePicker1.Value);
                ActualizarlistaConsumo();
            }
            textBoxCedula.Text = "";
        }

        private void FormConsumoAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!textBoxCedula.Focused)
            {
                textBoxCedula.Focus();
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    // Si no es un número ni una tecla de control, cancelar el evento
                    e.Handled = true;
                    return;
                }
                textBoxCedula.AppendText(e.KeyChar.ToString());
            }
            if (textBoxCedula.Text == "")
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (comboBoxConsumo.SelectedIndex == 0)
                    {
                        generalItems.Confirmacion(textBoxCedula.Text);
                        ActualizarlistaConsumo();
                    }
                    else
                    {
                        generalItems.insertarempleadoconfirmadoM(textBoxCedula.Text, comboBoxConsumo.Text, dateTimePicker1.Value);
                        ActualizarlistaConsumo();
                    }
                    textBoxCedula.Focus();
                    textBoxCedula.Text = "";
                }
                catch (Exception a)
                {
                    MessageBox.Show("ERROR AL INGRESAR EL CONSUMO DIGITADO: " + a);
                }
            }
>>>>>>> Stashed changes
        }
    }
}
