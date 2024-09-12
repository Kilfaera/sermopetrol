using ClosedXML.Excel;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormConsumoEstadisticas : Form
    {
        Configuraciones configuracion = new Configuraciones();
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        public FormConsumoEstadisticas()
        {
            InitializeComponent();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        private void iconButtonExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.Columns.Count != 0 && dataGridView.Rows.Count > 0) //Si hay contenido en el datagridview
                {
                    saveFileDialog.Filter = "XLSX (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "excel" + DateTime.Now.ToString("-HH_mm_ss-") + " " + DateTime.Now.ToString("-yyyy_MM_dd-");
                    saveFileDialog.AddExtension = true;
                    var workbook = new XLWorkbook(); //Variable que simula el archivo excel
                    var worksheet = workbook.AddWorksheet("Hoja1"); //Variable que crea hojas dentro del archivo excel
                    for (int i = 1; i <= dataGridView.Columns.Count; i++) //Recorre las columnas
                    {
                        worksheet.Cell(1, i).Value = dataGridView.Columns[i - 1].HeaderText; //Agrega el contenido
                    }
                    for (int i = 0; i < dataGridView.Rows.Count; i++) //Recorre las filas
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++) //Recorre las columnas de la fila actual
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value?.ToString(); //Agrega el contenido
                        }
                    }
                    saveFileDialog.FileName = configuracion.UbicacionExcel + saveFileDialog.FileName;
                    if (File.Exists(saveFileDialog.FileName)) //Elimina el archivo si existe
                    {
                        File.Delete(saveFileDialog.FileName);
                    }
                    if (!Directory.Exists(configuracion.UbicacionExcel))
                    {
                        Directory.CreateDirectory(configuracion.UbicacionExcel);
                    }
                    workbook.SaveAs(saveFileDialog.FileName); //Guarda el nuevo archivo
                    
                    //generalItems.sonido(true);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("ERROR AL EXPORTAR EL ARCHIVO XLSX: " + a);
            }
        }
    }
}
