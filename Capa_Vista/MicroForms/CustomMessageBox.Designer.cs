namespace Consumos_Sermopetrol.Capa_Vista.MicroForms
{
    partial class CustomMessageBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Imprimir = new FontAwesome.Sharp.IconButton();
            this.BTN_Eliminar = new FontAwesome.Sharp.IconButton();
            this.BTN_Cancelar = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 56);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(582, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp" +
    "pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp";
            // 
            // BTN_Imprimir
            // 
            this.BTN_Imprimir.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Imprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.BTN_Imprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.BTN_Imprimir.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.BTN_Imprimir.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BTN_Imprimir.IconSize = 25;
            this.BTN_Imprimir.Location = new System.Drawing.Point(306, 71);
            this.BTN_Imprimir.Name = "BTN_Imprimir";
            this.BTN_Imprimir.Size = new System.Drawing.Size(92, 30);
            this.BTN_Imprimir.TabIndex = 1;
            this.BTN_Imprimir.Text = "Imprimir";
            this.BTN_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_Imprimir.UseVisualStyleBackColor = false;
            this.BTN_Imprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // BTN_Eliminar
            // 
            this.BTN_Eliminar.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.BTN_Eliminar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BTN_Eliminar.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.BTN_Eliminar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BTN_Eliminar.IconSize = 25;
            this.BTN_Eliminar.Location = new System.Drawing.Point(404, 71);
            this.BTN_Eliminar.Name = "BTN_Eliminar";
            this.BTN_Eliminar.Size = new System.Drawing.Size(92, 30);
            this.BTN_Eliminar.TabIndex = 2;
            this.BTN_Eliminar.Text = "Eliminar";
            this.BTN_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_Eliminar.UseVisualStyleBackColor = false;
            this.BTN_Eliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // BTN_Cancelar
            // 
            this.BTN_Cancelar.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Cancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.BTN_Cancelar.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.BTN_Cancelar.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.BTN_Cancelar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BTN_Cancelar.IconSize = 25;
            this.BTN_Cancelar.Location = new System.Drawing.Point(502, 71);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(92, 30);
            this.BTN_Cancelar.TabIndex = 3;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_Cancelar.UseVisualStyleBackColor = false;
            this.BTN_Cancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(606, 113);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Eliminar);
            this.Controls.Add(this.BTN_Imprimir);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessageBox";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton BTN_Imprimir;
        private FontAwesome.Sharp.IconButton BTN_Eliminar;
        private FontAwesome.Sharp.IconButton BTN_Cancelar;
    }
}