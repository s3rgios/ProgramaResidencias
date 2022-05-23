using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedToner
{
    public partial class Servicios : Form
    {
        CD_Servicios objetoCN = new CD_Servicios();
        CD_Conexion cn = new CD_Conexion();
        //private string NumeroFolio = null;
        public Servicios()
        {
            InitializeComponent();
            InicioAplicacion();
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            
        }

        #region Inicio
        //Metodo para guardar los diferentes metodos que se requieran al inicio de la aplicacio, asignaciones, llenado de combobox,etc
        public void InicioAplicacion()
        {
            //Asignamos propiedades iniciales a nuestro datagriwview
            PropiedadesDtgServicios();

            //Desactivamos controles que no ocuparemos al inicio
            ControlesDesactivadosInicialmente();

            //Agregamos opciones a los combobox
            AgregarOpcionesMostrar();
            LlenarComboBox(cboClientes, "SeleccionarClientes", 1);
            LlenarComboBox(cboMarca, "SeleccionarMarca", 1);

            //Denegar escritura en combobox
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMostrar.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;

            //Mostramos los registros que tengamos en nuestra base de datos de los reportes de los servicos
            MostrarDatosServicios();
        }


        
        private void ControlesDesactivadosInicialmente()
        {
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
        }


        //Opciones combobox Mostrar
        public void AgregarOpcionesMostrar()
        {
            cboMostrar.Items.Add("Ultima Semana");
            cboMostrar.Items.Add("Ultimo Mes");
            cboMostrar.Items.Add("Mes pasado");
            cboMostrar.Items.Add("Este año");
            cboMostrar.Items.Add("Año pasado");
            cboMostrar.Items.Add("Todos");
        }

        
        public void PropiedadesDtgServicios()
        {
            //Solo lectura
            dtgServicios.ReadOnly = true;

            //No agregar renglones
            dtgServicios.AllowUserToAddRows = false;

            //No borrar renglones
            dtgServicios.AllowUserToDeleteRows = false;

            //Ajustar automaticamente el ancho de las columnas
            dtgServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtgServicios.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
            dtgServicios.AutoResizeColumns();
        }

        public void MostrarDatosServicios()
        {
            //Limpiamos los datos del datagridview
            dtgServicios.DataSource = null;
            dtgServicios.Refresh();
            DataTable tabla = new DataTable();
            //Guardamos los registros dependiendo la consulta
            tabla = objetoCN.Mostrar("SeleccionarTodosLosServicios");
            //Asignamos los registros que optuvimos al datagridview
            dtgServicios.DataSource = tabla;
        }

        #endregion
        private void rtxtServicio_TextChanged(object sender, EventArgs e)
        {

        }

        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string NumeroFolio = txtNumeroFolio.Text;
                //string IdCliente = cboClientes.SelectedItem.ToString();
                //Buscamos el Id del cliente con el stop procedure, mandando el nombre para ayudar en la consulta
                int IdC = objetoCN.BuscarId(cboClientes.SelectedItem.ToString(), "ObtenerIdCliente");
                string IdMarca = cboMarca.SelectedItem.ToString();
                //Buscamos el Id de la marca con el stop procedure, mandando el nombre para ayudar en la consulta
                int IdM = objetoCN.BuscarId(cboMarca.SelectedItem.ToString(), "ObtenerIdMarca");
                string Modelo = txtModelo.Text;
                string Serie = txtSerie.Text;
                string Contador = txtContador.Text;
                DateTime Fecha = dtpFecha.Value;
                string Tecnico = txtTecnico.Text;
                string Usuario = txtUsuario.Text;
                string Fusor = txtFusor.Text;
                string Servicio = rtxtServicio.Text;
                string Falla = rtxtFallas.Text;
                
               objetoCN.InsertarServicio(NumeroFolio,  IdC, IdM, Modelo, Serie, Contador, Fecha, Tecnico, Usuario, Fusor, Servicio, Falla);
                
               LimpiarForm();
               MostrarDatosServicios();
            }
            catch (Exception ex)
            {
               MessageBox.Show("No se pudieron guadar los datos por: " + ex);
                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Preguntamos si se esta seguro de la modificacion 
            if (MessageBox.Show("Desea modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("Modificacion cancelada!!");
                LimpiarForm();
                return;
            }
            try
            {
                string NumeroFolio = txtNumeroFolio.Text;
                string IdCliente = cboClientes.SelectedItem.ToString();
                int IdC = objetoCN.BuscarId(IdCliente, "ObtenerIdCliente");
                string IdMarca = cboMarca.SelectedItem.ToString();
                int IdM = objetoCN.BuscarId(IdMarca, "ObtenerIdMarca");
                string Modelo = txtModelo.Text;
                string Serie = txtSerie.Text;
                string Contador = txtContador.Text;
                DateTime Fecha = dtpFecha.Value;
                string Tecnico = txtTecnico.Text;
                string Usuario = txtUsuario.Text;
                string Fusor = txtFusor.Text;
                string Servicio = rtxtServicio.Text;
                string Falla = rtxtFallas.Text;

                objetoCN.ModificarServicio(NumeroFolio, IdC, IdM, Modelo, Serie, Contador, Fecha, Tecnico, Usuario, Fusor, Servicio, Falla);
                MessageBox.Show("Registro modificado correctamente");
                MostrarDatosServicios();
                LimpiarForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron modificar los datos: " + ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Regresaremos a como era al iniciar el programa
            ControlesDesactivadosInicialmente();
            btnGuardar.Enabled = true;
            LimpiarForm();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();

            //Dependiendo la opcion se enviaran diferentes stop procedures al metodo mostrar
            switch (cboClientes.SelectedItem.ToString())
            {
                case "Ultima Semana": tabla = objetoCN.Mostrar("MostrarUltimaSemana"); break;
                case "Ultimo Mes": tabla = objetoCN.Mostrar("MostrarUltimoMes"); break;
                case "Este año": tabla = objetoCN.Mostrar("MostrarAñoActual"); break;
                case "Todos": tabla = objetoCN.Mostrar("MostrarDatosServicios"); break;
            }
            //Asignamos los registros a nuestro datagridview
            dtgServicios.DataSource = tabla;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Preguntamos si se esta seguro de eliminar el registro 
            if (MessageBox.Show("Desea eliminar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("Elimacion cancelada!!");
                LimpiarForm();
                return;
            }

            try
            {
                string NumeroFolio = txtNumeroFolio.Text;
                objetoCN.EliminarServicio(NumeroFolio);
                MessageBox.Show("Se elimino el registro");
                MostrarDatosServicios();
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el registro: " + ex);
            }
        }
        #endregion

        //Metodo para limpiar todos los controles textbox y richtextbox
        private void LimpiarForm()
        {
            foreach (Control c in grpDatos.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if(c is RichTextBox)
                {
                    c.Text = "";
                }            
            }
            txtNumeroFolio.Focus();

            cboClientes.SelectedIndex = 0;
            cboMarca.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
        }

        //Metodo que ayuda a llenar los combobox dependiendo el stop procedure que se ejecute
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

        //Metodo que nos permite abrir una nueva forma
        private void AbrirForm(object formNuevo)
        {
            //Declaramos la forma
            Form fh = formNuevo as Form;

            //Mostramos la forma 
            fh.Show();
        }

        //Boton que abre la interfaz para generar los reportes
        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirForm(new txtCliente());
        }



        //Boton que mostrara los registros dependiendo de lo que solicite el usuario
        

        private void txtCliente_Click(object sender, EventArgs e)
        {
                    }
        #region Eventos

        //Evento que ayuda a saber el cliente solo con ingresar el id del cliente en el txtCliente
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {
                int IdCliente = int.Parse(txtCliente.Text);
                //Dependiendo el numero que se coloque lo buscara en el stop procedure
                SqlDataReader dr = objetoCN.BuscarCliente(IdCliente, "SeleccionarCliente");

                while (dr.Read())
                {
                    //Asiganmos al combobox el resgistro que nos devuelva la consulta
                    cboClientes.SelectedItem = dr[0].ToString();
                }

                dr.Close();
                cn.CerrarConexion();
            }
        }

        //Evento del datagridview que nos ayudara a saber cuando una fila es seleccionada  
        private void dtgServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Una vez que se escoga alguna fila podremos activar los botones para poder modificar y eliminar
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;

            //Asignacion a los controles
            txtNumeroFolio.Text = dtgServicios.CurrentRow.Cells[0].Value.ToString();
            cboClientes.SelectedItem = dtgServicios.CurrentRow.Cells[1].Value.ToString();
            cboMarca.SelectedItem = dtgServicios.CurrentRow.Cells[2].Value.ToString();
            txtModelo.Text = dtgServicios.CurrentRow.Cells[3].Value.ToString();
            txtSerie.Text = dtgServicios.CurrentRow.Cells[4].Value.ToString();
            txtContador.Text = dtgServicios.CurrentRow.Cells[5].Value.ToString();
            DateTime FechaRegistro = Convert.ToDateTime(dtgServicios.CurrentRow.Cells[6].Value.ToString());
            dtpFecha.Value = FechaRegistro;
            txtTecnico.Text = dtgServicios.CurrentRow.Cells[7].Value.ToString();
            txtUsuario.Text = dtgServicios.CurrentRow.Cells[8].Value.ToString();
            txtFusor.Text = dtgServicios.CurrentRow.Cells[9].Value.ToString();
            rtxtServicio.Text = dtgServicios.CurrentRow.Cells[10].Value.ToString();
            rtxtFallas.Text = dtgServicios.CurrentRow.Cells[11].Value.ToString();
        }
        #endregion

    }

    
}
