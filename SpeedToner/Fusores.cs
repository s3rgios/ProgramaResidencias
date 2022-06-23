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
    public partial class Fusores : Form
    {
        public Fusores()
        {
            InitializeComponent();
            Inicio();
        }

        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();

        bool Modificando = false;

        #region Inicio
        public void Inicio()
        {
            ControlesDesactivadosInicialmente(false);
            PropiedadesDtgServicios();
            MostrarDatosFusores();
        }

        private void ControlesDesactivadosInicialmente(bool activado)
        {
            btnCancelar.Enabled = activado;
            btnEliminar.Enabled = activado;
        }

        public void PropiedadesDtgServicios()
        {
            //Solo lectura
            dtgFusores.ReadOnly = true;

            //No agregar renglones
            dtgFusores.AllowUserToAddRows = false;

            //No borrar renglones
            dtgFusores.AllowUserToDeleteRows = false;

            //Ajustar automaticamente el ancho de las columnas
            dtgFusores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtgServicios.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
            dtgFusores.AutoResizeColumns();
        }

        public void MostrarDatosFusores()
        {
            //Limpiamos los datos del datagridview
            dtgFusores.DataSource = null;
            dtgFusores.Refresh();
            DataTable tabla = new DataTable();
            //Guardamos los registros dependiendo la consulta
            tabla = objetoCN.Mostrar("MostrarTodosFusores");
            //Asignamos los registros que optuvimos al datagridview
            dtgFusores.DataSource = tabla;
        }

        public bool ValidarCampos()
        {
            bool Validado = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if(c.Text == "")
                    {
                        erFusores.SetError(c, "Campo obligatorio");
                        Validado = false;
                    }
                }
            }
            return Validado;
        }
        #endregion


        public void LimpiarForm()
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            txtSerie.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    string Serie = txtSerie.Text;
                    string SerieSp = txtSerieSp.Text;
                    string NumeroFactura = txtFactura.Text;
                    DateTime FechaFactura = dtpFechaFactura.Value;
                    string Costo = txtCosto.Text;
                    string Garantia = cboGarantia.SelectedItem.ToString();
                    string Ubicacion = txtUbicacion.Text;
                    DateTime FechaInstalacion = dtpFechaInstalacion.Value;
                    if (Modificando)
                    {

                    }
                    else
                    {
                        objetoCN.AgregarFusor(Serie, SerieSp, NumeroFactura, FechaFactura, Costo, Garantia, Ubicacion, FechaInstalacion);
                        MessageBox.Show("Fusor agregado correctamente");
                    }
                    LimpiarForm();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
