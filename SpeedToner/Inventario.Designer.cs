namespace SpeedToner
{
    partial class Inventario
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadOficina = new System.Windows.Forms.TextBox();
            this.txtCantidadBodega = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidadSalida = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBuscarInventario = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cboModelos = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpDatosInventario = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpDatosInventario.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(78, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(385, 27);
            this.dtpFecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cantidad en oficina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad en bodega:";
            // 
            // txtCantidadOficina
            // 
            this.txtCantidadOficina.Location = new System.Drawing.Point(183, 104);
            this.txtCantidadOficina.Name = "txtCantidadOficina";
            this.txtCantidadOficina.Size = new System.Drawing.Size(280, 27);
            this.txtCantidadOficina.TabIndex = 5;
            // 
            // txtCantidadBodega
            // 
            this.txtCantidadBodega.Location = new System.Drawing.Point(195, 142);
            this.txtCantidadBodega.Name = "txtCantidadBodega";
            this.txtCantidadBodega.Size = new System.Drawing.Size(268, 27);
            this.txtCantidadBodega.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(565, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cliente:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(641, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(465, 29);
            this.comboBox1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cantidad Salida:";
            // 
            // txtCantidadSalida
            // 
            this.txtCantidadSalida.Location = new System.Drawing.Point(641, 24);
            this.txtCantidadSalida.Name = "txtCantidadSalida";
            this.txtCantidadSalida.Size = new System.Drawing.Size(465, 27);
            this.txtCantidadSalida.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(476, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cantidad Entrada:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(641, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(465, 27);
            this.textBox1.TabIndex = 12;
            // 
            // btnBuscarInventario
            // 
            this.btnBuscarInventario.Location = new System.Drawing.Point(578, 202);
            this.btnBuscarInventario.Name = "btnBuscarInventario";
            this.btnBuscarInventario.Size = new System.Drawing.Size(170, 47);
            this.btnBuscarInventario.TabIndex = 13;
            this.btnBuscarInventario.Text = "Buscar Inventario";
            this.btnBuscarInventario.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(13, 206);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 43);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(133, 206);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(114, 43);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(253, 206);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 43);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // cboModelos
            // 
            this.cboModelos.FormattingEnabled = true;
            this.cboModelos.Location = new System.Drawing.Point(88, 66);
            this.cboModelos.Name = "cboModelos";
            this.cboModelos.Size = new System.Drawing.Size(375, 29);
            this.cboModelos.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1148, 474);
            this.dataGridView1.TabIndex = 18;
            // 
            // grpDatosInventario
            // 
            this.grpDatosInventario.Controls.Add(this.dtpFecha);
            this.grpDatosInventario.Controls.Add(this.label1);
            this.grpDatosInventario.Controls.Add(this.cboModelos);
            this.grpDatosInventario.Controls.Add(this.label2);
            this.grpDatosInventario.Controls.Add(this.label3);
            this.grpDatosInventario.Controls.Add(this.label4);
            this.grpDatosInventario.Controls.Add(this.txtCantidadOficina);
            this.grpDatosInventario.Controls.Add(this.txtCantidadBodega);
            this.grpDatosInventario.Controls.Add(this.textBox1);
            this.grpDatosInventario.Controls.Add(this.label5);
            this.grpDatosInventario.Controls.Add(this.label7);
            this.grpDatosInventario.Controls.Add(this.comboBox1);
            this.grpDatosInventario.Controls.Add(this.txtCantidadSalida);
            this.grpDatosInventario.Controls.Add(this.label6);
            this.grpDatosInventario.Location = new System.Drawing.Point(13, 16);
            this.grpDatosInventario.Name = "grpDatosInventario";
            this.grpDatosInventario.Size = new System.Drawing.Size(1659, 184);
            this.grpDatosInventario.TabIndex = 19;
            this.grpDatosInventario.TabStop = false;
            this.grpDatosInventario.Text = "Datos";
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 750);
            this.Controls.Add(this.grpDatosInventario);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscarInventario);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inventario";
            this.Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpDatosInventario.ResumeLayout(false);
            this.grpDatosInventario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFecha;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCantidadOficina;
        private TextBox txtCantidadBodega;
        private Label label5;
        private ComboBox comboBox1;
        private Label label6;
        private TextBox txtCantidadSalida;
        private Label label7;
        private TextBox textBox1;
        private Button btnBuscarInventario;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private ComboBox cboModelos;
        private DataGridView dataGridView1;
        private GroupBox grpDatosInventario;
    }
}