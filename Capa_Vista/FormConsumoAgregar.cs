using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using Consumos_Sermopetrol.Capa_Vista.MicroForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            comboBoxConsumo.SelectedIndex = 0;
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(FormConsumoAgregar_KeyPress);
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
            if (e.RowIndex >= 0)
            {
                // Capturar el valor de la primera celda (que representa el ID del consumo)
                string valorPrimeraCelda = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                int idConsumo = int.Parse(valorPrimeraCelda); // Convertir el valor a entero

                string Nombre = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string Documento = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                string Zona = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                string Tipo = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                DateTime Fecha = (DateTime)dataGridView.Rows[e.RowIndex].Cells[5].Value;
                string Registro = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Mostrar el CustomMessageBox con tres opciones: Imprimir, Eliminar, Cancelar
                CustomMessageBox customMessageBox = new CustomMessageBox("Selecciona lo que deseas hacer con el registro #"
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
                            generalItems.imprimirSeleccion(Tipo, Nombre, Documento, Zona, Fecha);
                            break;

                        case CustomMessageBox.Result.Eliminar:
                            // Lógica para eliminar
                            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar el consumo #" + valorPrimeraCelda + "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (confirmacion == DialogResult.Yes)
                            {
                                QueryConsumo query = new QueryConsumo();
                                bool eliminado = query.EliminarConsumo(idConsumo);

                                if (eliminado)
                                {
                                    MessageBox.Show("El consumo ha sido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Lógica para refrescar la tabla si es necesario
                                    dataGridView.Rows.RemoveAt(e.RowIndex);
                                }
                                else
                                {
                                    MessageBox.Show("Hubo un problema al eliminar el consumo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            ActualizarlistaConsumo();
                            break;

                        case CustomMessageBox.Result.Cancelar:
                            // Lógica si seleccionan cancelar
                            MessageBox.Show("Operación cancelada.");
                            break;
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
        
        private void iconButtonAprobar_Click(object sender, EventArgs e)
        {
            string documentoEmpleado = textBoxCedula.Text; // Obtener el número de documento
            string rutaImagen = generalItems.ObtenerRutaImagen(documentoEmpleado); // Obtener la ruta de la imagen

            if (System.IO.File.Exists(rutaImagen)) // Verificar si la imagen existe
            {
                pictureBoxFoto.Image = Image.FromFile(rutaImagen); // Cargar la imagen en el PictureBox
            }
            else
            {
                pictureBoxFoto.Image = Properties.Resources.sin_imagen; // Restablecer a la imagen original
            }

            // Código existente para el proceso de consumo
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

            textBoxCedula.Focus();
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(textBoxCedula.Text))
            {
                string documentoEmpleado = textBoxCedula.Text; // Obtener el número de documento
                string rutaImagen = generalItems.ObtenerRutaImagen(documentoEmpleado); // Obtener la ruta de la imagen

                if (System.IO.File.Exists(rutaImagen)) // Verificar si la imagen existe
                {
                    pictureBoxFoto.Image = Image.FromFile(rutaImagen); // Cargar la imagen en el PictureBox
                }
                else
                {
                    MessageBox.Show("No se encontró la imagen del empleado.");
                    pictureBoxFoto.Image = Properties.Resources.sin_imagen; // Restablecer a la imagen original
                }

                ProcesarConsumo(); // Llamar al método de procesamiento de consumo
            }
        }
        private void ProcesarConsumo()
        {
            try
            {
                if (comboBoxConsumo.SelectedIndex == 0)
                {
                    generalItems.Confirmacion(textBoxCedula.Text);
                }
                else
                {
                    generalItems.insertarempleadoconfirmadoM(textBoxCedula.Text, comboBoxConsumo.Text, dateTimePicker1.Value);
                }

                ActualizarlistaConsumo();
                textBoxCedula.Clear();
                textBoxCedula.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL INGRESAR EL CONSUMO DIGITADO: " + ex.Message);
                generalItems.sonido(false);
            }
        }
    }
}

