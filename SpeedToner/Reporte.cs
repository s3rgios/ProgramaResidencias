using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SpeedToner
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
            InicioAplicacion();
        }

        public void AgregarOpcionesBusqueda()
        {
            cboOpcionReporte.Items.Add("Clientes");
            cboOpcionReporte.Items.Add("Serie");
            cboOpcionReporte.Items.Add("Contador");
            cboOpcionReporte.Items.Add("Fecha");
            cboOpcionReporte.Items.Add("Fusor");
        }

        public void InicioAplicacion()
        {
            //Controles desactivados inicialmente
            btnGenerarReporte.Enabled = false;
            txtDato.Enabled = false;

            //Agregamos opciones al combo box
            AgregarOpcionesBusqueda();

            //Denegamos escritura en el combo box
            cboOpcionReporte.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {

        }  

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lparam);

        private void cboOpcionReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            btnGenerarReporte.Enabled = true;

            switch (cboOpcionReporte.SelectedItem.ToString())
            {
                case "Serie": MostrarTextBoxDato() ; break;
                case "Contador": MostrarTextBoxDato(); break;
                case "Fusor": MostrarTextBoxDato(); break;
                case "Clientes": MostrarComboBoxClientes(); break;
                default: txtDato.Visible = false; cboClientes.Visible = false; 
                    break;
            }
        }

        private void MostrarTextBoxDato()
        {
            txtDato.Enabled = false;
            cboClientes.Visible = false;
            txtDato.Visible = true;
            txtDato.Enabled = true;
            txtDato.Focus();
        }

        private void MostrarComboBoxClientes()
        {
            txtDato.Enabled = false;
            txtDato.Visible = false;
            cboClientes.Visible = true;
        }

        private void BarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
