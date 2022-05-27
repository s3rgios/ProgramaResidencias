using System.Runtime.InteropServices;
namespace SpeedToner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Botones que cerraran
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lparam);

        //Metodo que nos permtira abrir las interfaces necesarias
        private void AbrirForm(object formNuevo)
        {
            //Si el contenedor central cuenta con formulario ya en el
            if (this.PanelContenedor.Controls.Count > 0)
            {
                //Lo removeremos para poder agregar el que se eligio
                this.PanelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formNuevo as Form;
            fh.TopLevel = false; //Decimos que no es un formulario de nivel superior
            fh.Dock = DockStyle.Fill;//Contenedor que estara en el centro
            this.PanelContenedor.Controls.Add(fh);//Añadimos la forma al panel
            this.PanelContenedor.Tag = fh;
            //Mostramos la interfaz que se haya seleccionado
            fh.Show();
        }

        //Evento que permitira al usuario poder mover la ventana del programa
        private void BarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Mostrar interfaz de los reportes de los servicios
        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirForm(new Servicios());
        }

        //Mostrar interfaz de los clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirForm(new Clientes());
        }

        //Mostrar interfaz del inventario
        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirForm(new Inventario());
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            AbrirForm(new Equipos());
        }
    }
}