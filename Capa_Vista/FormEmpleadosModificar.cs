using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormEmpleadosModificar : Form
    {
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        private Bitmap fotoCapturada = null;  // Bitmap para almacenar la foto tomada
        private bool fotoTomada = false;
        public FormEmpleadosModificar()
        {
            InitializeComponent();
            autocompletar();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        void autocompletar()
        {
            try
            {
                // Crear una colección de cadenas para las coincidencias de autocompletado
                AutoCompleteStringCollection coincidencias = new AutoCompleteStringCollection();
                AutoCompleteStringCollection coincidenciasEmpleado = new AutoCompleteStringCollection();
                // Obtener la lista de consumos
                List<Empleado> listaEmpleado = new ListarEmpleado().Listar();

                // Agregar los números de documento de los empleados a las coincidencias
                foreach (Empleado item in listaEmpleado)
                {
                    coincidencias.Add(item.ZonaDeTrabajo);
                    coincidenciasEmpleado.Add(item.NumeroDocumento);
                    coincidenciasEmpleado.Add(item.NombreCompleto);
                }
                textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  // Modo de sugerencia y completar
                textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;  // Fuente personalizada
                textBox4.AutoCompleteCustomSource = coincidenciasEmpleado;
                // Configurar el TextBox para usar autocompletado
                textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  // Modo de sugerencia y completar
                textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;  // Fuente personalizada
                textBox3.AutoCompleteCustomSource = coincidencias;  // Asignar las coincidencias
            }
            catch (Exception ex)
            {
                generalItems.sonido(false);
                MessageBox.Show("Error al configurar el autocompletado: " + ex.Message);
            }
        }
        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            pictureBox.Image = null;
            fotoCapturada = null;
            fotoTomada = true;
        }

        private void FormEmpleadosModificar_Load(object sender, EventArgs e)
        {
            comboBoxSelectCamera.Items.AddRange(generalItems.getCams().ToArray());
            comboBoxSelectCamera.SelectedIndex = 0;
        }

        private void comboBoxSelectCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            generalItems.inicialziar(comboBoxSelectCamera.SelectedIndex, pictureBox);
        }

        private void iconButtonReiniciar_Click(object sender, EventArgs e)
        {
            generalItems.closeCam();
            string documentoEmpleado = textBox4.Text; // Obtener el número de documento
            string rutaImagen = generalItems.ObtenerRutaImagen(documentoEmpleado); // Obtener la ruta de la imagen

            List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
            foreach (Empleado item in ListaEmpleados)
            {
                if (item.NumeroDocumento == textBox4.Text || item.NombreCompleto == textBox4.Text)
                {

                    if (System.IO.File.Exists(rutaImagen)) // Verificar si la imagen existe
                    {
                        pictureBox.Image = Image.FromFile(rutaImagen); // Cargar la imagen en el PictureBox
                    }
                    else
                    {
                        pictureBox.Image = Properties.Resources.sin_imagen; // Restablecer a la imagen original
                    }
                    textBox1.Text = item.NumeroDocumento;
                    textBox2.Text = item.NombreCompleto;
                    textBox3.Text = item.ZonaDeTrabajo;

                }
            }
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
                    iconButtonCamera.Text = "Activar Camara";
                    fotoTomada = true;  // Cambiar el estado
                }
                else
                {
                    generalItems.sonido(false);
                    MessageBox.Show("No se puede capturar una imagen, asegúrate de que la cámara esté transmitiendo.");
                }
            }
            else  // Si ya se tomó la foto, volver a activar la cámara
            {
                generalItems.inicialziar(comboBoxSelectCamera.SelectedIndex, pictureBox);  // Reiniciar la cámara
                iconButtonCamera.Text = "Tomar Foto";  // Cambiar el texto del botón
                fotoTomada = false;  // Cambiar el estado
                fotoCapturada = null;  // Limpiar la foto capturada
                QueryConfiguracion query = new QueryConfiguracion();

                Configuraciones configuracion = query.ObtenerConfiguracion(); // Obtener la ruta configurada
                string rutaImagen = configuracion.UbicacionImagenes; // Ruta donde se almacenarán las imágenes
                string nombreImagen = $"{rutaImagen}\\{textBox1.Text}.png";
                QueryEmpleado em = new QueryEmpleado();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
            }
        }

        private void iconButtonGuardar_Click(object sender, EventArgs e)
        {
            generalItems.actualizarempleado(textBox1.Text, textBox2.Text, textBox3.Text, fotoCapturada);
        }

        private void FormEmpleadosModificar_FormClosing(object sender, FormClosingEventArgs e)
        {
            generalItems.closeCam();
        }

        private void iconButtonEliminar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") { generalItems.eliminarempleado(textBox1.Text); }

        }
    }
}
