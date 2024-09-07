using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Http.Filters;
using System.Windows.Forms;
using Accord.Video;
using Accord.Video.DirectShow;

namespace AppConsumo
{
    internal class GeneralItems
    {
        FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice CaptureDevice;
        PictureBox picture;
        public GeneralItems()
        {
        }
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
    }
}
