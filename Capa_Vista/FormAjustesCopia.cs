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
                if (string.IsNullOrEmpty(archivoEmpleado) || string.IsNullOrEmpty(archivoConsumo))
                {
                    throw new Exception("Los archivos seleccionados no son válidos.");
                }

                ProcesarArchivos(archivoEmpleado, archivoConsumo);
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
            var configuracion = _queryConfiguracion.ObtenerConfiguracion();
            var rutaArchivo = $"{configuracion.UbicacionCopiasSeguridad}{nombreArchivoBase}{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (string.IsNullOrWhiteSpace(configuracion.UbicacionCopiasSeguridad) || Path.GetInvalidPathChars().Any(c => rutaArchivo.Contains(c)))
            {
                MessageBox.Show("La ruta especificada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = rutaArchivo
            };

            MessageBox.Show($"Ruta de archivo: {saveFileDialog.FileName}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            bool primeraFila = true; // Para detectar la primera fila (encabezados)

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();

                    // Omitir la primera fila si es la de encabezados
                    if (primeraFila)
                    {
                        primeraFila = false;
                        continue;
                    }

                    string[] empleadoData = linea.Split(',');

                    // Verificación del número de columnas
                    if (empleadoData.Length != 7)
                    {
                        MessageBox.Show($"La fila '{linea}' no tiene el número correcto de columnas (se esperaban 7).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    // Procesar el empleado solo si pasa la verificación
                    ProcesarEmpleado(empleadoData);
                }
            }
        }


        private void ProcesarEmpleado(string[] empleadoData)
        {
            try
            {
                if (empleadoData.Length != 7)
                {
                    throw new FormatException("La cantidad de columnas en el archivo CSV no es la esperada.");
                }

                if (!int.TryParse(empleadoData[0], out int idEmpleado))
                {
                    throw new FormatException($"Error al convertir el IdEmpleado: {empleadoData[0]}");
                }

                if (!int.TryParse(empleadoData[4], out int numeroConsumos))
                {
                    throw new FormatException($"Error al convertir NumeroConsumos: {empleadoData[4]}");
                }

                if (!bool.TryParse(empleadoData[5].ToLower(), out bool estado))
                {
                    throw new FormatException($"Error al convertir Estado: {empleadoData[5]}");
                }


                if (!DateTime.TryParse(empleadoData[6], out DateTime fechaRegistro))
                {
                    throw new FormatException($"Error al convertir FechaRegistro: {empleadoData[7]}");
                }

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
            catch (FormatException fe)
            {
                MessageBox.Show($"Error de formato en el archivo CSV empleado: {fe.Message}", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado en empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            new QueryEmpleado().InsertarEmpleado(nuevoEmpleado.NumeroDocumento, nuevoEmpleado.NombreCompleto, nuevoEmpleado.ZonaDeTrabajo, nuevoEmpleado.NumeroConsumos, nuevoEmpleado.Estado, DateTime.Now);
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

                new QueryEmpleado().ActualizarEmpleadoCS(empleadoExistente.IdEmpleado, empleadoExistente.NumeroDocumento, empleadoExistente.NombreCompleto, empleadoExistente.ZonaDeTrabajo, empleadoExistente.NumeroConsumos, empleadoExistente.Estado, empleadoExistente.FechaRegistro);
            }
        }

        private void ProcesarArchivoConsumos(string filePath)
        {
            bool primeraFila = true; // Para detectar la primera fila (encabezados)

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();

                    // Omitir la primera fila si es la de encabezados
                    if (primeraFila)
                    {
                        primeraFila = false;
                        continue;
                    }

                    string[] consumoData = linea.Split(',');

                    // Verificación del número de columnas
                    if (consumoData.Length != 5)
                    {
                        MessageBox.Show($"La fila '{linea}' no tiene el número correcto de columnas (se esperaban 5).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    // Procesar el consumo solo si pasa la verificación
                    ProcesarConsumo(consumoData);
                }
            }
        }

        private void ProcesarConsumo(string[] consumoData)
        {
            try
            {
                if (consumoData.Length != 5)
                {
                    throw new FormatException("La cantidad de columnas en el archivo CSV de consumos no es la esperada.");
                }

                if (!int.TryParse(consumoData[0], out int idConsumo))
                {
                    throw new FormatException($"Error al convertir el IdConsumo: {consumoData[0]}");
                }

                if (!int.TryParse(consumoData[1], out int idEmpleado))
                {
                    throw new FormatException($"Error al convertir el IdEmpleado: {consumoData[1]}");
                }


                if (!DateTime.TryParse(consumoData[3], out DateTime fechaRegistro))
                {
                    throw new FormatException($"Error al convertir FechaRegistro: {consumoData[3]}");
                }

                if (!bool.TryParse(consumoData[4].ToLower(), out bool formaRegistro))
                {
                    throw new FormatException($"Error al convertir FormaRegistro: {consumoData[4]}");
                }

                List<Consumo_CS> listaConsumos = new ListarConsumoCS().Listar();
                var consumoExistente = listaConsumos.FirstOrDefault(c => c.IdConsumo == idConsumo);

                if (consumoExistente == null)
                {
                    AgregarConsumo(consumoData);
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show($"Error de formato en el archivo CSV consumo: {fe.Message}", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado en consumo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
