using Accord.Video;
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
        private Bitmap fotoCapturada = null;  // Bitmap para almacenar la foto tomada
        private bool fotoTomada = false;
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
            fotoCapturada = new Bitmap(585, 347);

            if (!fotoTomada)  // Si no se ha tomado la foto
            {
                // Tomar el frame actual que se está mostrando en el PictureBox
                if (pictureBox.Image != null)
                {
                    pictureBox.Image = pictureBox.Image;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.DrawToBitmap(fotoCapturada, new Rectangle(0, 0, 585, 347));
                    generalItems.closeCam();
                    iconButtonCamera.Text = "Volver a tomar";
                    fotoTomada = true;  // Cambiar el estado
                }
                else
                {
                    MessageBox.Show("No se puede capturar una imagen, asegúrate de que la cámara esté transmitiendo.");
                }
            }
            else  // Si ya se tomó la foto, volver a activar la cámara
            {
                generalItems.inicialziar(comboBoxSelectCamera.SelectedIndex, pictureBox);  // Reiniciar la cámara
                iconButtonCamera.Text = "Tomar Foto";  // Cambiar el texto del botón
                fotoTomada = false;  // Cambiar el estado
                fotoCapturada = null;  // Limpiar la foto capturada
            }
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
            generalItems.insertarempleado(textBox1.Text, textBox2.Text, textBox3.Text, fotoCapturada);
            Limpiar();
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
        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            pictureBox.Image = null;
            fotoCapturada = null;
            fotoTomada = false;
        }

        private void iconButtonCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
