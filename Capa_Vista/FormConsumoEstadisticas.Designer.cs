﻿namespace Consumos_Sermopetrol.Capa_Vista
{
    partial class FormConsumoEstadisticas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconButtonReiniciar = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.labelHasta = new System.Windows.Forms.Label();
            this.labelDesde = new System.Windows.Forms.Label();
            this.comboBoxConsumo = new System.Windows.Forms.ComboBox();
            this.labelConsumo = new System.Windows.Forms.Label();
            this.textBoxZona = new System.Windows.Forms.TextBox();
            this.labelZona = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelFiltros = new System.Windows.Forms.Label();
            this.iconButtonExportar = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 36);
            this.panel1.TabIndex = 1;
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
            this.buttonClose.Size = new System.Drawing.Size(70, 36);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click_1);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.iconButtonExportar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(726, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 752);
            this.panel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.iconButton1);
            this.panel5.Controls.Add(this.iconButtonReiniciar);
            this.panel5.Location = new System.Drawing.Point(14, 531);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(278, 139);
            this.panel5.TabIndex = 16;
            // 
            // iconButtonReiniciar
            // 
            this.iconButtonReiniciar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.iconButtonReiniciar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButtonReiniciar.FlatAppearance.BorderSize = 2;
            this.iconButtonReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonReiniciar.IconChar = FontAwesome.Sharp.IconChar.RotateBackward;
            this.iconButtonReiniciar.IconColor = System.Drawing.Color.White;
            this.iconButtonReiniciar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonReiniciar.IconSize = 30;
            this.iconButtonReiniciar.Location = new System.Drawing.Point(-1, 3);
            this.iconButtonReiniciar.Name = "iconButtonReiniciar";
            this.iconButtonReiniciar.Size = new System.Drawing.Size(278, 60);
            this.iconButtonReiniciar.TabIndex = 7;
            this.iconButtonReiniciar.UseVisualStyleBackColor = false;
            this.iconButtonReiniciar.Click += new System.EventHandler(this.iconButtonReiniciar_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dateTimePickerHasta);
            this.panel4.Controls.Add(this.dateTimePickerDesde);
            this.panel4.Controls.Add(this.labelHasta);
            this.panel4.Controls.Add(this.labelDesde);
            this.panel4.Controls.Add(this.comboBoxConsumo);
            this.panel4.Controls.Add(this.labelConsumo);
            this.panel4.Controls.Add(this.textBoxZona);
            this.panel4.Controls.Add(this.labelZona);
            this.panel4.Controls.Add(this.textBoxNombre);
            this.panel4.Controls.Add(this.labelNombre);
            this.panel4.Controls.Add(this.labelFiltros);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 504);
            this.panel4.TabIndex = 15;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimePickerHasta.Location = new System.Drawing.Point(13, 438);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(278, 20);
            this.dateTimePickerHasta.TabIndex = 28;
            this.dateTimePickerHasta.ValueChanged += new System.EventHandler(this.dateTimePickerHasta_ValueChanged);
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimePickerDesde.Location = new System.Drawing.Point(13, 369);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(278, 20);
            this.dateTimePickerDesde.TabIndex = 27;
            this.dateTimePickerDesde.ValueChanged += new System.EventHandler(this.dateTimePickerDesde_ValueChanged);
            // 
            // labelHasta
            // 
            this.labelHasta.AutoSize = true;
            this.labelHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHasta.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHasta.Location = new System.Drawing.Point(15, 419);
            this.labelHasta.Name = "labelHasta";
            this.labelHasta.Size = new System.Drawing.Size(48, 16);
            this.labelHasta.TabIndex = 25;
            this.labelHasta.Text = "Hasta";
            // 
            // labelDesde
            // 
            this.labelDesde.AutoSize = true;
            this.labelDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesde.ForeColor = System.Drawing.SystemColors.Control;
            this.labelDesde.Location = new System.Drawing.Point(10, 350);
            this.labelDesde.Name = "labelDesde";
            this.labelDesde.Size = new System.Drawing.Size(53, 16);
            this.labelDesde.TabIndex = 23;
            this.labelDesde.Text = "Desde";
            // 
            // comboBoxConsumo
            // 
            this.comboBoxConsumo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.comboBoxConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxConsumo.ForeColor = System.Drawing.Color.White;
            this.comboBoxConsumo.FormattingEnabled = true;
            this.comboBoxConsumo.Items.AddRange(new object[] {
            "Todo",
            "Desayuno",
            "Almuerzo",
            "Cena"});
            this.comboBoxConsumo.Location = new System.Drawing.Point(14, 298);
            this.comboBoxConsumo.Name = "comboBoxConsumo";
            this.comboBoxConsumo.Size = new System.Drawing.Size(278, 21);
            this.comboBoxConsumo.TabIndex = 22;
            this.comboBoxConsumo.SelectedIndexChanged += new System.EventHandler(this.comboBoxConsumo_SelectedIndexChanged);
            // 
            // labelConsumo
            // 
            this.labelConsumo.AutoSize = true;
            this.labelConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConsumo.ForeColor = System.Drawing.SystemColors.Control;
            this.labelConsumo.Location = new System.Drawing.Point(11, 278);
            this.labelConsumo.Name = "labelConsumo";
            this.labelConsumo.Size = new System.Drawing.Size(129, 16);
            this.labelConsumo.TabIndex = 21;
            this.labelConsumo.Text = "Tipo de Consumo";
            // 
            // textBoxZona
            // 
            this.textBoxZona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxZona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxZona.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.textBoxZona.ForeColor = System.Drawing.Color.White;
            this.textBoxZona.Location = new System.Drawing.Point(14, 223);
            this.textBoxZona.Name = "textBoxZona";
            this.textBoxZona.Size = new System.Drawing.Size(278, 20);
            this.textBoxZona.TabIndex = 20;
            this.textBoxZona.TextChanged += new System.EventHandler(this.textBoxZona_TextChanged);
            // 
            // labelZona
            // 
            this.labelZona.AutoSize = true;
            this.labelZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZona.ForeColor = System.Drawing.SystemColors.Control;
            this.labelZona.Location = new System.Drawing.Point(11, 204);
            this.labelZona.Name = "labelZona";
            this.labelZona.Size = new System.Drawing.Size(123, 16);
            this.labelZona.TabIndex = 19;
            this.labelZona.Text = "Zona de Trabajo";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.textBoxNombre.ForeColor = System.Drawing.Color.White;
            this.textBoxNombre.Location = new System.Drawing.Point(14, 148);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(278, 20);
            this.textBoxNombre.TabIndex = 18;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBoxNombre_TextChanged);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.SystemColors.Control;
            this.labelNombre.Location = new System.Drawing.Point(11, 129);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(116, 16);
            this.labelNombre.TabIndex = 17;
            this.labelNombre.Text = "Nombre/Cedula";
            // 
            // labelFiltros
            // 
            this.labelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiltros.ForeColor = System.Drawing.SystemColors.Control;
            this.labelFiltros.Location = new System.Drawing.Point(0, 0);
            this.labelFiltros.Name = "labelFiltros";
            this.labelFiltros.Size = new System.Drawing.Size(304, 129);
            this.labelFiltros.TabIndex = 14;
            this.labelFiltros.Text = "Filtros";
            this.labelFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconButtonExportar
            // 
            this.iconButtonExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.iconButtonExportar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButtonExportar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButtonExportar.FlatAppearance.BorderSize = 2;
            this.iconButtonExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonExportar.ForeColor = System.Drawing.Color.White;
            this.iconButtonExportar.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleDown;
            this.iconButtonExportar.IconColor = System.Drawing.Color.White;
            this.iconButtonExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonExportar.IconSize = 50;
            this.iconButtonExportar.Location = new System.Drawing.Point(0, 698);
            this.iconButtonExportar.Name = "iconButtonExportar";
            this.iconButtonExportar.Size = new System.Drawing.Size(304, 54);
            this.iconButtonExportar.TabIndex = 14;
            this.iconButtonExportar.Text = "Exportar";
            this.iconButtonExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonExportar.UseVisualStyleBackColor = false;
            this.iconButtonExportar.Click += new System.EventHandler(this.iconButtonExportar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(726, 752);
            this.panel3.TabIndex = 3;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.documento,
            this.zona,
            this.consumo,
            this.fecha,
            this.FormaRegistro});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.Size = new System.Drawing.Size(726, 752);
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
            // FormaRegistro
            // 
            this.FormaRegistro.HeaderText = "Forma de registro";
            this.FormaRegistro.Name = "FormaRegistro";
            this.FormaRegistro.ReadOnly = true;
            this.FormaRegistro.Width = 183;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButton1.FlatAppearance.BorderSize = 2;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(0, 69);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(278, 60);
            this.iconButton1.TabIndex = 8;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // FormConsumoEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1030, 788);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConsumoEstadisticas";
            this.Text = "FormConsumoEstadisticas";
            this.Load += new System.EventHandler(this.FormConsumoEstadisticas_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonClose;
        private FontAwesome.Sharp.IconButton iconButtonExportar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelHasta;
        private System.Windows.Forms.Label labelDesde;
        private System.Windows.Forms.ComboBox comboBoxConsumo;
        private System.Windows.Forms.Label labelConsumo;
        private System.Windows.Forms.TextBox textBoxZona;
        private System.Windows.Forms.Label labelZona;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelFiltros;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn zona;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconButton iconButtonReiniciar;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaRegistro;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}