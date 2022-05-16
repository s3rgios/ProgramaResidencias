namespace SpeedToner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BarraSuperior = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInventario = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnServicios = new System.Windows.Forms.Button();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.BarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.PanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(117)))), ((int)(((byte)(20)))));
            this.BarraSuperior.Controls.Add(this.btnRestaurar);
            this.BarraSuperior.Controls.Add(this.btnMaximizar);
            this.BarraSuperior.Controls.Add(this.btnMinimizar);
            this.BarraSuperior.Controls.Add(this.btnCerrar);
            this.BarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraSuperior.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.BarraSuperior.Name = "BarraSuperior";
            this.BarraSuperior.Size = new System.Drawing.Size(1386, 38);
            this.BarraSuperior.TabIndex = 0;
            this.BarraSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraSuperior_MouseDown);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.ErrorImage")));
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(1302, 7);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(25, 25);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.ErrorImage")));
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(1302, 7);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(25, 25);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.ErrorImage")));
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1261, 7);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.ErrorImage")));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1349, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PanelMenu
            // 
            this.PanelMenu.AllowDrop = true;
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.PanelMenu.Controls.Add(this.panel3);
            this.PanelMenu.Controls.Add(this.btnClientes);
            this.PanelMenu.Controls.Add(this.pictureBox1);
            this.PanelMenu.Controls.Add(this.panel2);
            this.PanelMenu.Controls.Add(this.btnInventario);
            this.PanelMenu.Controls.Add(this.panel1);
            this.PanelMenu.Controls.Add(this.btnServicios);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 38);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(214, 750);
            this.PanelMenu.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel3.Location = new System.Drawing.Point(3, 326);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 57);
            this.panel3.TabIndex = 6;
            // 
            // btnClientes
            // 
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(12, 326);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(199, 57);
            this.btnClientes.TabIndex = 7;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.Location = new System.Drawing.Point(3, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 57);
            this.panel2.TabIndex = 5;
            // 
            // btnInventario
            // 
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInventario.Image")));
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.Location = new System.Drawing.Point(12, 238);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(196, 57);
            this.btnInventario.TabIndex = 5;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Location = new System.Drawing.Point(3, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 57);
            this.panel1.TabIndex = 4;
            // 
            // btnServicios
            // 
            this.btnServicios.FlatAppearance.BorderSize = 0;
            this.btnServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnServicios.ForeColor = System.Drawing.Color.White;
            this.btnServicios.Image = ((System.Drawing.Image)(resources.GetObject("btnServicios.Image")));
            this.btnServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicios.Location = new System.Drawing.Point(12, 150);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(199, 57);
            this.btnServicios.TabIndex = 3;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.UseVisualStyleBackColor = true;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(69)))), ((int)(((byte)(82)))));
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(214, 38);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(1172, 750);
            this.PanelContenedor.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.PanelMenu);
            this.Controls.Add(this.BarraSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.BarraSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.PanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel BarraSuperior;
        private PictureBox btnRestaurar;
        private PictureBox btnMaximizar;
        private PictureBox btnMinimizar;
        private PictureBox btnCerrar;
        private Panel PanelMenu;
        private Panel PanelContenedor;
        private Button btnServicios;
        private Panel panel1;
        private Panel panel2;
        private Button btnInventario;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Button btnClientes;
    }
}