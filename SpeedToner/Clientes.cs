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
    public partial class Clientes : Form
    {
        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();
        int Id = 0;
        public Clientes()
        {
            InitializeComponent();
            Inicio();
        }

        public void Inicio()
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;   

            LlenarDtg();
            MostrarDatosClientes();
        }

        public void LlenarDtg()
        {
            //Solo lectura
            dtgClientes.ReadOnly = true;

            //No agregar renglones
            dtgClientes.AllowUserToAddRows = false;

            //No borrar renglones
            dtgClientes.AllowUserToDeleteRows = false;

            //Ajustar automaticamente el ancho de las columnas
            dtgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void MostrarDatosClientes()
        {  
            DataTable tabla = new DataTable();
            tabla = objetoCN.Mostrar("MostrarClientes");
            dtgClientes.DataSource = tabla;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Empresa = txtEmpresa.Text;

                objetoCN.InsertarCliente(Empresa);
                LimpiarForm();
                MostrarDatosClientes();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void LimpiarForm()
        {
            foreach (Control c in grpDatosClientes.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            txtEmpresa.Focus();
        }

        //Llenar campos dependiendo la fila que se eliga
        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

            //Guardamos el Id en dado caso que se quiera modificar o eliminar
            Id = int.Parse(dtgClientes.CurrentRow.Cells[0].Value.ToString());
            txtEmpresa.Text = dtgClientes.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string Empresa = txtEmpresa.Text;

                objetoCN.ModificarCliente(Id,Empresa);
                LimpiarForm();
                MostrarDatosClientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string Empresa = txtEmpresa.Text;
                objetoCN.Eliminar(Convert.ToString(Id),"EliminarCliente");
                LimpiarForm();
                MostrarDatosClientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }
    }

    
}
