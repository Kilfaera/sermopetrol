using AppConsumo.Controlador;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Consumos_Sermopetrol.Capa_Vista
{
    public partial class FormEmpleadosLista : Form
    {
        Funciones_frecuentes generalItems = new Funciones_frecuentes();
        private Form1 mainForm;
        public FormEmpleadosLista(Form1 parentForm)
        {
            InitializeComponent();
            mainForm = parentForm; //Asignar el formulario principal
            ActualizarDataWriteView();
            autocompletar();
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        void autocompletar()
        {
            try
            {
                // Crear una colección de cadenas para las coincidencias de autocompletado
                AutoCompleteStringCollection coincidencias = new AutoCompleteStringCollection();
                AutoCompleteStringCollection coincidenciasEmpleado = new AutoCompleteStringCollection();
                // Obtener la lista de consumos
                List<Empleado> listaEmpleado = new ListarEmpleado().Listar();

                // Agregar los números de documento de los empleados a las coincidencias
                foreach (Empleado item in listaEmpleado)
                {
                    coincidenciasEmpleado.Add(item.ZonaDeTrabajo);
                    coincidenciasEmpleado.Add(item.NumeroDocumento);
                    coincidenciasEmpleado.Add(item.NombreCompleto);
                }

                textBoxCedula.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  // Modo de sugerencia y completar
                textBoxCedula.AutoCompleteSource = AutoCompleteSource.CustomSource;  // Fuente personalizada
                textBoxCedula.AutoCompleteCustomSource = coincidenciasEmpleado;
                
            }
            catch (Exception ex)
            {
                generalItems.sonido(false);
                MessageBox.Show("Error al configurar el autocompletado: " + ex.Message);
            }
        }
        private void ActualizarDataWriteView()
        {
            try
            {
                dataGridView.Rows.Clear();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                foreach (Empleado item in ListaEmpleados)
                {

                    string Estado = item.Estado == false ? "Inactivo" : "Activo";
                    dataGridView.Rows.Add(new object[] {
                    Text = item.IdEmpleado.ToString(), item.NombreCompleto, item.NumeroDocumento, item.ZonaDeTrabajo,
                    item.NumeroConsumos, item.Estado, item.FechaRegistro });


                }
            }
            catch (Exception e)
            {
                generalItems.sonido(false);
                MessageBox.Show("ERROR AL ACTUALIZAR LA TABLA: " + e);
            }
        }
        private void iconButtonReiniciar_Click(object sender, EventArgs e)
        {
            ActualizarDataWriteView();
        }

        private void iconButtonExportar_Click(object sender, EventArgs e)
        {
            mainForm.buttonExportarSideMenu_Click(sender, e);
            mainForm.buttonQrExportar_Click(sender, e);
        }

        private void textBoxCedula_TextChanged(object sender, EventArgs e)
        {
            Flitrado();
        }

        private void Flitrado()
        {


            try
            {

                dataGridView.Rows.Clear();
                List<Empleado> ListaEmpleados = new ListarEmpleado().Listar();
                foreach (Empleado item in ListaEmpleados)
                {
                    if (item.NumeroDocumento.Contains(textBoxCedula.Text) || item.ZonaDeTrabajo.Contains(textBoxCedula.Text) || item.NombreCompleto.Contains(textBoxCedula.Text) && item.Estado != false)
                    {
                        string Estado = item.Estado == false ? "Inactivo" : "Activo";
                        dataGridView.Rows.Add(new object[] {
                    item.IdEmpleado,
                    item.NombreCompleto,
                    item.NumeroDocumento,
                    item.ZonaDeTrabajo,
                    item.NumeroConsumos,
                    Estado,
                    item.FechaRegistro
                    });
                    }
                }
            }
            catch (Exception a)
            {
                generalItems.sonido(false);
                MessageBox.Show("ERROR AL APLICAR LOS FILTROS: " + a);
            }

        }

        private void iconButtonEditar_Click(object sender, EventArgs e)
        {
            mainForm.buttonModificarEmpleados_Click(sender, e);
        }

        private void iconButtonAgregar_Click(object sender, EventArgs e)
        {
            mainForm.buttonAgregarEmpleados_Click(sender, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
