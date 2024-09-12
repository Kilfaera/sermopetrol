using System;
using System.Collections.Generic;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using ZXing;
using Consumos_Sermopetrol.Capa_Control.Entidades;

namespace Consumos_Sermopetrol.Capa_Vista.MicroForms
{
    public partial class ExportarPDFs : Form
    {
        Configuraciones configuracion = new Configuraciones();
        List<Bitmap> bitmapQR = new List<Bitmap>();
        List<string> textQR = new List<string>();
        List<iTextSharp.text.Image> paginas = new List<iTextSharp.text.Image>(); //Para añadir las imagenes al documento
        Zen.Barcode.Code128BarcodeDraw barcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
        int cantHojas;
        int loopCount = 1;
        int indicesImprimir = 0;
        public ExportarPDFs()
        {
            InitializeComponent();
        }
        public ExportarPDFs(List<Bitmap> list, List<string> texts)
        {
            bitmapQR = list;
            textQR = texts;
            cantHojas = bitmapQR.Count / 6;
            if (bitmapQR.Count % 6 != 0)
            {
                cantHojas += 1;
            }
            InitializeComponent();
        }
        private void limpiarImages() //Limpia las imagenes de los picturebox
        {
            pictureBox1.Image = pictureBox2.Image = pictureBox3.Image = pictureBox4.Image = pictureBox5.Image 
                = pictureBox6.Image = pictureBox7.Image = pictureBox8.Image = pictureBox9.Image = pictureBox10.Image 
                = pictureBox11.Image = pictureBox12.Image = pictureBox13.Image = pictureBox14.Image = pictureBox15.Image 
                = pictureBox16.Image = pictureBox17.Image = pictureBox18.Image = pictureBox19.Image = pictureBox20.Image = null;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text 
                = textBox8.Text = textBox9.Text = textBox10.Text = "";
        }
        private void ocultarTodo()
        {
            pictureBox1.Visible = pictureBox2.Visible = pictureBox3.Visible = pictureBox4.Visible
                = pictureBox5.Visible = pictureBox6.Visible = pictureBox7.Visible = pictureBox8.Visible
                = pictureBox9.Visible = pictureBox10.Visible = pictureBox11.Visible = pictureBox12.Visible
                = pictureBox13.Visible = pictureBox14.Visible = pictureBox15.Visible = pictureBox16.Visible
                = pictureBox17.Visible = pictureBox18.Visible = pictureBox19.Visible = pictureBox20.Visible
                = textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible
                = textBox6.Visible = textBox7.Visible = textBox8.Visible = textBox9.Visible = textBox10.Visible = false;
        }
        BarcodeReader barcodeReader = new BarcodeReader(); //Variable que permite leer codigos QR
        private void viewImages() //Proceso para organizar los QR automáticamente
        {
            indicesImprimir = loopCount * 10 - 10;
            pictureBox1.Visible = pictureBox2.Visible = textBox1.Visible = true;
            pictureBox1.Image = bitmapQR[indicesImprimir];
            textBox1.Text = textQR[indicesImprimir];
            pictureBox2.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
            indicesImprimir += 1;
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox3.Visible = pictureBox4.Visible = textBox2.Visible = true;
                pictureBox3.Image = bitmapQR[indicesImprimir];
                textBox2.Text = textQR[indicesImprimir];
                pictureBox4.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox5.Visible = pictureBox6.Visible = textBox3.Visible = true;
                pictureBox5.Image = bitmapQR[indicesImprimir];
                textBox3.Text = textQR[indicesImprimir];
                pictureBox6.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox7.Visible = pictureBox8.Visible = textBox4.Visible = true;
                pictureBox7.Image = bitmapQR[indicesImprimir];
                textBox4.Text = textQR[indicesImprimir];
                pictureBox8.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox9.Visible = pictureBox10.Visible = textBox5.Visible = true;
                pictureBox9.Image = bitmapQR[indicesImprimir];
                textBox5.Text = textQR[indicesImprimir];
                pictureBox10.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox11.Visible = pictureBox12.Visible = textBox6.Visible = true;
                pictureBox11.Image = bitmapQR[indicesImprimir];
                textBox6.Text = textQR[indicesImprimir];
                pictureBox12.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox13.Visible = pictureBox14.Visible = textBox7.Visible = true;
                pictureBox13.Image = bitmapQR[indicesImprimir];
                textBox7.Text = textQR[indicesImprimir];
                pictureBox14.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox15.Visible = pictureBox16.Visible = textBox8.Visible = true;
                pictureBox15.Image = bitmapQR[indicesImprimir];
                textBox8.Text = textQR[indicesImprimir];
                pictureBox16.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox17.Visible = pictureBox18.Visible = textBox9.Visible = true;
                pictureBox17.Image = bitmapQR[indicesImprimir];
                textBox9.Text = textQR[indicesImprimir];
                pictureBox18.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
            if (bitmapQR.Count > indicesImprimir)
            {
                pictureBox19.Visible = pictureBox20.Visible = textBox10.Visible = true;
                pictureBox19.Image = bitmapQR[indicesImprimir];
                textBox10.Text = textQR[indicesImprimir];
                pictureBox20.Image = barcodeDraw.Draw(barcodeReader.Decode(bitmapQR[indicesImprimir]).ToString(), 100);
                indicesImprimir += 1;
            }
        }
        Bitmap bitmap = new Bitmap(792, 958);
        Document doc = new Document(PageSize.LETTER);
        private void guardarImagenes() //Genera y guarda lo que se ve en el panel dentro de una lista de variables iTextSharp
        {
            int hojas = cantHojas;
            for (int i = 0; i < hojas; i++) //Función para organizar los QR automáticamente, generar y guardar las imagenes que sean necesarias, cada imagen corresponde a una pagina de pdf
            {
                viewImages();
                panel1.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel1.Width, panel1.Height));
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Bmp);
                paginas.Add(image);
                limpiarImages();
                ocultarTodo();
                if (cantHojas > 1)
                {
                    loopCount++;
                    cantHojas--;
                }
            }
            loopCount = 1;
            cantHojas = bitmapQR.Count / 10;
            if (bitmapQR.Count % 10 != 0)
            {
                cantHojas += 1;
            }
        }
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private void ExportarPDFs_Load(object sender, EventArgs e)
        {
            guardarImagenes(); //Genera y guarda las imagenes del panel que organiza los QR
            limpiarImages();
            this.WindowState = FormWindowState.Minimized;
            saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = "QRdocument" + DateTime.Now.ToString("-HH_mm-") + " " + DateTime.Now.ToString("-yyyy_MM_dd-");
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = configuracion.UbicacionPDF + saveFileDialog.FileName;
            if (File.Exists(saveFileDialog.FileName)) //Elimina el archivo si existe
            {
                File.Delete(saveFileDialog.FileName);
            }
            if (!Directory.Exists(configuracion.UbicacionPDF))
            {
                Directory.CreateDirectory(configuracion.UbicacionPDF);
            }
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create)); //Crea el docuento
            doc.Open();
            foreach (iTextSharp.text.Image imagen in paginas) //Modifica su contenido añadiendo las cada imagen en una pagina
            {
                imagen.ScaleToFit(580, 950);
                doc.NewPage();
                doc.Add(imagen);
            }
            doc.Close();
        }
    }
}
