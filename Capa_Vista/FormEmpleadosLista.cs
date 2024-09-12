using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormEmpleadosLista : Form
    {
        private Form1 mainForm;
        public FormEmpleadosLista(Form1 parentForm)
        {
            InitializeComponent();
            mainForm = parentForm; //Asignar el formulario principal
            ActualizarDataWriteView();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ActualizarDataWriteView()
        {
            try
            {
                dataGridView.Rows.Clear();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                foreach (Empleado item in ListaEmpleados)
                {
                    if (item.Estado)
                    {
                        dataGridView.Rows.Add(new object[] { 
                            Text = item.IdEmpleado.ToString(), item.NombreCompleto, item.NumeroDocumento, item.ZonaDeTrabajo, 
                            item.NumeroConsumos, item.Estado, item.FechaRegistro });

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR LA TABLA: " + e);
            }
        }
        private void iconButtonReiniciar_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonExportar_Click(object sender, EventArgs e)
        {
            mainForm.buttonExportarSideMenu_Click(sender, e);
            mainForm.buttonQrExportar_Click(sender, e);
        }
    }
}
