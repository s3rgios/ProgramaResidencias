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
        bool Modificando = false;
        public Clientes()
        {
            InitializeComponent();
            Inicio();
        }

        #region Inicio
        public void Inicio()
        {
            DesactivarControles(false);
            
            LlenarDtg();
            MostrarDatosClientes();
        }

        public void DesactivarControles(bool activado)
        {
            btnEliminar.Enabled = activado;
            btnCancelar.Enabled = activado;
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

        public bool ValidarCampos()
        {
            bool Validado = true;
            erClientes.Clear();

            if (txtEmpresa.Text == "")
            {
                erClientes.SetError(txtEmpresa, "Campo obligatorio");
                Validado = false;
            }
            return Validado;
        }
        #endregion


        #region Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (ValidarCampos())
                {
                    string Empresa = txtEmpresa.Text;
                    if (Modificando)
                    {
                        if (MessageBox.Show("¿Desea modificar el cliente?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("Modificacion cancelada!!", "CANCELADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarCliente(Id, Empresa);
                        MessageBox.Show("Se ha modificado el cliente correctamente");
                    }
                    else
                    {
                        objetoCN.InsertarCliente(Empresa);
                        MessageBox.Show("Se ha agregado correctamente");
                    }

                    LimpiarForm();
                    MostrarDatosClientes();
                }
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
                if (MessageBox.Show("¿Desea eliminar el cliente?", "CONFIRME LA ELIMINACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("Eliminacion cancelada!!", "CANCELADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarForm();
                    return;
                }
                string Empresa = txtEmpresa.Text;
                objetoCN.Eliminar(Id, "EliminarCliente");
                LimpiarForm();
                MostrarDatosClientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesactivarControles(false);
            Modificando = true;
            LimpiarForm();
        }
        #endregion

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

        #region Eventos
        //Llenar campos dependiendo la fila que se eliga
        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DesactivarControles(true);
            Modificando = true;
            erClientes.Clear();

            //Guardamos el Id en dado caso que se quiera modificar o eliminar
            Id = int.Parse(dtgClientes.CurrentRow.Cells[0].Value.ToString());
            txtEmpresa.Text = dtgClientes.CurrentRow.Cells[1].Value.ToString();
        }
        #endregion
    }

    
}
