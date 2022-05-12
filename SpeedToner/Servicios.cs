using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedToner
{
    public partial class Servicios : Form
    {
        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();
        //private string NumeroFolio = null;
        public Servicios()
        {
            InitializeComponent();
            ControlesDesactivadosInicialmente();
            AgregarOpcionesBusqueda();
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
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMostrar.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOpcionesMostrar.DropDownStyle = ComboBoxStyle.DropDownList;

            LlenarComboBox(cboClientes, "SeleccionarClientes", 0);
            LlenarComboBox(cboMarca, "SeleccionarMarca", 1);
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


        private void cboOpcionesMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReporte.Enabled = true;
        }

        private void rtxtServicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string NumeroFolio = txtNumeroFolio.Text;
                string IdCliente = cboClientes.SelectedItem.ToString();
                int IdC = BuscarId(IdCliente, "ObtenerIdCliente");
                string IdMarca = cboMarca.SelectedItem.ToString();
                int IdM = BuscarId(IdMarca, "ObtenerIdMarca");
                string Modelo = txtModelo.Text;
                string Serie = txtSerie.Text;
                string Contador = txtContador.Text;
                string Fecha = dtpFecha.Value.ToString("yyy-MM-dd");
                string Hora = DateTime.Now.ToString("hh:mm:ss tt");
                string Tecnico = txtTecnico.Text;
                string Usuario = txtUsuario.Text;
                string Fusor = txtFusor.Text;
                string Servicio = rtxtServicio.Text;
                string Falla = rtxtFallas.Text;

                
                //objetoCN.Insertar(NumeroFolio,  IdCliente, IdMarca, Modelo, Serie, Contador, Fecha, Hora, Tecnico, Usuario, Fusor, Servicio, Falla);
                MessageBox.Show("Servicio registrado correctamente " + IdC + " IdMarca:" + IdM);
                LimpiarForm();
            }
            catch (Exception ex)
            {
               MessageBox.Show("no se pudo editar los datos por: " + ex);
                
            }

          
        }
        private void LimpiarForm()
        {
            foreach (Control c in grpDatos.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                txtNumeroFolio.Focus();
            }
        }

        public void LlenarComboBox(ComboBox cb, string sp, int indice)
        {
            cb.Items.Clear();

            SqlDataReader dr = objetoCN.LlenarComboBox(sp);

            while (dr.Read())
            {
                cb.Items.Add(dr[indice].ToString());
            }
            
            cb.Items.Insert(0, " ");
            cb.SelectedIndex = 0;
            dr.Close();
            cn.CerrarConexion();
        }

        public int BuscarId(string campo, string sp)
        {
            SqlDataReader dr = objetoCN.BuscarId(campo,sp);
            int id = 0;

            while (dr.Read())
            {
                id = int.Parse(dr[0].ToString());
            }

            dr.Close();
            cn.CerrarConexion();
            return id;
        }
    }

    
}
