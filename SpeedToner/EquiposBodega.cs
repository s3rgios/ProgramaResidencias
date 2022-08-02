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
    public partial class EquiposBodega : Form
    {
        public EquiposBodega()
        {
            InitializeComponent();
            InicioAplicacion();
        }

        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();
        //Sabremos si estamos modificando o agregando
        private bool Modificando = false;
        bool Buscando = false;
        //Guardar el id de un registro
        int Id;

        #region Inicio
        public void InicioAplicacion()
        {
            PropiedadesDtg();
            ControlesDesactivados(false);

            //Llenamos el datagridview
            Mostrar("MostrarBodega");

            LlenarComboBox(cboMarcas, "SeleccionarMarca", 0);
            LlenarComboBox(cboModelos, "SeleccionarModelos", 0);
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
        #endregion

        #region Validaciones
        private bool ValidarDatos()
        {
            bool Validado = true;
            erBodega.Clear();
            foreach (Control c in grpDatos.Controls)
            {
                if (c is ComboBox || c is TextBox)
                {
                    if (c.Text == "" || c.Text == " ")
                    {
                        erBodega.SetError(c, "Campo obligatorio");
                        Validado = false;
                    }
                }
            }
            return Validado;
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetrasYNumeros(e);
        }
        #endregion

        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool SerieDuplicada = false;
            try
            {
                if (ValidarDatos())
                {
                    int Marca = objetoCN.BuscarId(cboMarcas.SelectedItem.ToString(), "ObtenerIdMarca");
                    int Modelo = objetoCN.BuscarId(cboModelos.SelectedItem.ToString(), "ObtenerIdModelo");
                    string Serie = txtSerie.Text;
                    string Ubicacion = txtUbicacion.Text;
                    string Estado = cboEstado.SelectedItem.ToString();
                    string Notas = rtxtNotas.Text;
                    if (Modificando)
                    {
                        if (MessageBox.Show("¿Esta seguro de modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("!!Modificación cancelada!!", "OPERACION CANCELADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarBodega(Id, Marca, Modelo, Serie, Ubicacion, Estado, Notas);
                        MessageBox.Show("¡Equipo modificado correctamente!","OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SerieDuplicada = objetoCN.VerificarDuplicados(Serie, "VerificarDuplicadoSerieBodega");
                        if (SerieDuplicada)
                        {
                            MessageBox.Show("Ingrese un numero de serie distinto", "SERIE YA EXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            objetoCN.AgregarBodega(Marca, Modelo, Serie, Ubicacion, Estado, Notas);
                            MessageBox.Show("¡Equipo añadido correctamente!", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Mostrar("MostrarBodega");
                    LimpiarForm();
                }
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlesDesactivados(false);
            Modificando = false;
            LimpiarForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "CONFIRME LA ELIMINACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("!!Eliminacion cancelada!!","OPERACION CANCELADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarForm();
                    return;
                }
                objetoCN.Eliminar(Id, "EliminarBodega");
                MessageBox.Show("Se ha eliminado el registro correctamente", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar("MostrarEquipos");
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBorrador_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            erBodega.Clear();
            Modificando = true;
            Buscando = false;
        }

        //Buscara un equipo en especifico por su numero de serie
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                SqlDataReader dr;
                Buscando = true;
                dr = objetoCN.Buscar(txtBusqueda.Text, "BuscarSerieBodega");
                if (dr.Read())
                {
                    cboMarcas.SelectedItem = dr[1].ToString();
                    cboModelos.SelectedItem = dr[2].ToString();
                    txtSerie.Text = dr[3].ToString();
                    txtUbicacion.Text = dr[4].ToString();
                    cboEstado.SelectedItem = dr[5].ToString();
                    rtxtNotas.Text = dr[6].ToString();
                    dr.Close();
                }
                else
                {
                    MessageBox.Show("La serie no esta registrado en la base de datos", "REGISTRO NO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr.Close();
                }
            }
            else
            {
                erBodega.SetError(txtBusqueda, "Coloque una serie");
            }
        }
        #endregion

        public void LimpiarForm()
        {
            foreach (Control c in
                grpDatos.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            cboMarcas.Focus();

            cboMarcas.SelectedIndex = 0;
            cboModelos.SelectedIndex = 0;
            cboEstado.SelectedIndex = -1;
            LlenarComboBox(cboModelos, "SeleccionarModelos", 0);
        }
        #region Eventos
        //Nos ayudara a llenar el combobox de modelos dependiendo de su marca
        private void cboMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mientras haya una marca seleccionada y mientras no estemos buscando algo
            if (cboMarcas.SelectedItem.ToString() != " " && Buscando == false)
            {
                int IdMarca = objetoCN.BuscarId(cboMarcas.SelectedItem.ToString(), "ObtenerIdMarca");
                //Se mostraran los modelos de acuerdo a la marca que se haya escogido
                LlenarComboBox(cboModelos, "SeleccionarModelos", IdMarca);
            }
        }

        //Seleccionamos algun registro del dtg para poder modificarlo o eliminarlo
        private void dtgEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarForm();
            ControlesDesactivados(true);
            Modificando = true;

            //Se cargan los controles con el registro seleccionado
            Id = int.Parse(dtgEquipos.CurrentRow.Cells[0].Value.ToString());
            cboMarcas.SelectedItem = dtgEquipos.CurrentRow.Cells[1].Value.ToString();
            cboModelos.SelectedItem = dtgEquipos.CurrentRow.Cells[2].Value.ToString();
            txtSerie.Text = dtgEquipos.CurrentRow.Cells[3].Value.ToString();
            txtUbicacion.Text = dtgEquipos.CurrentRow.Cells[4].Value.ToString();
            cboEstado.SelectedItem = dtgEquipos.CurrentRow.Cells[5].Value.ToString();
            rtxtNotas.Text = dtgEquipos.CurrentRow.Cells[6].Value.ToString();
        }

        #endregion

    }
}
