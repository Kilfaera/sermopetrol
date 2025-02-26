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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            this.chartConsumos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel7 = new System.Windows.Forms.Panel();
            this.iconButtonHideLeftSidePanel = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zonatrabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoConsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamara)).BeginInit();
            this.panelDiagramas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartConsumos)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 29);
            this.panel1.TabIndex = 0;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox2.Location = new System.Drawing.Point(877, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 17);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Imprecion";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(809, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Camara";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(469, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(308, 22);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
            this.panel5.Location = new System.Drawing.Point(11, 647);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(334, 38);
            this.panel5.TabIndex = 31;
            // 
            // iconButtonAprobar
            // 
            this.iconButtonAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.iconButtonAprobar.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButtonAprobar.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconButtonAprobar.IconColor = System.Drawing.Color.White;
            this.iconButtonAprobar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonAprobar.IconSize = 30;
            this.iconButtonAprobar.Location = new System.Drawing.Point(174, 0);
            this.iconButtonAprobar.Name = "iconButtonAprobar";
            this.iconButtonAprobar.Size = new System.Drawing.Size(160, 38);
            this.iconButtonAprobar.TabIndex = 31;
            this.iconButtonAprobar.UseVisualStyleBackColor = false;
            this.iconButtonAprobar.Click += new System.EventHandler(this.iconButtonAprobar_Click);
            // 
            // iconButtonCancelar
            // 
            this.iconButtonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconButtonCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonCancelar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.iconButtonCancelar.IconColor = System.Drawing.Color.White;
            this.iconButtonCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonCancelar.IconSize = 30;
            this.iconButtonCancelar.Location = new System.Drawing.Point(0, 0);
            this.iconButtonCancelar.Name = "iconButtonCancelar";
            this.iconButtonCancelar.Size = new System.Drawing.Size(160, 38);
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
            this.pictureBoxFoto.Location = new System.Drawing.Point(13, 335);
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
            this.comboBoxSelectCamara.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.panelDiagramas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.panelDiagramas.Controls.Add(this.chartConsumos);
            this.panelDiagramas.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDiagramas.Location = new System.Drawing.Point(495, 29);
            this.panelDiagramas.Name = "panelDiagramas";
            this.panelDiagramas.Size = new System.Drawing.Size(278, 759);
            this.panelDiagramas.TabIndex = 2;
            this.panelDiagramas.Visible = false;
            // 
            // chartConsumos
            // 
            this.chartConsumos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chartConsumos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.chartConsumos.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartConsumos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartConsumos.Legends.Add(legend1);
            this.chartConsumos.Location = new System.Drawing.Point(8, 6);
            this.chartConsumos.Name = "chartConsumos";
            this.chartConsumos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartConsumos.Series.Add(series1);
            this.chartConsumos.Size = new System.Drawing.Size(261, 224);
            this.chartConsumos.TabIndex = 0;
            this.chartConsumos.TabStop = false;
            this.chartConsumos.Text = "Consumos";
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
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(495, 759);
            this.panel4.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Documentos,
            this.Zonatrabajo,
            this.TipoConsumo,
            this.FechaRegistro,
            this.FormaRegistro});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(141)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(469, 759);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Documentos
            // 
            this.Documentos.HeaderText = "Documento";
            this.Documentos.Name = "Documentos";
            this.Documentos.ReadOnly = true;
            this.Documentos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Zonatrabajo
            // 
            this.Zonatrabajo.HeaderText = "Zona de Trabajo";
            this.Zonatrabajo.Name = "Zonatrabajo";
            this.Zonatrabajo.ReadOnly = true;
            this.Zonatrabajo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TipoConsumo
            // 
            this.TipoConsumo.HeaderText = "Tipo de Consumo";
            this.TipoConsumo.Name = "TipoConsumo";
            this.TipoConsumo.ReadOnly = true;
            this.TipoConsumo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha de registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormaRegistro
            // 
            this.FormaRegistro.HeaderText = "Forma de registro";
            this.FormaRegistro.Name = "FormaRegistro";
            this.FormaRegistro.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "I";
            this.dataGridViewImageColumn1.Image = global::Consumos_Sermopetrol.Properties.Resources.documento;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 21;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "E";
            this.dataGridViewImageColumn2.Image = global::Consumos_Sermopetrol.Properties.Resources.contenedor_de_basura;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 30;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConsumoAgregar_FormClosing_1);
            this.Load += new System.EventHandler(this.FormConsumoAgregar_Load_1);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormConsumoAgregar_KeyPress);
            this.Leave += new System.EventHandler(this.FormConsumoAgregar_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamara)).EndInit();
            this.panelDiagramas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartConsumos)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConsumos;
        private System.Windows.Forms.Panel panel7;
        private FontAwesome.Sharp.IconButton iconButtonHideLeftSidePanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zonatrabajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaRegistro;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}