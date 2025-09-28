using Accord.Video;
using Accord.Video.DirectShow;
using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using static Consumos_Sermopetrol.Capa_Negocio.Funciones_frecuentes;


namespace Consumos_Sermopetrol.Capa_Negocio
{
    internal class Funciones_frecuentes
    {
        QueryConfiguracion query = new QueryConfiguracion();
        public DateTime FR;
        SoundPlayer player;
        #region ImpresoraTermica
        BarcodeReader barcodeReader = new BarcodeReader(); //Variable que permite leer codigos QR
        Result result;
        public PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog preview = new PrintPreviewDialog();
        private readonly Font cal8 = new Font("Calibri", 8, FontStyle.Bold);
        private readonly Font cal10 = new Font("Calibri", 10, FontStyle.Bold);
        private readonly StringFormat right = new StringFormat { Alignment = StringAlignment.Far };
        private readonly StringFormat center = new StringFormat { Alignment = StringAlignment.Center };
        private readonly Image logo = Properties.Resources.logo_ico;
        private Bitmap bitmap = null;
        private DatosImpresion datosImpresion;
        public class DatosImpresion
        {
            public string TC { get; set; }
            public string NC { get; set; }
            public string ND { get; set; }
            public string ZT { get; set; }
            public DateTime FR { get; set; }
        }
      
        public void iniciarImpresion(object sender, PrintEventArgs e)
        {
            PageSettings pageSettings = new PageSettings
            {
                PaperSize = new PaperSize("Custom", 250, 410)
            };
            doc.DefaultPageSettings = pageSettings;
        }

        public void imprimir(object sender, PrintPageEventArgs e)
        {
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            int centermargin = doc.DefaultPageSettings.PaperSize.Width / 2;

            e.Graphics.DrawImage(logo, (e.PageBounds.Width - 50) / 3 + 8, 5, 150, 150);
            e.Graphics.DrawString("TICKET DE " + datosImpresion.TC, cal10, Brushes.Black, centermargin + 20, 155, center);
            e.Graphics.DrawString(datosImpresion.FR.ToString("yyyy/MMMM/dddd-dd"), cal10, Brushes.Black, centermargin + 20, 170, center);
            e.Graphics.DrawString(datosImpresion.FR.ToString("hh:mm:ss tt"), cal10, Brushes.Black, centermargin + 20, 185, center);
            e.Graphics.DrawString(datosImpresion.NC, cal8, Brushes.Black, centermargin + 20, 210, center);
            e.Graphics.DrawString(datosImpresion.ND, cal8, Brushes.Black, centermargin + 20, 225, center);
            e.Graphics.DrawString(datosImpresion.ZT, cal8, Brushes.Black, centermargin + 20, 240, center);

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 150,
                    Width = 150,
                    Margin = 1,
                }
            };
            bitmap = writer.Write("Ticket de " + datosImpresion.TC + " canjeado en " + datosImpresion.FR.ToString("yyyy/MMMM/dddd-dd") +
            " a las " + datosImpresion.FR.ToString("hh:mm:ss-tt") + " para el empleado " + datosImpresion.NC + " C.C." + datosImpresion.ND);
            e.Graphics.DrawImage(bitmap, (e.PageBounds.Width - 50) / 3 + 8, 255, 150, 150);
        }

        public void imprimirSeleccion(DatosImpresion datos)
        {
            this.datosImpresion = datos;
            sonido(true);
            doc.Print();
        }
       
        #endregion

        #region Camara
        FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice CaptureDevice;
        PictureBox picture;

        public void inicialziar(int index, PictureBox pictureBox)
        {
            try
            {
                picture = pictureBox;
                closeCam();
                CaptureDevice = new VideoCaptureDevice(filterInfoCollection[index].MonikerString); //Inicializa la camara seleccionada
                CaptureDevice.NewFrame += videoCaptureDevice_NewFrame; //Guarda lo que ve la camara en el picturebox
                resolucion(CaptureDevice, pictureBox); //Cambia la resolución de la nueva camara
                CaptureDevice.Start(); //Prende la camara
            }
            catch (Exception)
            {
                sonido(false);
                MessageBox.Show("ERROR FATAL AL INICIAR LA CAMARA. REINICIE EL PROGRAMA.");
            }
        }
        private void resolucion(VideoCaptureDevice device, PictureBox pictureBox) //Función que modifica la resolución de la camara para que tenga el tamaño más parecido al del picturebox
        {
            var resolution = CaptureDevice.VideoCapabilities; //Variable para modificar las caracteristicas de la camara
            double relacionAspectoPictureBox = (double)pictureBox.Width / pictureBox.Height; //Obtiene la relación de aspecto de la camara
            VideoCapabilities camResolution = null; //Variable que guardará el ajuste de la resolución
            //Formula para obtener el mejor tamaño posible(
            double mejorDiferenciaRelacionAspecto = double.MaxValue;
            foreach (var resolucion in resolution)
            {
                double relacionAspectoResolucion = (double)resolucion.FrameSize.Width / resolucion.FrameSize.Height;
                double diferenciaRelacionAspecto = Math.Abs(relacionAspectoResolucion - relacionAspectoPictureBox);
                if (diferenciaRelacionAspecto < mejorDiferenciaRelacionAspecto)
                {
                    camResolution = resolucion;
                    mejorDiferenciaRelacionAspecto = diferenciaRelacionAspecto;
                }
            }
            //)
            //Cambia la resolución de la camara
            device.VideoResolution = camResolution;
        }
        private void videoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                picture.Image = (Bitmap)eventArgs.Frame.Clone();
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {
                sonido(false);
                MessageBox.Show("ERROR. REINICIE EL PROGRAMA.");
            }
        }

        public Bitmap ResizeImage(Bitmap imagen, Size tamañoDeseado)
        {
            try
            {
                Bitmap imagenRedimensionada = new Bitmap(tamañoDeseado.Width, tamañoDeseado.Height); // Crea una nueva imagen del tamaño deseado
                using (Graphics gr = Graphics.FromImage(imagenRedimensionada))
                {
                    gr.DrawImage(imagen, 0, 0, tamañoDeseado.Width, tamañoDeseado.Height); // Dibuja la imagen original en la nueva imagen con el tamaño deseado
                }
                return imagenRedimensionada;
            }
            catch (Exception)
            {
                sonido(false);
                MessageBox.Show("ERROR. REINICIE EL PROGRAMA.");
            }
            return null;
        }
        public void startCam(int index)
        {
            try
            {
                closeCam();
                CaptureDevice = new VideoCaptureDevice(filterInfoCollection[index].MonikerString); //Inicializa la camara seleccionada
                CaptureDevice.NewFrame += videoCaptureDevice_NewFrame; //Guarda lo que ve la camara en el picturebox
                resolucion(CaptureDevice, picture); //Cambia la resolución de la nueva camara
                CaptureDevice.Start(); //Prende la camara
            }
            catch (Exception)
            {
                sonido(false);
                MessageBox.Show("ERROR FATAL AL INICIAR LA CAMARA. REINICIE EL PROGRAMA.");
            }
        }
        public void closeCam() //Función para cerrar la camara
        {
            try
            {
                if (CaptureDevice != null && CaptureDevice.IsRunning)
                {
                    CaptureDevice.Stop();
                    CaptureDevice = null;
                }
            }
            catch (Exception)
            {
                sonido(false);
                MessageBox.Show("ERROR. REINICIE EL PROGRAMA.");
            }
        }
        List<string> cams = new List<string>();
        public List<string> getCams()
        {
            try
            {
                foreach (Accord.Video.DirectShow.FilterInfo filter in filterInfoCollection)
                {
                    cams.Add(filter.Name); //Añade el nombre de las camaras instaladas al combobox
                }
                return cams;
            }
            catch (Exception)
            {
                sonido(false);
                MessageBox.Show("ERROR. NO SE DETECTARON CÁMARAS.");
            }
            return null;
        }


        #endregion

        #region Consumos

        public void Confirmacion(string ND,bool impri)
        {
            List<Consumo> listaConsumo = new ListarConsumo().Listar();
            string _tipoConsumo;
            bool consumoRepetido = false; // Variable para controlar si el consumo ya existe

            // Determinar el tipo de consumo según la hora actual
            if (DateTime.Now.Hour < 9) { _tipoConsumo = "Desayuno"; }
            else if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 15) { _tipoConsumo = "Almuerzo"; }
            else { _tipoConsumo = "Cena"; }

            // Recorrer la lista de consumos para verificar si ya existe
            foreach (Consumo item in listaConsumo)
            {
                if (item.DocumentoEmpleado == ND && item.TipoConsumo == _tipoConsumo && item.FechaRegistro.Date == DateTime.Now.Date && item.DocumentoEmpleado != "0000")
                {
                    consumoRepetido = true; // Ya existe el consumo, no se debe agregar
                    break; // Salir del bucle al encontrar una repetición
                }
            }

            // Si no se encontró un consumo repetido, agregar el nuevo consumo
            if (!consumoRepetido)
            {
                insertarConsumoConfirmadoAutomatico(_tipoConsumo, ND, true,impri); // Inserta el consumo si no está repetido
            }
        }
        bool encontrado = false;
        public void insertarConsumoConfirmadoAutomatico(string TC, string ND, bool FR,bool impri)
        {
            
            try
            {
                encontrado = false;
                QueryConsumo consumo = new QueryConsumo();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                 
                foreach (Empleado item in ListaEmpleados)
                {
                    if (item.NumeroDocumento == ND && item.Estado)
                    {
                        QueryEmpleado emm = new QueryEmpleado();
                        consumo.InsertarConsumo(item.IdEmpleado, TC, FR);
                        emm.IncrementarConsumo(item.IdEmpleado);
                        
                            var datos = new DatosImpresion
                                {
                                    TC = TC,
                                    NC = item.NombreCompleto,
                                    ND = item.NumeroDocumento,
                                    ZT = item.ZonaDeTrabajo,
                                    FR = DateTime.Now
                                };
                            imprimirSeleccion(datos);
                        
                        encontrado = true;
                        /*pictureBox2.Image = Image.FromFile(item.Imagen.ToString());
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        BusquedaDocumento.Text = ""*/
                        return; // Salir del bucle al encontrar un empleado válido
                    }
                }


            }
            catch (Exception e)
            {
                sonido(false);
                MessageBox.Show("ERROR AL INGRESAR EL CONSUMO: " + e);
            }
        }
        public void insertarConsumoConfirmadoManual(string ND, string TC, DateTime FR, bool impri)
        {

            int Hora;
            encontrado = false;
            QueryConsumo consumo = new QueryConsumo();
            List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
            if (TC == "Desayuno") { Hora = 6; }
            else if (TC == "Almuerzo") { Hora = 12; }
            else { Hora = 18; }
            FR = new DateTime(FR.Year, FR.Month, FR.Day, Hora, FR.Minute, FR.Second);
            foreach (Empleado item in ListaEmpleados)
            {
                if (item.NumeroDocumento == ND && item.Estado)
                {
                    QueryEmpleado emm = new QueryEmpleado();
                    consumo.AgregarConsumoCS(item.IdEmpleado, TC, FR, false);
                    emm.IncrementarConsumo(item.IdEmpleado);
                   var datos = new DatosImpresion
                        {
                            TC = TC,
                            NC = item.NombreCompleto,
                            ND = item.NumeroDocumento,
                            ZT = item.ZonaDeTrabajo,
                            FR = DateTime.Now
                        };
                            imprimirSeleccion(datos);
                       
                    encontrado = true;
                    /*pictureBox2.Image = Image.FromFile(item.Imagen.ToString());
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    BusquedaDocumento.Text = ""*/
                    return; // Salir del bucle al encontrar un empleado válido
                }
            }
        }

        #endregion
        #region Sonido
        public void sonido(bool select) //Función para reproducir sonido
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string soundPath = select ? Path.Combine(basePath, "Recursos", "alert.wav") : Path.Combine(basePath, "Recursos", "error.wav");

                player = new SoundPlayer(soundPath); //Variable que permite reproducir el audio proporcionado
                player.Play(); //Reproduce el audio
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL REPRODUCIR EL SONIDO: " + e);
            }
        }
        #endregion
        #region Empleados
        public void insertarempleado(string ND, string NC, string ZT, Bitmap bitmap)
        {
            try
            {
                if (string.IsNullOrEmpty(ND) || string.IsNullOrEmpty(NC) || string.IsNullOrEmpty(ZT))
                {
                    sonido(false);
                    MessageBox.Show("Hay campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la configuración para la ruta de la imagen
                Configuraciones configuracion = query.ObtenerConfiguracion();
                string rutaImagen = configuracion.UbicacionImagenes; // Ruta donde se almacenarán las imágenes

                QueryEmpleado em = new QueryEmpleado();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                Empleado empleadoExistente = ListaEmpleados.FirstOrDefault(emp => emp.NumeroDocumento == ND);

                if (empleadoExistente != null)
                {
                    if (empleadoExistente.Estado)
                    {
                        MessageBox.Show("El empleado ya existe y está activo.", "Empleado Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show("El empleado ya existe pero está inactivo. ¿Desea reactivarlo?", "Reactivar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        em.CambiarEstadoEmpleado(empleadoExistente.IdEmpleado, true); // Reactivar al empleado
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    em.InsertarEmpleado(ND, NC, ZT, 0, true, DateTime.Now);
                }

                // Guardar la imagen solo si el bitmap no es null
                if (bitmap != null)
                {
                    // Crear el nombre completo de la imagen con el número de documento
                    string nombreImagen = $"{rutaImagen}\\{ND}.png";

                    // Guardar la imagen en la ruta especificada
                    bitmap.Save(nombreImagen, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                sonido(false);
                MessageBox.Show("ERROR AL REGISTRAR: " + ex.Message);
            }
        }
        public string ObtenerRutaImagen(string numeroDocumento)
        {
            try
            {
                Configuraciones configuracion = query.ObtenerConfiguracion(); // Obtener la ruta configurada
                string rutaImagen = configuracion.UbicacionImagenes;

                // Ruta donde se almacenan las imágenes
                if (System.IO.File.Exists($"{rutaImagen}\\{numeroDocumento}.png")) // Verificar si la imagen existe
                {
                    return $"{rutaImagen}\\{numeroDocumento}.png"; // Cargar la imagen en el PictureBox
                }


            }
            catch (Exception ex) {
                return null;
            }
            return null;
             // Devolver la ruta completa de la imagen
        }

        public void actualizarempleado(string ND, string NC, string ZT, Bitmap bitmap)
        {
            try
            {
                if (string.IsNullOrEmpty(ND) || string.IsNullOrEmpty(NC) || string.IsNullOrEmpty(ZT))
                {
                    MessageBox.Show("Hay campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la configuración para la ruta de la imagen
                Configuraciones configuracion = query.ObtenerConfiguracion();
                string rutaImagen = configuracion.UbicacionImagenes; // Ruta donde se almacenarán las imágenes

                QueryEmpleado em = new QueryEmpleado();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                
                foreach(Empleado empleado in ListaEmpleados)
                {
                    if (empleado.NumeroDocumento == ND)
                    {
                        em.ActualizarEmpleado(empleado.IdEmpleado, ND, NC, ZT);
                        break;
                    }
                }
                // Insertar o actualizar la información del empleado
              

                // Guardar la imagen solo si el bitmap no es null
                if (bitmap != null)
                {

                    // Crear el nombre completo de la imagen con el número de documento
                    string nombreImagen = $"{rutaImagen}\\{ND}.png";
                    if (System.IO.File.Exists(nombreImagen))
                    {
                        // Eliminar la imagen existente
                        System.IO.File.Delete(nombreImagen);
                    }
                    using (Bitmap newBitmap = new Bitmap(bitmap))
                    {
                     
                            // Guardar la imagen como nueva
                            newBitmap.Save(nombreImagen, System.Drawing.Imaging.ImageFormat.Png);
                        
                    }
                }
                MessageBox.Show("EMPLEADO MODIFICADO CON ÉXITO");
            }
            catch (Exception ex)
            {
                sonido(false);
                MessageBox.Show("ERROR AL REGISTRAR: " + ex.Message);
            }
        }

        public string SolicitarContraseña()
        {
            // Crear un nuevo Form para solicitar la contraseña
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            string password = "srmpetrol2024admin";

            form.Text = "Contraseña";
            label.Text = "Ingrese la contraseña:";
            textBox.PasswordChar = '*'; // Para ocultar la contraseña

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancelar";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            // Mostrar el formulario como cuadro de diálogo
            if (form.ShowDialog() == DialogResult.OK)
            {
                password = textBox.Text;
            }
            else
            {
                return"";
            }

            return password;
        }

        internal void eliminarempleado(string text)
        {
            QueryEmpleado em = new QueryEmpleado();
            List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
            foreach (Empleado empleado in ListaEmpleados)
            {
                if (empleado.NumeroDocumento == text)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar al empleado?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        em.CambiarEstadoEmpleado(empleado.IdEmpleado, false); // Cambiar el estado del empleado a inactivo
                        MessageBox.Show("EMPLEADO ELIMINADO CON ÉXITO.");
                    }
                    break;
                }
            }
        }

        public void Backup(string rutaBackup)
        {
            try
            {


                // Verificar que la ruta no esté vacía
                if (string.IsNullOrEmpty(rutaBackup))
                {
                    MessageBox.Show("Por favor, selecciona una ruta válida para guardar la copia de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nombre del archivo de respaldo
                string fileName = $"Copia de seguridad {DateTime.Now:dd 'de' MMMM 'del' yyyy}.sql";
                string filePath = Path.Combine(rutaBackup, fileName);

                // Comando para exportar la base de datos
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=consumoempleado;uid=root;password=12345678;"
))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;

                            // Exportar la base de datos a un archivo SQL
                            mb.ExportInfo.AddCreateDatabase = true;
                            mb.ExportToFile(filePath);
                            MessageBox.Show("Copia de seguridad completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la copia de seguridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            public void RestaurarBackup(string rutaBackup)
        {
            try
            {
                // Verificar que la ruta no esté vacía
                if (string.IsNullOrEmpty(rutaBackup))
                {
                    MessageBox.Show("Por favor, selecciona una ruta válida para restaurar la copia de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Comando para restaurar la base de datos
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;password=12345678;"))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;

                            // Restaurar la base de datos desde un archivo SQL
                            mb.ImportFromFile(rutaBackup);
                            MessageBox.Show("Restauración de la copia de seguridad completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la copia de seguridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }
        #endregion
    }
}

