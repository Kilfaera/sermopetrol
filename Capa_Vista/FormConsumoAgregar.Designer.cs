namespace Consumos_Sermopetrol.Capa_Vista
{
    partial class FormConsumoAgregar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconButtonAprobar = new FontAwesome.Sharp.IconButton();
            this.iconButtonCancelar = new FontAwesome.Sharp.IconButton();
            this.comboBoxConsumo = new System.Windows.Forms.ComboBox();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.textBoxCedula = new System.Windows.Forms.TextBox();
            this.comboBoxSelectCamara = new System.Windows.Forms.ComboBox();
            this.pictureBoxCamara = new System.Windows.Forms.PictureBox();
            this.panelDiagramas = new System.Windows.Forms.Panel();
            this.diagrama3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.diagrama2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.diagrama1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel7 = new System.Windows.Forms.Panel();
            this.iconButtonHideLeftSidePanel = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamara)).BeginInit();
            this.panelDiagramas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagrama3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagrama2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagrama1)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 29);
            this.panel1.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(62)))), ((int)(((byte)(54)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(62)))), ((int)(((byte)(54)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("MS Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonClose.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonClose.Location = new System.Drawing.Point(0, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 29);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click_1);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(773, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 759);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.comboBoxConsumo);
            this.panel6.Controls.Add(this.pictureBoxFoto);
            this.panel6.Controls.Add(this.textBoxCedula);
            this.panel6.Controls.Add(this.comboBoxSelectCamara);
            this.panel6.Controls.Add(this.pictureBoxCamara);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(359, 698);
            this.panel6.TabIndex = 31;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.iconButtonAprobar);
            this.panel5.Controls.Add(this.iconButtonCancelar);
            this.panel5.Location = new System.Drawing.Point(11, 561);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(334, 124);
            this.panel5.TabIndex = 31;
            // 
            // iconButtonAprobar
            // 
            this.iconButtonAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.iconButtonAprobar.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButtonAprobar.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconButtonAprobar.IconColor = System.Drawing.Color.White;
            this.iconButtonAprobar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonAprobar.IconSize = 100;
            this.iconButtonAprobar.Location = new System.Drawing.Point(174, 0);
            this.iconButtonAprobar.Name = "iconButtonAprobar";
            this.iconButtonAprobar.Size = new System.Drawing.Size(160, 124);
            this.iconButtonAprobar.TabIndex = 31;
            this.iconButtonAprobar.UseVisualStyleBackColor = false;
            // 
            // iconButtonCancelar
            // 
            this.iconButtonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconButtonCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonCancelar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.iconButtonCancelar.IconColor = System.Drawing.Color.White;
            this.iconButtonCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonCancelar.IconSize = 100;
            this.iconButtonCancelar.Location = new System.Drawing.Point(0, 0);
            this.iconButtonCancelar.Name = "iconButtonCancelar";
            this.iconButtonCancelar.Size = new System.Drawing.Size(160, 124);
            this.iconButtonCancelar.TabIndex = 30;
            this.iconButtonCancelar.UseVisualStyleBackColor = false;
            // 
            // comboBoxConsumo
            // 
            this.comboBoxConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxConsumo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.comboBoxConsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxConsumo.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxConsumo.FormattingEnabled = true;
            this.comboBoxConsumo.Items.AddRange(new object[] {
            "Automatico",
            "Desayuno",
            "Almuerzo",
            "Cena"});
            this.comboBoxConsumo.Location = new System.Drawing.Point(11, 301);
            this.comboBoxConsumo.Name = "comboBoxConsumo";
            this.comboBoxConsumo.Size = new System.Drawing.Size(334, 28);
            this.comboBoxConsumo.TabIndex = 30;
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFoto.Image = global::Consumos_Sermopetrol.Properties.Resources.sin_imagen;
            this.pictureBoxFoto.InitialImage = global::Consumos_Sermopetrol.Properties.Resources.sin_imagen;
            this.pictureBoxFoto.Location = new System.Drawing.Point(11, 334);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(334, 220);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFoto.TabIndex = 29;
            this.pictureBoxFoto.TabStop = false;
            // 
            // textBoxCedula
            // 
            this.textBoxCedula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.textBoxCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCedula.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxCedula.Location = new System.Drawing.Point(11, 265);
            this.textBoxCedula.Name = "textBoxCedula";
            this.textBoxCedula.Size = new System.Drawing.Size(334, 31);
            this.textBoxCedula.TabIndex = 28;
            this.textBoxCedula.Text = "ID/Cédula";
            // 
            // comboBoxSelectCamara
            // 
            this.comboBoxSelectCamara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSelectCamara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.comboBoxSelectCamara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectCamara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSelectCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectCamara.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxSelectCamara.FormattingEnabled = true;
            this.comboBoxSelectCamara.Location = new System.Drawing.Point(11, 232);
            this.comboBoxSelectCamara.Name = "comboBoxSelectCamara";
            this.comboBoxSelectCamara.Size = new System.Drawing.Size(334, 28);
            this.comboBoxSelectCamara.TabIndex = 27;
            // 
            // pictureBoxCamara
            // 
            this.pictureBoxCamara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCamara.Image = global::Consumos_Sermopetrol.Properties.Resources.logo_ico;
            this.pictureBoxCamara.InitialImage = global::Consumos_Sermopetrol.Properties.Resources.logo_ico;
            this.pictureBoxCamara.Location = new System.Drawing.Point(11, 6);
            this.pictureBoxCamara.Name = "pictureBoxCamara";
            this.pictureBoxCamara.Size = new System.Drawing.Size(334, 220);
            this.pictureBoxCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCamara.TabIndex = 26;
            this.pictureBoxCamara.TabStop = false;
            // 
            // panelDiagramas
            // 
            this.panelDiagramas.BackColor = System.Drawing.Color.White;
            this.panelDiagramas.Controls.Add(this.diagrama3);
            this.panelDiagramas.Controls.Add(this.diagrama2);
            this.panelDiagramas.Controls.Add(this.diagrama1);
            this.panelDiagramas.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDiagramas.Location = new System.Drawing.Point(495, 29);
            this.panelDiagramas.Name = "panelDiagramas";
            this.panelDiagramas.Size = new System.Drawing.Size(278, 759);
            this.panelDiagramas.TabIndex = 2;
            this.panelDiagramas.Visible = false;
            // 
            // diagrama3
            // 
            chartArea1.Name = "ChartArea1";
            this.diagrama3.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.diagrama3.Legends.Add(legend1);
            this.diagrama3.Location = new System.Drawing.Point(8, 474);
            this.diagrama3.Name = "diagrama3";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.diagrama3.Series.Add(series1);
            this.diagrama3.Size = new System.Drawing.Size(261, 224);
            this.diagrama3.TabIndex = 2;
            this.diagrama3.Text = "chart3";
            // 
            // diagrama2
            // 
            chartArea2.Name = "ChartArea1";
            this.diagrama2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.diagrama2.Legends.Add(legend2);
            this.diagrama2.Location = new System.Drawing.Point(8, 240);
            this.diagrama2.Name = "diagrama2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.diagrama2.Series.Add(series2);
            this.diagrama2.Size = new System.Drawing.Size(261, 224);
            this.diagrama2.TabIndex = 1;
            this.diagrama2.Text = "chart2";
            // 
            // diagrama1
            // 
            chartArea3.Name = "ChartArea1";
            this.diagrama1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.diagrama1.Legends.Add(legend3);
            this.diagrama1.Location = new System.Drawing.Point(8, 6);
            this.diagrama1.Name = "diagrama1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.diagrama1.Series.Add(series3);
            this.diagrama1.Size = new System.Drawing.Size(261, 224);
            this.diagrama1.TabIndex = 0;
            this.diagrama1.Text = "chart1";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.iconButtonHideLeftSidePanel);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(469, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(26, 759);
            this.panel7.TabIndex = 2;
            // 
            // iconButtonHideLeftSidePanel
            // 
            this.iconButtonHideLeftSidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconButtonHideLeftSidePanel.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.iconButtonHideLeftSidePanel.IconColor = System.Drawing.Color.Black;
            this.iconButtonHideLeftSidePanel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonHideLeftSidePanel.IconSize = 20;
            this.iconButtonHideLeftSidePanel.Location = new System.Drawing.Point(0, 0);
            this.iconButtonHideLeftSidePanel.Name = "iconButtonHideLeftSidePanel";
            this.iconButtonHideLeftSidePanel.Size = new System.Drawing.Size(26, 759);
            this.iconButtonHideLeftSidePanel.TabIndex = 0;
            this.iconButtonHideLeftSidePanel.UseVisualStyleBackColor = true;
            this.iconButtonHideLeftSidePanel.Click += new System.EventHandler(this.iconButtonHideLeftSidePanel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.dataGridView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(495, 759);
            this.panel4.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(93)))), ((int)(((byte)(118)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.documento,
            this.zona,
            this.consumo,
            this.fecha});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.Size = new System.Drawing.Size(495, 759);
            this.dataGridView.TabIndex = 1;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 54;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 110;
            // 
            // documento
            // 
            this.documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            this.documento.Width = 142;
            // 
            // zona
            // 
            this.zona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zona.HeaderText = "Zona de Trabajo";
            this.zona.Name = "zona";
            this.zona.ReadOnly = true;
            this.zona.Width = 173;
            // 
            // consumo
            // 
            this.consumo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.consumo.HeaderText = "Tipo de Consumo";
            this.consumo.Name = "consumo";
            this.consumo.ReadOnly = true;
            this.consumo.Width = 184;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fecha.HeaderText = "Fecha de Registro";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 188;
            // 
            // FormConsumoAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1132, 788);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelDiagramas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConsumoAgregar";
            this.Text = "FormConsumoAgregar";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamara)).EndInit();
            this.panelDiagramas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diagrama3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagrama2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagrama1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonClose;
        private FontAwesome.Sharp.IconButton iconButtonAprobar;
        private FontAwesome.Sharp.IconButton iconButtonCancelar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox comboBoxConsumo;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.ComboBox comboBoxSelectCamara;
        private System.Windows.Forms.PictureBox pictureBoxCamara;
        private System.Windows.Forms.Panel panelDiagramas;
        private System.Windows.Forms.TextBox textBoxCedula;
        private System.Windows.Forms.DataVisualization.Charting.Chart diagrama3;
        private System.Windows.Forms.DataVisualization.Charting.Chart diagrama2;
        private System.Windows.Forms.DataVisualization.Charting.Chart diagrama1;
        private System.Windows.Forms.Panel panel7;
        private FontAwesome.Sharp.IconButton iconButtonHideLeftSidePanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn zona;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
    }
}