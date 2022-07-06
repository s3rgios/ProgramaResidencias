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
using System.Data.SqlClient;
using System.Diagnostics;

namespace SpeedToner
{
    public partial class txtCliente : Form
    {
        string Parametro;
        string TipoBusqueda = "";
        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lparam);
        public txtCliente()
        {
            InitializeComponent();
            InicioAplicacion();
        }
        #region Inicio
        public void AgregarOpcionesBusqueda()
        {
            cboOpcionReporte.Items.Add("Cliente");
            cboOpcionReporte.Items.Add("Serie");
            cboOpcionReporte.Items.Add("Fecha");
            cboOpcionReporte.Items.Add("Fusor");
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

        public void InicioAplicacion()
        {
            //Controles desactivados inicialmente
            btnGenerarReporte.Enabled = true;
            txtDato.Enabled = false;

            //Agregamos opciones al combo box
            AgregarOpcionesBusqueda();

            //Denegamos escritura en el combo box
            cboOpcionReporte.DropDownStyle = ComboBoxStyle.DropDownList;

            //Llenamos nuestro combobox de Clientes
            LlenarComboBox(cboClientes, "SeleccionarClientes", 0);
        }

        private bool ValidarCampos()
        {
            bool Validado = true;
            erReporte.Clear();
            if(cboOpcionReporte.SelectedItem == null)
            {
                erReporte.SetError(cboOpcionReporte, "Escoja una opcion");
                Validado = false;
            }
            else
            {
                switch (cboOpcionReporte.SelectedItem.ToString())
                {
                    case "Serie": Validado = ValidarTxtDato(); break;
                    case "Tecnico":Validado = ValidarTxtDato() ; break;
                    case "Fusor": Validado = ValidarTxtDato() ; break;
                    case "Cliente": Validado = ValidarCb(); break;
                    default:
                        break;
                }
            }
            return Validado;
        }

        private bool ValidarTxtDato()
        {
            bool Validado = true;
            if (txtDato.Text == "")
            {
                erReporte.SetError(txtDato, "Campo Obligatorio");
                Validado = false;
            }
            return Validado;
        }

        private bool ValidarCb()
        {
            bool Validado = true;
            if (cboClientes.SelectedItem == " ")
            {
                erReporte.SetError(cboClientes, "Escoga un cliente");
                Validado = false;
            }
            return Validado;
        }
        #endregion

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (ValidarCampos())
                {
                    if (txtDato.Text != "")
                    {
                        Parametro = txtDato.Text;
                    }
                    else
                    {
                        Parametro = cboClientes.SelectedItem.ToString();
                    }
                    DateTime FechaInicial = dtpFechaInicial.Value;
                    DateTime FechaFinal = dtpFechaFinal.Value;
                    objetoCN.GenerarReporte(FechaInicial, FechaFinal, Parametro, TipoBusqueda);
                }
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  

        #region Metodos Locales

        private void MostrarTextBoxDato()
        {
            txtDato.Enabled = false;
            cboClientes.Visible = false;
            txtDato.Visible = true;
            txtDato.Enabled = true;
            txtIdCliente.Visible = false;
            txtDato.Focus();
            erReporte.Clear();
        }

        private void MostrarComboBoxClientes()
        {
            txtDato.Enabled = false;
            txtDato.Visible = false;
            cboClientes.Visible = true;
            txtIdCliente.Visible = true;
            erReporte.Clear();
        }
        #endregion

        #region Eventos
        private void BarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cboOpcionReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerarReporte.Enabled = true;
            TipoBusqueda = cboOpcionReporte.SelectedItem.ToString();
            
            switch (cboOpcionReporte.SelectedItem.ToString())
            {
                case "Serie": MostrarTextBoxDato(); break;
                case "Fecha": Parametro = " "; break;
                case "Fusor": MostrarTextBoxDato(); break;
                case "Cliente": MostrarComboBoxClientes(); break;
                default:
                    txtDato.Visible = false; cboClientes.Visible = false;
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtIdCliente.Text != "")
            {
                int IdCliente = int.Parse(txtIdCliente.Text);
                SqlDataReader dr = objetoCN.BuscarCliente(IdCliente, "SeleccionarCliente");
                int id = 0;

                while (dr.Read())
                {
                    cboClientes.SelectedItem = dr[0].ToString();
                }

                dr.Close();
                cn.CerrarConexion();

            }
        }

        #endregion

        private void txtDato_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }
    }
}
