using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedToner
{
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
            ControlesDesactivadosInicialmente();
            AgregarOpcionesBusqueda();
            AgregarModelos();
            AgregarOpcionesMostrar();
        }

        private void Servicios_Load(object sender, EventArgs e)
        {

        }

        private void ControlesDesactivadosInicialmente()
        {

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnReporte.Enabled = false;
            //Denegar escritura en combo boxs
            cboModelos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMostrar.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOpcionesMostrar.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void AgregarOpcionesBusqueda()
        {
            cboOpcionesMostrar.Items.Add("Clientes");
            cboOpcionesMostrar.Items.Add("Serie");
            cboOpcionesMostrar.Items.Add("Contador");
            cboOpcionesMostrar.Items.Add("Fecha");
        }

        public void AgregarOpcionesMostrar()
        {
            cboMostrar.Items.Add("Ultima Semana");
            cboMostrar.Items.Add("Ultimo Mes");
            cboMostrar.Items.Add("Mes pasado");
            cboMostrar.Items.Add("Este año");
            cboMostrar.Items.Add("Año pasado");
            cboMostrar.Items.Add("Todos");
        }

        public void AgregarModelos()
        {
            cboModelos.Items.Add("Hp");
            cboModelos.Items.Add("Brother");
            cboModelos.Items.Add("Canon");
            cboModelos.Items.Add("Samsung");
            cboModelos.Items.Add("Otro");
            cboModelos.Items.Add("Ricon Aficio");
        }

        private void cboOpcionesMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReporte.Enabled = true;
        }

        private void rtxtServicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string Hora = DateTime.Now.ToString("hh:mm:ss tt");
            string Fecha = dtpFecha.Value.ToString("yyy-MM-dd");



            MessageBox.Show(Fecha + " " + " " + Hora); 
        }
    }
}
