using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using Consumos_Sermopetrol.Capa_Vista.MicroForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormExportarQr : Form
    {
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        public FormExportarQr()
        {
            InitializeComponent();
            ActualizarDataWriteView();
        }
        private void ActualizarDataWriteView()
        {
            try
            {
                dataGridView.Rows.Clear();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                foreach (Empleado item in ListaEmpleados)
                {
                    if (item.Estado)
                    {
                        dataGridView.Rows.Add(new object[] { Text = item.IdEmpleado.ToString(), item.NombreCompleto, item.NumeroDocumento, item.ZonaDeTrabajo, item.NumeroConsumos, item.Estado, item.FechaRegistro });

                    }
                }
            }
            catch (Exception e)
            {
                generalItems.sonido(false);
                MessageBox.Show("ERROR AL ACTUALIZAR LA TABLA: " + e);
            }
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        List<Bitmap> bitmaps = new List<Bitmap>();
        List<string> textoQR = new List<string>();
        Bitmap bitmap = null;
        private void iconButtonExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarPDFs pdf = new ExportarPDFs(bitmaps, textoQR);
                pdf.Show();
                pdf.Close();
            }
            catch (Exception a)
            {
                generalItems.sonido(false);
                MessageBox.Show("ERROR AL GENERAR EL PDF: " + a);
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bitmaps.Clear();
            textoQR.Clear();
            dataGridView2.Rows.Clear();
            if (dataGridView.SelectedCells == null)
            {
                iconButtonExportar.Visible = false;
            }
            else
            {
                iconButtonExportar.Visible = true;
            }
            try
            {
                object cellValue;
                var writer = new BarcodeWriter() //Variable que permite generar y confgurar el codigo QR
                {
                    Format = BarcodeFormat.QR_CODE, //Formato QR
                    Options = new EncodingOptions() //Personalización del codigo
                    {
                        Height = 200,
                        Width = 200,
                        Margin = 0,
                    }
                };
                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                {
                    cellValue = dataGridView.Rows[cell.RowIndex].Cells[2].Value;
                    if (cellValue != null)
                    {
                        dataGridView2.Rows.Add(dataGridView.Rows[cell.RowIndex].Cells[1].Value, dataGridView.Rows[cell.RowIndex].Cells[2].Value);
                        bitmap = writer.Write(cellValue.ToString()); //Genera el codigo QR y lo guarda en la variable bitmap
                        pictureBox1.Image = bitmap; //Muestra el codigo generado en el picturebox
                        bitmaps.Add(bitmap);
                        textoQR.Add(dataGridView.Rows[cell.RowIndex].Cells[1].Value.ToString() + " - " + cellValue.ToString() + " - " + dataGridView.Rows[cell.RowIndex].Cells[3].Value.ToString());
                    }
                }
            }
            catch (Exception)
            {
                generalItems.sonido(false);
                dataGridView.ClearSelection();
                iconButtonExportar.Visible = false;
            }
        }

        private void BusquedaDocumento_TextChanged(object sender, EventArgs e)
        {
            Flitrado();
        }
        private void Flitrado()
        {


            try
            {

                dataGridView.Rows.Clear();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                foreach (Empleado item in ListaEmpleados)
                {
                    if (item.NumeroDocumento.Contains(BusquedaDocumento.Text) || item.ZonaDeTrabajo.Contains(BusquedaDocumento.Text) || item.NombreCompleto.Contains(BusquedaDocumento.Text) && item.Estado != false)
                    {
                        dataGridView.Rows.Add(new object[] {
                    item.IdEmpleado,
                    item.NombreCompleto,
                    item.NumeroDocumento,
                    item.ZonaDeTrabajo,
                    item.NumeroConsumos,
                    item.Estado,
                    item.FechaRegistro
                    });
                    }
                }
            }
            catch (Exception a)
            {
                generalItems.sonido(false);
                MessageBox.Show("ERROR AL APLICAR LOS FILTROS: " + a);
            }

        }

        private void iconButtonReiniciar_Click(object sender, EventArgs e)
        {
            ActualizarDataWriteView();
        }
    }
}
