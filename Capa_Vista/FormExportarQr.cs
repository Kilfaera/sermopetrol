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
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;

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
                        dataGridView.Rows.Add(new object[] {
                    item.IdEmpleado,
                    item.NombreCompleto,
                    item.NumeroDocumento,
                    item.ZonaDeTrabajo,
                    item.FechaRegistro
                    });

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
                bitmaps.Clear();
                textoQR.Clear();
                var writer = new BarcodeWriter()
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions()
                    {
                        Height = 200,
                        Width = 200,
                        Margin = 0,
                    }
                };

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    string nombre = row.Cells[0].Value.ToString();
                    string documento = row.Cells[1].Value.ToString();
                    string zona = row.Cells[2].Value.ToString();

                    Bitmap bitmap = writer.Write(documento);
                    pictureBox1.Image = bitmap;
                    bitmaps.Add(bitmap);
                    textoQR.Add(nombre + " - " + documento + " - " + zona);
                }

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
                
                
                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                {
                    
                    
                        dataGridView2.Rows.Add(dataGridView.Rows[cell.RowIndex].Cells[1].Value, dataGridView.Rows[cell.RowIndex].Cells[2].Value, dataGridView.Rows[cell.RowIndex].Cells[3].Value);
                     
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
