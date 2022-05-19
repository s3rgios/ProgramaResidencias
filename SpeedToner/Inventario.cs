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
        }

        #endregion
    }
}
