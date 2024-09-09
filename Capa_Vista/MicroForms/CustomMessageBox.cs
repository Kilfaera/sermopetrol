using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista.MicroForms
{
    public partial class CustomMessageBox : Form
    {
        public enum Result { Imprimir, Eliminar, Cancelar }
        public Result Resultado { get; private set; }

        public CustomMessageBox(string mensaje)
        {
            InitializeComponent();
            label1.Text = mensaje;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Resultado = Result.Imprimir;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Resultado = Result.Eliminar;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Resultado = Result.Cancelar;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
