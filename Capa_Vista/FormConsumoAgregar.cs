using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using Consumos_Sermopetrol.Capa_Vista.MicroForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormConsumoAgregar : Form
    {
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        public FormConsumoAgregar()
        {
            InitializeComponent();
            ActualizarlistaConsumo();
            autocompletar();
            comboBoxConsumo.SelectedIndex = 0;
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
            }
            else { panelDiagramas.Visible = true; }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                if (e.RowIndex >= 0)
                {
                    // Capturar el valor de la primera celda (columna 0)
                    string valorPrimeraCelda = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string Nombre = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string Documento = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string Zona = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string tipo = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DateTime fecha = (DateTime)dataGridView.Rows[e.RowIndex].Cells[0].Value;
                    string Registro = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    // Mostrar el CustomMessageBox con tres opciones: Imprimir, Eliminar, Cancelar
                    CustomMessageBox customMessageBox = new CustomMessageBox("Selecciona lo que deceas hacer con el registro #"
                        + valorPrimeraCelda + " de " + Nombre);
                    var resultado = customMessageBox.ShowDialog();

                    // Evaluar qué botón fue seleccionado
                    if (resultado == DialogResult.OK)
                    {
                        switch (customMessageBox.Resultado)
                        {
                            case CustomMessageBox.Result.Imprimir:
                                // Lógica para imprimir
                                MessageBox.Show("Imprimiendo el consumo #" + valorPrimeraCelda);
                                generalItems.doc.BeginPrint += new PrintEventHandler(generalItems.iniciarImpresion);
                                generalItems.doc.PrintPage += (s, ev) => generalItems.imprimir(s, ev, tipo, fecha, Nombre, Documento, Zona); break;

                            case CustomMessageBox.Result.Eliminar:
                                // Lógica para eliminar
                                MessageBox.Show("Eliminando el valor: " + valorPrimeraCelda);
                                break;

                            case CustomMessageBox.Result.Cancelar:
                                // Lógica si seleccionan cancelar
                                MessageBox.Show("Operación cancelada.");
                                break;
                        }
                    }
                }
            }
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
                List<Empleado> listaEmpleado = new ListarEmpleado().Listar();

                // Agregar los números de documento de los empleados a las coincidencias
                foreach (Empleado item in listaEmpleado)
                {
                    coincidencias.Add(item.NumeroDocumento);
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
        private void iconButtonAprobar_Click(object sender, EventArgs e)
        {
            if (comboBoxConsumo.SelectedIndex == 0)
            {
                generalItems.Confirmacion(textBoxCedula.Text);
                ActualizarlistaConsumo();
            }
            else
            {
                generalItems.insertarempleadoconfirmadoM(textBoxCedula.Text, comboBoxConsumo.Text, dateTimePicker1.Value);
                ActualizarlistaConsumo();
            }
            textBoxCedula.Text = "";
        }

        private void FormConsumoAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!textBoxCedula.Focused)
            {
                textBoxCedula.Focus();
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    // Si no es un número ni una tecla de control, cancelar el evento
                    e.Handled = true;
                    return;
                }
                textBoxCedula.AppendText(e.KeyChar.ToString());
            }
            if (textBoxCedula.Text == "")
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (comboBoxConsumo.SelectedIndex == 0)
                    {
                        generalItems.Confirmacion(textBoxCedula.Text);
                        ActualizarlistaConsumo();
                    }
                    else
                    {
                        generalItems.insertarempleadoconfirmadoM(textBoxCedula.Text, comboBoxConsumo.Text, dateTimePicker1.Value);
                        ActualizarlistaConsumo();
                    }

                    ActualizarlistaConsumo();
                    textBoxCedula.Text = "";
                    textBoxCedula.Focus();
                }
                catch (Exception a)
                {
                    MessageBox.Show("ERROR AL INGRESAR EL CONSUMO DIGITADO: " + a);
                }
            }
        }
    }
}
