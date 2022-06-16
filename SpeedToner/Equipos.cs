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
        private bool Buscando = false;
        int Id;
        string TipoBusqueda = "";

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

            //Se manda el nombre del cbo,el stop procedure que ejecutara, en dado caso de que sea modelos se manda el id de la marca
            LlenarComboBox(cboClientes, "SeleccionarClientes",0);
            LlenarComboBox(cboTipoRenta, "SeleccionarTipoRenta",0);
            LlenarComboBox(cboMarcas, "SeleccionarMarca", 0);
            LlenarComboBox(cboModelos, "SeleccionarModelos", 0);


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
            btnMostrar.Enabled = Desactivado;
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

        public void LlenarComboBox(ComboBox cb, string sp, int Marca)
        {
            SqlDataReader dr;
            cb.Items.Clear();
            if (sp == "SeleccionarModelos")
            {
                dr = objetoCN.LlenarComboBoxModelos(sp, Marca);
            }
            else
            {
                dr = objetoCN.LlenarComboBox(sp);
            }

            while (dr.Read())
            {
                //Agregamos las opciones dependiendo los registros que nos devolvieron
                cb.Items.Add(dr[0].ToString());
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
                    string Ubicacion = txtReferencia.Text;
                    int Marca = objetoCN.BuscarId(cboMarcas.SelectedItem.ToString(), "ObtenerIdMarca");
                    int Modelo = objetoCN.BuscarId(cboModelos.SelectedItem.ToString(), "ObtenerIdModelo"); 
                    string Serie = txtSerie.Text;
                    int TipoRenta = objetoCN.BuscarId(cboTipoRenta.SelectedItem.ToString(), "ObtenerIdTipoRenta");
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
                        objetoCN.ModificarEquipo(Id, Cliente, Ubicacion, Marca,Modelo, Serie, TipoRenta, Precio, FechaPago);
                    }
                    else
                    {
                        objetoCN.AgregarEquipo(Cliente, Ubicacion,Marca, Modelo, Serie, TipoRenta, Precio, FechaPago);
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
            cboMarcas.SelectedItem = dtgEquipos.CurrentRow.Cells[3].Value.ToString();
            cboModelos.SelectedItem = dtgEquipos.CurrentRow.Cells[4].Value.ToString();
            txtSerie.Text = dtgEquipos.CurrentRow.Cells[5].Value.ToString();
            cboTipoRenta.SelectedItem = dtgEquipos.CurrentRow.Cells[6].Value.ToString();
            txtPrecio.Text = dtgEquipos.CurrentRow.Cells[7].Value.ToString();
            txtFechaPago.Text = dtgEquipos.CurrentRow.Cells[8].Value.ToString();
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
                objetoCN.Eliminar(Convert.ToString(Id),"EliminarEquipo");
                MessageBox.Show("Se ha eliminado el registro correctamente");
                Mostrar("MostrarEquipos");
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //En dado caso que se haya seleccionado algo de las marcas
            if (cboMarcas.SelectedItem.ToString() != " " && Buscando == false)
            {
                int IdMarca = objetoCN.BuscarId(cboMarcas.SelectedItem.ToString(), "ObtenerIdMarca");
                //Se llenara de acuerdo a la marca que se haya escogido
                LlenarComboBox(cboModelos, "SeleccionarModelos", IdMarca);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = objetoCN.Buscar(txtSerieBusqueda.Text,"BuscarSerie");
            Buscando = true;
            //Comprobamos si la consulta nos devuelve informacion
            if (dr.Read())
            {
                //Cargamos la infomacion en el formulario
                cboClientes.SelectedItem = (dr[1].ToString());
                txtReferencia.Text = (dr[2].ToString());
                cboMarcas.SelectedItem = (dr[3].ToString());
                cboModelos.SelectedItem = (dr[4].ToString());
                txtSerie.Text = (dr[5].ToString());
                cboTipoRenta.SelectedItem = (dr[6].ToString());
                txtPrecio.Text = (dr[7].ToString());
                txtFechaPago.Text = (dr[8].ToString());
                //Agregamos las opciones dependiendo los registros que nos devolvieron
            }
            else
            {
                MessageBox.Show("El número de folio no esta registrado en la base de datos");
            }

            dr.Close();
            cn.CerrarConexion();
            txtSerieBusqueda.Text = "";
            Buscando = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMostrar.Enabled = true;
            TipoBusqueda = cboMostrar.SelectedItem.ToString();
            switch (TipoBusqueda)
            {
                case "Cliente": LlenarComboBox(cboBusqueda, "SeleccionarClientes", 0); break;
                case "Marca": LlenarComboBox(cboBusqueda, "SeleccionarMarca", 0); break;
                case "Modelo": LlenarComboBox(cboBusqueda, "SeleccionarModelos", 0); break;
            }
        }

        public void MostrarComboBox(ComboBox cb, string TipoBusqueda)
        {
            txtDato.Visible = false;
            cb.Visible = true;
            switch (TipoBusqueda)
            {
                case "Clientes":  break;
            }
            LlenarComboBox(cboBusqueda, "SeleccionarClientes", 0);
            LlenarComboBox(cboTipoRenta, "SeleccionarTipoRenta", 0);
            LlenarComboBox(cboMarcas, "SeleccionarMarca", 0);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //Limpiamos los datos del datagridview
            dtgEquipos.DataSource = null;
            dtgEquipos.Refresh();
            DataTable tabla = new DataTable();
            //Guardamos los registros dependiendo la consulta
            tabla = objetoCN.OrdenarEquipos(cboBusqueda.SelectedItem.ToString());
            //Asignamos los registros que optuvimos al datagridview
            dtgEquipos.DataSource = tabla;
            cboMostrar.SelectedIndex = 0;
            cboBusqueda.SelectedIndex = 0;
        }
    }
}
