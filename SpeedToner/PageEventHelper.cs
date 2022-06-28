
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace SpeedToner
{
    internal class PageEventHelper : PdfPageEventHelper
    {
        //Permite escribir sobre un documento ya existente
        PdfContentByte cb;
        PdfTemplate template;

        //Por si queremos agregar alguna fuente
        BaseFont bf = null;
        BaseFont title = null;
        //Para añadir la fecha de impresion
        DateTime PrintTime = DateTime.Now;
        iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);


        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

        #region Propiedades

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _HeaderLeft;
        public string HeaderLeft
        {
            get { return _HeaderLeft; }
            set { _HeaderLeft = value; }
        }

        private string _HeaderRight;
        public string HeaderRight
        {
            get { return _HeaderRight; }
            set { _HeaderRight = value; }
        }

        //Para definir la fuente del encabezado
        private iTextSharp.text.Font _HeaderFont;
        public iTextSharp.text.Font HeaderFont
        {
            get { return _HeaderFont; }
            set { _HeaderFont = value; }
        }

        //Para definir la fuente del pie de pagina
        private iTextSharp.text.Font _FooterFont;
        public iTextSharp.text.Font FooterFont
        {
            get { return _FooterFont; }
            set { _FooterFont = value; }
        }

        #endregion

        public override void OnOpenDocument(PdfWriter writer, Document  document)
        {
            try
            {
                PrintTime = DateTime.Now;
                //Fuente que se utilizara en la clase

                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                title = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                //Para poder agregar contenido
                cb = writer.DirectContent;
                //Sirve como canvas 
                template = cb.CreateTemplate(document.PageSize.Width, 50);

            }catch (DocumentException de){

            }
            catch(System.IO.IOException ioe){

            }
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            iTextSharp.text.Rectangle pagesize = document.PageSize;

            //Agregamos el logo izquierdo
            iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoSpeedToner, System.Drawing.Imaging.ImageFormat.Png);
            Logo.ScaleToFit(150, 80);
            //Logo.ScaleToFit(100, 80);
            Logo.Alignment = iTextSharp.text.Image.UNDERLYING;
            Logo.SetAbsolutePosition(document.LeftMargin, document.Top - 50);
            cb.AddImage(Logo);

            //Agregamos el logo de la derecha
            iTextSharp.text.Image Logotipo = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoSpeedToner, System.Drawing.Imaging.ImageFormat.Png);
            Logotipo.ScaleToFit(150, 80);
            //Logotipo.ScaleToFit(100, 80);
            Logotipo.Alignment = iTextSharp.text.Image.UNDERLYING;
            Logotipo.SetAbsolutePosition(document.Right - 150, document.Top - 50);
            //Logotipo.SetAbsolutePosition(document.Right - 100, document.Top - 50);
            cb.AddImage(Logotipo);

            Paragraph NombreEmpresa = new Paragraph("SPEDD TONER NUEVO LAREDO.", fontTitle);
            NombreEmpresa.Alignment = Element.ALIGN_CENTER;
            NombreEmpresa.
            document.Add(NombreEmpresa);

            Paragraph Telefono = new Paragraph("TEL.: (867) 712-0964 FAX:(867)712-2741", font);
            Telefono.Alignment = Element.ALIGN_CENTER;
            document.Add(Telefono);

            Paragraph Direccion = new Paragraph("BOLIVAR #1507 NUEVO LAREDO, TAMPS. C.P 88060", font);
            Direccion.Alignment = Element.ALIGN_CENTER;
            document.Add(Direccion);

            

        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            //Obtenemos la pagina actual
            int pageN = writer.PageNumber;
            String text = "Page " + pageN;
            //Tamaño del texto
            float len = bf.GetWidthPoint(text, 8);
            //Creamos rectangulo del tamaño de la pagina
            iTextSharp.text.Rectangle pagesize = document.PageSize;
            cb.SetRGBColorFill(100, 100, 100);
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pagesize.GetLeft(40), pagesize.GetBottom(20));
            cb.ShowText(text);
            cb.EndText();
            //Definimos otra platilla 
            cb.AddTemplate(template, pagesize.GetLeft(40) + len, pagesize.GetBottom(30));

            //Imprime la hora en la que fue impreso
            //Opcional
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                "Printed On " + PrintTime.ToString(),
                pagesize.GetRight(40),
                pagesize.GetBottom(20), 0);
            cb.EndText();
            document.Add(new Chunk());
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.BeginText();
            template.SetFontAndSize(bf, 8);
            template.SetTextMatrix(0, 0);
            //template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }
}
