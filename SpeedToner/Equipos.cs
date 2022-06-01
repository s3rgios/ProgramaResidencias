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
    public partial class Equipos : Form
    {
        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();
        //Variable para saber si realizaremos acciones en resgistros o en inventario
        private bool inventario = true;

        //Sabremos si estamos modificando o agregando
        private bool Modificando = false;
        int Id;

        public Equipos()
        {
            InitializeComponent();
            InicioAplicacion();
        }

        #region Inicio

        public void InicioAplicacion()
        {
            PropiedadesDtg();

            ControlesDesactivados(false);

            LlenarComboBox(cboClientes, "SeleccionarClientes", 1);
            LlenarComboBox(cboTipoRenta, "SeleccionarTipoRenta", 1);

            //Llenamos el datagridview
            Mostrar("MostrarEquipos");

            //Deshabilitamos escritura en combobox
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoRenta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void ControlesDesactivados(bool Desactivado)
        {
            btnEliminar.Enabled = Desactivado;
            btnCancelar.Enabled = Desactivado;
        }

        public void PropiedadesDtg()
        {
            //Solo lectura
            dtgEquipos.ReadOnly = true;

            //No agregar renglones
            dtgEquipos.AllowUserToAddRows = false;

            //No borrar renglones
            dtgEquipos.AllowUserToDeleteRows = false;

            //Ajustar automaticamente el ancho de las columnas
            dtgEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtgServicios.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
            dtgEquipos.AutoResizeColumns();

            dtgEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void LlenarComboBox(ComboBox cb, string sp, int indice)
        {
            cb.Items.Clear();
            SqlDataReader dr = objetoCN.LlenarComboBox(sp);

            while (dr.Read())
            {
                //Agregamos las opciones dependiendo los registros que nos devolvieron
                cb.Items.Add(dr[indice].ToString());
            }

            //Agregamos un espacio en blanco y lo asignamos como opcion por defecto
            cb.Items.Insert(0, " ");
            cb.SelectedIndex = 0;
            dr.Close();
            cn.CerrarConexion();
        }

        public void Mostrar(string sp)
        {
            //Limpiamos los datos del datagridview
            dtgEquipos.DataSource = null;
            dtgEquipos.Refresh();
            DataTable tabla = new DataTable();
            //Guardamos los registros dependiendo la consulta
            tabla = objetoCN.Mostrar(sp);
            //Asignamos los registros que optuvimos al datagridview
            dtgEquipos.DataSource = tabla;
        }

        #endregion

        public void LimpiarForm()
        {
            foreach (Control c in
                grpDatos.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            cboClientes.Focus();

            cboClientes.SelectedIndex = 0;
            cboTipoRenta.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (inventario)
                {
                    int Cliente = objetoCN.BuscarId(cboClientes.SelectedItem.ToString(), "ObtenerIdCliente");
                    string Referencia = txtReferencia.Text;
                    string Modelo = txtModelo.Text;
                    string Serie = txtSerie.Text;
                    int TipoRenta = objetoCN.BuscarId(cboTipoRenta.SelectedItem.ToString(),"ObtenerIdTipoRenta");
                    //int TipoRenta = objetoCN.BuscarId(cboTipoRenta.SelectedItem.ToString(), "ObtenerIdTipoRenta");
                    int Precio = int.Parse(txtPrecio.Text);
                    string FechaPago = txtFechaPago.Text;

                    if (Modificando)
                    {
                        //Modificar stop procedure de modificar, para que se pueda cambiar la fecha
                        if (MessageBox.Show("¿Esta seguro de modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("!!Modificación cancelada!!");
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarEquipo(Id,Cliente,Referencia, Modelo,Serie, TipoRenta,Precio, FechaPago);
                    }
                    else
                    {
                        objetoCN.AgregarEquipo(Cliente, Referencia,Modelo, Serie, TipoRenta,Precio,FechaPago);
                    }
                    Mostrar("MostrarEquipos");
                    LimpiarForm();
                }
                else
                {

                    if (Modificando)
                    {
                        if (MessageBox.Show("¿Esta seguro de modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("!!Modificación cancelada!!");
                            LimpiarForm();
                            return;
                        }
                        //objetoCN.ModificarRegistroInventario(Id, IdCartucho, Salida, Entrada, Cliente, Fecha);
                    }
                    else
                    {
                        //objetoCN.AgregarRegistroInventario(IdCartucho, Salida, Entrada, Cliente, Fecha, destino);
                    }
                    //Mostrar("VerRegistroInventario");
                    LimpiarForm();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error" + ex);
            }
        }

        private void dtgEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ControlesDesactivados(true);
            Modificando = true;

            Id = int.Parse(dtgEquipos.CurrentRow.Cells[0].Value.ToString());
            cboClientes.SelectedItem = dtgEquipos.CurrentRow.Cells[1].Value.ToString();
            txtReferencia.Text = dtgEquipos.CurrentRow.Cells[2].Value.ToString();
            txtModelo.Text = dtgEquipos.CurrentRow.Cells[3].Value.ToString();
            txtSerie.Text = dtgEquipos.CurrentRow.Cells[4].Value.ToString();
            cboTipoRenta.SelectedItem = dtgEquipos.CurrentRow.Cells[5].Value.ToString();
            txtPrecio.Text = dtgEquipos.CurrentRow.Cells[6].Value.ToString();
            txtFechaPago.Text = dtgEquipos.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlesDesactivados(false);
            LimpiarForm();
            Modificando = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "CONFIRME LA ELIMINACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("!!Eliminacion cancelada!!");
                    LimpiarForm();
                    return;
                }
                objetoCN.EliminarEquipo(Id);
                MessageBox.Show("Se ha eliminado el registro correctamente");
                Mostrar("MostrarEquipos");
                LimpiarForm();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
