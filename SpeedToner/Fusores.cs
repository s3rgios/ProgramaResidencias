using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

            cboBusqueda.Items.Add("Habilitado");
            cboBusqueda.Items.Add("Deshabilitada");
            cboBusqueda.Items.Add("Rango Fecha");
            cboBusqueda.Items.Add("Serie");
            cboBusqueda.Items.Add("Todos");

            cboDiasGarantía.Items.Add("90");
            cboDiasGarantía.Items.Add("180");
        }

        private void ControlesDesactivadosInicialmente(bool activado)
        {
            btnCancelar.Enabled = activado;
            btnEliminar.Enabled = activado;
            btnGenerarReporte.Enabled = activado;
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



        #endregion

        #region Validaciones 

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
            if (txtCosto.Text == "")
            {
                erFusores.SetError(txtCosto, "Campo obligatorio");
                Validado = false;
            }
            if (cboDiasGarantía.SelectedItem == null)
            {
                erFusores.SetError(cboDiasGarantía, "Campo obligatorio");
                Validado = false;
            }
            return Validado;
        }

        public bool ValidarCampoBusqueda()
        {
            bool Validado = true;
            erFusores.Clear();
            if (txtBusqueda.Text == "")
            {
                erFusores.SetError(txtBusqueda, "Ingrese un numero de serie");
                Validado = false;
            }
            
            return Validado;
        }

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
                        };break;
                }
            }
            return Validado;

        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }

        private void txtSerieSp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
            if ((e.KeyChar == '.') && (!txtCosto.Text.Contains(".")))
            {
                e.Handled = false;
            }
        }

        private void txtSerieBusqueda_KeyPress(object sender, KeyPressEventArgs e)
       {
            Validacion.SoloLetrasYNumeros(e);
        }
        #endregion


        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Repetido = false;
            try
            {
                if (ValidarCampos())
                {
                    string Serie = txtSerie.Text;
                    string SerieSp = txtSerieSp.Text;
                    string NumeroFactura = txtFactura.Text;
                    DateTime FechaFactura = dtpFechaFactura.Value;
                    string Costo = txtCosto.Text.Replace(",", "");
                    //string Garantia = cboGarantia.SelectedItem.ToString();
                    string DiasGarantia = cboDiasGarantía.SelectedItem.ToString();
                    string Ubicacion = txtUbicacion.Text;
                    DateTime FechaInstalacion = dtpFechaInstalacion.Value;
                    if (Modificando)
                    {
                        if (MessageBox.Show("Desea modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("Modificacion cancelada!!", "CANCELADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarFusor(Id, Serie, SerieSp, NumeroFactura, FechaFactura, Costo, DiasGarantia, Ubicacion, FechaInstalacion);
                        MessageBox.Show("Fusor modificado correctamente", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarDatosFusores();
                    }
                    else
                    {
                        //Verificamos que los numeros de serie no esten duplicados
                        Repetido = objetoCN.VerificarDuplicados(Serie, "VerificarSerieExistenteFusor");
                        Repetido = objetoCN.VerificarDuplicados(SerieSp, "VerificarSerieExistenteFusor");
                        if (Repetido)
                        {
                            MessageBox.Show("Ingrese un numero de serie distinto", "SERIE YA EXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            objetoCN.AgregarFusor(Serie, SerieSp, NumeroFactura, FechaFactura, Costo, DiasGarantia, Ubicacion, FechaInstalacion);
                            MessageBox.Show("Fusor agregado correctamente", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarDatosFusores();
                        }
                    }
                    LimpiarForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Modificando = false;
            LimpiarForm();
            txtSerie.Focus();
            ControlesDesactivadosInicialmente(false);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el registro?", "CONFIRME LA ELIMINACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("Eliminación cancelada!!", "OPERACION CANCELADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarForm();
                return;
            }
            objetoCN.Eliminar(Id, "EliminarFusor");
            MessageBox.Show("Fusor eliminado correctamente", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (Serie != "")
                    {
                        SqlDataReader dr = objetoCN.Buscar(txtSerieBusqueda.Text, "BuscarSerieSp");
                        //Si no nos regresa un registro quiere decir que no existe en nuestra base de datos
                        if (!dr.Read())
                        {
                            MessageBox.Show("Serie no encontrada", "SERIE NO EXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dr.Close();
                    }
                    DateTime FechaInicio = dtpFechaInicio.Value;
                    DateTime FechaFinal = dtpFechaFinal.Value;
                    objetoCN.ReporteFusores(Parametro, FechaInicio, FechaFinal, Serie);
                    LimpiarForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoBusqueda())
            {
                string str = txtBusqueda.Text;
                SqlDataReader dr;

                dr = objetoCN.Buscar(txtBusqueda.Text, "BuscarSerieSp");
                //BuscandoFolio = true;
                btnCancelar.Enabled = true;

                if (dr.Read())
                {
                    Id = int.Parse(dr[0].ToString());
                    txtSerie.Text = (dr[1].ToString());
                    txtSerieSp.Text = (dr[2].ToString());
                    txtFactura.Text = (dr[3].ToString());
                    txtCosto.Text = dr[6].ToString().Replace("$", "");
                    dtpFechaFactura.Value = Convert.ToDateTime(dr[4].ToString());
                    cboDiasGarantía.SelectedItem = dr[7].ToString();
                    txtUbicacion.Text = dr[8].ToString();
                    dtpFechaInstalacion.Value = Convert.ToDateTime(dr[9].ToString());
                    //Agregamos las opciones dependiendo los registros que nos devolvieron
                }
                else
                {
                    MessageBox.Show("El número de serie no esta registrado en la base de datos", "REGISTRO NO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dr.Close();
                cn.CerrarConexion();
                txtBusqueda.Text = "";
                //BuscandoFolio = false;
            }
        }

        private void btnBorrador_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            Modificando = false;
            erFusores.Clear();
        }
        #endregion

        #region Eventos
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
            txtUbicacion.Text = dtgFusores.CurrentRow.Cells[9].Value.ToString();
            txtCosto.Text = dtgFusores.CurrentRow.Cells[6].Value.ToString().Replace("$", "");
            dtpFechaInstalacion.Value = Convert.ToDateTime(dtgFusores.CurrentRow.Cells[10].Value.ToString());
            cboDiasGarantía.SelectedItem = dtgFusores.CurrentRow.Cells[7].Value.ToString();
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerarReporte.Enabled = true;
            string Parametro = cboBusqueda.SelectedItem.ToString();
            switch (Parametro)
            {
                case "Habilitado": MostrarFechas(false); txtSerieBusqueda.Visible = false; break;
                case "Deshabilitada": MostrarFechas(false); txtSerieBusqueda.Visible = false; break;
                case "Rango Fecha": MostrarFechas(true); txtSerieBusqueda.Visible = false; break;
                case "Serie": MostrarFechas(false); txtSerieBusqueda.Visible = true; break;
                case "Todos": MostrarFechas(false); txtSerieBusqueda.Visible = false; break;
            }

        }
        #endregion
        public void MostrarFechas(bool Mostrar)
        {
            lblFechaFinal.Visible = Mostrar;
            lblFechaInicio.Visible = Mostrar;
            dtpFechaInicio.Visible = Mostrar;
            dtpFechaFinal.Visible = Mostrar;
        }

        public void LimpiarForm()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
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
    }
}
