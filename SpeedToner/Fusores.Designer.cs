﻿namespace SpeedToner
{
    partial class Fusores
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.dtgFusores = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtSerieSp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaInstalacion = new System.Windows.Forms.DateTimePicker();
            this.cboGarantia = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.erFusores = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFusores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erFusores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "#Serie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "#Factura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de factura:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(80, 15);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(454, 27);
            this.txtSerie.TabIndex = 4;
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(106, 94);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(428, 27);
            this.txtFactura.TabIndex = 5;
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Location = new System.Drawing.Point(169, 134);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(365, 27);
            this.dtpFechaFactura.TabIndex = 7;
            // 
            // dtgFusores
            // 
            this.dtgFusores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFusores.Location = new System.Drawing.Point(16, 303);
            this.dtgFusores.Name = "dtgFusores";
            this.dtgFusores.RowTemplate.Height = 25;
            this.dtgFusores.Size = new System.Drawing.Size(1144, 434);
            this.dtgFusores.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Costo $:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ubicacion:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(106, 170);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(428, 27);
            this.txtUbicacion.TabIndex = 11;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(106, 203);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(92, 27);
            this.txtCosto.TabIndex = 12;
            // 
            // txtSerieSp
            // 
            this.txtSerieSp.Location = new System.Drawing.Point(101, 51);
            this.txtSerieSp.Name = "txtSerieSp";
            this.txtSerieSp.Size = new System.Drawing.Size(433, 27);
            this.txtSerieSp.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "#Serie SP:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(16, 254);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 43);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(136, 254);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 43);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(256, 254);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 43);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(540, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "Fecha instalacion:";
            // 
            // dtpFechaInstalacion
            // 
            this.dtpFechaInstalacion.Location = new System.Drawing.Point(697, 13);
            this.dtpFechaInstalacion.Name = "dtpFechaInstalacion";
            this.dtpFechaInstalacion.Size = new System.Drawing.Size(365, 27);
            this.dtpFechaInstalacion.TabIndex = 19;
            // 
            // cboGarantia
            // 
            this.cboGarantia.AutoCompleteCustomSource.AddRange(new string[] {
            "Habilitada",
            "Inhabilitada"});
            this.cboGarantia.FormattingEnabled = true;
            this.cboGarantia.Items.AddRange(new object[] {
            "Habilitado",
            "Inhabilitado"});
            this.cboGarantia.Location = new System.Drawing.Point(632, 46);
            this.cboGarantia.Name = "cboGarantia";
            this.cboGarantia.Size = new System.Drawing.Size(257, 29);
            this.cboGarantia.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(540, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 21);
            this.label8.TabIndex = 21;
            this.label8.Text = "Garantia:";
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(540, 239);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(134, 58);
            this.btnGenerarReporte.TabIndex = 22;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            // 
            // erFusores
            // 
            this.erFusores.ContainerControl = this;
            // 
            // Fusores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 749);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboGarantia);
            this.Controls.Add(this.dtpFechaInstalacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtSerieSp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgFusores);
            this.Controls.Add(this.dtpFechaFactura);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Fusores";
            this.Text = "Fusores";
            ((System.ComponentModel.ISupportInitialize)(this.dtgFusores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erFusores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSerie;
        private TextBox txtFactura;
        private DateTimePicker dtpFechaFactura;
        private DataGridView dtgFusores;
        private Label label5;
        private Label label6;
        private TextBox txtUbicacion;
        private TextBox txtCosto;
        private TextBox txtSerieSp;
        private Label label4;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCancelar;
        private Label label7;
        private DateTimePicker dtpFechaInstalacion;
        private ComboBox cboGarantia;
        private Label label8;
        private Button btnGenerarReporte;
        private ErrorProvider erFusores;
    }
}