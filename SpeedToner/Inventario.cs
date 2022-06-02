﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SpeedToner
{
    public partial class Inventario : Form
    {
        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();
        //Variable para saber si realizaremos acciones en resgistros o en inventario
        private bool inventario = true;

        //Sabremos si estamos modificando o agregando
        private bool Modificando = false;

        //Variable para guadar el id ya sea de un cartucho en el inventario o de algun regristro que se seleccione
        int Id = 0;

        public Inventario()
        {
            InitializeComponent();
            InicioAplicacion();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {

        }

        #region Inicio

        public void InicioAplicacion()
        {
            PropiedadesDtg();

            //Metodo que controla los controles que seran utiles al iniciar la aplicacion
            ControlesDesactivados(false, true);

            //Agregamos opciones que estan en la base de datos
            LlenarComboBox(cboClientes, "SeleccionarClientes", 1);
            LlenarComboBox(cboModelos, "SeleccionarCartuchos", 1);


            //Denegar escritura en combobox
            cboModelos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;

            Mostrar("MostrarInventario");
            radOficina.Checked = true;
        }

        //Metodo que dependiendo el valor que se envie activara o desactivara los botones
        public void ControlesDesactivados(bool Desactivado, bool Activar)
        {
            btnEliminar.Enabled = Desactivado;
            btnCancelar.Enabled = Desactivado;
            btnGuardar.Enabled = Activar;

            lblRestarBodega.Visible = Desactivado;
            txtRestanteBodega.Visible = Desactivado;
            btnRestar.Visible = Desactivado;
        }

        public void PropiedadesDtg()
        {
            //Solo lectura
            dtgCartuchos.ReadOnly = true;

            //No agregar renglones
            dtgCartuchos.AllowUserToAddRows = false;

            //No borrar renglones
            dtgCartuchos.AllowUserToDeleteRows = false;

            //Ajustar automaticamente el ancho de las columnas
            dtgCartuchos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtgServicios.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
            dtgCartuchos.AutoResizeColumns();

            dtgCartuchos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void Mostrar(string sp)
        {
            //Limpiamos los datos del datagridview
            dtgCartuchos.DataSource = null;
            dtgCartuchos.Refresh();
            DataTable tabla = new DataTable();
            //Guardamos los registros dependiendo la consulta
            tabla = objetoCN.Mostrar(sp);
            //Asignamos los registros que optuvimos al datagridview
            dtgCartuchos.DataSource = tabla;
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

        #endregion

        #region Botones
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlesDesactivados(false, true);
            LimpiarForm();
            Modificando = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Entrara en dado caso que nos encontremos en el inventario
                if (inventario)
                {
                    string Modelo = txtModelo.Text;
                    string CantidadOficina = txtOficina.Text;
                    string CantidadBodega = txtBodega.Text;
                    if (Modificando)
                    {
                        //Modificar stop procedure de modificar, para que se pueda cambiar la fecha
                        if (MessageBox.Show("¿Esta seguro de modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("!!Modificación cancelada!!");
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarRegistroInventario(Id, Modelo, CantidadOficina, CantidadBodega);
                    }
                    else
                    {
                        objetoCN.AñadirRegistroInventario(Modelo, CantidadOficina, CantidadBodega);
                    }
                    Mostrar("MostrarInventario");
                    LimpiarForm();
                }
                else//Estamos en los registros
                {
                    //string Cliente = cboClientes.SelectedItem.ToString();
                    string destino = "";
                    string Cliente = cboClientes.SelectedItem.ToString();
                    //string IdCartucho = cboModelos.SelectedItem.ToString();
                    int IdCartucho = objetoCN.BuscarId(cboModelos.SelectedItem.ToString(), "ObtenerIdCartucho");
                    string Salida = txtCantidadSalida.Text;
                    string Entrada = txtCantidadEntrada.Text;
                    DateTime Fecha = dtpFecha.Value;
                    if (radBodega.Checked)
                    {
                        destino = "Bodega";
                    }
                    else
                    {
                        destino = "Oficina";
                    }

                    if (Modificando)
                    {
                        if (MessageBox.Show("¿Esta seguro de modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("!!Modificación cancelada!!");
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarRegistroInventario(Id, IdCartucho, Salida, Entrada, Cliente, Fecha);
                    }
                    else
                    {
                        objetoCN.AgregarRegistroInventario(IdCartucho, Salida, Entrada, Cliente, Fecha, destino);
                        MessageBox.Show("Se ha agregado el resgitro correctamente. Se ha actualizado el inventario");
                    }
                    Mostrar("VerRegistroInventario");
                    LimpiarForm();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error" + ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de elminar el registro?", "CONFIRME LA ELIMINACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("!!Eliminación cancelada!!");
                LimpiarForm();
                return;
            }
            try
            {
                if (inventario)
                {
                    objetoCN.EliminarRegistroInventario(Id);
                    Mostrar("MostrarInventario");
                }
                else
                {
                    objetoCN.DeleteRegistroInventario(Id);
                    Mostrar("VerRegistroInventario");
                }
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error" + ex);
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro de agregar la cantidad?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("!!Modificación cancelada!!");
                    LimpiarForm();
                    return;
                }
                string Mensaje = objetoCN.EnviarOficina(txtRestanteBodega.Text, Id);
                MessageBox.Show(Mensaje);
                Mostrar("MostrarInventario");
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdCartucho = objetoCN.BuscarId(txtBusqueda.Text, "ObtenerIdCartucho");

            SqlDataReader dr = objetoCN.Buscar(IdCartucho);

            while (dr.Read())
            {
                //Agregamos las opciones dependiendo los registros que nos devolvieron
                txtModelo.Text = (dr[0].ToString());
                txtOficina.Text = (dr[1].ToString());
                txtBodega.Text = (dr[2].ToString());
                dtpFecha.Value = Convert.ToDateTime(dr[3].ToString());
            }

            dr.Close();
            cn.CerrarConexion();
        }

        #endregion

        private void Cantidad_Click(object sender, EventArgs e)
        {

        }

        //Metodo para reiniciar todos los controles para una posible nueva insercion, modificacion o eliminacion
        private void LimpiarForm()
        {
            foreach (Control c in 
                grpDatosInventario.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            foreach (Control c in grpDatosRegistro.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            txtModelo.Focus();

            cboClientes.SelectedIndex = 0;
            cboModelos.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
        }


        #region Eventos

        private void dtgCartuchos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Activamos botones elminar, cancelar y modificar, desactivamos guardar
            ControlesDesactivados(true, true);

            //Para poder decir al sistema que vamos a modificar y no agregar algo al inventario al dar clic a agregar
            Modificando = true;
            
            //Asignacion a los controles
            if (inventario)//En caso de ser verdadero se asignaran a los datos para el inventario
            {
                Id = int.Parse(dtgCartuchos.CurrentRow.Cells[0].Value.ToString());
                txtModelo.Text = dtgCartuchos.CurrentRow.Cells[1].Value.ToString();
                txtOficina.Text = dtgCartuchos.CurrentRow.Cells[2].Value.ToString();
                txtBodega.Text = dtgCartuchos.CurrentRow.Cells[3].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dtgCartuchos.CurrentRow.Cells[4].Value.ToString());
            }
            else //Si no para los datos de registro
            {
                Id = int.Parse(dtgCartuchos.CurrentRow.Cells[0].Value.ToString());
                cboModelos.SelectedItem = dtgCartuchos.CurrentRow.Cells[1].Value.ToString();
                txtCantidadSalida.Text = dtgCartuchos.CurrentRow.Cells[2].Value.ToString();
                txtCantidadEntrada.Text = dtgCartuchos.CurrentRow.Cells[3].Value.ToString();
                cboClientes.SelectedItem = dtgCartuchos.CurrentRow.Cells[4].Value.ToString();
                dtpFechaRegistro.Value = Convert.ToDateTime(dtgCartuchos.CurrentRow.Cells[5].Value.ToString());
            }
        }

        //Muestra el inventario 
        
        //Evento que nos ayudara a saber cuando se realizan acciones en el inventario o en el registro del mismo
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tab_Inventario)
            {
                Mostrar("MostrarInventario");
                inventario = true;
            }
            else
            {
                Mostrar("VerRegistroInventario");
                inventario=false;
                Modificando = false;
            }
        }
        #endregion

        

    }
}
