namespace SpeedToner
{
    partial class Servicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servicios));
            this.label1 = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroFolio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTecnico = new System.Windows.Forms.TextBox();
            this.dtgServicios = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rtxtFallas = new System.Windows.Forms.RichTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.cboMostrar = new System.Windows.Forms.ComboBox();
            this.v = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFusor = new System.Windows.Forms.TextBox();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.rtxtServicio = new System.Windows.Forms.RichTextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cboModelos = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.erServicios = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnBorrador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).BeginInit();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // cboClientes
            // 
            this.cboClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(145, 72);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(336, 29);
            this.cboClientes.Sorted = true;
            this.cboClientes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número de Folio:";
            // 
            // txtNumeroFolio
            // 
            this.txtNumeroFolio.Location = new System.Drawing.Point(145, 32);
            this.txtNumeroFolio.Name = "txtNumeroFolio";
            this.txtNumeroFolio.Size = new System.Drawing.Size(336, 27);
            this.txtNumeroFolio.TabIndex = 1;
            this.txtNumeroFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFolio_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Marca:";
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(81, 114);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(401, 29);
            this.cboMarca.TabIndex = 3;
            this.cboMarca.SelectedIndexChanged += new System.EventHandler(this.cboMarca_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Serie:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(68, 196);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(413, 27);
            this.txtSerie.TabIndex = 5;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contador:";
            // 
            // txtContador
            // 
            this.txtContador.Location = new System.Drawing.Point(106, 230);
            this.txtContador.Name = "txtContador";
            this.txtContador.Size = new System.Drawing.Size(375, 27);
            this.txtContador.TabIndex = 6;
            this.txtContador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContador_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.label6.Location = new System.Drawing.Point(12, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(87, 267);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(394, 27);
            this.dtpFecha.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Técnico:";
            // 
            // txtTecnico
            // 
            this.txtTecnico.Location = new System.Drawing.Point(87, 303);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Size = new System.Drawing.Size(394, 27);
            this.txtTecnico.TabIndex = 8;
            this.txtTecnico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTecnico_KeyPress);
            // 
            // dtgServicios
            // 
            this.dtgServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dtgServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgServicios.Location = new System.Drawing.Point(11, 407);
            this.dtgServicios.Name = "dtgServicios";
            this.dtgServicios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgServicios.RowTemplate.Height = 25;
            this.dtgServicios.Size = new System.Drawing.Size(1149, 331);
            this.dtgServicios.TabIndex = 15;
            this.dtgServicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgServicios_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(483, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Servicio Realizado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(488, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "Reporte Fallas:";
            // 
            // rtxtFallas
            // 
            this.rtxtFallas.Location = new System.Drawing.Point(488, 233);
            this.rtxtFallas.Name = "rtxtFallas";
            this.rtxtFallas.Size = new System.Drawing.Size(649, 106);
            this.rtxtFallas.TabIndex = 12;
            this.rtxtFallas.Text = "";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(15, 358);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(68, 43);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(89, 358);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(68, 43);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(105)))), ((int)(((byte)(5)))));
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(523, 361);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 30);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReporte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReporte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporte.Location = new System.Drawing.Point(1032, 356);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(120, 45);
            this.btnReporte.TabIndex = 26;
            this.btnReporte.Text = "Reportes";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // cboMostrar
            // 
            this.cboMostrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboMostrar.FormattingEnabled = true;
            this.cboMostrar.Location = new System.Drawing.Point(794, 358);
            this.cboMostrar.Name = "cboMostrar";
            this.cboMostrar.Size = new System.Drawing.Size(218, 29);
            this.cboMostrar.TabIndex = 27;
            this.cboMostrar.SelectedIndexChanged += new System.EventHandler(this.cboMostrar_SelectedIndexChanged);
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.Location = new System.Drawing.Point(481, 28);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(70, 21);
            this.v.TabIndex = 28;
            this.v.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(557, 26);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(461, 27);
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Modelo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(483, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 21);
            this.label10.TabIndex = 32;
            this.label10.Text = "Fusor:";
            // 
            // txtFusor
            // 
            this.txtFusor.Location = new System.Drawing.Point(557, 57);
            this.txtFusor.Name = "txtFusor";
            this.txtFusor.Size = new System.Drawing.Size(461, 27);
            this.txtFusor.TabIndex = 10;
            this.txtFusor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFusor_KeyPress);
            // 
            // grpDatos
            // 
            this.grpDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(69)))), ((int)(((byte)(82)))));
            this.grpDatos.Controls.Add(this.rtxtServicio);
            this.grpDatos.Controls.Add(this.txtCliente);
            this.grpDatos.Controls.Add(this.cboModelos);
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Controls.Add(this.txtFusor);
            this.grpDatos.Controls.Add(this.label10);
            this.grpDatos.Controls.Add(this.cboClientes);
            this.grpDatos.Controls.Add(this.txtNumeroFolio);
            this.grpDatos.Controls.Add(this.label11);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.txtUsuario);
            this.grpDatos.Controls.Add(this.cboMarca);
            this.grpDatos.Controls.Add(this.v);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.txtSerie);
            this.grpDatos.Controls.Add(this.label5);
            this.grpDatos.Controls.Add(this.txtContador);
            this.grpDatos.Controls.Add(this.label6);
            this.grpDatos.Controls.Add(this.dtpFecha);
            this.grpDatos.Controls.Add(this.label7);
            this.grpDatos.Controls.Add(this.txtTecnico);
            this.grpDatos.Controls.Add(this.rtxtFallas);
            this.grpDatos.Controls.Add(this.label8);
            this.grpDatos.Controls.Add(this.label9);
            this.grpDatos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpDatos.ForeColor = System.Drawing.Color.White;
            this.grpDatos.Location = new System.Drawing.Point(15, 8);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(1146, 344);
            this.grpDatos.TabIndex = 34;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos:";
            // 
            // rtxtServicio
            // 
            this.rtxtServicio.Location = new System.Drawing.Point(488, 112);
            this.rtxtServicio.Name = "rtxtServicio";
            this.rtxtServicio.Size = new System.Drawing.Size(649, 96);
            this.rtxtServicio.TabIndex = 11;
            this.rtxtServicio.Text = "";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(81, 74);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(58, 27);
            this.txtCliente.TabIndex = 34;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged_1);
            // 
            // cboModelos
            // 
            this.cboModelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelos.FormattingEnabled = true;
            this.cboModelos.Location = new System.Drawing.Point(81, 154);
            this.cboModelos.Name = "cboModelos";
            this.cboModelos.Size = new System.Drawing.Size(401, 29);
            this.cboModelos.Sorted = true;
            this.cboModelos.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(163, 358);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(68, 43);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // erServicios
            // 
            this.erServicios.ContainerControl = this;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBusqueda.Location = new System.Drawing.Point(260, 364);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.PlaceholderText = "Numero de folio o fusor";
            this.txtBusqueda.Size = new System.Drawing.Size(244, 27);
            this.txtBusqueda.TabIndex = 34;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(685, 364);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 21);
            this.label13.TabIndex = 37;
            this.label13.Text = "Mostrar por:";
            // 
            // btnBorrador
            // 
            this.btnBorrador.BackColor = System.Drawing.Color.Thistle;
            this.btnBorrador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBorrador.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrador.Image")));
            this.btnBorrador.Location = new System.Drawing.Point(605, 357);
            this.btnBorrador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBorrador.Name = "btnBorrador";
            this.btnBorrador.Size = new System.Drawing.Size(56, 37);
            this.btnBorrador.TabIndex = 38;
            this.btnBorrador.UseVisualStyleBackColor = false;
            this.btnBorrador.Click += new System.EventHandler(this.btnBorrador_Click);
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1172, 750);
            this.Controls.Add(this.btnBorrador);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.cboMostrar);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtgServicios);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Servicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.Servicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cboClientes;
        private Label label2;
        private TextBox txtNumeroFolio;
        private Label label3;
        private ComboBox cboMarca;
        private Label label4;
        private TextBox txtSerie;
        private Label label5;
        private TextBox txtContador;
        private Label label6;
        private DateTimePicker dtpFecha;
        private Label label7;
        private TextBox txtTecnico;
        private DataGridView dtgServicios;
        private Label label8;
        private Label label9;
        private RichTextBox rtxtFallas;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnBuscar;
        private Button btnReporte;
        private ComboBox cboMostrar;
        private Label v;
        private TextBox txtUsuario;
        private Label label11;
        private Label label10;
        private TextBox txtFusor;
        private GroupBox grpDatos;
        private Button btnCancelar;
        private ErrorProvider erServicios;
        private ComboBox cboModelos;
        private TextBox txtBusqueda;
        private TextBox txtCliente;
        private RichTextBox rtxtServicio;
        private Label label13;
        private Button btnBorrador;
    }
}