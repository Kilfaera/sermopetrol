using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;

namespace Consumos_Sermopetrol.Capa_Negocio
{
    internal class Funciones_frecuentes
    {
        private void imprimir(object sender, PrintPageEventArgs e)
        {  
            /*
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
            bitmap = writer.Write("Ticket de " + TC + " canjeado en " + DateTime.Now.ToString("yyyy/MMMM/dddd-dd") +
                " a las " + DateTime.Now.ToString("hh:mm:ss-tt") + " para el empleado " + NC + " C.C." + ND);
            e.Graphics.DrawImage(bitmap, (e.PageBounds.Width - 50) / 3 + 8, 255, 150, 150);
       */ }
    }
}
