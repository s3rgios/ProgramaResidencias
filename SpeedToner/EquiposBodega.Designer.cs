namespace SpeedToner
{
    partial class EquiposBodega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquiposBodega));
            this.cboMarcas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboModelos = new System.Windows.Forms.ComboBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.rtxtNotas = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.dtgEquipos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.erBodega = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBorrador = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erBodega)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMarcas
            // 
            this.cboMarcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMarcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarcas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboMarcas.FormattingEnabled = true;
            this.cboMarcas.Location = new System.Drawing.Point(89, 31);
            this.cboMarcas.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboMarcas.Name = "cboMarcas";
            this.cboMarcas.Size = new System.Drawing.Size(342, 29);
            this.cboMarcas.TabIndex = 1;
            this.cboMarcas.SelectedIndexChanged += new System.EventHandler(this.cboMarcas_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(13, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 21);
            this.label8.TabIndex = 21;
            this.label8.Text = "Marca:";
            // 
            // cboModelos
            // 
            this.cboModelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboModelos.FormattingEnabled = true;
            this.cboModelos.Location = new System.Drawing.Point(89, 68);
            this.cboModelos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboModelos.Name = "cboModelos";
            this.cboModelos.Size = new System.Drawing.Size(342, 29);
            this.cboModelos.TabIndex = 2;
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSerie.Location = new System.Drawing.Point(73, 111);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(358, 27);
            this.txtSerie.TabIndex = 3;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Serie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Modelo:";
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.rtxtNotas);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.cboEstado);
            this.grpDatos.Controls.Add(this.lbl);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Controls.Add(this.txtUbicacion);
            this.grpDatos.Controls.Add(this.label8);
            this.grpDatos.Controls.Add(this.cboMarcas);
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.cboModelos);
            this.grpDatos.Controls.Add(this.txtSerie);
            this.grpDatos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grpDatos.Location = new System.Drawing.Point(12, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(1148, 223);
            this.grpDatos.TabIndex = 23;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos:";
            // 
            // rtxtNotas
            // 
            this.rtxtNotas.Location = new System.Drawing.Point(482, 58);
            this.rtxtNotas.Name = "rtxtNotas";
            this.rtxtNotas.Size = new System.Drawing.Size(639, 152);
            this.rtxtNotas.TabIndex = 6;
            this.rtxtNotas.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(482, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Notas:";
            // 
            // cboEstado
            // 
            this.cboEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Disponible",
            "Inhabilitado"});
            this.cboEstado.Location = new System.Drawing.Point(96, 178);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(335, 29);
            this.cboEstado.TabIndex = 5;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl.Location = new System.Drawing.Point(18, 186);
            this.lbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(68, 21);
            this.lbl.TabIndex = 25;
            this.lbl.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ubicacion:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUbicacion.Location = new System.Drawing.Point(116, 146);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(315, 27);
            this.txtUbicacion.TabIndex = 4;
            // 
            // dtgEquipos
            // 
            this.dtgEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEquipos.Location = new System.Drawing.Point(21, 290);
            this.dtgEquipos.Name = "dtgEquipos";
            this.dtgEquipos.RowTemplate.Height = 25;
            this.dtgEquipos.Size = new System.Drawing.Size(1139, 422);
            this.dtgEquipos.TabIndex = 24;
            this.dtgEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEquipos_CellClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(21, 241);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(68, 47);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(95, 241);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(68, 47);
            this.btnEliminar.TabIndex = 26;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(169, 241);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(68, 47);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // erBodega
            // 
            this.erBodega.ContainerControl = this;
            // 
            // btnBorrador
            // 
            this.btnBorrador.BackColor = System.Drawing.Color.Thistle;
            this.btnBorrador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBorrador.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrador.Image")));
            this.btnBorrador.Location = new System.Drawing.Point(698, 241);
            this.btnBorrador.Name = "btnBorrador";
            this.btnBorrador.Size = new System.Drawing.Size(53, 37);
            this.btnBorrador.TabIndex = 39;
            this.btnBorrador.UseVisualStyleBackColor = false;
            this.btnBorrador.Click += new System.EventHandler(this.btnBorrador_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBusqueda.Location = new System.Drawing.Point(269, 257);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.PlaceholderText = "Serie";
            this.txtBusqueda.Size = new System.Drawing.Size(244, 27);
            this.txtBusqueda.TabIndex = 40;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(105)))), ((int)(((byte)(5)))));
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(533, 255);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 30);
            this.btnBuscar.TabIndex = 41;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // EquiposBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1172, 749);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnBorrador);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtgEquipos);
            this.Controls.Add(this.grpDatos);
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "EquiposBodega";
            this.Text = "EquiposBodega";
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erBodega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboMarcas;
        private Label label8;
        private ComboBox cboModelos;
        private TextBox txtSerie;
        private Label label3;
        private Label label2;
        private GroupBox grpDatos;
        private RichTextBox rtxtNotas;
        private Label label4;
        private ComboBox cboEstado;
        private Label lbl;
        private Label label1;
        private TextBox txtUbicacion;
        private DataGridView dtgEquipos;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCancelar;
        private ErrorProvider erBodega;
        private Button btnBorrador;
        private TextBox txtBusqueda;
        private Button btnBuscar;
    }
}