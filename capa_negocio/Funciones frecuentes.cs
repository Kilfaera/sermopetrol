using Accord.Video;
using Accord.Video.DirectShow;
using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;


namespace Consumos_Sermopetrol.Capa_Negocio
{
    internal class Funciones_frecuentes
    {
        QueryConfiguracion query = new QueryConfiguracion();
        string TC, NC, ND, ZT;
        public DateTime FR;
        SoundPlayer player;
        #region ImpresoraTermica
        BarcodeReader barcodeReader = new BarcodeReader(); //Variable que permite leer codigos QR
        Result result;
        public PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog preview = new PrintPreviewDialog();
        public void iniciarImpresion(object sender, PrintEventArgs e)
        {
            PageSettings pageSettings = new PageSettings();
            pageSettings.PaperSize = new PaperSize("Custom", 250, 410);
            doc.DefaultPageSettings = pageSettings;
        }
        Bitmap bitmap = null;
        public void imprimir(object sender, PrintPageEventArgs e)
        {
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            Font cal8 = new Font("Calibri", 8, FontStyle.Bold);
            Font cal10 = new Font("Calibri", 10, FontStyle.Bold);

            int leftmargin = doc.DefaultPageSettings.Margins.Left;
            int centermargin = doc.DefaultPageSettings.PaperSize.Width / 2;
            int rightmargin = doc.DefaultPageSettings.PaperSize.Width;

            StringFormat right = new StringFormat();
            StringFormat center = new StringFormat();
            right.Alignment = StringAlignment.Far;
            center.Alignment = StringAlignment.Center;

            string line = "***************************************************************************************";

            System.Drawing.Image logo = Properties.Resources.logo1_sf;
            e.Graphics.DrawImage(logo, (e.PageBounds.Width - 50) / 3 + 8, 5, 150, 150);

            e.Graphics.DrawString("TICKET DE " + TC, cal10, Brushes.Black, centermargin + 20, 155, center);
            e.Graphics.DrawString(FR.ToString("yyyy/MMMM/dddd-dd"), cal10, Brushes.Black, centermargin + 20, 170, center);
            e.Graphics.DrawString(FR.ToString("hh:mm:ss tt"), cal10, Brushes.Black, centermargin + 20, 185, center);

            e.Graphics.DrawString(NC, cal8, Brushes.Black, centermargin + 20, 210, center);
            e.Graphics.DrawString(ND, cal8, Brushes.Black, centermargin + 20, 225, center);
            e.Graphics.DrawString(ZT, cal8, Brushes.Black, centermargin + 20, 240, center);

            var writer = new BarcodeWriter() //Variable que permite generar y confgurar el codigo QR
            {
                Format = BarcodeFormat.QR_CODE, //Formato QR
                Options = new EncodingOptions() //Personalización del codigo
                {
                    Height = 150,
                    Width = 150,
                    Margin = 1,
                }
            };
            bitmap = writer.Write("Ticket de " + TC + " canjeado en " + FR.ToString("yyyy/MMMM/dddd-dd") +
                " a las " + FR.ToString("hh:mm:ss-tt") + " para el empleado " + NC + " C.C." + ND);
            e.Graphics.DrawImage(bitmap, (e.PageBounds.Width - 50) / 3 + 8, 255, 150, 150);
            ///////////////////

        }
        public void imprimirSeleccion(string TC, string NC, string ND, string ZT, DateTime FR)
        {
            this.TC = TC;
            this.NC = NC;
            this.ND = ND;
            this.ZT = ZT;
            this.FR = FR;
            doc.BeginPrint += new PrintEventHandler(iniciarImpresion);
            doc.PrintPage += new PrintPageEventHandler(imprimir);
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
                MessageBox.Show("ERROR. NO SE DETECTARON CÁMARAS.");
            }
            return null;
        }


        #endregion

        #region Consumos

        public void Confirmacion(string ND)
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
                insertarempleadoconfirmado(_tipoConsumo, ND, true); // Inserta el consumo si no está repetido
            }
        }
        bool encontrado = false;
        public void insertarempleadoconfirmado(string TC, string ND, bool FR)
        {
            this.TC = TC;
            this.ND = ND;
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
                        imprimirSeleccion(TC, NC, ND, ZT, DateTime.Now);
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
                MessageBox.Show("ERROR AL INGRESAR EL CONSUMO: " + e);
            }
        }
        public void insertarempleadoconfirmadoM(string ND, string TC, DateTime FR)
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
                if (select)
                {
                    player = new SoundPlayer("C:/Program Files/STL AppConsumo/Resources/alert.wav"); //Variable que permite reproducir el audio proporcionado
                }
                else
                {
                    player = new SoundPlayer("C:/Program Files/STL AppConsumo/Resources/error.wav"); //Variable que permite reproducir el audio proporcionado
                }
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
                MessageBox.Show("ERROR AL REGISTRAR: " + ex.Message);
            }
        }
        public string ObtenerRutaImagen(string numeroDocumento)
        {
            Configuraciones configuracion = query.ObtenerConfiguracion(); // Obtener la ruta configurada
            string rutaImagen = configuracion.UbicacionImagenes; // Ruta donde se almacenan las imágenes
            return $"{rutaImagen}\\{numeroDocumento}.png"; // Devolver la ruta completa de la imagen
        }



        #endregion
    }
}

