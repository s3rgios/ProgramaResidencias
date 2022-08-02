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
using System.Drawing;



namespace SpeedToner
{
    public class CD_Servicios
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader reporte;
        //Lista para evitar duplicados de los clientes y de las series, para que solo se muestren una sola vez en el pdf
        List<string> Parametros = new List<string>();
        PdfPTable Equipos;

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

        //Metodo que hara una consulta a la base de datos en base a la marca que se haya seleccionado, seleccionando solamente los modelos de dicha marca
        public SqlDataReader LlenarComboBoxModelos(string sp, int Marca)
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
            SqlDataReader ver;
            int id = 0;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CampoBusqueda", campo);
            ver = comando.ExecuteReader();
            comando.Parameters.Clear();

            while (ver.Read())
            {
                id = int.Parse(ver[0].ToString());
            }

            conexion.CerrarConexion();
            ver.Close();
            return id;
        }

        #region Servicios
        public void InsertarServicio(string NumeroFolio, int IdCliente, int IdMarca, int Modelo, string Serie, string Contador, DateTime Fecha, string Tecnico, string Usuario, string Fusor, string ServicioRealizado, string ReporteFalla)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarServicio";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NumeroFolio", int.Parse(NumeroFolio));
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("IdMarca", IdMarca);
            comando.Parameters.AddWithValue("IdModelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@Contador", int.Parse(Contador));
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Tecnico", Tecnico);
            comando.Parameters.AddWithValue("@Usuario", Usuario);
            comando.Parameters.AddWithValue("@Fusor", Fusor);
            comando.Parameters.AddWithValue("@ServicioRealizado", ServicioRealizado);
            comando.Parameters.AddWithValue("@ReporteFalla", ReporteFalla);

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
            comando.Parameters.AddWithValue("IdModelo", Modelo);
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

        //METODO GLOBAL PARA ELIMINAR EN CUALQUIER TABLA
        public void Eliminar(int Id, string sp)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }

        public bool VerificarDuplicados(string ParametroBusqueda,string sp)
        {
            SqlDataReader leer;
            bool FolioRepetido = false;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ParametroBusqueda", ParametroBusqueda);


            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            
            //Nos ayuda a comprobar si el inventario fue modificado(Dependiendo si se haya modificado algo o no)
            if (leer.Read())
            {
                leer.Close();
                return FolioRepetido = true;
            }
            else
            {
                leer.Close();
                return FolioRepetido;
            }
        }

        //Metodo que nos regresara el registro, para poder mostrarlo en los controles correspondientes
        public SqlDataReader Buscar(string Serie, string sp)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ParametroBusqueda", Serie);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            return leer;
        }

        public bool VerificarExistenciaRegistro(string ParametroBusqueda,string sp)
        {
            SqlDataReader leer;
            bool Encontrado = false;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ParametroBusqueda", ParametroBusqueda);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Encontrado = (leer.Read()) ? true : false;
            leer.Close();
            return Encontrado;
        }


        #endregion

        #region Clientes

        //Metodo para devolver el cliente dependiendo el Id que tenga SE PUEDE REUTILIZAR
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

        public void ModificarCliente(int IdCliente, string Empresa)
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

        #endregion

        #region Inventario

        public void AñadirRegistroInventario(string cartucho, int Marca, string Oficina, string Bodega)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AñadirInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Modelo", cartucho);
            comando.Parameters.AddWithValue("@IdMarca", Marca);
            comando.Parameters.AddWithValue("@CantidadOficina", int.Parse(Oficina));
            comando.Parameters.AddWithValue("@CantidadBodega", int.Parse(Bodega));


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarRegistroInventario(int Id, string cartucho, int Marca, string Oficina, string Bodega)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Modelo", cartucho);
            comando.Parameters.AddWithValue("@IdMarca", Marca);
            comando.Parameters.AddWithValue("@CantidadOficina", int.Parse(Oficina));
            comando.Parameters.AddWithValue("@CantidadBodega", int.Parse(Bodega));


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        public string AgregarRegistroInventario(int Marca, int cartucho, string Salida, string Entrada, string Cliente, DateTime Fecha, string destino)
        {
            SqlDataReader leer;
            int valor = 0;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UpdateInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdCartucho", cartucho);
            comando.Parameters.AddWithValue("@CantidadSalida", int.Parse(Salida));
            comando.Parameters.AddWithValue("@CantidadEntrada", int.Parse(Entrada));
            comando.Parameters.AddWithValue("@DestinoEntrada", destino);


            valor = comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //Nos ayuda a comprobar si el inventario fue modificado(Dependiendo si se haya modificado algo o no)
            if (valor > 0)
            {
                //En dado caso de que haya modificado el inventario, se agregara el registro a la tabla de registros
                comando.CommandText = "AgregarRegistroInventario";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdMarca", Marca);
                comando.Parameters.AddWithValue("@IdCartucho", cartucho);
                comando.Parameters.AddWithValue("@CantidadSalida", int.Parse(Salida));
                comando.Parameters.AddWithValue("@CantidadEntrada", int.Parse(Entrada));
                comando.Parameters.AddWithValue("@Cliente", Cliente);
                comando.Parameters.AddWithValue("@Fecha", Fecha);
                comando.Parameters.AddWithValue("@DestinoEntrada", destino);

                valor = comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
                return "Se ha agregado el resgitro correctamente. Se ha actualizado el inventario";
            }
            else
            {
                conexion.CerrarConexion();
                return "No se ha agregado el registro. La cantidad excede la cantidad en existencia";
            }

        }

        public void ModificarRegistroInventario(int IdRegistro, int Marca, int IdCartucho, string Salida, string Entrada, string Cliente, DateTime Fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarRegistroInventario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdRegistro", IdRegistro);
            comando.Parameters.AddWithValue("@IdMarca", Marca);
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

        public void AgregarEquipo(int IdCliente, string Ubicacion, int Marca, int Modelo, string Serie, int IdRenta, double Precio, string Fecha_Pago)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarEquipo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.Parameters.AddWithValue("@IdMarca", Marca);
            comando.Parameters.AddWithValue("@IdModelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@IdRenta", IdRenta);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarEquipo(int Id, int IdCliente, string Ubicacion, int Marca, int Modelo, string Serie, int IdRenta, double Precio, string Fecha_Pago)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarEquipo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.Parameters.AddWithValue("@IdMarca", Marca);
            comando.Parameters.AddWithValue("@IdModelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@IdRenta", IdRenta);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        //Muestra los equipos dependiendo lo que necesite el usuario
        public DataTable OrdenarEquipos(string ParametroBusqueda, string TipoBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "OrdenarEquipos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ParametroBusqueda", ParametroBusqueda);
            leer = comando.ExecuteReader();

            GenerarReporteEquipos(leer, TipoBusqueda, ParametroBusqueda);
            tabla.Load(leer);

            comando.Parameters.Clear();
            leer.Close();

            return tabla;
        }

        //EQUIPOS BODEGA

        public void AgregarBodega(int Marca, int Modelo, string Serie, string Ubicacion, string Estado, string Notas)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarBodega";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdMarca", Marca);
            comando.Parameters.AddWithValue("@IdModelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Parameters.AddWithValue("@Notas", Notas);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarBodega(int Id, int Marca, int Modelo, string Serie, string Ubicacion, string Estado, string Notas)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarBodega";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@IdMarca", Marca);
            comando.Parameters.AddWithValue("@IdModelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Parameters.AddWithValue("@Notas", Notas);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        #endregion

        #region PDF

        public void GenerarReporte(DateTime FechaInicio, DateTime FechaFinal, string ParametroBusqueda, string TipoBusqueda)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GenerarReporte";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
            comando.Parameters.AddWithValue("@CampoBusqueda", ParametroBusqueda);
            reporte = comando.ExecuteReader();
            comando.Parameters.Clear();
            GenerarPdf(TipoBusqueda, ParametroBusqueda, FechaInicio, FechaFinal);
        }

        public void ColocarFormatosSuperiores(Document document, iTextSharp.text.Font fontTitle)
        {
            //Agregamos el logo de la izquierda
            iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoSpeedToner, System.Drawing.Imaging.ImageFormat.Png);
            Logo.ScaleToFit(150, 80);
            //Logo.ScaleToFit(100, 80);
            Logo.Alignment = iTextSharp.text.Image.UNDERLYING;
            Logo.SetAbsolutePosition(document.LeftMargin, document.Top - 50);
            document.Add(Logo);

            //Agregamos el logo de la derecha
            iTextSharp.text.Image Logotipo = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoSpeedToner, System.Drawing.Imaging.ImageFormat.Png);
            Logotipo.ScaleToFit(150, 80);
            //Logotipo.ScaleToFit(100, 80);
            Logotipo.Alignment = iTextSharp.text.Image.UNDERLYING;
            Logotipo.SetAbsolutePosition(document.Right - 150, document.Top - 50);
            //Logotipo.SetAbsolutePosition(document.Right - 100, document.Top - 50);
            document.Add(Logotipo);

            Paragraph NombreEmpresa = new Paragraph("SPEED TONER NUEVO LAREDO.", fontTitle) { Alignment = Element.ALIGN_CENTER };
            document.Add(NombreEmpresa);

            Paragraph Telefono = new Paragraph("TEL.: (867) 712-0964 FAX:(867)712-2741", fontTitle) { Alignment = Element.ALIGN_CENTER };
            document.Add(Telefono);

            Paragraph Direccion = new Paragraph("BOLIVAR #1507 NUEVO LAREDO, TAMPS. C.P 88060", fontTitle) { Alignment = Element.ALIGN_CENTER };
            document.Add(Direccion);
        }

        public void GenerarPdf(string TipoBusqueda, string ParametroBusqueda, DateTime FechaInicio, DateTime FechaFinal)
        {
            //string NombreArchivo = @"C:\Users\Acer\Documents\Diseño web\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            //Se tendra que cambiar cuando se cambie a otra computadora
            string NombreArchivo;
            //string NombreArchivo = @"C:\" + "ReporteServicio" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            //string NombreArchivo = @"C:\Users\DELL PC\Documents\Base de datos\" + "Reporte" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
            //Restaurar la ventana despues del open fileDialog
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                NombreArchivo = saveFileDialog.FileName;
            }
            else
            {
                NombreArchivo = @"\\administracion-pc\ARCHIVOS COMPARTIDOS\Reportes\" + "Reporte" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            }
            //Lista de las series para evitar que se repitan las series en algunas consultas
            List<string> Series = new List<string>();
            FileStream fs = new FileStream(NombreArchivo, FileMode.Create);
            Document document = new Document(PageSize.LETTER);
            document.SetMargins(25f, 25f, 25f, 25f);
            //Colocamos el pdf en horizontal
            document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            //Nos ayudara a controlar el numero de registros que seran mostrados
            int contadorRegistros = 0;

            //Instanciamos la clase para la paginacion
            var pe = new PageEventHelperEquipos();
            pw.PageEvent = pe;
            document.Open();

            //TIPO DE FUENTE
            //Variable para definir tipo de fuente normal
            iTextSharp.text.Font fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontParapragh = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //Fuente para los parrafos en negritas
            iTextSharp.text.Font fontParapraghBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontFecha = FontFactory.GetFont("arial", 9);

            ColocarFormatosSuperiores(document, fontTitulo);

            Paragraph titulo = new Paragraph("REPORTE SERVICIO TECNICO " + TipoBusqueda.ToUpper(), fontTitulo) { Alignment = Element.ALIGN_CENTER };

            Paragraph Fechas = new Paragraph("FECHA DE INICIO: " + FechaInicio.ToString("dd/MM/yyyy") + "       FECHA FINAL: " + FechaFinal.ToString("dd/MM/yyyy"), fontFecha) { Alignment = Element.ALIGN_CENTER };

            document.Add(titulo);
            document.Add(Fechas);

            //Tabla para cuando se requiera hacer reporte por cliente
            PdfPTable tblCliente = new PdfPTable(5) { WidthPercentage = 80 };

            document.Add(new Paragraph("\n"));

            //Si estamos filtrando por cliente, entonces se añade una tabla con los titulos de los datos que nos arrojara
            if (TipoBusqueda == "Cliente" || TipoBusqueda == "Fusor")
            {
                PdfPCell clCliente = new PdfPCell(new Phrase(TipoBusqueda, fontParapraghBold)) { BorderWidth = .5f };
                PdfPCell clSerie = new PdfPCell(new Phrase("Serie", fontParapraghBold)) { BorderWidth = .5f };
                PdfPCell clFecha = new PdfPCell(new Phrase("Fecha Servicio", fontParapraghBold)) { BorderWidth = .5f };
                PdfPCell clTecnico = new PdfPCell(new Phrase("Técnico", fontParapraghBold)) { BorderWidth = .5f };
                PdfPCell clFolio = new PdfPCell(new Phrase("Numero Folio", fontParapraghBold)) { BorderWidth = .5f };

                tblCliente.AddCell(clCliente);
                tblCliente.AddCell(clSerie);
                tblCliente.AddCell(clFecha);
                tblCliente.AddCell(clTecnico);
                tblCliente.AddCell(clFolio);

                tblCliente.HorizontalAlignment = Element.ALIGN_LEFT;
                document.Add(tblCliente);
                document.Add(new Paragraph(ParametroBusqueda, fontParapraghBold));
            }
            bool PrimerRegistro = true;
            //Recorremos el arreglo que nos genero la consulta
            while (reporte.Read())
            {
                //Codigo para despues de mostrar 4 registros haga saltos de pagina
                contadorRegistros++;
                //Si esta vacia que agregue la primer tabla con la serie, marca y modelo
                if (!Series.Any())
                {
                    PdfPTable tblSerie = new PdfPTable(3) { WidthPercentage = 80 };
                    //Guardamos los registros que obtengamos d ela base de datos
                    string Serie = reporte[4].ToString();
                    string Marca = reporte[2].ToString();
                    string Modelo = reporte[3].ToString();
                    //Mandamos los nombres de los titulos que tendran las columnas de la tabla
                    tblSerie = AgregarTablaSerie(Serie, Marca, Modelo);
                    //Agregamos la tabla al documento
                    document.Add(tblSerie);
                    if (TipoBusqueda != "Cliente")
                    {
                        document.Add(new Paragraph("Cliente: " + reporte[1].ToString(), fontParapraghBold));
                    }
                    //Añadimos la serie a la lista de series
                    Series.Add(reporte[4].ToString());
                }
                else
                {
                    //Usamos el metodo contains para verificar si ese numero de serie ya se encuentra en la lista
                    bool nSerie = Series.Contains(reporte[4].ToString());
                    //En caso de ser verdadero, solamente colocamos una linea para separar los registros
                    if (nSerie)
                    {
                        iTextSharp.text.pdf.draw.LineSeparator lineSeparator = new iTextSharp.text.pdf.draw.LineSeparator() { Offset = 2f };
                        document.Add(new Chunk(lineSeparator));
                    }
                    else//Caso contrario se creara una nueva tabla donde se mestre dicha serie
                    {
                        document.Add(new Chunk());
                        PdfPTable tblSerie = new PdfPTable(3) { WidthPercentage = 80 };
                        string Serie = reporte[4].ToString();
                        string Marca = reporte[2].ToString();
                        string Modelo = reporte[3].ToString();
                        //Mandamos los nombres de los titulos que tendran las columnas de la tabla
                        tblSerie = AgregarTablaSerie(Serie, Marca, Modelo);
                        document.Add(tblSerie);
                        if (TipoBusqueda != "Cliente")
                        {
                            document.Add(new Paragraph("Cliente: " + reporte[1].ToString(), fontParapraghBold));
                        }
                        contadorRegistros++;
                    }
                }

                //Colocamos los datos del servicio
                DateTime Fecha = Convert.ToDateTime(reporte[6].ToString());
                document.Add(new Paragraph("                                                                                                   " + Fecha.ToString("dd/MM/yyyy") + "                          " + reporte[7].ToString().ToUpper() + "                               " + reporte[0].ToString(), fontParapragh));
                document.Add(new Paragraph("DIAGNOSTICO: " + reporte[11].ToString().ToUpper(), fontParapragh));
                document.Add(new Paragraph("SERVICIO: " + reporte[10].ToString().ToUpper(), fontParapragh));
                document.Add(new Paragraph("FUSOR: " + reporte[9].ToString().ToUpper(), fontParapragh));
                document.Add(new Paragraph("CONTADOR: " + string.Format("{0:n0}", int.Parse(reporte[5].ToString())), fontParapragh));
                //Agregamos la serie a la lista
                Series.Add(reporte[4].ToString());

            }
            reporte.Close();
            document.Close();

            //Abrimos el pdf 
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(NombreArchivo)
            {
                UseShellExecute = true
            };
            p.Start();
            
        }

        //Inserta los titulos de cada Serie en el pdf
        public PdfPTable AgregarTablaSerie(string Serie, string Marca, string Modelo)
        {
            iTextSharp.text.Font fontParapraghBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            PdfPTable tblSerie = new PdfPTable(3) { HorizontalAlignment = Element.ALIGN_LEFT, WidthPercentage = 80,PaddingTop = 10f };

            PdfPCell clSerie = new PdfPCell(new Phrase(Serie, fontParapraghBold)) { BorderWidth = .5f };

            PdfPCell clMarca = new PdfPCell(new Phrase(Marca, fontParapraghBold)) { BorderWidth = .5f };

            PdfPCell clModelo = new PdfPCell(new Phrase(Modelo, fontParapraghBold)) { BorderWidth = .5f };

            tblSerie.AddCell(clSerie);
            tblSerie.AddCell(clMarca);
            tblSerie.AddCell(clModelo);
            return tblSerie;
        }

        public void ImprimirInventario()
        {
            //Primero obtenemos de la base de datos nuestro inventario 
            SqlDataReader Inventario;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarInventario";
            comando.CommandType = CommandType.StoredProcedure;
            Inventario = comando.ExecuteReader();

            //string NombreArchivo = @"C:\Users\Cobranza\Documents\Reportes\" + "ReporteServicio" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            string NombreArchivo = @"C:\Users\DELL PC\Documents\Base de datos\" + "Inventario" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";
            //string NombreArchivo = @"\\administracion-pc\ARCHIVOS COMPARTIDOS\Reportes\Inventario\" + "Reporte" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            FileStream fs = new FileStream(NombreArchivo, FileMode.Create);
            Document document = new Document(PageSize.LETTER);
            document.SetMargins(25f, 25f, 25f, 25f);
            document.SetPageSize(iTextSharp.text.PageSize.LETTER);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            document.Open();
            //Fuentes 
            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontParapragh = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fontParapraghBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font fontFecha = FontFactory.GetFont("arial", 9);

            Paragraph titulo = new Paragraph("EXISTENCIAS CARTUCHOS SPEED TONER", fontTitle);
            titulo.Alignment = Element.ALIGN_CENTER;
            document.Add(titulo);

            //Colocamos la imagen para gasolinas de los carros
            iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance(Properties.Resources.TanquesGasolina, System.Drawing.Imaging.ImageFormat.Png);
            Logo.ScaleToFit(350, 250);
            Logo.Alignment = iTextSharp.text.Image.UNDERLYING;
            Logo.SetAbsolutePosition(document.LeftMargin, document.Top - 65);
            document.Add(Logo);

            Paragraph Fecha = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), fontFecha) { Alignment = Element.ALIGN_RIGHT };
            document.Add(Fecha);

            Paragraph Hora = new Paragraph("Hora: " + DateTime.Now.ToString("hh:mm:ss tt"), fontFecha) { Alignment = Element.ALIGN_RIGHT };
            document.Add(Hora);


            PdfPTable tblInventario = new PdfPTable(3);
            //tblInventario.WidthPercentage = 100;
            document.Add(new Paragraph("\n"));
            PdfPCell clModelo = new PdfPCell(new Phrase("MODELO", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };
            PdfPCell clCantidadOficina = new PdfPCell(new Phrase("CANTIDAD OFICINA", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };
            PdfPCell clCantidadBodega = new PdfPCell(new Phrase("CANTIDAD BODEGA", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };

            tblInventario.AddCell(clModelo);
            tblInventario.AddCell(clCantidadOficina);
            tblInventario.AddCell(clCantidadBodega);

            while (Inventario.Read())
            {
                PdfPCell clModeloDato = new PdfPCell(new Phrase(Inventario[1].ToString() + " " + Inventario[2].ToString(), fontParapragh)) { BorderWidth = .5f, Colspan = 1 };
                PdfPCell clCantidadOficinaDato = new PdfPCell(new Phrase(Inventario[3].ToString(), fontParapragh)) { BorderWidth = .5f, Colspan = 1 };
                PdfPCell clCantidadBodegaDato = new PdfPCell(new Phrase(Inventario[4].ToString(), fontParapragh)) { BorderWidth = .5f, Colspan = 1 };

                tblInventario.AddCell(clModeloDato);
                tblInventario.AddCell(clCantidadOficinaDato);
                tblInventario.AddCell(clCantidadBodegaDato);
            }
            //Añadimos la tabla al documento
            document.Add(tblInventario);
            document.Close();

            //Abrimos el pdf 
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(NombreArchivo)
            {
                UseShellExecute = true
            };
            p.Start();
            conexion.CerrarConexion();
        }

        public void GenerarReporteEquipos(SqlDataReader leer, string TipoBusqueda, string ParametroBusqueda)
        {
            //string NombreArchivo = @"\\administracion-pc\ARCHIVOS COMPARTIDOS\Reportes\Equipos\" + "ReporteEquipos" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            string NombreArchivo = @"C:\Users\DELL PC\Documents\Base de datos\" + "ReporteEquipos" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            SaveFileDialog guardar = new SaveFileDialog();
            //Lista de las series para evitar que se repitan las series en algunas consultas
            FileStream fs = new FileStream(NombreArchivo, FileMode.Create);
            Document document = new Document(PageSize.LETTER);
            document.SetMargins(25f, 25f, 25f, 25f);
            //Colocamos el pdf en horizontal
            document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            //Variables para controlar las vistas del pdf 
            bool pCliente = true;
            bool pMarca = true;
            bool pModelo = true;
            //Nos ayudara a verificar si lo titulos ya fueron colocados una sola vez
            bool titulosListos = true;
            //Variable para controlar cuando se eligan modelos, y no s equiera colocar su columna en las tablas, por lo que la serie abarcara lo de 2 celdas
            int tamañoCeldaSerie = 0;

            var pe = new PageEventHelperEquipos();
            pw.PageEvent = pe;

            document.Open();

            //TIPO DE FUENTE
            //Variable para definir tipo de fuente normal
            iTextSharp.text.Font fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontParapragh = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //Fuente para los parrafos en negritas
            iTextSharp.text.Font fontParapraghBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontFecha = FontFactory.GetFont("arial", 9);

            ColocarFormatosSuperiores(document, fontTitulo);

            Paragraph titulo = new Paragraph("REPORTE EQUIPOS " + TipoBusqueda.ToUpper(), fontTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;

            document.Add(titulo);

            Equipos = new PdfPTable(5);
            Equipos.WidthPercentage = 100;

            switch (TipoBusqueda)
            {
                case "Cliente": pCliente = false; ; break;//Para no mostrar los clientes en el reporte
                case "Marca":; pMarca = false; break;//Para no mostrar las marcas
                case "Modelo":; pModelo = false; pMarca = false; tamañoCeldaSerie = 2; break;//No mostraremos los modelos, ni las marcas y la serie abarcara 2 celdas
            }
            Paragraph Busqueda = new Paragraph(TipoBusqueda.ToUpper() + ": " + ParametroBusqueda, fontParapraghBold);
            Busqueda.Alignment = Element.ALIGN_CENTER;
            document.Add(Busqueda);

            iTextSharp.text.pdf.draw.LineSeparator lineSeparator = new iTextSharp.text.pdf.draw.LineSeparator();
            lineSeparator.Offset = 1f;
            document.Add(new Chunk(lineSeparator));

            while (leer.Read())
            {
                //En dado caso de no estar generando por cliente
                if (pCliente)
                {
                    //Entonces la añadimos a la lista, esto para evitar repetir el cliente, y abjuntar todos los registros de dicho cliente
                    AñadirLista(TipoBusqueda, leer[1].ToString(), fontParapragh);
                }
                //En dado caso de no estar generando por marca
                if (pMarca)
                {
                    //Las añadimos a la lista para evitar de igual forma que se repita la marca
                    AñadirLista(TipoBusqueda, leer[3].ToString(), fontParapragh);
                }

                PdfPCell clSerie = new PdfPCell(new Phrase(leer[5].ToString(), fontParapragh)) { BorderWidth = .5f, Padding = 2 };

                PdfPCell clModelo;
                //Si no estamos en generando por modelo 
                if (pModelo)
                {
                    if (titulosListos)
                    {
                        ColocarTitulosTablaEquipos(tamañoCeldaSerie, fontParapraghBold);
                        titulosListos = false;
                    }
                    //Mostramos los modelos de manera normal
                    clModelo = new PdfPCell(new Phrase(leer[4].ToString(), fontParapragh)) { BorderWidth = .5f, Padding = 2 };
                    Equipos.AddCell(clModelo);
                }
                else//Si no, quiere decir que estamos generando reporte por modelo
                {
                    //En el cual no queremos que se muestre el modelo, por lo cual la serie abarcara dos espacios para cubrir ese hueco que quedaria en la tabla
                    clSerie.Colspan = 2;
                    if (titulosListos)
                    {
                        ColocarTitulosTablaEquipos(tamañoCeldaSerie, fontParapraghBold);
                        titulosListos = false;
                    }
                }

                Equipos.AddCell(clSerie);

                PdfPCell TipoPago = new PdfPCell(new Phrase(leer[6].ToString(), fontParapragh)) { BorderWidth = .5f, Padding = 2 };

                PdfPCell clCosto = new PdfPCell(new Phrase("$" + String.Format("{0:n0}", double.Parse(leer[7].ToString())), fontParapragh)) { BorderWidth = .5f, Padding = 2 };

                PdfPCell clFechaPago = new PdfPCell(new Phrase(leer[8].ToString(), fontParapragh)) { BorderWidth = .5f, Padding = 2 };

                Equipos.AddCell(TipoPago);
                Equipos.AddCell(clCosto);
                Equipos.AddCell(clFechaPago);
            }
            //Añadimos la tabla al documento
            document.Add(Equipos);

            document.Close();
            Parametros.Clear();

            //Abrimos el pdf 
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(NombreArchivo)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        public void AñadirLista(string TipoBusqueda, string Parametro, iTextSharp.text.Font fontParapragh)
        {
            bool NuevoParametro = false;
            string titulo = "";
            PdfPCell nuevaCelda;
            //Para saber que titulo tendra cada registro por si es cliente o marca
            switch (TipoBusqueda)
            {
                case "Cliente": titulo = "Marca: "; break;
                case "Marca": titulo = "Cliente: "; break;
            }
            //Comprobamos que sea el primer registro
            if (!Parametros.Any())
            {
                nuevaCelda = new PdfPCell(new Phrase(titulo + Parametro, fontParapragh)) { BorderWidth = 0, Colspan = 5};
                //Agregamos en este caso al cliente a la lista
                Parametros.Add(Parametro);
                Equipos.AddCell(nuevaCelda);

            }
            else
            {
                bool parametroExistente = Parametros.Contains(Parametro);
                if (parametroExistente == false)
                {
                    nuevaCelda = new PdfPCell(new Phrase(titulo + Parametro, fontParapragh)) { BorderWidth = 0, Colspan = 5 };
                    //Agregamos en este caso al cliente a la lista
                    Parametros.Add(Parametro);
                    Equipos.AddCell(nuevaCelda);
                }
            }

        }

        public void ColocarTitulosTablaEquipos(int cspan, iTextSharp.text.Font fontParapragh)
        {
            if (cspan == 0)
            {
                PdfPCell Modelo = new PdfPCell(new Phrase("Modelo", fontParapragh)) { BorderWidth = .5f,Padding = 2};
                Equipos.AddCell(Modelo);
            }
            PdfPCell cltSerie = new PdfPCell(new Phrase("Serie", fontParapragh)) { BorderWidth = .5f, Padding = 2,Colspan = cspan};
            PdfPCell cltTipoRenta = new PdfPCell(new Phrase("Tipo Renta", fontParapragh)) { BorderWidth = .5f, Padding = 2 };
            PdfPCell cltCosto = new PdfPCell(new Phrase("Precio", fontParapragh)) { BorderWidth = .5f, Padding = 2 };
            PdfPCell clFechaRenta = new PdfPCell(new Phrase("Fecha Renta", fontParapragh)) { BorderWidth = .5f, Padding = 2 };

            Equipos.AddCell(cltSerie);
            Equipos.AddCell(cltTipoRenta);
            Equipos.AddCell(cltCosto);
            Equipos.AddCell(clFechaRenta);
        }

        //Nos ayudara a extraer la información dependiendo los parametros que le pasemos y las condiciones que se cumplan en el mismo
        public void ReporteFusores(string Parametro, DateTime FechaInicio, DateTime FechaFinal, string Serie)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ReporteFusores";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Garantia", Parametro);
            comando.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
            comando.Parameters.AddWithValue("@Serie", Serie);
            leer = comando.ExecuteReader();//Guardamos la informacion obtenida, para posteriormente ir mostrandola en el pdf
            GenerarReporteFusores(leer, Parametro, FechaInicio, FechaFinal, Serie);
            comando.Parameters.Clear();
        }

        public void GenerarReporteFusores(SqlDataReader leer, string Parametro, DateTime FechaInicio, DateTime FechaFinal, string Serie)
        {
            //string NombreArchivo = @"\\administracion-pc\ARCHIVOS COMPARTIDOS\Reportes\Fusores" + "ReporteFusores" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            string NombreArchivo = @"C:\Users\DELL PC\Documents\Base de datos\" + "ReporteFusores" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            //Lista de las series para evitar que se repitan las series en algunas consultas
            FileStream fs = new FileStream(NombreArchivo, FileMode.Create);
            Document document = new Document(PageSize.LETTER);
            document.SetMargins(25f, 25f, 25f, 25f);
            //Colocamos el pdf en horizontal
            document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            //Variable que servira para que dependiendo lo que eliga el usuario, una columna abarque dos espacios, ya que una columna en especifico no aparecera
            int colspanSerie = 1;

            //Instanciamos para que podamos obtener los indices de cada hoja
            var pe = new PageEventHelperEquipos();
            pw.PageEvent = pe;

            document.Open();

            //TIPO DE FUENTE
            //Variable para definir tipo de fuente normal
            iTextSharp.text.Font fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontParapragh = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //Fuente para los parrafos en negritas
            iTextSharp.text.Font fontParapraghBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font fontFecha = FontFactory.GetFont("arial", 11);

            ColocarFormatosSuperiores(document, fontTitulo);

            Paragraph titulo = new Paragraph("REPORTE FUSORES GARANTIA " + Parametro.ToUpper() + " " + Serie.ToUpper(), fontTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            document.Add(titulo);

            document.Add(new Chunk());
            switch (Parametro)
            {
                case "Habilitado":
                    colspanSerie = 1
                        ; break;
                case "Deshabilitada": colspanSerie = 2; break;
                case "Rango Fecha":
                    Paragraph RangoFechas = new Paragraph("Fecha Inicial: " + string.Format("{0:d}", FechaInicio) + "    Fecha Final: " + string.Format("{0:d}", FechaFinal), fontFecha) { Alignment = Element.ALIGN_CENTER };
                    document.Add(RangoFechas);
                    document.Add(new Chunk());
                    ; break;
                case "Serie": colspanSerie = 2; break;
            }

            PdfPTable Fusores = new PdfPTable(7);
            Fusores.WidthPercentage = 100;

            PdfPCell cltSerie = new PdfPCell(new Phrase("Serie", fontParapraghBold)) { BorderWidth = .5f, Colspan = colspanSerie };
            Fusores.AddCell(cltSerie);
            if (Parametro != "Serie")
            {
                PdfPCell cltSerieSp = new PdfPCell(new Phrase("Serie Sp", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };
                Fusores.AddCell(cltSerieSp);
            }
            PdfPCell cltFactura = new PdfPCell(new Phrase("#Factura", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };
            PdfPCell cltFechaFactura = new PdfPCell(new Phrase("FechaFactura", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };
            PdfPCell cltPrecio = new PdfPCell(new Phrase("Precio", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };


            Fusores.AddCell(cltFactura);
            Fusores.AddCell(cltFechaFactura);
            Fusores.AddCell(cltPrecio);
            //Solo se añadira la columna dias restantes en dado caso de que sea diferente de fusores deshabilitados
            if (Parametro != "Deshabilitada")
            {
                PdfPCell cltDiasRestantes = new PdfPCell(new Phrase("Dias Restantes", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };
                Fusores.AddCell(cltDiasRestantes);
            }
            PdfPCell cltUbicacion = new PdfPCell(new Phrase("Ubicacion", fontParapraghBold)) { BorderWidth = .5f, Colspan = 1 };



            Fusores.AddCell(cltUbicacion);
            while (leer.Read())
            {
                PdfPCell clSerie = new PdfPCell(new Phrase(leer[1].ToString(), fontParapragh)) { BorderWidth = .5f, Colspan = colspanSerie };
                Fusores.AddCell(clSerie);
                //Solo se mostrara en dado caso de que no estemos generando reporte por el numero de serie
                if (Parametro != "Serie")
                {
                    PdfPCell clSerieSp = new PdfPCell(new Phrase(leer[2].ToString(), fontParapragh)) { BorderWidth = .5f, Colspan = 1 };
                    Fusores.AddCell(clSerieSp);
                }

                PdfPCell clFactura = new PdfPCell(new Phrase(leer[3].ToString(), fontParapragh)) { BorderWidth = .5f, Colspan = 1 };
                PdfPCell clFechaFactura = new PdfPCell(new Phrase(string.Format("{0:d}", leer[4]), fontParapragh)) { BorderWidth = .5f, Colspan = 1 };
                PdfPCell clPrecio = new PdfPCell(new Phrase(leer[6].ToString(), fontParapragh)) { BorderWidth = .5f, Colspan = 1 };

                Fusores.AddCell(clFactura);
                Fusores.AddCell(clFechaFactura);
                Fusores.AddCell(clPrecio);
                //Solo se mostraran los dias restantes en dado caso de que no estemos generando reporte por fusores deshabilitados
                if (Parametro != "Deshabilitada")
                {
                    PdfPCell clDiasRestantes = new PdfPCell(new Phrase(leer[5].ToString(), fontParapragh)) { BorderWidth = .5f };
                    Fusores.AddCell(clDiasRestantes);
                }

                PdfPCell clUbicacion = new PdfPCell(new Phrase(leer[8].ToString(), fontParapragh)) { BorderWidth = .5f };

                Fusores.AddCell(clUbicacion);
            }
            document.Add(Fusores);
            leer.Close();
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

        #region Fusores
        public void AgregarFusor(string NumeroSerie, string NumeroSerieSp, string NumeroFactura, DateTime FechaFactura, string Costo, string DiasGarantia, string Ubicacion, DateTime FechaInstalacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarFusor";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NumeroSerieO", NumeroSerie);
            comando.Parameters.AddWithValue("@NumeroSerieS", NumeroSerieSp);
            comando.Parameters.AddWithValue("@NumeroFactura", NumeroFactura);
            comando.Parameters.AddWithValue("@FechaFactura", FechaFactura);
            comando.Parameters.AddWithValue("@Costo", double.Parse(Costo));
            comando.Parameters.AddWithValue("@DiasGarantia", DiasGarantia);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.Parameters.AddWithValue("@FechaInstalacion", FechaInstalacion);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarFusor(int Id, string NumeroSerie, string NumeroSerieSp, string NumeroFactura, DateTime FechaFactura, string Costo, string DiasGarantia, string Ubicacion, DateTime FechaInstalacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarFusor";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@NumeroSerieO", NumeroSerie);
            comando.Parameters.AddWithValue("@NumeroSerieS", NumeroSerieSp);
            comando.Parameters.AddWithValue("@NumeroFactura", NumeroFactura);
            comando.Parameters.AddWithValue("@FechaFactura", FechaFactura);
            comando.Parameters.AddWithValue("@Costo", double.Parse(Costo));
            comando.Parameters.AddWithValue("@DiasGarantia", DiasGarantia);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.Parameters.AddWithValue("@FechaInstalacion", FechaInstalacion);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        #endregion
    }
}
