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
    public partial class FormAjustesRutas : Form
    {
        QueryConfiguracion query = new QueryConfiguracion();
        Configuraciones ruta = new Configuraciones();
        FolderBrowserDialog save = new FolderBrowserDialog();
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        public FormAjustesRutas()
        {
            InitializeComponent();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void obtenerRutas()
        {
            ruta = query.ObtenerConfiguracion();
            textBoxRutaXlsx.Text = ruta.UbicacionExcel;
            textBoxRutaCsv.Text = ruta.UbicacionCopiasSeguridad;
            textBoxRutaPdf.Text = ruta.UbicacionPDF;
            textBoxRutaPng.Text = ruta.UbicacionImagenes;
            textBoxRutaPlantilla.Text = ruta.UbicacionPlantilla;
            buttonPng.Visible = buttonPlantilla.Visible = buttonXlsx.Visible = buttonCsv.Visible = buttonPdf.Visible = false;
        }

        private void FormAjustesRutas_Load(object sender, EventArgs e)
        {
            obtenerRutas();
        }

        private void buttonXlsx_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, ruta.UbicacionPDF, ruta.UbicacionPlantilla, textBoxRutaXlsx.Text, true, ruta.UbicacionCopiasSeguridad);
            obtenerRutas();
            generalItems.sonido(true);
        }

        private void buttonCsv_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, ruta.UbicacionPDF, ruta.UbicacionPlantilla, ruta.UbicacionExcel, true, textBoxRutaCsv.Text);
            obtenerRutas();
            generalItems.sonido(true);
        }

        private void buttonPdf_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, textBoxRutaPdf.Text, ruta.UbicacionPlantilla, ruta.UbicacionExcel, true, ruta.UbicacionCopiasSeguridad);
            obtenerRutas();
            generalItems.sonido(true);
        }
        private void buttonPlantilla_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(ruta.UbicacionImagenes, ruta.UbicacionPDF, textBoxRutaPlantilla.Text, ruta.UbicacionExcel, true, ruta.UbicacionCopiasSeguridad);
            obtenerRutas();
            generalItems.sonido(true);
        }

        private void buttonPng_Click(object sender, EventArgs e)
        {
            query.ActualizarConfiguracion(textBoxRutaPng.Text, ruta.UbicacionPDF, ruta.UbicacionPlantilla, ruta.UbicacionExcel, true, ruta.UbicacionCopiasSeguridad);
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
    }
}
