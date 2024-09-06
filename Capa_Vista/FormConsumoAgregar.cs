using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Control;
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
    public partial class FormConsumoAgregar : Form
    {
        public FormConsumoAgregar()
        {
            InitializeComponent();
            ActualizarlistaConsumo();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
        public void ActualizarlistaConsumo()
        {
            try
            {
                comboBoxConsumo.Text = comboBoxConsumo.Items[0].ToString();
                dataGridView.Rows.Clear();
                List<Consumo> listaConsumo = new ListarConsumo().Listar();
                foreach (Consumo item in listaConsumo)
                {
                    if (item.FechaRegistro.Date == DateTime.Now.Date)
                    {
                        // Verificar si FormaRegistro es 0 o 1 para mostrar el texto adecuado
                        string formaRegistro = item.FormaRegistro == false ? "Manual" : "Automático";

                        // Agregar la fila al DataGridView
                        dataGridView.Rows.Add(new object[]
                        {
                    item.NombreEmpleado,
                    item.DocumentoEmpleado,
                    item.ZonaTrabajoEmpleado,
                    item.TipoConsumo,
                    item.FechaRegistro,
                    formaRegistro
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR EL CONSUMO: " + e.Message);
            }
        }

        private void iconButtonHideLeftSidePanel_Click(object sender, EventArgs e)
        {
            if (panelDiagramas.Visible)
            {
                panelDiagramas.Visible = false;
            } else { panelDiagramas.Visible = true; }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
