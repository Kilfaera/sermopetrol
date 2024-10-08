﻿using Accord.Video;
using Accord.Video.DirectShow;
using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Media;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;


namespace Consumos_Sermopetrol.Capa_Negocio
{
    internal class Funciones_frecuentes
    {
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
        public void imprimir(object sender, PrintPageEventArgs e, string TC, DateTime FR,string NC,string ND,string ZT)
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
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy/MMMM/dddd-dd"), cal10, Brushes.Black, centermargin + 20, 170, center);
            e.Graphics.DrawString(DateTime.Now.ToString("hh:mm:ss tt"), cal10, Brushes.Black, centermargin + 20, 185, center);

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
                        doc.BeginPrint += new PrintEventHandler(iniciarImpresion);
                        doc.PrintPage += (s, ev) => imprimir(s, ev, TC, DateTime.Now, item.NombreCompleto, item.NumeroDocumento, item.ZonaDeTrabajo); break;
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
    }
}
