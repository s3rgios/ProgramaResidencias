using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml.Linq;
using System.Diagnostics;

namespace SpeedToner
{
    public class CD_Servicios
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlCommand  comando = new SqlCommand();
        SqlDataReader reporte;


        //Metodo para mostrar los registros de los servicios, dependiendo el stop procedure que se envie, se mostrara informacion como la requiera el usuario
        public DataTable Mostrar(string sp)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo que ejecuta los stop procedure para llenar los combo box
        public SqlDataReader LlenarComboBox(string sp)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            return leer;
        }

        //Metodo que ejecuta los stop procedure para poder obtener el id que se requiera
        public int BuscarId(string campo, string sp)
        {
            SqlDataReader leer;
            int id = 0;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CampoBusqueda", campo);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();

            while (leer.Read())
            {
                id = int.Parse(leer[0].ToString());
            }

            conexion.CerrarConexion();
            return id;
        }

        #region Servicios
        public void InsertarServicio(string NumeroFolio,int IdCliente, int IdMarca, string Modelo, string Serie, string Contador, DateTime Fecha, string Tecnico, string Usuario, string Fusor, string ServicioRealizado, string ReporteFalla )
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarServicio";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NumeroFolio", int.Parse(NumeroFolio));
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("IdMarca", IdMarca);
            comando.Parameters.AddWithValue("Modelo",Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@Contador", int.Parse(Contador));
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Tecnico", Tecnico);
            comando.Parameters.AddWithValue("@Usuario", Usuario);
            comando.Parameters.AddWithValue("@Fusor", Fusor);
            comando.Parameters.AddWithValue("@ServicioRealizado", ServicioRealizado);
            comando.Parameters.AddWithValue("@ReporteFalla",ReporteFalla);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarServicio(string NumeroFolio, int IdCliente, int IdMarca, string Modelo, string Serie, string Contador, DateTime Fecha, string Tecnico, string Usuario, string Fusor, string ServicioRealizado, string ReporteFalla)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarServicio";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NumeroFolio", int.Parse(NumeroFolio));
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("IdMarca", IdMarca);
            comando.Parameters.AddWithValue("Modelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Contador", int.Parse(Contador));
            comando.Parameters.AddWithValue("@Tecnico", Tecnico);
            comando.Parameters.AddWithValue("@Usuario", Usuario);
            comando.Parameters.AddWithValue("@Fusor", Fusor);
            comando.Parameters.AddWithValue("@ServicioRealizado", ServicioRealizado);
            comando.Parameters.AddWithValue("@ReporteFalla", ReporteFalla);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarServicio(string NumeroFolio)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NumeroFolio", int.Parse(NumeroFolio));
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            
            
            conexion.CerrarConexion();
        }

        public SqlDataReader BuscarServicio(string NumeroFolio)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NumeroFolio", int.Parse(NumeroFolio));
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();

            return leer;
        }

        public void GenerarReporte(DateTime FechaInicio, DateTime FechaFinal, string ParametroBusqueda,string TipoBusqueda)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GenerarReporte";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
            comando.Parameters.AddWithValue("@CampoBusqueda", ParametroBusqueda);
            reporte = comando.ExecuteReader();
            comando.Parameters.Clear();
            GenerarPdf(TipoBusqueda,ParametroBusqueda,FechaInicio, FechaFinal);
        }


        public void GenerarPdf(string TipoBusqueda, string ParametroBusqueda, DateTime FechaInicio, DateTime FechaFinal)
        {
            //string NombreArchivo = @"C:\Users\Acer\Documents\Diseño web\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            string NombreArchivo = @"C:\Users\DELL PC\Documents\Base de datos\" +"Reporte"+ DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            FileStream fs = new FileStream(NombreArchivo, FileMode.Create);
            Document document = new Document(PageSize.LETTER);
            document.SetMargins(25f, 25f, 25f, 25f);
            document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());

            PdfWriter pw = PdfWriter.GetInstance(document, fs);
            //Leemos el archivo que generamos
            //string paginahtml_texto = Properties.Resources.plantilla.toString();

            document.Open();

            //Definir el titulo
            document.AddAuthor("Sergio Manuel García");
            document.AddTitle("Reporte de ");

            //Definir tipo de fuente
            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //iTextSharp.text.Font _fonts = FontFactory.GetFont("Tahoma", 11f, 1);
            //_pdfCell = new PdfPCell(new Phrase("Título del documento", _fonts));
            //_pdfCell.Colspan = 3;
            //_pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfCell.Border = 0;
            //_pdfCell.BackgroundColor = BaseColor.WHITE;
            //_pdfCell.ExtraParagraphSpace = 0;
            

            //Codigo para la imagen
            iTextSharp.text.Image Logotipo = iTextSharp.text.Image.GetInstance(Properties.Resources.Speed_toner,System.Drawing.Imaging.ImageFormat.Png);
            Logotipo.ScaleToFit(150, 80);
            Logotipo.Alignment = iTextSharp.text.Image.UNDERLYING;
            Logotipo.SetAbsolutePosition(document.LeftMargin, document.Top - 40);
            document.Add(Logotipo);

            iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance(Properties.Resources.Speed_toner, System.Drawing.Imaging.ImageFormat.Png);
            Logo.ScaleToFit(150, 80);
            Logo.Alignment = iTextSharp.text.Image.UNDERLYING;
            Logo.SetAbsolutePosition(document.Right - 150, document.Top - 40);
            document.Add(Logo);

            //Variable para definir tipo de fuente
            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            //iTextSharp.text.Font fontTitle = FontFactory.GetFont("arial", 20);
            iTextSharp.text.Font fontParapragh = FontFactory.GetFont("arial", 12);
            iTextSharp.text.Font fontFecha = FontFactory.GetFont("arial", 9);

            Paragraph titulo =  new Paragraph("REPORTE SERVICIO TECNICO " + TipoBusqueda.ToUpper(), fontTitle);
            titulo.Alignment = Element.ALIGN_CENTER;

            Paragraph Fechas = new Paragraph("Fecha Inicio: "+ FechaInicio.ToString("dd-MM-yyyy")+ "       Fecha Final: " + FechaFinal.ToString("dd-MM-yyyy"), fontFecha);
            Fechas.Alignment = Element.ALIGN_CENTER;


            document.Add(titulo);
            document.Add(Fechas);

            document.Add(Chunk.NEWLINE);//Salto de linea

            //Recorremos el arreglo que nos genero la consulta
            while (reporte.Read())
            {
                DateTime Fecha = Convert.ToDateTime(reporte[5].ToString());
                document.Add(new Paragraph("Fecha Servicio: " + Fecha.ToString("dd-MM-yyyy") + "                      "+ reporte[7].ToString() + "                     " + reporte[0].ToString(), fontParapragh));
                //document.Add(new Paragraph("Numero de Folio:" + reporte[0].ToString(), fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea
                //document.Add(new Paragraph("Cliente:" + reporte[1].ToString(),fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea
                //document.Add(new Paragraph("Modelo:" + reporte[2].ToString(), fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea
                //document.Add(new Paragraph("Serie:" + reporte[3].ToString(), fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea
                document.Add(new Paragraph("Reporte de falla:" + reporte[10].ToString(), fontParapragh));
                document.Add(new Paragraph("Servicio realizado:" + reporte[9].ToString(), fontParapragh));
                document.Add(new Paragraph("Fusor:" + reporte[8].ToString(), fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea
                document.Add(new Paragraph("Contador: " + string.Format("{0:n0}", int.Parse(reporte[4].ToString())), fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea
                //document.Add(new Paragraph("Hora:" + reporte[6].ToString(), fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea
                //document.Add(new Paragraph("Tecnico:" + reporte[7].ToString(), fontParapragh));
                //document.Add(Chunk.NEWLINE);//Salto de linea

                //document.Add(Chunk.NEWLINE);//Salto de linea

                //document.Add(Chunk.NEWLINE);//Salto de linea
                document.Add(new Paragraph("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fontParapragh));
                document.Add(Chunk.NEWLINE);//Salto de linea
            }

            document.Close();

            //Abrimos el pdf 
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(NombreArchivo)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        #endregion

        #region Clientes

        //Metodo para devolver el cliente dependiendo el Id que tenga
        public SqlDataReader BuscarCliente(int IdCliente, string sp)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();

            return leer;
        }

        public void InsertarCliente(string Empresa)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Empresa", Empresa);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarCliente(int IdCliente,string Empresa)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("@Empresa", Empresa);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarCliente(int IdCliente)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        #endregion

        #region Inventario

        public void AñadirRegistroInventario(string cartucho, string Oficina, string Bodega)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AñadirInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", cartucho);
            comando.Parameters.AddWithValue("@CantidadOficina", int.Parse(Oficina));
            comando.Parameters.AddWithValue("@CantidadBodega", int.Parse(Bodega));


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarRegistroInventario(int Id,string cartucho, string Oficina, string Bodega)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Nombre", cartucho);
            comando.Parameters.AddWithValue("@CantidadOficina", int.Parse(Oficina));
            comando.Parameters.AddWithValue("@CantidadBodega", int.Parse(Bodega));


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarRegistroInventario(int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarInventario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void AgregarRegistroInventario(int cartucho, string Salida, string Entrada, string Cliente, DateTime Fecha, string destino)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AñadirRegistroInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdCartucho", cartucho);
            comando.Parameters.AddWithValue("@CantidadSalida", int.Parse(Salida));
            comando.Parameters.AddWithValue("@CantidadEntrada", int.Parse(Entrada));
            comando.Parameters.AddWithValue("@Cliente", Cliente);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@DestinoEntrada", destino);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarRegistroInventario(int IdRegistro, int IdCartucho, string Salida,string Entrada, string Cliente, DateTime Fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarRegistroInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdRegistro", IdRegistro);
            comando.Parameters.AddWithValue("@IdCartucho", IdCartucho);
            comando.Parameters.AddWithValue("@CantidadSalida", int.Parse(Salida));
            comando.Parameters.AddWithValue("@CantidadEntrada", int.Parse(Entrada));
            comando.Parameters.AddWithValue("@Cliente", Cliente);
            comando.Parameters.AddWithValue("@Fecha", Fecha);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void DeleteRegistroInventario(int IdRegistro) 
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarRegistroInventario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdRegistro", IdRegistro);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public SqlDataReader Buscar(int IdCartucho)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarCartucho";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCartucho", IdCartucho);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();

            return leer;
        }

        public string EnviarOficina(string Cantidad, int Id)
        {
            SqlDataReader leer;
            int valor = 0;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EnviarOficina";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Cantidad", int.Parse(Cantidad));
            comando.Parameters.AddWithValue("@Id", Id);

            //leer = comando.ExecuteReader();
            valor = comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            if (valor > 0)
            {
                conexion.CerrarConexion();
                return "Se ha añadido a oficina correctamente";
            }
            else
            {
                conexion.CerrarConexion();
                return "La cantidad excede la cantidad en la bodega";
            }
        
            
        }

        #endregion

        #region Equipos

        public void AgregarEquipo(int IdCliente, string Referencia,string Modelo,string Serie, int IdRenta, int Precio, string Fecha_Pago)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarEquipo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdCliente",IdCliente);
            comando.Parameters.AddWithValue("@Referencia", Referencia);
            comando.Parameters.AddWithValue("@Modelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@IdRenta", IdRenta);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago);

            comando.ExecuteNonQuery(); 

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarEquipo(int Id,int IdCliente,string Referencia, string Modelo, string Serie, int IdRenta, int Precio, string Fecha_Pago)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarEquipo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("@Referencia", Referencia);
            comando.Parameters.AddWithValue("@Modelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@IdRenta", IdRenta);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarEquipo(int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEquipo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        #endregion
    }
}
