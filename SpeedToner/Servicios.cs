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

        //Sabremos cuando estamos añadiendo un nuevo registro o modificando
        bool Modificar = false;
        bool BuscandoFolio = false;
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
            ControlesDesactivadosInicialmente(false);

            //Agregamos opciones a los combobox
            AgregarOpcionesMostrar();
            LlenarComboBox(cboClientes, "SeleccionarClientes",0);
            LlenarComboBox(cboMarca, "SeleccionarMarca",0);
            LlenarComboBox(cboModelos, "SeleccionarModelos",0);

            //Denegar escritura en combobox
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMostrar.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModelos.DropDownStyle = ComboBoxStyle.DropDownList;

            //Mostramos los registros que tengamos en nuestra base de datos de los reportes de los servicos
            MostrarDatosServicios();
        }

        private void ControlesDesactivadosInicialmente(bool activado)
        {
            btnCancelar.Enabled = activado;
            btnEliminar.Enabled = activado;
            btnMostrar.Enabled = activado;
        }

        //Opciones combobox Mostrar
        public void AgregarOpcionesMostrar()
        {
            cboMostrar.Items.Add("Ultima Semana");
            cboMostrar.Items.Add("Ultimo Mes");
            cboMostrar.Items.Add("Mes pasado");
            cboMostrar.Items.Add("Este año");
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

        public bool ValidarCamposVacios()
        {
            bool Validado = true;
            erServicios.Clear();

            if (txtNumeroFolio.Text == "")
            {
                erServicios.SetError(txtNumeroFolio, "Ingrese número de folio");
                Validado = false;
            }
            if (txtSerie.Text == "")
            {
                erServicios.SetError(txtSerie, "Ingrese una serie");
                Validado = false;
            }
            if (txtContador.Text == "")
            {
                erServicios.SetError(txtContador, "Ingrese contador");
                Validado = false;
            }
            if (txtTecnico.Text == "")
            {
                erServicios.SetError(txtTecnico, "Ingrese tecnico");
                Validado = false;
            }
            if (txtUsuario.Text == "")
            {
                erServicios.SetError(txtUsuario, "Ingrese usuario");
                Validado = false;
            }
            foreach (Control c in grpDatos.Controls)
            {
                if (c is ComboBox || c is RichTextBox)
                {
                    if (c.Text == "" || c.Text == " ")
                    {
                        erServicios.SetError(c, "Campo Obligatorio");
                        Validado = false;
                    }
                }
            }
            return Validado;
        }

        #endregion

        
        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposVacios())
                {
                    string NumeroFolio = txtNumeroFolio.Text;
                    //Buscamos el Id del cliente con el stop procedure, mandando el nombre para ayudar en la consulta
                    int IdCliente = objetoCN.BuscarId(cboClientes.SelectedItem.ToString(), "ObtenerIdCliente");
                    //Buscamos el Id de la marca con el stop procedure, mandando el nombre para ayudar en la consulta
                    int IdMarca = objetoCN.BuscarId(cboMarca.SelectedItem.ToString(), "ObtenerIdMarca");
                    int Modelo = objetoCN.BuscarId(cboModelos.SelectedItem.ToString(), "ObtenerIdModelo");
                    string Serie = txtSerie.Text;
                    string Contador = txtContador.Text;
                    DateTime Fecha = dtpFecha.Value;
                    string Tecnico = txtTecnico.Text;
                    string Usuario = txtUsuario.Text;
                    string Fusor = txtFusor.Text;
                    string Servicio = rtxtServicio.Text;
                    string Falla = rtxtFallas.Text;

                    if (Modificar)
                    {
                        if (MessageBox.Show("Desea modificar el registro?", "CONFIRME LA MODIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("Modificacion cancelada!!");
                            LimpiarForm();
                            return;
                        }
                        objetoCN.ModificarServicio(NumeroFolio, IdCliente, IdMarca, Modelo, Serie, Contador, Fecha, Tecnico, Usuario, Fusor, Servicio, Falla);
                        MessageBox.Show("Registro modificado correctamente");
                    }
                    else
                    {
                        objetoCN.InsertarServicio(NumeroFolio, IdCliente, IdMarca, Modelo, Serie, Contador, Fecha, Tecnico, Usuario, Fusor, Servicio, Falla);
                        MessageBox.Show("Registro agregado correctamente");
                    }

                    LimpiarForm();
                    MostrarDatosServicios();
                }
                
            }
            catch (Exception ex)
            {
               MessageBox.Show("No se pudieron guadar los datos por: " + ex);
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Regresaremos a como era al iniciar el programa
            ControlesDesactivadosInicialmente(false);
            btnGuardar.Enabled = true;
            LimpiarForm();
            Modificar = false;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            

            //Dependiendo la opcion se enviaran diferentes stop procedures al metodo mostrar
            switch (cboMostrar.SelectedItem.ToString())
            {
                case "Ultima Semana": tabla = objetoCN.Mostrar("MostrarUltimaSemana"); break;
                case "Mes pasado": tabla = objetoCN.Mostrar("MostrarMesPasado"); break;
                case "Ultimo Mes": tabla = objetoCN.Mostrar("MostrarUltimoMes"); break;
                case "Este año": tabla = objetoCN.Mostrar("MostrarAñoActual"); break;
                case "Todos": tabla = objetoCN.Mostrar("SeleccionarTodosLosServicios"); break;
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
                int NumeroFolio = int.Parse(txtNumeroFolio.Text);
                objetoCN.Eliminar(NumeroFolio,"EliminarServicio");
                MessageBox.Show("Se elimino el registro");
                MostrarDatosServicios();
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el registro: " + ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = objetoCN.BuscarServicio(txtBusqueda.Text);
            BuscandoFolio = true;

            if (dr.Read())
            {
                txtNumeroFolio.Text = (dr[0].ToString());
                cboClientes.SelectedItem = (dr[1].ToString());
                cboMarca.SelectedItem = (dr[2].ToString());
                cboModelos.SelectedItem = (dr[3].ToString());
                txtSerie.Text = (dr[4].ToString());
                txtContador.Text = (dr[5].ToString());
                DateTime FechaRegistro = Convert.ToDateTime((dr[6].ToString()));
                dtpFecha.Value = FechaRegistro;
                txtTecnico.Text = (dr[7].ToString()); ;
                txtUsuario.Text = (dr[8].ToString()); ;
                txtFusor.Text = (dr[9].ToString()); ;
                rtxtServicio.Text = (dr[10].ToString()); ;
                rtxtFallas.Text = (dr[11].ToString()); ;
                //Agregamos las opciones dependiendo los registros que nos devolvieron
            }
            else
            {
                MessageBox.Show("El número de folio no esta registrado en la base de datos");
            }

            dr.Close();
            cn.CerrarConexion();
            txtBusqueda.Text = "";
            BuscandoFolio = false;
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

            //Limpiamos los combobox
            cboClientes.SelectedIndex = 0;
            cboMarca.SelectedIndex = 0;
            cboModelos.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            LlenarComboBox(cboModelos, "SeleccionarModelos", 0);
        }

        //Metodo que ayuda a llenar los combobox dependiendo el stop procedure que se ejecute
        public void LlenarComboBox(ComboBox cb, string sp,int Marca)
        {
            SqlDataReader dr;
            cb.Items.Clear();
            if(sp == "SeleccionarModelos")
            {
                dr = objetoCN.LlenarComboBoxModelos(sp,Marca);
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
            LimpiarForm();
            //Una vez que se escoga alguna fila podremos activar los botones para poder modificar y eliminar
            btnGuardar.Enabled = true;
            ControlesDesactivadosInicialmente(true);
            Modificar = true;

            //Asignacion a los controles
            txtNumeroFolio.Text = dtgServicios.CurrentRow.Cells[0].Value.ToString();
            cboClientes.SelectedItem = dtgServicios.CurrentRow.Cells[1].Value.ToString();
            cboMarca.SelectedItem = dtgServicios.CurrentRow.Cells[2].Value.ToString();
            cboModelos.SelectedItem = dtgServicios.CurrentRow.Cells[3].Value.ToString();
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

        private void cboMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Habilitamos el boton para poder mostrarlo
            btnMostrar.Enabled = true;
        }

        //Se llenara el combo box modelos dependiendo la marca que se seleccione
        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            //En dado caso que se haya seleccionado algo de las marcas y mientras no estemos buscando un registro en especifico
            if (cboMarca.SelectedItem.ToString() != " " && BuscandoFolio == false)
            {
                int IdMarca = objetoCN.BuscarId(cboMarca.SelectedItem.ToString(), "ObtenerIdMarca");
                LlenarComboBox(cboModelos, "SeleccionarModelos", IdMarca);
            }

        }
        #endregion
       
    }

    
}
