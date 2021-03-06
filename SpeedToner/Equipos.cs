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
        //Sabremos si estamos modificando o agregando
        private bool Modificando = false;
        //Ayudara a saber si estamos buscando algun registro
        private bool Buscando = false;
        //Guardara el id en caso de que se seleccione algun registro del datagridview
        int Id;
        //Segun la variable es lo que mostrara en el datagridview
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
            LlenarComboBox(cboClientes, "SeleccionarClientes", 0);
            LlenarComboBox(cboTipoRenta, "SeleccionarTipoRenta", 0);
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

        #region Validaciones

        public bool ValidarCampos()
        {
            bool Validado = true;
            erEquipos.Clear();
            if (txtSerie.Text == "")
            {
                erEquipos.SetError(txtSerie, "Ingrese una serie");
                Validado = false;
            }
            if (txtPrecio.Text == "")
            {
                erEquipos.SetError(txtPrecio, "Ingrese el precio");
                Validado = false;
            }
            if (txtFechaPago.Text == "")
            {
                erEquipos.SetError(txtFechaPago, "Ingrese una fecha de pago");
                Validado = false;
            }
            foreach (Control c in grpDatos.Controls)
            {
                if (c is ComboBox)
                {
                    if (c.Text == "" || c.Text == " ")
                    {
                        erEquipos.SetError(c, "Campo Obligatorio");
                        Validado = false;
                    }
                }
            }
            return Validado;
        }

        public bool ValidarCamposReporte()
        {
            bool Validado = true;
            erEquipos.Clear();
            if (cboMostrar.SelectedItem == null)
            {
                erEquipos.SetError(cboMostrar, "Campo obligatorio");
                Validado = false;
            }
            else
            {
                if (cboBusqueda.SelectedItem == " ")
                {
                    erEquipos.SetError(cboBusqueda, "Campo obligatorio");
                    Validado = false;
                }
            }
            return Validado;
        }
        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
            if ((e.KeyChar == '.') && (!txtPrecio.Text.Contains(".")))
            {
                e.Handled = false;
            }
        }

        private void txtFechaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }

        private void txtSerieBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }
        #endregion

        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool SerieRepetida = false;
            try
            {
                if (ValidarCampos())
                {
                    int Cliente = objetoCN.BuscarId(cboClientes.SelectedItem.ToString(), "ObtenerIdCliente");
                    string Ubicacion = txtReferencia.Text;
                    int Marca = objetoCN.BuscarId(cboMarcas.SelectedItem.ToString(), "ObtenerIdMarca");
                    int Modelo = objetoCN.BuscarId(cboModelos.SelectedItem.ToString(), "ObtenerIdModelo");
                    string Serie = txtSerie.Text;
                    int TipoRenta = objetoCN.BuscarId(cboTipoRenta.SelectedItem.ToString(), "ObtenerIdTipoRenta");
                    double Precio = double.Parse(txtPrecio.Text.Replace(",", ""));
                    string FechaPago = txtFechaPago.Text;

                    if (Modificando)
                    {
                        //Modificar stop procedure de modificar, para que se pueda cambiar la fecha
                        if (MessageBox.Show("¿Esta seguro de modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("!!Modificación cancelada!!", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarEquipo(Id, Cliente, Ubicacion, Marca, Modelo, Serie, TipoRenta, Precio, FechaPago);
                        MessageBox.Show("Equipo modificado correctamente", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SerieRepetida = objetoCN.VerificarDuplicados(Serie, "VerificarDuplicadoSerieEquipos");
                        if (SerieRepetida)
                        {
                            MessageBox.Show("Ingrese un numero de serie distinto", "SERIE YA EXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            objetoCN.AgregarEquipo(Cliente, Ubicacion, Marca, Modelo, Serie, TipoRenta, Precio, FechaPago);
                            MessageBox.Show("Equipo agregado correctamente", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Mostrar("MostrarEquipos");
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
            try
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "CONFIRME LA ELIMINACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("!!Eliminacion cancelada!!", "CANCELADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LimpiarForm();
                    return;
                }
                objetoCN.Eliminar(Id, "EliminarEquipo");
                MessageBox.Show("Se ha eliminado el registro correctamente", "ELIMINACION CONFIRMADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Mostrar("MostrarEquipos");
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            erEquipos.Clear();
            if (txtSerieBusqueda.Text != "")
            {
                dr = objetoCN.Buscar(txtSerieBusqueda.Text, "BuscarSerie");
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
                    MessageBox.Show("Ingrese otro numero de serie", "Serie no existente en la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                dr.Close();
                cn.CerrarConexion();
                txtSerieBusqueda.Text = "";
                Buscando = false;
            }
            else
            {
                erEquipos.SetError(txtSerieBusqueda, "Ingrese una serie");
            }
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //Limpiamos los datos del datagridview
            //dtgEquipos.DataSource = null;
            //dtgEquipos.Refresh();
            DataTable tabla = new DataTable();
            //Guardamos los registros dependiendo la consulta
            if (ValidarCamposReporte())
            {
                objetoCN.OrdenarEquipos(cboBusqueda.SelectedItem.ToString(), TipoBusqueda);
                cboMostrar.ResetText();
                cboBusqueda.SelectedIndex = 0;
            }

            //Asignamos los registros que optuvimos al datagridview
            //dtgEquipos.DataSource = tabla;

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            ControlesDesactivados(false);
            LimpiarForm();
            Modificando = false;
        }
        #endregion

        #region Eventos
        private void dtgEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarForm();
            ControlesDesactivados(true);
            Modificando = true;
            erEquipos.Clear();
            

            Id = int.Parse(dtgEquipos.CurrentRow.Cells[0].Value.ToString());
            cboClientes.SelectedItem = dtgEquipos.CurrentRow.Cells[1].Value.ToString();
            txtReferencia.Text = dtgEquipos.CurrentRow.Cells[2].Value.ToString();
            cboMarcas.SelectedItem = dtgEquipos.CurrentRow.Cells[3].Value.ToString();
            cboModelos.SelectedItem = dtgEquipos.CurrentRow.Cells[4].Value.ToString();
            txtSerie.Text = dtgEquipos.CurrentRow.Cells[5].Value.ToString();
            cboTipoRenta.SelectedItem = dtgEquipos.CurrentRow.Cells[6].Value.ToString();
            txtPrecio.Text = dtgEquipos.CurrentRow.Cells[7].Value.ToString().Replace("$", "");
            txtFechaPago.Text = dtgEquipos.CurrentRow.Cells[8].Value.ToString();
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
            cboModelos.SelectedIndex = 0;
            LlenarComboBox(cboModelos, "SeleccionarModelos", 0);
        }

        public void MostrarComboBox(ComboBox cb, string TipoBusqueda)
        {
            cb.Visible = true;
            switch (TipoBusqueda)
            {
                case "Clientes": break;
            }
            LlenarComboBox(cboBusqueda, "SeleccionarClientes", 0);
            LlenarComboBox(cboTipoRenta, "SeleccionarTipoRenta", 0);
            LlenarComboBox(cboMarcas, "SeleccionarMarca", 0);
        }

        private void btnBorrador_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            erEquipos.Clear();
        }
    }
}
