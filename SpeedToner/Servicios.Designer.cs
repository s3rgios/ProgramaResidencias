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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
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
            this.rtxtServicio = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rtxtFallas = new System.Windows.Forms.RichTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.cboMostrar = new System.Windows.Forms.ComboBox();
            this.v = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFusor = new System.Windows.Forms.TextBox();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(91, 56);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(43, 27);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.Click += new System.EventHandler(this.txtCliente_Click);
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // cboClientes
            // 
            this.cboClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(139, 54);
            this.cboClientes.Margin = new System.Windows.Forms.Padding(2);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(289, 29);
            this.cboClientes.Sorted = true;
            this.cboClientes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número de Folio:";
            // 
            // txtNumeroFolio
            // 
            this.txtNumeroFolio.Location = new System.Drawing.Point(170, 21);
            this.txtNumeroFolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroFolio.Name = "txtNumeroFolio";
            this.txtNumeroFolio.Size = new System.Drawing.Size(258, 27);
            this.txtNumeroFolio.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Marca:";
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(87, 90);
            this.cboMarca.Margin = new System.Windows.Forms.Padding(2);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(341, 29);
            this.cboMarca.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Serie:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(87, 169);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(341, 27);
            this.txtSerie.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contador:";
            // 
            // txtContador
            // 
            this.txtContador.Location = new System.Drawing.Point(113, 202);
            this.txtContador.Margin = new System.Windows.Forms.Padding(2);
            this.txtContador.Name = "txtContador";
            this.txtContador.Size = new System.Drawing.Size(322, 27);
            this.txtContador.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.label6.Location = new System.Drawing.Point(7, 242);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(83, 240);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(345, 27);
            this.dtpFecha.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 271);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Técnico:";
            // 
            // txtTecnico
            // 
            this.txtTecnico.Location = new System.Drawing.Point(97, 273);
            this.txtTecnico.Margin = new System.Windows.Forms.Padding(2);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Size = new System.Drawing.Size(299, 27);
            this.txtTecnico.TabIndex = 8;
            // 
            // dtgServicios
            // 
            this.dtgServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dtgServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgServicios.Location = new System.Drawing.Point(16, 373);
            this.dtgServicios.Margin = new System.Windows.Forms.Padding(2);
            this.dtgServicios.Name = "dtgServicios";
            this.dtgServicios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgServicios.RowTemplate.Height = 25;
            this.dtgServicios.Size = new System.Drawing.Size(1145, 366);
            this.dtgServicios.TabIndex = 15;
            this.dtgServicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgServicios_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(449, 82);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Servicio Realizado:";
            // 
            // rtxtServicio
            // 
            this.rtxtServicio.Location = new System.Drawing.Point(449, 107);
            this.rtxtServicio.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtServicio.Name = "rtxtServicio";
            this.rtxtServicio.Size = new System.Drawing.Size(697, 77);
            this.rtxtServicio.TabIndex = 11;
            this.rtxtServicio.Text = "";
            this.rtxtServicio.TextChanged += new System.EventHandler(this.rtxtServicio_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(449, 186);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "Reporte Fallas:";
            // 
            // rtxtFallas
            // 
            this.rtxtFallas.Location = new System.Drawing.Point(449, 213);
            this.rtxtFallas.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtFallas.Name = "rtxtFallas";
            this.rtxtFallas.Size = new System.Drawing.Size(697, 87);
            this.rtxtFallas.TabIndex = 12;
            this.rtxtFallas.Text = "";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(9, 316);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 53);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(130, 316);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(112, 52);
            this.btnModificar.TabIndex = 21;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(246, 316);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(112, 52);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Location = new System.Drawing.Point(526, 316);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 51);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMostrar.Location = new System.Drawing.Point(764, 316);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(112, 52);
            this.btnMostrar.TabIndex = 24;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReporte.Location = new System.Drawing.Point(921, 318);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(2);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(112, 51);
            this.btnReporte.TabIndex = 26;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // cboMostrar
            // 
            this.cboMostrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboMostrar.FormattingEnabled = true;
            this.cboMostrar.Location = new System.Drawing.Point(652, 328);
            this.cboMostrar.Margin = new System.Windows.Forms.Padding(2);
            this.cboMostrar.Name = "cboMostrar";
            this.cboMostrar.Size = new System.Drawing.Size(108, 29);
            this.cboMostrar.TabIndex = 27;
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.Location = new System.Drawing.Point(449, 21);
            this.v.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(70, 21);
            this.v.TabIndex = 28;
            this.v.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(534, 18);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(370, 27);
            this.txtUsuario.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 133);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(88, 130);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(2);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(340, 27);
            this.txtModelo.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(449, 54);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 21);
            this.label10.TabIndex = 32;
            this.label10.Text = "Fusor:";
            // 
            // txtFusor
            // 
            this.txtFusor.Location = new System.Drawing.Point(534, 51);
            this.txtFusor.Margin = new System.Windows.Forms.Padding(2);
            this.txtFusor.Name = "txtFusor";
            this.txtFusor.Size = new System.Drawing.Size(370, 27);
            this.txtFusor.TabIndex = 10;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Controls.Add(this.txtFusor);
            this.grpDatos.Controls.Add(this.txtCliente);
            this.grpDatos.Controls.Add(this.label10);
            this.grpDatos.Controls.Add(this.cboClientes);
            this.grpDatos.Controls.Add(this.txtModelo);
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
            this.grpDatos.Controls.Add(this.rtxtServicio);
            this.grpDatos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpDatos.Location = new System.Drawing.Point(9, -1);
            this.grpDatos.Margin = new System.Windows.Forms.Padding(2);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Padding = new System.Windows.Forms.Padding(2);
            this.grpDatos.Size = new System.Drawing.Size(1150, 313);
            this.grpDatos.TabIndex = 34;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(371, 316);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 52);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1172, 750);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.cboMostrar);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtgServicios);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Servicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.Servicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox txtCliente;
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
        private RichTextBox rtxtServicio;
        private Label label9;
        private RichTextBox rtxtFallas;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnBuscar;
        private Button btnMostrar;
        private Button btnReporte;
        private ComboBox cboMostrar;
        private Label v;
        private TextBox txtUsuario;
        private Label label11;
        private TextBox txtModelo;
        private Label label10;
        private TextBox txtFusor;
        private GroupBox grpDatos;
        private Button btnCancelar;
    }
}