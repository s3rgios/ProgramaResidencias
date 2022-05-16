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
            LlenarDtg();
            ControlesDesactivadosInicialmente();
            AgregarOpcionesMostrar();
            MostrarDatosServicios();
            
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            
        }

        private void ControlesDesactivadosInicialmente()
        {
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            //Denegar escritura en combo boxs
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMostrar.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;

            LlenarComboBox(cboClientes, "SeleccionarClientes", 1);
            LlenarComboBox(cboMarca, "SeleccionarMarca", 1);
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

        public void LlenarDtg()
        {
            //Solo lectura
            dtgServicios.ReadOnly = true;

            //No agregar renglones
            dtgServicios.AllowUserToAddRows = false;

            //No borrar renglones
            dtgServicios.AllowUserToDeleteRows = false;

            //Ajustar automaticamente el ancho de las columnas
            dtgServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtgServicios.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
        }

        public void MostrarDatosServicios()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCN.Mostrar("MostrarDatosServicios");
            dtgServicios.DataSource = tabla;
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
                DateTime Fecha = dtpFecha.Value;
                string Tecnico = txtTecnico.Text;
                string Usuario = txtUsuario.Text;
                string Fusor = txtFusor.Text;
                string Servicio = rtxtServicio.Text;
                string Falla = rtxtFallas.Text;
                


               objetoCN.InsertarServicio(NumeroFolio,  IdC, IdM, Modelo, Serie, Contador, Fecha, Tecnico, Usuario, Fusor, Servicio, Falla);
                
               LimpiarForm();
            }
            catch (Exception ex)
            {
               MessageBox.Show("no se pudo editar los datos por: " + ex);
                
            }

//            CREATE PROCEDURE SeleccionarCliente
//@IdCliente int
//AS
//SELECT Empresa FROM Clientes
//WHERE IdCliente = @IdCliente
//GO



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

        private void AbrirForm(object formNuevo)
        {
            Form fh = formNuevo as Form;
           
            fh.Show();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirForm(new txtCliente());
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dtgServicios.SelectedRows.Count > 1)
            {

            }
        }

        private void dtgServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            
            switch (cboClientes.SelectedItem.ToString())
            {
                case "Ultima Semana": tabla = objetoCN.Mostrar("MostrarUltimaSemana");  break;
                case "Ultimo Mes": tabla = objetoCN.Mostrar("MostrarUltimoMes");  break;
                case "Este año": tabla = objetoCN.Mostrar("MostrarAñoActual"); break;
                case "Todos": tabla = objetoCN.Mostrar("MostrarDatosServicios");break;
            }
            dtgServicios.DataSource = tabla;
        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {
                int IdCliente = int.Parse(txtCliente.Text);
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
    }

    
}
