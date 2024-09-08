using Consumos_Sermopetrol.Capa_Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumos_Sermopetrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            InitializeComponent();
            openChildForm(new FormConsumoAgregar());
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region SubMenus
        private void hideSubMenu(Panel panel)
        {
            if (panel.Visible == true)
            {
                panel.Visible = false;
            }
        }
        private void showSubMenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                panel.Visible = true;
            }
        }
        private void hideAllSubMenus()
        {
            panelSubmenuAjustes.Visible = panelSubmenuConsumo.Visible = panelSubmenuEmpleados.Visible = panelSubmenuExportar.Visible = false;
        }
        private void removeAllButtonBackColor()
        {
            buttonAgregarConsumo.BackColor = buttonAgregarEmpleados.BackColor = buttonAjustesSideMenu.BackColor = buttonCloseBorderStyle.BackColor =
                buttonConsumoSideMenu.BackColor = buttonCopiaAjustes.BackColor = buttonEmpleadosSideMenu.BackColor = buttonEstadisticasConsumo.BackColor =
                buttonExcelExportar.BackColor = buttonExportarSideMenu.BackColor = buttonListaEmpleados.BackColor =
                buttonMinimizeBorderStyle.BackColor = buttonModificarEmpleados.BackColor = buttonQrExportar.BackColor = buttonRutasAjustes.BackColor = Color.Transparent;
        }
        #endregion
        #region BorderStyle
        private void buttonCloseBorderStyle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizeBorderStyle_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Consumo
        private void buttonConsumoSideMenu_Click(object sender, EventArgs e)
        {
            if (panelSubmenuConsumo.Visible)
            {
                hideSubMenu(panelSubmenuConsumo);
            }
            else
            {
                hideAllSubMenus();
                showSubMenu(panelSubmenuConsumo);
            }
        }
        private void buttonAgregarConsumo_Click(object sender, EventArgs e)
        {
            openChildForm(new FormConsumoAgregar());
            buttonAgregarConsumo.BackColor = Color.White;
        }
        private void buttonEstadisticasConsumo_Click(object sender, EventArgs e)
        {
            openChildForm(new FormConsumoEstadisticas());
            buttonEstadisticasConsumo.BackColor = Color.White;
        }
        #endregion
        #region Empleados
        private void buttonEmpleadosSideMenu_Click(object sender, EventArgs e)
        {
            if (panelSubmenuEmpleados.Visible)
            {
                hideSubMenu(panelSubmenuEmpleados);
            }
            else
            {
                hideAllSubMenus();
                showSubMenu(panelSubmenuEmpleados);
            }
        }
        private void buttonModificarEmpleados_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEmpleadosModificar());
            buttonModificarEmpleados.BackColor = Color.White;
        }
        private void buttonListaEmpleados_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEmpleadosLista());
            buttonListaEmpleados.BackColor = Color.White;
        }
        private void buttonAgregarEmpleados_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEmpleadosAgregar());
            buttonAgregarEmpleados.BackColor= Color.White;
        }
        #endregion
        #region Exportar
        private void buttonExportarSideMenu_Click(object sender, EventArgs e)
        {
            if (panelSubmenuExportar.Visible)
            {
                hideSubMenu(panelSubmenuExportar);
            }
            else
            {
                hideAllSubMenus();
                showSubMenu(panelSubmenuExportar);
            }
        }
        private void buttonExcelExportar_Click(object sender, EventArgs e)
        {
            openChildForm(new FormExportarExcel());
            buttonExcelExportar.BackColor = Color.White;
        }
        private void buttonQrExportar_Click(object sender, EventArgs e)
        {
            openChildForm(new FormExportarQr());
            buttonQrExportar.BackColor = Color.White;
        }
        #endregion
        #region Ajustes
        private void buttonAjustesSideMenu_Click(object sender, EventArgs e)
        {
            if (panelSubmenuAjustes.Visible)
            {
                hideSubMenu(panelSubmenuAjustes);
            }
            else
            {
                hideAllSubMenus();
                showSubMenu(panelSubmenuAjustes);
            }
        }
        private void buttonRutasAjustes_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAjustesRutas());
            buttonRutasAjustes.BackColor = Color.White;
        }
        private void buttonCopiaAjustes_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAjustesCopia());
            buttonCopiaAjustes.BackColor = Color.White;
        }
        #endregion
        #region ChildForm
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void panelChildForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            removeAllButtonBackColor();
        }







        #endregion
    }
}
