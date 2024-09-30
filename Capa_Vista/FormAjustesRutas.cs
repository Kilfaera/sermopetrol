using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using System;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormAjustesRutas : Form
    {
        QueryConfiguracion query = new QueryConfiguracion();
        Configuraciones ruta = new Configuraciones();
        FolderBrowserDialog save = new FolderBrowserDialog();
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        bool permiso;
        public FormAjustesRutas()
        {
            InitializeComponent();
            ActualizarTextoBotonPermiso();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void obtenerRutas()
        {
            ruta = query.ObtenerConfiguracion();
            permiso = ruta.PermisoEliminacionRegistros;
            textBoxRutaXlsx.Text = ruta.UbicacionExcel;
            textBoxRutaCsv.Text = ruta.UbicacionCopiasSeguridad;
            textBoxRutaPdf.Text = ruta.UbicacionPDF;
            textBoxRutaPng.Text = ruta.UbicacionImagenes;
            textBoxRutaPlantilla.Text = ruta.UbicacionPlantilla;
            buttonPng.Visible = buttonPlantilla.Visible = buttonXlsx.Visible = buttonCsv.Visible = buttonPdf.Visible = false;
            ActualizarTextoBotonPermiso();
        }

        private void ActualizarTextoBotonPermiso()
        {
            buttonEliminacion.Text = permiso ? "Deshabilitar" : "Habilitar";
        }

        private void FormAjustesRutas_Load(object sender, EventArgs e)
        {
            obtenerRutas();
        }

        private void buttonXlsx_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, ruta.UbicacionPDF, ruta.UbicacionPlantilla, textBoxRutaXlsx.Text, ruta.PermisoEliminacionRegistros, ruta.UbicacionCopiasSeguridad);
            obtenerRutas();
            generalItems.sonido(true);
        }

        private void buttonCsv_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, ruta.UbicacionPDF, ruta.UbicacionPlantilla, ruta.UbicacionExcel, ruta.PermisoEliminacionRegistros, textBoxRutaCsv.Text);
            obtenerRutas();
            generalItems.sonido(true);
        }

        private void buttonPdf_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, textBoxRutaPdf.Text, ruta.UbicacionPlantilla, ruta.UbicacionExcel, ruta.PermisoEliminacionRegistros, ruta.UbicacionCopiasSeguridad);
            obtenerRutas();
            generalItems.sonido(true);
        }
        private void buttonPlantilla_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, ruta.UbicacionPDF, textBoxRutaPlantilla.Text, ruta.UbicacionExcel, ruta.PermisoEliminacionRegistros, ruta.UbicacionCopiasSeguridad);
            obtenerRutas();
            generalItems.sonido(true);
        }

        private void buttonPng_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(textBoxRutaPng.Text, ruta.UbicacionPDF, ruta.UbicacionPlantilla, ruta.UbicacionExcel, ruta.PermisoEliminacionRegistros, ruta.UbicacionCopiasSeguridad);
            obtenerRutas();
            generalItems.sonido(true);
        }
        private void textBoxRutaXlsx_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRutaXlsx.Text != ruta.UbicacionExcel)
            {
                buttonXlsx.Visible = true;
            }
            else
            {
                buttonXlsx.Visible = false;
            }
        }

        private void textBoxRutaCsv_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRutaCsv.Text != ruta.UbicacionCopiasSeguridad)
            {
                buttonCsv.Visible = true;
            }
            else
            {
                buttonCsv.Visible = false;
            }
        }

        private void textBoxRutaPdf_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRutaPdf.Text != ruta.UbicacionPDF)
            {
                buttonPdf.Visible = true;
            }
            else
            {
                buttonPdf.Visible = false;
            }
        }

        private void textBoxRutaPng_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRutaPng.Text != ruta.UbicacionImagenes)
            {
                buttonPng.Visible = true;
            }
            else
            {
                buttonPng.Visible = false;
            }
        }

        private void textBoxRutaPlantilla_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRutaPlantilla.Text != ruta.UbicacionPlantilla)
            {
                buttonPlantilla.Visible = true;
            }
            else
            {
                buttonPlantilla.Visible = false;
            }
        }

        private void buttonModificarPng_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                textBoxRutaPng.Text = save.SelectedPath + "/";
            }
        }

        private void buttonModificarPlantilla_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                textBoxRutaPlantilla.Text = save.SelectedPath + "/";
            }
        }

        private void buttonModificarXlsx_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                textBoxRutaXlsx.Text = save.SelectedPath + "/";
            }
        }

        private void buttonModificarCsv_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                textBoxRutaCsv.Text = save.SelectedPath + "/";
            }
        }

        private void buttonModificarPdf_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                textBoxRutaPdf.Text = save.SelectedPath + "/";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputPassword = generalItems.SolicitarContraseña(); // Usar el nuevo método para pedir la contraseña

            if (inputPassword == null)
            {
                MessageBox.Show("Operación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verificar la contraseña (aquí deberías agregar la validación real de la contraseña)
            string contraseñaCorrecta = "srmpetrol2024admin"; // Contraseña de ejemplo

            if (inputPassword == contraseñaCorrecta)
            {
                // Cambiar el estado del permiso
                permiso = !permiso;

                // Actualizar la configuración en la base de datos

                query.ActualizarConfiguracion(ruta.UbicacionImagenes, ruta.UbicacionPDF, ruta.UbicacionPlantilla, ruta.UbicacionExcel, permiso, ruta.UbicacionCopiasSeguridad);

                // Actualizar el texto del botón
                ActualizarTextoBotonPermiso();

                MessageBox.Show("Permiso actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            generalItems.Backup(textBoxRutaCsv.Text);
        }
    }

}
