using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AppConsumo;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormConsumoAgregar : Form
    {
        GeneralItems generalItems = new GeneralItems();
        public FormConsumoAgregar()
        {
            InitializeComponent();
            ActualizarlistaConsumo();
            autocompletar();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            generalItems.inicialziar(comboBoxSelectCamara.SelectedIndex, pictureBoxCamara);
        }

       

        private void iconButton1_Click(object sender, EventArgs e)
        {

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
                    if (item.FechaRegistro.Date == dateTimePicker1.Value.Date)
                    {
                        // Verificar si FormaRegistro es 0 o 1 para mostrar el texto adecuado
                        string formaRegistro = item.FormaRegistro == false ? "Manual" : "Automático";
                        // Limpiar gráfico previo
                        chartConsumos.Series.Clear();
                        // Filtrar los consumos por la fecha seleccionada en el DateTimePicker
                        DateTime fechaSeleccionada = dateTimePicker1.Value.Date;
                        List<Consumo> consumosFiltrados = listaConsumo.Where(c => c.FechaRegistro.Date == fechaSeleccionada).ToList();

                        // Limpiar gráfico previo
                        chartConsumos.Series.Clear();

                        // Contar los consumos por tipo
                        var tipoConsumoGrupo = consumosFiltrados
                            .GroupBy(c => c.TipoConsumo)
                            .Select(grupo => new
                            {
                                TipoConsumo = grupo.Key,
                                Cantidad = grupo.Count()
                            })
                            .ToList();

                        // Calcular el total de consumos filtrados
                        int totalConsumos = consumosFiltrados.Count;

                        // Crear serie para el gráfico
                        Series serie = new Series("Consumo por tipo");
                        serie.ChartType = SeriesChartType.Pie; // Gráfico de pastel

                        // Crear etiqueta para mostrar el total de consumos
                        //labelTotalConsumos.Text = $"Total de Consumos: {totalConsumos}";

                        foreach (var tipo in tipoConsumoGrupo)
                        {
                            // Calcular el porcentaje
                            double porcentaje = (double)tipo.Cantidad / totalConsumos * 100;

                            // Agregar los puntos al gráfico con el número total y el porcentaje
                            string labelPunto = $"{tipo.TipoConsumo} {tipo.Cantidad} ";
                            serie.Points.AddXY(labelPunto, porcentaje);
                        }

                        // Agregar la serie al gráfico
                        chartConsumos.Series.Add(serie);

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
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR EL CONSUMO: " + e.Message);
            }
        }

        private void iconButtonHideLeftSidePanel_Click(object sender, EventArgs e)
        {
            if (panelDiagramas.Visible)
            {
                panelDiagramas.Visible = false;
            } else { panelDiagramas.Visible = true; }
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
                List<Consumo> listaConsumo = new ListarConsumo().Listar();

                // Agregar los números de documento de los empleados a las coincidencias
                foreach (Consumo item in listaConsumo)
                {
                    coincidencias.Add(item.DocumentoEmpleado);
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
    }
}
