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
        int Id;

        #region Inicio
        public void Inicio()
        {
            ControlesDesactivadosInicialmente(false);
            PropiedadesDtgServicios();
            MostrarDatosFusores();
            cboGarantia.Items.Add("Habilitado");
            cboGarantia.Items.Add("Deshabilitada");

            cboBusqueda.Items.Add("Habilitado");
            cboBusqueda.Items.Add("Deshabilitada");
            cboBusqueda.Items.Add("Rango Fecha");
            cboBusqueda.Items.Add("Serie");
            cboBusqueda.Items.Add("Todos");
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
            erFusores.Clear();
            if (txtSerie.Text == "")
            {
                erFusores.SetError(txtSerie, "Campo obligatorio");
                Validado = false;
            }
            if (txtSerieSp.Text == "")
            {
                erFusores.SetError(txtSerieSp, "Campo obligatorio");
                Validado = false;
            }
            if (txtFactura.Text == "")
            {
                erFusores.SetError(txtFactura, "Campo obligatorio");
                Validado = false;
            }
            if ( txtCosto.Text == "")
            {
                erFusores.SetError(txtCosto, "Campo obligatorio");
                Validado = false;
            }
            if (cboGarantia.Items.Count <= 0)
            {
                erFusores.SetError(cboGarantia, "Campo obligatorio");
                Validado = false;
            }
            return Validado;
        }
        #endregion

        public bool ValidarCamposReporte()
        {
            bool Validado = true;
            erFusores.Clear();
            if (cboBusqueda.SelectedItem == null)
            {
                erFusores.SetError(cboBusqueda, "Campo obligatorio");
                Validado = false;
            }
            else
            {
                string Parametro = cboBusqueda.SelectedItem.ToString();
                switch (Parametro)
                {
                    case "Serie":
                        if (txtSerieBusqueda.Text == "")
                        {
                            erFusores.SetError(txtSerieBusqueda, "Campo obligatorio");
                            Validado = false;
                        };
                        break;
                }
            }
            
            return Validado;
        }

        public void LimpiarForm()
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }
            }
            dtpFechaFactura.Value = DateTime.Now;
            dtpFechaInstalacion.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
            MostrarFechas(false); 
            txtSerieBusqueda.Visible = false;
            cboBusqueda.Text = "";
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
                    string Costo = txtCosto.Text.Replace(",", "");
                    string Garantia = cboGarantia.SelectedItem.ToString();
                    string Ubicacion = txtUbicacion.Text;
                    DateTime FechaInstalacion = dtpFechaInstalacion.Value;
                    if (Modificando)
                    {
                        if (MessageBox.Show("Desea modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("Modificacion cancelada!!");
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarFusor(Id,Serie, SerieSp, NumeroFactura, FechaFactura, Costo, Garantia, Ubicacion, FechaInstalacion);
                        MessageBox.Show("Fusor modificado correctamente");
                        MostrarDatosFusores();
                    }
                    else
                    {
                        objetoCN.AgregarFusor(Serie, SerieSp, NumeroFactura, FechaFactura, Costo, Garantia, Ubicacion, FechaInstalacion);
                        MessageBox.Show("Fusor agregado correctamente");
                        MostrarDatosFusores();
                    }
                    LimpiarForm();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dtgFusores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ControlesDesactivadosInicialmente(true);
            //LimpiarForm();
            Modificando = true;
            Id = int.Parse(dtgFusores.CurrentRow.Cells[0].Value.ToString());
            txtSerie.Text = dtgFusores.CurrentRow.Cells[1].Value.ToString();
            txtSerieSp.Text = dtgFusores.CurrentRow.Cells[2].Value.ToString();
            txtFactura.Text = dtgFusores.CurrentRow.Cells[3].Value.ToString();
            dtpFechaFactura.Value = Convert.ToDateTime(dtgFusores.CurrentRow.Cells[4].Value.ToString());
            txtUbicacion.Text = dtgFusores.CurrentRow.Cells[8].Value.ToString();
            txtCosto.Text = dtgFusores.CurrentRow.Cells[6].Value.ToString().Replace("$", "");
            dtpFechaInstalacion.Value = Convert.ToDateTime(dtgFusores.CurrentRow.Cells[9].Value.ToString());
            cboGarantia.SelectedItem = dtgFusores.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Modificando = false;
            LimpiarForm();
            txtSerie.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el registro?", "CONFIRME LA ELIMINACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("Eliminación cancelada!!");
                LimpiarForm();
                return;
            }
            objetoCN.Eliminar(Id, "EliminarFusor");
            MessageBox.Show("Fusor eliminado correctamente");
            MostrarDatosFusores();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposReporte())
                {
                    string Parametro = cboBusqueda.SelectedItem.ToString();
                    string Serie = txtSerieBusqueda.Text;
                    DateTime FechaInicio = dtpFechaInicio.Value;
                    DateTime FechaFinal = dtpFechaFinal.Value;
                    objetoCN.ReporteFusores(Parametro, FechaInicio, FechaFinal, Serie);
                    LimpiarForm();
                }
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Parametro = cboBusqueda.SelectedItem.ToString();
            switch (Parametro)
            {
                case "Habilitado":MostrarFechas(false); txtSerieBusqueda.Visible = false; break;
                case "Deshabilitada":MostrarFechas(false); txtSerieBusqueda.Visible = false; break;
                case "Rango Fecha":MostrarFechas(true); txtSerieBusqueda.Visible = false; break;
                case "Serie":MostrarFechas(false); txtSerieBusqueda.Visible = true; break;
                case "Todos":MostrarFechas(false); txtSerieBusqueda.Visible = false; break;
            }

        }

        public void MostrarFechas(bool Mostrar)
        {
            lblFechaFinal.Visible = Mostrar;
            lblFechaInicio.Visible = Mostrar;
            dtpFechaInicio.Visible = Mostrar;
            dtpFechaFinal.Visible = Mostrar;
        }
    }
}
