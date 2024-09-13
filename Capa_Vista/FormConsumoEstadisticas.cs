using AppConsumo.Controlador;
using ClosedXML.Excel;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormConsumoEstadisticas : Form
    {
        QueryConfiguracion query = new QueryConfiguracion();
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        public FormConsumoEstadisticas()
        {
            InitializeComponent();
            autocompletar();
            ActualizarlistaConsumo();
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
                Configuraciones configuracion = query.ObtenerConfiguracion();
                if (dataGridView.Columns.Count != 0 && dataGridView.Rows.Count > 0) //Si hay contenido en el datagridview
                {
                    saveFileDialog.Filter = "XLSX (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "consumos" + DateTime.Now.ToString("-HH_mm_ss-") + " " + DateTime.Now.ToString("-yyyy_MM_dd-") + ".xlsx";
                    saveFileDialog.AddExtension = true;
                    var workbook = new XLWorkbook(); //Variable que simula el archivo excel
                    var worksheet = workbook.AddWorksheet("Consumos"); //Variable que crea hojas dentro del archivo excel
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
                    saveFileDialog.FileName = configuracion.UbicacionExcel + saveFileDialog.FileName + ".xlsx";
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

        private void FormConsumoEstadisticas_Load(object sender, EventArgs e)
        {

        }
        void autocompletar()
        {
            try
            {
                // Crear una colección de cadenas para las coincidencias de autocompletado de nombres/documentos
                AutoCompleteStringCollection coincidenciasNombre = new AutoCompleteStringCollection();

                // Crear una colección de cadenas para las coincidencias de autocompletado de zonas de trabajo
                AutoCompleteStringCollection coincidenciasZona = new AutoCompleteStringCollection();

                // Crear un HashSet para evitar duplicados en las zonas
                HashSet<string> zonasUnicas = new HashSet<string>();

                // Obtener la lista de empleados
                List<Empleado> listaEmpleado = new ListarEmpleado().Listar();

                // Agregar los números de documento, nombres y zonas de los empleados a las coincidencias
                foreach (Empleado item in listaEmpleado)
                {
                    coincidenciasNombre.Add(item.NumeroDocumento);
                    coincidenciasNombre.Add(item.NombreCompleto);

                    // Verificar si la zona ya está en el HashSet y agregarla si no
                    if (!zonasUnicas.Contains(item.ZonaDeTrabajo))
                    {
                        coincidenciasZona.Add(item.ZonaDeTrabajo);
                        zonasUnicas.Add(item.ZonaDeTrabajo); // Agregar al HashSet para evitar duplicados
                    }
                }

                // Configurar el TextBox para nombres/documentos
                textBoxNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxNombre.AutoCompleteCustomSource = coincidenciasNombre;

                // Configurar el TextBox para zonas de trabajo
                textBoxZona.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxZona.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxZona.AutoCompleteCustomSource = coincidenciasZona;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar el autocompletado: " + ex.Message);
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {

            try
            {
                string documentoynombre = textBoxNombre.Text;
                string zona = textBoxZona.Text;
                string tipoConsumo;
                DateTime desdeDate = dateTimePickerDesde.Value.Date,
                hastaDate = dateTimePickerHasta.Value.Date;

                if (comboBoxConsumo.SelectedIndex == 0)
                {
                    tipoConsumo = "";
                }
                else
                {
                    tipoConsumo = comboBoxConsumo.Text;
                }




                List<Consumo> listaConsumo = new ListarConsumo().Listar();

                dataGridView.Rows.Clear();

                foreach (Consumo item in listaConsumo)
                {
                    if ((documentoynombre == "" || item.DocumentoEmpleado == documentoynombre || item.NombreEmpleado.Contains(documentoynombre)) &&
                        (zona == "" || item.ZonaTrabajoEmpleado == zona) &&
                        (tipoConsumo == "" || item.TipoConsumo == tipoConsumo) &&
                        (item.FechaRegistro.Date >= desdeDate) &&
                        (item.FechaRegistro.Date <= hastaDate))
                    {
                        dataGridView.Rows.Add(new object[] { item.IdConsumo, item.NombreEmpleado, item.DocumentoEmpleado, item.ZonaTrabajoEmpleado, item.TipoConsumo, item.FechaRegistro, item.FormaRegistro });
                    }

                }
            }
            catch (Exception a)
            {
                MessageBox.Show("ERROR AL APLICAR LOS FILTROS: " + a);
            }
        }

        private void textBoxZona_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void comboBoxConsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void dateTimePickerDesde_ValueChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void dateTimePickerHasta_ValueChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        public void ActualizarlistaConsumo()
        {
            try
            {

                comboBoxConsumo.Text = comboBoxConsumo.Items[0].ToString();
                dataGridView.Rows.Clear();
                List<Consumo> listaConsumo = new ListarConsumo().Listar();
                foreach (Consumo item in listaConsumo)
                {

                    // Verificar si FormaRegistro es 0 o 1 para mostrar el texto adecuado
                    string formaRegistro = item.FormaRegistro == false ? "Manual" : "Automático";


                    // Agregar la fila al DataGridView
                    dataGridView.Rows.Add(new object[]
                    {
                            item.IdConsumo,
                    item.NombreEmpleado,
                    item.DocumentoEmpleado,
                    item.ZonaTrabajoEmpleado,
                    item.TipoConsumo,
                    item.FechaRegistro,
                    formaRegistro
                    });
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR EL CONSUMO: " + e.Message);
            }
        }

        private void iconButtonReiniciar_Click(object sender, EventArgs e)
        {
            ActualizarlistaConsumo();
        }
    }
}
