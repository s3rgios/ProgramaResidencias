﻿using System;
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

        public SqlDataReader LlenarComboBoxModelos(string sp,int Marca)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdMarca", Marca);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
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
            leer.Close();
            return id;
        }

        #region Servicios
        public void InsertarServicio(string NumeroFolio,int IdCliente, int IdMarca, int Modelo, string Serie, string Contador, DateTime Fecha, string Tecnico, string Usuario, string Fusor, string ServicioRealizado, string ReporteFalla )
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

        public void ModificarServicio(string NumeroFolio, int IdCliente, int IdMarca, int Modelo, string Serie, string Contador, DateTime Fecha, string Tecnico, string Usuario, string Fusor, string ServicioRealizado, string ReporteFalla)
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
            //Se tendra que cambiar cuando se cambie a otra computadora
            string NombreArchivo = @"C:\Users\DELL PC\Documents\Base de datos\" + "Reporte" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            //Lista de las series para evitar que se repitan las series en algunas consultas
            List<string> Series = new List<string>();
            FileStream fs = new FileStream(NombreArchivo, FileMode.Create);
            Document document = new Document(PageSize.LETTER);
            document.SetMargins(25f, 25f, 25f, 25f);
            document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());

            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            int contadorRegistros = 0;
            //Instanciamos la clase para la paginacion
            var pe = new PageEventHelper();
            pw.PageEvent = pe;
            document.Open();

            //Definir el titulo
            document.AddAuthor("Sergio Manuel García");
            document.AddTitle("Reporte de ");

            //Definir tipo de fuente
            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 28);

            //Variable para definir tipo de fuente normal
            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontParapragh = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //Fuente para los parrafos en negritas
            iTextSharp.text.Font fontParapraghBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //iTextSharp.text.Font fontParapragh = FontFactory.GetFont("arial", 10);

            iTextSharp.text.Font fontFecha = FontFactory.GetFont("arial", 9);

            Paragraph titulo = new Paragraph("REPORTE SERVICIO TECNICO " + TipoBusqueda.ToUpper(), fontTitle);
            titulo.Alignment = Element.ALIGN_CENTER;


            Paragraph Fechas = new Paragraph("FECHA DE INICIO: " + FechaInicio.ToString("dd/MM/yyyy") + "       FECHA FINAL: " + FechaFinal.ToString("dd/MM/yyyy"), fontFecha);
            Fechas.Alignment = Element.ALIGN_CENTER;

            document.Add(titulo);
            document.Add(Fechas);
            //Tabla para colocar la serie, modelo y la marca
            

            //Tabla para cuando se requiera hacer reporte por cliente
            PdfPTable tblCliente = new PdfPTable(4);
            tblCliente.WidthPercentage = 100;

            document.Add(Chunk.NEWLINE);//Salto de linea
            if (reporte.Read())
            {
                if (TipoBusqueda == "Serie")
                {
                    //document.Add(new Paragraph("SERIE: " + reporte[4].ToString().ToUpper() + "               " + reporte[2].ToString().ToUpper() + "           " + reporte[3].ToString().ToUpper(), fontParapraghBold));
                    //PdfPCell clSerie = new PdfPCell(new Phrase("SERIE:" + reporte[4].ToString().ToUpper(), fontParapraghBold));
                    //clSerie.BorderWidth = 0;
                    //clSerie.BorderWidthLeft = .5f;
                    //clSerie.BorderWidthTop = .5f;
                    //clSerie.BorderWidthBottom = .5f;

                    //PdfPCell clMarca = new PdfPCell(new Phrase(reporte[2].ToString().ToUpper(), fontParapraghBold));
                    //clMarca.BorderWidth = 0;
                    //clMarca.BorderWidthTop = .5f;
                    //clMarca.BorderWidthBottom = .5f;

                    //PdfPCell clModelo = new PdfPCell(new Phrase(reporte[3].ToString().ToUpper(), fontParapraghBold));
                    //clModelo.BorderWidth = 0;
                    //clModelo.BorderWidthRight = .5f;
                    //clModelo.BorderWidthTop = .5f;
                    //clModelo.BorderWidthBottom = .5f;

                    //tblSerie.AddCell(clSerie);
                    //tblSerie.AddCell(clMarca);
                    //tblSerie.AddCell(clModelo);
                    //tblSerie.HorizontalAlignment = Element.ALIGN_LEFT;
                    PdfPTable tblSerie = new PdfPTable(3);
                    tblSerie.WidthPercentage = 80;
                    string Serie = reporte[4].ToString();
                    string Marca = reporte[2].ToString();
                    string Modelo = reporte[3].ToString();
                    //Mandamos los nombres de los titulos que tendran las columnas de la tabla
                    tblSerie = AgregarTablaSerie(Serie, Marca,Modelo);
                    document.Add(tblSerie);
                    document.Add(new Paragraph("CLIENTE: " + reporte[1].ToString().ToUpper(), fontParapraghBold));
                }
                else if(TipoBusqueda == "Clientes")
                {
                    PdfPCell clCliente = new PdfPCell(new Phrase("Cliente", fontParapraghBold));
                    clCliente.BorderWidth = 0;
                    clCliente.BorderWidthLeft = .5f;
                    clCliente.BorderWidthTop = .5f;
                    clCliente.BorderWidthBottom = .5f;

                    PdfPCell clSerie = new PdfPCell(new Phrase("Serie", fontParapraghBold));
                    clSerie.BorderWidth = 0;
                    clSerie.BorderWidthLeft = .5f;
                    clSerie.BorderWidthTop = .5f;
                    clSerie.BorderWidthBottom = .5f;

                    PdfPCell clFecha = new PdfPCell(new Phrase("Fecha Servicio", fontParapraghBold));
                    clFecha.BorderWidth = 0;
                    clFecha.BorderWidthTop = .5f;
                    clFecha.BorderWidthBottom = .5f;

                    PdfPCell clFolio = new PdfPCell(new Phrase("Numero Folio",fontParapraghBold));
                    clFolio.BorderWidth = 0;
                    clFolio.BorderWidthRight = .5f;
                    clFolio.BorderWidthTop = .5f;
                    clFolio.BorderWidthBottom = .5f;

                    tblCliente.AddCell(clCliente);
                    tblCliente.AddCell(clSerie);
                    tblCliente.AddCell(clFecha);
                    tblCliente.AddCell(clFolio);

                    tblCliente.HorizontalAlignment = Element.ALIGN_LEFT;
                    document.Add(tblCliente);
                    document.Add(new Paragraph(reporte[1].ToString().ToUpper(), fontParapraghBold));
                }
            }
            
            //Recorremos el arreglo que nos genero la consulta
            while (reporte.Read())
            {
                //Codigo para despues de mostrar 4 registros haga saltos de pagina
                contadorRegistros++;
                if (contadorRegistros > 4)
                {
                    document.Add(Chunk.NEWLINE);//Salto de linea
                    document.Add(Chunk.NEWLINE);//Salto de linea
                    document.Add(Chunk.NEWLINE);//Salto de linea
                    contadorRegistros = 0;
                }
                if(TipoBusqueda == "Serie")
                {
                    DateTime Fecha = Convert.ToDateTime(reporte[6].ToString());
                    document.Add(new Paragraph("                                 Fecha Servicio:" + Fecha.ToString("dd/MM/yyyy") + "                      " + reporte[8].ToString().ToUpper() + "                     " + reporte[0].ToString(), fontParapragh));
                    document.Add(new Paragraph("DIAGNOSTICO: " + reporte[11].ToString().ToUpper(), fontParapragh));
                    document.Add(new Paragraph("SERVICIO: " + reporte[10].ToString().ToUpper(), fontParapragh));
                    document.Add(new Paragraph("FUSOR: " + reporte[9].ToString().ToUpper(), fontParapragh));
                    document.Add(new Paragraph("CONTADOR: " + string.Format("{0:n0}", int.Parse(reporte[5].ToString())), fontParapragh));

                    document.Add(new Paragraph("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fontParapragh));
                }
                else if(TipoBusqueda == "Clientes")
                {
                    foreach(string serie in Series)
                    {
                        if(serie != reporte[4].ToString())
                        {
                            PdfPTable tblSerie = new PdfPTable(3);
                            tblSerie.WidthPercentage = 80;
                            string Serie = reporte[4].ToString();
                            string Marca = reporte[2].ToString();
                            string Modelo = reporte[3].ToString();
                            //Mandamos los nombres de los titulos que tendran las columnas de la tabla
                            tblSerie = AgregarTablaSerie(Serie, Marca, Modelo);
                            document.Add(tblSerie);
                        }
                    }
                    DateTime Fecha = Convert.ToDateTime(reporte[6].ToString());
                    document.Add(new Paragraph("                                 Fecha Servicio:" + Fecha.ToString("dd/MM/yyyy") + "                      " + reporte[8].ToString().ToUpper() + "                     " + reporte[0].ToString(), fontParapragh));
                    document.Add(new Paragraph("DIAGNOSTICO: " + reporte[11].ToString().ToUpper(), fontParapragh));
                    document.Add(new Paragraph("SERVICIO: " + reporte[10].ToString().ToUpper(), fontParapragh));
                    document.Add(new Paragraph("FUSOR: " + reporte[9].ToString().ToUpper(), fontParapragh));
                    document.Add(new Paragraph("CONTADOR: " + string.Format("{0:n0}", int.Parse(reporte[5].ToString())), fontParapragh));

                    document.Add(new Paragraph("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fontParapragh));
                    Series.Add(reporte[4].ToString());

                }


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

        public PdfPTable AgregarTablaSerie(string Serie, string Marca, string Modelo)
        {
            iTextSharp.text.Font fontParapraghBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            PdfPTable tblSerie = new PdfPTable(3);
            tblSerie.WidthPercentage = 80;

            PdfPCell clSerie = new PdfPCell(new Phrase("SERIE:" + Serie, fontParapraghBold));
            clSerie.BorderWidth = 0;
            clSerie.BorderWidthLeft = .5f;
            clSerie.BorderWidthTop = .5f;
            clSerie.BorderWidthBottom = .5f;

            PdfPCell clMarca = new PdfPCell(new Phrase(Marca, fontParapraghBold));
            clMarca.BorderWidth = 0;
            clMarca.BorderWidthTop = .5f;
            clMarca.BorderWidthBottom = .5f;

            PdfPCell clModelo = new PdfPCell(new Phrase(Modelo, fontParapraghBold));
            clModelo.BorderWidth = 0;
            clModelo.BorderWidthRight = .5f;
            clModelo.BorderWidthTop = .5f;
            clModelo.BorderWidthBottom = .5f;

            tblSerie.AddCell(clSerie);
            tblSerie.AddCell(clMarca);
            tblSerie.AddCell(clModelo);
            tblSerie.HorizontalAlignment = Element.ALIGN_LEFT;
            return tblSerie;
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
