namespace Consumos_Sermopetrol.Capa_Vista
{
    partial class FormEmpleadosLista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButtonAgregar = new FontAwesome.Sharp.IconButton();
            this.iconButtonEditar = new FontAwesome.Sharp.IconButton();
            this.iconButtonExportar = new FontAwesome.Sharp.IconButton();
            this.iconButtonReiniciar = new FontAwesome.Sharp.IconButton();
            this.textBoxCedula = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 29);
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
            this.buttonClose.Size = new System.Drawing.Size(70, 29);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 323);
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
            this.imagen,
            this.estado,
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
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.Size = new System.Drawing.Size(800, 323);
            this.dataGridView.TabIndex = 2;
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
            this.consumo.HeaderText = "Cantidad de Consumos";
            this.consumo.Name = "consumo";
            this.consumo.ReadOnly = true;
            this.consumo.Width = 229;
            // 
            // imagen
            // 
            this.imagen.HeaderText = "Imagen";
            this.imagen.Name = "imagen";
            this.imagen.ReadOnly = true;
            this.imagen.Width = 104;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 99;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fecha.HeaderText = "Fecha de Registro";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 188;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.panel2.Controls.Add(this.iconButtonAgregar);
            this.panel2.Controls.Add(this.iconButtonEditar);
            this.panel2.Controls.Add(this.iconButtonExportar);
            this.panel2.Controls.Add(this.iconButtonReiniciar);
            this.panel2.Controls.Add(this.textBoxCedula);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 98);
            this.panel2.TabIndex = 2;
            // 
            // iconButtonAgregar
            // 
            this.iconButtonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.iconButtonAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButtonAgregar.FlatAppearance.BorderSize = 2;
            this.iconButtonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonAgregar.ForeColor = System.Drawing.Color.White;
            this.iconButtonAgregar.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.iconButtonAgregar.IconColor = System.Drawing.Color.White;
            this.iconButtonAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonAgregar.IconSize = 50;
            this.iconButtonAgregar.Location = new System.Drawing.Point(656, 21);
            this.iconButtonAgregar.Name = "iconButtonAgregar";
            this.iconButtonAgregar.Size = new System.Drawing.Size(133, 54);
            this.iconButtonAgregar.TabIndex = 17;
            this.iconButtonAgregar.Text = "Añadir";
            this.iconButtonAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonAgregar.UseVisualStyleBackColor = false;
            // 
            // iconButtonEditar
            // 
            this.iconButtonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.iconButtonEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButtonEditar.FlatAppearance.BorderSize = 2;
            this.iconButtonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonEditar.ForeColor = System.Drawing.Color.White;
            this.iconButtonEditar.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.iconButtonEditar.IconColor = System.Drawing.Color.White;
            this.iconButtonEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonEditar.IconSize = 50;
            this.iconButtonEditar.Location = new System.Drawing.Point(526, 21);
            this.iconButtonEditar.Name = "iconButtonEditar";
            this.iconButtonEditar.Size = new System.Drawing.Size(124, 54);
            this.iconButtonEditar.TabIndex = 16;
            this.iconButtonEditar.Text = "Editar";
            this.iconButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonEditar.UseVisualStyleBackColor = false;
            // 
            // iconButtonExportar
            // 
            this.iconButtonExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.iconButtonExportar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButtonExportar.FlatAppearance.BorderSize = 2;
            this.iconButtonExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonExportar.ForeColor = System.Drawing.Color.White;
            this.iconButtonExportar.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleDown;
            this.iconButtonExportar.IconColor = System.Drawing.Color.White;
            this.iconButtonExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonExportar.IconSize = 50;
            this.iconButtonExportar.Location = new System.Drawing.Point(311, 21);
            this.iconButtonExportar.Name = "iconButtonExportar";
            this.iconButtonExportar.Size = new System.Drawing.Size(209, 54);
            this.iconButtonExportar.TabIndex = 15;
            this.iconButtonExportar.Text = "Exportar Empleados";
            this.iconButtonExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonExportar.UseVisualStyleBackColor = false;
            // 
            // iconButtonReiniciar
            // 
            this.iconButtonReiniciar.FlatAppearance.BorderSize = 0;
            this.iconButtonReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonReiniciar.IconChar = FontAwesome.Sharp.IconChar.RotateForward;
            this.iconButtonReiniciar.IconColor = System.Drawing.Color.White;
            this.iconButtonReiniciar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonReiniciar.Location = new System.Drawing.Point(260, 28);
            this.iconButtonReiniciar.Name = "iconButtonReiniciar";
            this.iconButtonReiniciar.Size = new System.Drawing.Size(50, 43);
            this.iconButtonReiniciar.TabIndex = 1;
            this.iconButtonReiniciar.UseVisualStyleBackColor = true;
            // 
            // textBoxCedula
            // 
            this.textBoxCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.textBoxCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCedula.ForeColor = System.Drawing.Color.White;
            this.textBoxCedula.Location = new System.Drawing.Point(34, 34);
            this.textBoxCedula.Name = "textBoxCedula";
            this.textBoxCedula.Size = new System.Drawing.Size(220, 31);
            this.textBoxCedula.TabIndex = 0;
            // 
            // FormEmpleadosLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEmpleadosLista";
            this.Text = "FormEmpleadosLista";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn zona;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButtonAgregar;
        private FontAwesome.Sharp.IconButton iconButtonEditar;
        private FontAwesome.Sharp.IconButton iconButtonExportar;
        private FontAwesome.Sharp.IconButton iconButtonReiniciar;
        private System.Windows.Forms.TextBox textBoxCedula;
    }
}