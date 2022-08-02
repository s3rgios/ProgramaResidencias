namespace SpeedToner
{
    partial class Equipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipos));
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.cboMarcas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboModelos = new System.Windows.Forms.ComboBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTipoRenta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaPago = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerieBusqueda = new System.Windows.Forms.TextBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMostrar = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgEquipos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.erEquipos = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBorrador = new System.Windows.Forms.Button();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erEquipos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.cboClientes);
            this.grpDatos.Controls.Add(this.cboMarcas);
            this.grpDatos.Controls.Add(this.label8);
            this.grpDatos.Controls.Add(this.cboModelos);
            this.grpDatos.Controls.Add(this.txtReferencia);
            this.grpDatos.Controls.Add(this.label7);
            this.grpDatos.Controls.Add(this.cboTipoRenta);
            this.grpDatos.Controls.Add(this.label6);
            this.grpDatos.Controls.Add(this.txtFechaPago);
            this.grpDatos.Controls.Add(this.txtPrecio);
            this.grpDatos.Controls.Add(this.txtSerie);
            this.grpDatos.Controls.Add(this.label5);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grpDatos.Location = new System.Drawing.Point(13, 13);
            this.grpDatos.Margin = new System.Windows.Forms.Padding(4);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Padding = new System.Windows.Forms.Padding(4);
            this.grpDatos.Size = new System.Drawing.Size(1146, 223);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos:";
            // 
            // cboClientes
            // 
            this.cboClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(86, 32);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(678, 29);
            this.cboClientes.Sorted = true;
            this.cboClientes.TabIndex = 17;
            // 
            // cboMarcas
            // 
            this.cboMarcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMarcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarcas.FormattingEnabled = true;
            this.cboMarcas.Location = new System.Drawing.Point(86, 104);
            this.cboMarcas.Name = "cboMarcas";
            this.cboMarcas.Size = new System.Drawing.Size(482, 29);
            this.cboMarcas.TabIndex = 16;
            this.cboMarcas.SelectedIndexChanged += new System.EventHandler(this.cboMarcas_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Marca:";
            // 
            // cboModelos
            // 
            this.cboModelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelos.FormattingEnabled = true;
            this.cboModelos.Location = new System.Drawing.Point(86, 139);
            this.cboModelos.Name = "cboModelos";
            this.cboModelos.Size = new System.Drawing.Size(482, 29);
            this.cboModelos.TabIndex = 14;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(111, 71);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(457, 27);
            this.txtReferencia.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Referencia:";
            // 
            // cboTipoRenta
            // 
            this.cboTipoRenta.FormattingEnabled = true;
            this.cboTipoRenta.Location = new System.Drawing.Point(690, 67);
            this.cboTipoRenta.Name = "cboTipoRenta";
            this.cboTipoRenta.Size = new System.Drawing.Size(273, 29);
            this.cboTipoRenta.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(591, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo renta:";
            // 
            // txtFechaPago
            // 
            this.txtFechaPago.Location = new System.Drawing.Point(732, 136);
            this.txtFechaPago.Name = "txtFechaPago";
            this.txtFechaPago.Size = new System.Drawing.Size(340, 27);
            this.txtFechaPago.TabIndex = 5;
            this.txtFechaPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFechaPago_KeyPress);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(690, 101);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(273, 27);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(63, 178);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(505, 27);
            this.txtSerie.TabIndex = 4;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(591, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha de pago:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio $:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // txtSerieBusqueda
            // 
            this.txtSerieBusqueda.Location = new System.Drawing.Point(435, 283);
            this.txtSerieBusqueda.Name = "txtSerieBusqueda";
            this.txtSerieBusqueda.Size = new System.Drawing.Size(185, 27);
            this.txtSerieBusqueda.TabIndex = 6;
            this.txtSerieBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerieBusqueda_KeyPress);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(899, 263);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(109, 55);
            this.btnMostrar.TabIndex = 10;
            this.btnMostrar.Text = "Mostrar Reporte";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(379, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "Serie:";
            // 
            // cboMostrar
            // 
            this.cboMostrar.FormattingEnabled = true;
            this.cboMostrar.Items.AddRange(new object[] {
            "",
            "Cliente",
            "Marca",
            "Modelo"});
            this.cboMostrar.Location = new System.Drawing.Point(129, 240);
            this.cboMostrar.Name = "cboMostrar";
            this.cboMostrar.Size = new System.Drawing.Size(244, 29);
            this.cboMostrar.TabIndex = 9;
            this.cboMostrar.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(14, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Generar por:";
            // 
            // dtgEquipos
            // 
            this.dtgEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEquipos.Location = new System.Drawing.Point(13, 324);
            this.dtgEquipos.Name = "dtgEquipos";
            this.dtgEquipos.RowTemplate.Height = 25;
            this.dtgEquipos.Size = new System.Drawing.Size(1146, 414);
            this.dtgEquipos.TabIndex = 1;
            this.dtgEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEquipos_CellClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(12, 275);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(68, 47);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(86, 275);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(68, 47);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(160, 275);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(68, 47);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // erEquipos
            // 
            this.erEquipos.ContainerControl = this;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(105)))), ((int)(((byte)(5)))));
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(649, 281);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 29);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBorrador
            // 
            this.btnBorrador.BackColor = System.Drawing.Color.Thistle;
            this.btnBorrador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBorrador.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrador.Image")));
            this.btnBorrador.Location = new System.Drawing.Point(724, 274);
            this.btnBorrador.Name = "btnBorrador";
            this.btnBorrador.Size = new System.Drawing.Size(53, 36);
            this.btnBorrador.TabIndex = 37;
            this.btnBorrador.UseVisualStyleBackColor = false;
            this.btnBorrador.Click += new System.EventHandler(this.btnBorrador_Click);
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBusqueda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Location = new System.Drawing.Point(379, 240);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(498, 29);
            this.cboBusqueda.Sorted = true;
            this.cboBusqueda.TabIndex = 38;
            // 
            // Equipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1172, 750);
            this.Controls.Add(this.cboBusqueda);
            this.Controls.Add(this.btnBorrador);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.txtSerieBusqueda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtgEquipos);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboMostrar);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Equipos";
            this.Text = "Equipos";
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erEquipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox grpDatos;
        private TextBox txtFechaPago;
        private TextBox txtPrecio;
        private TextBox txtSerie;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dtgEquipos;
        private ComboBox cboTipoRenta;
        private Label label6;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCancelar;
        private TextBox txtReferencia;
        private Label label7;
        private ComboBox cboMarcas;
        private Label label8;
        private ComboBox cboModelos;
        private TextBox txtSerieBusqueda;
        private Label label9;
        private Label label10;
        private ComboBox cboMostrar;
        private Button btnMostrar;
        private ErrorProvider erEquipos;
        private Button btnBuscar;
        private Button btnBorrador;
        private ComboBox cboClientes;
        private ComboBox cboBusqueda;
    }
}