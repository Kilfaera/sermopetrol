using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
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
    public partial class FormEmpleadosAgregar : Form
    {
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        public FormEmpleadosAgregar()
        {
            InitializeComponent();
            autocompletar();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButtonCamera_Click(object sender, EventArgs e)
        {
            
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
                    coincidencias.Add(item.ZonaDeTrabajo);
                }

                // Configurar el TextBox para usar autocompletado
                textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  // Modo de sugerencia y completar
                textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;  // Fuente personalizada
                textBox3.AutoCompleteCustomSource = coincidencias;  // Asignar las coincidencias
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar el autocompletado: " + ex.Message);
            }
        }

        private void iconButtonAgregar_Click(object sender, EventArgs e)
        {

        }

        private void FormEmpleadosAgregar_Load(object sender, EventArgs e)
        {
            comboBoxSelectCamera.Items.AddRange(generalItems.getCams().ToArray());
            comboBoxSelectCamera.SelectedIndex = 0;
        }

        private void comboBoxSelectCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            generalItems.inicialziar(comboBoxSelectCamera.SelectedIndex, pictureBox);
        }

        private void FormEmpleadosAgregar_FormClosing(object sender, FormClosingEventArgs e)
        {
            generalItems.closeCam();
        }
    }
}
