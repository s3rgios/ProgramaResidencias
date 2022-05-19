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
            this.label5 = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidadSalida = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBuscarInventario = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cboModelos = new System.Windows.Forms.ComboBox();
            this.dtgCartuchos = new System.Windows.Forms.DataGridView();
            this.grpDatosInventario = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rBodega = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartuchos)).BeginInit();
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cliente:";
            // 
            // cboClientes
            // 
            this.cboClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(573, 24);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(582, 29);
            this.cboClientes.Sorted = true;
            this.cboClientes.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cantidad Salida:";
            // 
            // txtCantidadSalida
            // 
            this.txtCantidadSalida.Location = new System.Drawing.Point(154, 104);
            this.txtCantidadSalida.Name = "txtCantidadSalida";
            this.txtCantidadSalida.Size = new System.Drawing.Size(309, 27);
            this.txtCantidadSalida.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(497, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cantidad Entrada:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(662, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 27);
            this.textBox1.TabIndex = 12;
            // 
            // btnBuscarInventario
            // 
            this.btnBuscarInventario.Location = new System.Drawing.Point(527, 181);
            this.btnBuscarInventario.Name = "btnBuscarInventario";
            this.btnBuscarInventario.Size = new System.Drawing.Size(170, 47);
            this.btnBuscarInventario.TabIndex = 13;
            this.btnBuscarInventario.Text = "Buscar Inventario";
            this.btnBuscarInventario.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(13, 181);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 43);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(133, 181);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(114, 43);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(253, 181);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 43);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // cboModelos
            // 
            this.cboModelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelos.FormattingEnabled = true;
            this.cboModelos.Location = new System.Drawing.Point(88, 66);
            this.cboModelos.Name = "cboModelos";
            this.cboModelos.Size = new System.Drawing.Size(375, 29);
            this.cboModelos.Sorted = true;
            this.cboModelos.TabIndex = 17;
            // 
            // dtgCartuchos
            // 
            this.dtgCartuchos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCartuchos.Location = new System.Drawing.Point(12, 241);
            this.dtgCartuchos.Name = "dtgCartuchos";
            this.dtgCartuchos.RowTemplate.Height = 25;
            this.dtgCartuchos.Size = new System.Drawing.Size(1148, 488);
            this.dtgCartuchos.TabIndex = 18;
            // 
            // grpDatosInventario
            // 
            this.grpDatosInventario.Controls.Add(this.label3);
            this.grpDatosInventario.Controls.Add(this.rBodega);
            this.grpDatosInventario.Controls.Add(this.radioButton1);
            this.grpDatosInventario.Controls.Add(this.dtpFecha);
            this.grpDatosInventario.Controls.Add(this.label1);
            this.grpDatosInventario.Controls.Add(this.cboModelos);
            this.grpDatosInventario.Controls.Add(this.label2);
            this.grpDatosInventario.Controls.Add(this.textBox1);
            this.grpDatosInventario.Controls.Add(this.label5);
            this.grpDatosInventario.Controls.Add(this.label7);
            this.grpDatosInventario.Controls.Add(this.cboClientes);
            this.grpDatosInventario.Controls.Add(this.txtCantidadSalida);
            this.grpDatosInventario.Controls.Add(this.label6);
            this.grpDatosInventario.Location = new System.Drawing.Point(13, 16);
            this.grpDatosInventario.Name = "grpDatosInventario";
            this.grpDatosInventario.Size = new System.Drawing.Size(1155, 159);
            this.grpDatosInventario.TabIndex = 19;
            this.grpDatosInventario.TabStop = false;
            this.grpDatosInventario.Text = "Datos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 21;
            this.label3.Text = "Agregar a:";
            // 
            // rBodega
            // 
            this.rBodega.AutoSize = true;
            this.rBodega.Location = new System.Drawing.Point(690, 107);
            this.rBodega.Name = "rBodega";
            this.rBodega.Size = new System.Drawing.Size(90, 25);
            this.rBodega.TabIndex = 20;
            this.rBodega.TabStop = true;
            this.rBodega.Text = "Bodega";
            this.rBodega.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(600, 107);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 25);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Oficina";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 54);
            this.button1.TabIndex = 18;
            this.button1.Text = "Añadir cartucho";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(373, 181);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 43);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 750);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpDatosInventario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgCartuchos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscarInventario);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartuchos)).EndInit();
            this.grpDatosInventario.ResumeLayout(false);
            this.grpDatosInventario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFecha;
        private Label label2;
        private Label label5;
        private ComboBox cboClientes;
        private Label label6;
        private TextBox txtCantidadSalida;
        private Label label7;
        private TextBox textBox1;
        private Button btnBuscarInventario;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private ComboBox cboModelos;
        private DataGridView dtgCartuchos;
        private GroupBox grpDatosInventario;
        private Button button1;
        private Button btnCancelar;
        private Label label3;
        private RadioButton rBodega;
        private RadioButton radioButton1;
    }
}