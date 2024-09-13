using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
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
    public partial class FormAjustesCopia : Form
    {
        QueryConfiguracion query = new QueryConfiguracion();
        public FormAjustesCopia()
        {
            InitializeComponent();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButtonExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuraciones configuracion = query.ObtenerConfiguracion();
                if (!Directory.Exists(configuracion.UbicacionCopiasSeguridad))
                {
                    Directory.CreateDirectory(configuracion.UbicacionCopiasSeguridad);
                }
                SaveFileDialog saveFileDialogEmpleados = new SaveFileDialog
                {
                    Filter = "CSV (*.csv)|*.csv",
                    FileName = configuracion.UbicacionCopiasSeguridad + "registros_empleados_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
                };

                List<Empleado> listaEmpleados = new ListarEmpleado().Listar();

                using (StreamWriter sw = new StreamWriter(saveFileDialogEmpleados.FileName))
                {
                    // Escribir cabeceras de empleados
                    sw.WriteLine("IdEmpleado,NombreCompleto,NumeroDocumento,ZonaDeTrabajo,NumeroConsumos,Imagen,Estado,FechaRegistro");
                    foreach (var empleado in listaEmpleados)
                    {
                        sw.WriteLine($"{empleado.IdEmpleado},{empleado.NumeroDocumento},{empleado.NombreCompleto},{empleado.ZonaDeTrabajo},{empleado.NumeroConsumos},{empleado.Estado},{empleado.FechaRegistro}");
                    }
                }

                MessageBox.Show("Registros de empleados exportados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SaveFileDialog saveFileDialogConsumo = new SaveFileDialog
                {
                    Filter = "CSV (*.csv)|*.csv",
                    FileName = configuracion.UbicacionCopiasSeguridad + "registros_consumo_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
                };

                List<Consumo_CS> listaConsumo = new ListarConsumoCS().Listar();

                using (StreamWriter sw = new StreamWriter(saveFileDialogConsumo.FileName))
                {
                    // Escribir cabeceras de consumo
                    sw.WriteLine("IdConsumo,IdEmpleado,TipoConsumo,FechaRegistro");
                    foreach (var consumo in listaConsumo)
                    {
                        sw.WriteLine($"{consumo.IdConsumo},{consumo.IdEmpleado},{consumo.TipoConsumo},{consumo.FechaRegistro},{consumo.FormaRegistro}");
                    }
                }

                MessageBox.Show("Registros de consumo exportados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception a)
            {
                MessageBox.Show($"Error al Exportar las Copias de Seguridad: {a.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButtonImportar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Multiselect = false
                };
                bool isEmpleadoFile = false;
                bool isConsumoFile = false;
                string file1 = "";
                string file2 = "";
                openFileDialog.FileName = "EMPLEADOS";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file1 = openFileDialog.FileName;
                    isEmpleadoFile = file1.Contains("empleados");
                }
                else
                {
                    return;
                }
                openFileDialog.FileName = "CONSUMO";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file2 = openFileDialog.FileName;
                    isConsumoFile = file2.Contains("consumo");

                    if (isEmpleadoFile && isConsumoFile)
                    {
                        ProcesarArchivos(file1, file2);
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un archivo de empleados y uno de consumo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception a)
            {

            }
        }
        private void ProcesarArchivos(string empleadoFilePath, string consumoFilePath)
        {
            try
            {
                // Procesar el archivo de empleados
                using (StreamReader sr = new StreamReader(empleadoFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] empleadoData = line.Split(',');
                        try
                        {
                            int idEmpleado = int.Parse(empleadoData[0]); // Suponiendo que el primer valor es el ID del empleado

                            // Verificar si el empleado ya existe en la base de datos
                            List<Empleado> listaEmpleados = new ListarEmpleado().Listar();
                            Empleado empleadoExistente = listaEmpleados.FirstOrDefault(e => e.IdEmpleado == idEmpleado);

                            if (empleadoExistente == null)
                            {
                                // Si el empleado no existe, insertarlo en la base de datos
                                string numeroDocumento = empleadoData[1];
                                string nombreCompleto = empleadoData[2];
                                string zonaDeTrabajo = empleadoData[3];
                                int consumos = int.Parse(empleadoData[4]);
                                string imagen = empleadoData[5]; // Suponiendo que la imagen es el sexto valor
                                bool estado = bool.Parse(empleadoData[6]); // Suponiendo que el estado es el séptimo valor
                                DateTime fechaRegistro = DateTime.Parse(empleadoData[7]); // Suponiendo que la fecha de registro es el octavo valor

                                new QueryEmpleado().InsertarEmpleado(numeroDocumento, nombreCompleto, zonaDeTrabajo, consumos, estado, fechaRegistro);
                            }
                            else
                            {
                                // Si el empleado existe, verificar si hay cambios y actualizarlos si es necesario
                                string numeroDocumento = empleadoData[1];
                                string nombreCompleto = empleadoData[2];
                                string zonaDeTrabajo = empleadoData[3];
                                int numeroconumo = int.Parse(empleadoData[4]);
                                string imagen = empleadoData[5]; // Suponiendo que la imagen es el sexto valor
                                bool estado = bool.Parse(empleadoData[7]);// Suponiendo que el estado es el séptimo valor
                                DateTime fechaRegistro = DateTime.Parse(empleadoData[8]); // Suponiendo que la fecha de registro es el octavo valor

                                if (empleadoExistente.NumeroDocumento != numeroDocumento ||
                                    empleadoExistente.NombreCompleto != nombreCompleto ||
                                    empleadoExistente.ZonaDeTrabajo != zonaDeTrabajo ||
                                    empleadoExistente.Estado != estado ||
                                    empleadoExistente.FechaRegistro != fechaRegistro)
                                {
                                    new QueryEmpleado().ActualizarEmpleadoCS(empleadoExistente.IdEmpleado, numeroDocumento, nombreCompleto, zonaDeTrabajo, numeroconumo, estado, fechaRegistro);
                                }
                            }
                        }
                        catch
                        {
                            // Manejo de errores al procesar cada línea de empleado
                        }
                    }
                }

                // Procesar el archivo de consumo
                using (StreamReader sr = new StreamReader(consumoFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] consumoData = line.Split(',');
                        try
                        {
                            int idConsumo = int.Parse(consumoData[0]); // Suponiendo que el primer valor es el ID del consumo

                            // Verificar si el consumo ya existe en la base de datos
                            List<Consumo_CS> listaConsumos = new ListarConsumoCS().Listar();
                            Consumo_CS consumoExistente = listaConsumos.FirstOrDefault(c => c.IdConsumo == idConsumo);

                            if (consumoExistente == null)
                            {
                                // Si el consumo no existe, insertarlo en la base de datos
                                int idEmpleado = int.Parse(consumoData[1]);
                                string tipoConsumo = consumoData[2];
                                DateTime fechaRegistro = DateTime.Parse(consumoData[3]);
                                bool formaRegistro = Boolean.Parse(consumoData[4]);

                                new QueryConsumo().AgregarConsumoCS(idEmpleado, tipoConsumo, fechaRegistro, formaRegistro);
                            }
                        }
                        catch
                        {
                            // Manejo de errores al procesar cada línea de consumo
                        }
                    }
                }

                MessageBox.Show("Archivos procesados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar archivos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
