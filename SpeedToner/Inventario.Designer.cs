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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOficina = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dtgCartuchos = new System.Windows.Forms.DataGridView();
            this.grpDatosInventario = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.lblRestarBodega = new System.Windows.Forms.Label();
            this.btnRestar = new System.Windows.Forms.Button();
            this.txtRestanteBodega = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtBodega = new System.Windows.Forms.TextBox();
            this.lblBodega = new System.Windows.Forms.Label();
            this.lblOficina = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Inventario = new System.Windows.Forms.TabPage();
            this.Registro = new System.Windows.Forms.TabPage();
            this.grpDatosRegistro = new System.Windows.Forms.GroupBox();
            this.cboMarcas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadEntrada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radBodega = new System.Windows.Forms.RadioButton();
            this.radOficina = new System.Windows.Forms.RadioButton();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cboModelos = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.txtCantidadSalida = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnImprimirInventario = new System.Windows.Forms.Button();
            this.erInventario = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnBorrador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartuchos)).BeginInit();
            this.grpDatosInventario.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Inventario.SuspendLayout();
            this.Registro.SuspendLayout();
            this.grpDatosRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(561, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(385, 27);
            this.dtpFecha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo cartucho:";
            // 
            // txtOficina
            // 
            this.txtOficina.Location = new System.Drawing.Point(169, 104);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(294, 27);
            this.txtOficina.TabIndex = 3;
            this.txtOficina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOficina_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(21, 257);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(69, 43);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(96, 257);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(69, 43);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtgCartuchos
            // 
            this.dtgCartuchos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCartuchos.Location = new System.Drawing.Point(12, 314);
            this.dtgCartuchos.Name = "dtgCartuchos";
            this.dtgCartuchos.RowTemplate.Height = 25;
            this.dtgCartuchos.Size = new System.Drawing.Size(1148, 423);
            this.dtgCartuchos.TabIndex = 18;
            this.dtgCartuchos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCartuchos_CellClick);
            // 
            // grpDatosInventario
            // 
            this.grpDatosInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.grpDatosInventario.Controls.Add(this.label3);
            this.grpDatosInventario.Controls.Add(this.cboMarca);
            this.grpDatosInventario.Controls.Add(this.lblRestarBodega);
            this.grpDatosInventario.Controls.Add(this.btnRestar);
            this.grpDatosInventario.Controls.Add(this.txtRestanteBodega);
            this.grpDatosInventario.Controls.Add(this.txtModelo);
            this.grpDatosInventario.Controls.Add(this.txtBodega);
            this.grpDatosInventario.Controls.Add(this.lblBodega);
            this.grpDatosInventario.Controls.Add(this.lblOficina);
            this.grpDatosInventario.Controls.Add(this.dtpFecha);
            this.grpDatosInventario.Controls.Add(this.label1);
            this.grpDatosInventario.Controls.Add(this.label2);
            this.grpDatosInventario.Controls.Add(this.txtOficina);
            this.grpDatosInventario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grpDatosInventario.Location = new System.Drawing.Point(6, 6);
            this.grpDatosInventario.Name = "grpDatosInventario";
            this.grpDatosInventario.Size = new System.Drawing.Size(1050, 183);
            this.grpDatosInventario.TabIndex = 19;
            this.grpDatosInventario.TabStop = false;
            this.grpDatosInventario.Text = "Datos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 34;
            this.label3.Text = "Marca:";
            // 
            // cboMarca
            // 
            this.cboMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(169, 24);
            this.cboMarca.Margin = new System.Windows.Forms.Padding(2);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(294, 29);
            this.cboMarca.Sorted = true;
            this.cboMarca.TabIndex = 1;
            // 
            // lblRestarBodega
            // 
            this.lblRestarBodega.AutoSize = true;
            this.lblRestarBodega.Location = new System.Drawing.Point(492, 72);
            this.lblRestarBodega.Name = "lblRestarBodega";
            this.lblRestarBodega.Size = new System.Drawing.Size(224, 21);
            this.lblRestarBodega.TabIndex = 31;
            this.lblRestarBodega.Text = "Mover de bodega a oficina";
            // 
            // btnRestar
            // 
            this.btnRestar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRestar.Location = new System.Drawing.Point(722, 97);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(120, 28);
            this.btnRestar.TabIndex = 30;
            this.btnRestar.Text = "Calcular";
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Visible = false;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // txtRestanteBodega
            // 
            this.txtRestanteBodega.Location = new System.Drawing.Point(496, 98);
            this.txtRestanteBodega.Name = "txtRestanteBodega";
            this.txtRestanteBodega.Size = new System.Drawing.Size(220, 27);
            this.txtRestanteBodega.TabIndex = 29;
            this.txtRestanteBodega.Visible = false;
            this.txtRestanteBodega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRestanteBodega_KeyPress);
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(169, 64);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(294, 27);
            this.txtModelo.TabIndex = 2;
            this.txtModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelo_KeyPress);
            // 
            // txtBodega
            // 
            this.txtBodega.Location = new System.Drawing.Point(170, 137);
            this.txtBodega.Name = "txtBodega";
            this.txtBodega.Size = new System.Drawing.Size(293, 27);
            this.txtBodega.TabIndex = 4;
            this.txtBodega.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBodega_KeyDown);
            this.txtBodega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBodega_KeyPress);
            // 
            // lblBodega
            // 
            this.lblBodega.AutoSize = true;
            this.lblBodega.Location = new System.Drawing.Point(6, 137);
            this.lblBodega.Name = "lblBodega";
            this.lblBodega.Size = new System.Drawing.Size(157, 21);
            this.lblBodega.TabIndex = 25;
            this.lblBodega.Text = "Cantidad Bodega:";
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.Location = new System.Drawing.Point(6, 104);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(151, 21);
            this.lblOficina.TabIndex = 24;
            this.lblOficina.Text = "Cantidad Oficina:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(171, 257);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 43);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Inventario);
            this.tabControl1.Controls.Add(this.Registro);
            this.tabControl1.Location = new System.Drawing.Point(21, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1070, 228);
            this.tabControl1.TabIndex = 25;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab_Inventario
            // 
            this.tab_Inventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.tab_Inventario.Controls.Add(this.grpDatosInventario);
            this.tab_Inventario.Location = new System.Drawing.Point(4, 30);
            this.tab_Inventario.Name = "tab_Inventario";
            this.tab_Inventario.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Inventario.Size = new System.Drawing.Size(1062, 194);
            this.tab_Inventario.TabIndex = 0;
            this.tab_Inventario.Text = "Inventario";
            // 
            // Registro
            // 
            this.Registro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Registro.Controls.Add(this.grpDatosRegistro);
            this.Registro.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Registro.Location = new System.Drawing.Point(4, 24);
            this.Registro.Name = "Registro";
            this.Registro.Padding = new System.Windows.Forms.Padding(3);
            this.Registro.Size = new System.Drawing.Size(1062, 200);
            this.Registro.TabIndex = 1;
            this.Registro.Text = "Registros";
            // 
            // grpDatosRegistro
            // 
            this.grpDatosRegistro.Controls.Add(this.cboMarcas);
            this.grpDatosRegistro.Controls.Add(this.label4);
            this.grpDatosRegistro.Controls.Add(this.txtCantidadEntrada);
            this.grpDatosRegistro.Controls.Add(this.label7);
            this.grpDatosRegistro.Controls.Add(this.radBodega);
            this.grpDatosRegistro.Controls.Add(this.radOficina);
            this.grpDatosRegistro.Controls.Add(this.dtpFechaRegistro);
            this.grpDatosRegistro.Controls.Add(this.label8);
            this.grpDatosRegistro.Controls.Add(this.cboModelos);
            this.grpDatosRegistro.Controls.Add(this.label9);
            this.grpDatosRegistro.Controls.Add(this.label10);
            this.grpDatosRegistro.Controls.Add(this.label11);
            this.grpDatosRegistro.Controls.Add(this.cboClientes);
            this.grpDatosRegistro.Controls.Add(this.txtCantidadSalida);
            this.grpDatosRegistro.Controls.Add(this.label12);
            this.grpDatosRegistro.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.grpDatosRegistro.Location = new System.Drawing.Point(6, 6);
            this.grpDatosRegistro.Name = "grpDatosRegistro";
            this.grpDatosRegistro.Size = new System.Drawing.Size(1050, 177);
            this.grpDatosRegistro.TabIndex = 26;
            this.grpDatosRegistro.TabStop = false;
            this.grpDatosRegistro.Text = "Datos";
            this.grpDatosRegistro.Enter += new System.EventHandler(this.grpDatosRegistro_Enter);
            // 
            // cboMarcas
            // 
            this.cboMarcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMarcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarcas.FormattingEnabled = true;
            this.cboMarcas.Location = new System.Drawing.Point(88, 61);
            this.cboMarcas.Name = "cboMarcas";
            this.cboMarcas.Size = new System.Drawing.Size(375, 29);
            this.cboMarcas.Sorted = true;
            this.cboMarcas.TabIndex = 2;
            this.cboMarcas.SelectedIndexChanged += new System.EventHandler(this.cboMarcas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Marca:";
            // 
            // txtCantidadEntrada
            // 
            this.txtCantidadEntrada.Location = new System.Drawing.Point(662, 63);
            this.txtCantidadEntrada.Name = "txtCantidadEntrada";
            this.txtCantidadEntrada.Size = new System.Drawing.Size(293, 27);
            this.txtCantidadEntrada.TabIndex = 6;
            this.txtCantidadEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadEntrada_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Agregar a:";
            // 
            // radBodega
            // 
            this.radBodega.AutoSize = true;
            this.radBodega.Location = new System.Drawing.Point(690, 107);
            this.radBodega.Name = "radBodega";
            this.radBodega.Size = new System.Drawing.Size(90, 25);
            this.radBodega.TabIndex = 20;
            this.radBodega.TabStop = true;
            this.radBodega.Text = "Bodega";
            this.radBodega.UseVisualStyleBackColor = true;
            // 
            // radOficina
            // 
            this.radOficina.AutoSize = true;
            this.radOficina.Location = new System.Drawing.Point(600, 107);
            this.radOficina.Name = "radOficina";
            this.radOficina.Size = new System.Drawing.Size(84, 25);
            this.radOficina.TabIndex = 19;
            this.radOficina.TabStop = true;
            this.radOficina.Text = "Oficina";
            this.radOficina.UseVisualStyleBackColor = true;
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Location = new System.Drawing.Point(78, 27);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(385, 27);
            this.dtpFechaRegistro.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Fecha:";
            // 
            // cboModelos
            // 
            this.cboModelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelos.FormattingEnabled = true;
            this.cboModelos.Location = new System.Drawing.Point(88, 101);
            this.cboModelos.Name = "cboModelos";
            this.cboModelos.Size = new System.Drawing.Size(375, 29);
            this.cboModelos.Sorted = true;
            this.cboModelos.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Modelo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(497, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "Cliente:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(497, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 21);
            this.label11.TabIndex = 11;
            this.label11.Text = "Cantidad Entrada:";
            // 
            // cboClientes
            // 
            this.cboClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(573, 24);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(455, 29);
            this.cboClientes.Sorted = true;
            this.cboClientes.TabIndex = 5;
            // 
            // txtCantidadSalida
            // 
            this.txtCantidadSalida.Location = new System.Drawing.Point(154, 137);
            this.txtCantidadSalida.Name = "txtCantidadSalida";
            this.txtCantidadSalida.Size = new System.Drawing.Size(309, 27);
            this.txtCantidadSalida.TabIndex = 4;
            this.txtCantidadSalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadSalida_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 21);
            this.label12.TabIndex = 9;
            this.label12.Text = "Cantidad Salida:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(435, 281);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(210, 27);
            this.txtBusqueda.TabIndex = 26;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(670, 271);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(53, 37);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImprimirInventario
            // 
            this.btnImprimirInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnImprimirInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirInventario.Image")));
            this.btnImprimirInventario.Location = new System.Drawing.Point(301, 251);
            this.btnImprimirInventario.Name = "btnImprimirInventario";
            this.btnImprimirInventario.Size = new System.Drawing.Size(58, 49);
            this.btnImprimirInventario.TabIndex = 28;
            this.btnImprimirInventario.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImprimirInventario.UseVisualStyleBackColor = false;
            this.btnImprimirInventario.Click += new System.EventHandler(this.btnImprimirInventario_Click);
            // 
            // erInventario
            // 
            this.erInventario.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(435, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 21);
            this.label5.TabIndex = 35;
            this.label5.Text = "Modelo cartucho:";
            // 
            // btnBorrador
            // 
            this.btnBorrador.BackColor = System.Drawing.Color.Thistle;
            this.btnBorrador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBorrador.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrador.Image")));
            this.btnBorrador.Location = new System.Drawing.Point(729, 272);
            this.btnBorrador.Name = "btnBorrador";
            this.btnBorrador.Size = new System.Drawing.Size(53, 36);
            this.btnBorrador.TabIndex = 36;
            this.btnBorrador.UseVisualStyleBackColor = false;
            this.btnBorrador.Click += new System.EventHandler(this.btnBorrador_Click);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1172, 749);
            this.Controls.Add(this.btnBorrador);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnImprimirInventario);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtgCartuchos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inventario";
            this.Text = "6";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartuchos)).EndInit();
            this.grpDatosInventario.ResumeLayout(false);
            this.grpDatosInventario.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_Inventario.ResumeLayout(false);
            this.Registro.ResumeLayout(false);
            this.grpDatosRegistro.ResumeLayout(false);
            this.grpDatosRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFecha;
        private Label label2;
        private TextBox txtOficina;
        private Button btnGuardar;
        private Button btnEliminar;
        private DataGridView dtgCartuchos;
        private GroupBox grpDatosInventario;
        private Button btnCancelar;
        private Label lblOficina;
        private Label lblBodega;
        private TextBox txtBodega;
        private TabControl tabControl1;
        private TabPage tab_Inventario;
        private TabPage Registro;
        private GroupBox grpDatosRegistro;
        private TextBox txtCantidadEntrada;
        private Label label7;
        private RadioButton radBodega;
        private RadioButton radOficina;
        private DateTimePicker dtpFechaRegistro;
        private Label label8;
        private ComboBox cboModelos;
        private Label label9;
        private Label label10;
        private ComboBox cboClientes;
        private TextBox txtCantidadSalida;
        private Label label12;
        private TextBox txtModelo;
        private Label label11;
        private TextBox txtBusqueda;
        private Button btnBuscar;
        private Button btnRestar;
        private TextBox txtRestanteBodega;
        private Label lblRestarBodega;
        private ComboBox cboMarca;
        private ComboBox cboMarcas;
        private Label label4;
        private Button btnImprimirInventario;
        private ErrorProvider erInventario;
        private Label label3;
        private Label label5;
        private Button btnBorrador;
    }
}