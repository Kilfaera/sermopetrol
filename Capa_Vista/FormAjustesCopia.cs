using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormAjustesCopia : Form
    {
        private readonly QueryConfiguracion _queryConfiguracion = new QueryConfiguracion();
        private readonly Funciones_frecuentes _generalItems = new Funciones_frecuentes();

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
                var configuracion = _queryConfiguracion.ObtenerConfiguracion();
                ExportarDatos(configuracion.UbicacionCopiasSeguridad);
                _generalItems.sonido(true);
                MessageBox.Show("Exportación completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _generalItems.sonido(false);
                MostrarError("Error al exportar las copias de seguridad", ex);
            }
        }

        private void iconButtonImportar_Click(object sender, EventArgs e)
        {
            try
            {
                (string archivoEmpleado, string archivoConsumo) = SeleccionarArchivos();
                if (!string.IsNullOrEmpty(archivoEmpleado) && !string.IsNullOrEmpty(archivoConsumo))
                {
                    ProcesarArchivos(archivoEmpleado, archivoConsumo);
                }
                else
                {
                    _generalItems.sonido(false);
                    MessageBox.Show("Por favor seleccione ambos archivos (empleados y consumo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _generalItems.sonido(false);
                MostrarError("Error al importar los archivos", ex);
            }
        }

        private void ExportarDatos(string ubicacionCopiasSeguridad)
        {
            if (!Directory.Exists(ubicacionCopiasSeguridad))
            {
                Directory.CreateDirectory(ubicacionCopiasSeguridad);
            }

            ExportarArchivoCSV(
                "registros_empleados_",
                "IdEmpleado,NombreCompleto,NumeroDocumento,ZonaDeTrabajo,NumeroConsumos,Estado,FechaRegistro",
                new ListarEmpleado().Listar().Select(empleado => $"{empleado.IdEmpleado},{empleado.NombreCompleto},{empleado.NumeroDocumento},{empleado.ZonaDeTrabajo},{empleado.NumeroConsumos},{empleado.Estado},{empleado.FechaRegistro}")
            );

            ExportarArchivoCSV(
                "registros_consumo_",
                "IdConsumo,IdEmpleado,TipoConsumo,FechaRegistro,FormaRegistro",
                new ListarConsumoCS().Listar().Select(consumo => $"{consumo.IdConsumo},{consumo.IdEmpleado},{consumo.TipoConsumo},{consumo.FechaRegistro},{consumo.FormaRegistro}")
            );
        }

        private void ExportarArchivoCSV(string nombreArchivoBase, string cabeceras, IEnumerable<string> registros)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"{_queryConfiguracion.ObtenerConfiguracion().UbicacionCopiasSeguridad}{nombreArchivoBase}{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            using (var sw = new StreamWriter(saveFileDialog.FileName))
            {
                sw.WriteLine(cabeceras);
                foreach (var registro in registros)
                {
                    sw.WriteLine(registro);
                }
            }
        }

        private (string, string) SeleccionarArchivos()
        {
            string archivoEmpleados = SeleccionarArchivo("EMPLEADOS");
            string archivoConsumos = SeleccionarArchivo("CONSUMO");

            return (archivoEmpleados, archivoConsumos);
        }

        private string SeleccionarArchivo(string nombreInicial)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Multiselect = false,
                FileName = nombreInicial
            };

            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
        }

        private void ProcesarArchivos(string empleadoFilePath, string consumoFilePath)
        {
            ProcesarArchivoEmpleados(empleadoFilePath);
            ProcesarArchivoConsumos(consumoFilePath);
        }

        private void ProcesarArchivoEmpleados(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] empleadoData = sr.ReadLine().Split(',');
                    ProcesarEmpleado(empleadoData);
                }
            }
        }

        private void ProcesarEmpleado(string[] empleadoData)
        {
            int idEmpleado = int.Parse(empleadoData[0]);
            List<Empleado> listaEmpleados = new ListarEmpleado().Listar();
            var empleadoExistente = listaEmpleados.FirstOrDefault(e => e.IdEmpleado == idEmpleado);

            if (empleadoExistente == null)
            {
                InsertarEmpleado(empleadoData);
            }
            else
            {
                ActualizarEmpleadoSiNecesario(empleadoExistente, empleadoData);
            }
        }

        private void InsertarEmpleado(string[] empleadoData)
        {
            var nuevoEmpleado = new Empleado
            {
                NumeroDocumento = empleadoData[1],
                NombreCompleto = empleadoData[2],
                ZonaDeTrabajo = empleadoData[3],
                NumeroConsumos = int.Parse(empleadoData[4]),
                Estado = bool.Parse(empleadoData[6]),
                FechaRegistro = DateTime.Parse(empleadoData[7])
            };

            new QueryEmpleado().InsertarEmpleado(nuevoEmpleado.NumeroDocumento,nuevoEmpleado.NombreCompleto,nuevoEmpleado.ZonaDeTrabajo,nuevoEmpleado.NumeroConsumos,nuevoEmpleado.Estado,DateTime.Now);
        }

        private void ActualizarEmpleadoSiNecesario(Empleado empleadoExistente, string[] empleadoData)
        {
            if (empleadoExistente.NombreCompleto != empleadoData[2] ||
                empleadoExistente.ZonaDeTrabajo != empleadoData[3] ||
                empleadoExistente.NumeroConsumos != int.Parse(empleadoData[4]) ||
                empleadoExistente.Estado != bool.Parse(empleadoData[6]) ||
                empleadoExistente.FechaRegistro != DateTime.Parse(empleadoData[7]))
            {
                empleadoExistente.NombreCompleto = empleadoData[2];
                empleadoExistente.ZonaDeTrabajo = empleadoData[3];
                empleadoExistente.NumeroConsumos = int.Parse(empleadoData[4]);
                empleadoExistente.Estado = bool.Parse(empleadoData[6]);
                empleadoExistente.FechaRegistro = DateTime.Parse(empleadoData[7]);

                new QueryEmpleado().ActualizarEmpleadoCS(empleadoExistente.IdEmpleado,empleadoExistente.NumeroDocumento,empleadoExistente.NombreCompleto,empleadoExistente.ZonaDeTrabajo,empleadoExistente.NumeroConsumos,empleadoExistente.Estado,empleadoExistente.FechaRegistro);
            }
        }

        private void ProcesarArchivoConsumos(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] consumoData = sr.ReadLine().Split(',');
                    ProcesarConsumo(consumoData);
                }
            }
        }

        private void ProcesarConsumo(string[] consumoData)
        {
            int idConsumo = int.Parse(consumoData[0]);
            List<Consumo_CS> listaConsumos = new ListarConsumoCS().Listar();
            var consumoExistente = listaConsumos.FirstOrDefault(c => c.IdConsumo == idConsumo);

            if (consumoExistente == null)
            {
                AgregarConsumo(consumoData);
            }
        }

        private void AgregarConsumo(string[] consumoData)
        {
            new QueryConsumo().AgregarConsumoCS(
                int.Parse(consumoData[1]),
                consumoData[2],
                DateTime.Parse(consumoData[3]),
                bool.Parse(consumoData[4])
            );
        }

        private void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show($"{mensaje}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
