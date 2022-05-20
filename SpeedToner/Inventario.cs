using System;
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
        private bool Inven = false;

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

            Mostrar("VerRegistroInventario");

        }

        //Metodo que dependiendo el valor que se envie activara o desactivara los botones
        public void ControlesDesactivados(bool Desactivado, bool Activar)
        {
            btnModificar.Enabled = Desactivado;
            btnEliminar.Enabled = Desactivado;
            btnCancelar.Enabled = Desactivado;
            btnAgregar.Enabled = Activar;
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


        #endregion

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

        #region Botones
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlesDesactivados(false, true);
            LimpiarForm();
            dtgCartuchos.DataSource = null;
            dtgCartuchos.Refresh();

            lblBodega.Visible = false;
            lblOficina.Visible = false;
            lblEntrada.Visible = true;
            lblSalida.Visible = true;

            Mostrar("VerRegistroInventario");
            Inven = false;
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Cliente = cboClientes.SelectedItem.ToString();
                string IdCartucho = cboModelos.SelectedItem.ToString();
                int Idcar = objetoCN.BuscarId(IdCartucho, "ObtenerIdCartucho");
                DateTime Fecha = dtpFecha.Value;
                string Oficina = txtOficina.Text;
                string Bodega = txtBodega.Text;

                objetoCN.AñadirRegistroInventario(Idcar, Oficina, Cliente, Bodega, Fecha);
                Mostrar("VerRegistroInventario");
                LimpiarForm();
            }
            catch (Exception ex)
            {

            }
        }

        private void Cantidad_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarForm()
        {
            foreach (Control c in grpDatosInventario.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            cboModelos.Focus();

            cboClientes.SelectedIndex = 0;
            cboModelos.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
        }

        private void dtgCartuchos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Activamos botones elminar, cancelar y modificar, desactivamos guardar
            ControlesDesactivados(true, false);

            //Asignacion a los controles
            if (Inven)//En caso de ser verdadero se asignaran a los datos para el inventario
            {
                Id = int.Parse(dtgCartuchos.CurrentRow.Cells[0].Value.ToString());
                cboModelos.SelectedItem = dtgCartuchos.CurrentRow.Cells[1].Value.ToString();
                txtOficina.Text = dtgCartuchos.CurrentRow.Cells[2].Value.ToString();
                txtBodega.Text = dtgCartuchos.CurrentRow.Cells[3].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dtgCartuchos.CurrentRow.Cells[4].Value.ToString());
            }
            else //Si no para los datos de registro
            {
                cboModelos.SelectedItem = dtgCartuchos.CurrentRow.Cells[0].Value.ToString();
                txtOficina.Text = dtgCartuchos.CurrentRow.Cells[1].Value.ToString();
                txtBodega.Text = dtgCartuchos.CurrentRow.Cells[2].Value.ToString();
                cboClientes.SelectedItem = dtgCartuchos.CurrentRow.Cells[3].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dtgCartuchos.CurrentRow.Cells[4].Value.ToString());
            }
            
        }

        //Muestra el inventario 
        private void btnInventario_Click_1(object sender, EventArgs e)
        {
            Mostrar("MostrarInventario");
            btnCancelar.Enabled = true;
            //Mostramos los labels para mostrar la cantidad en oficina y bodega, desactivamos  las salidas y las entradas
            lblBodega.Visible = true;
            lblOficina.Visible = true;
            lblEntrada.Visible = false;
            lblSalida.Visible = false;
            Inven = true;
        }
    }
}
