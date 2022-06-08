﻿
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
        //Para añadir la fecha de impresion
        DateTime PrintTime = DateTime.Now;

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
            iTextSharp.text.Rectangle pageSize = document.PageSize;

            if(Title != String.Empty)
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 15);//Tamaño 
                cb.SetRGBColorFill(50, 50, 200);//Color
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(40));//Definir la posicion
                cb.ShowText(Title);
                cb.EndText();
            }
            //Agregar texto a la izquierda o la derecha
            if(HeaderLeft + HeaderRight != String.Empty)
            {
                PdfPTable HeaderTable =  new PdfPTable(2);
                HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                HeaderTable.TotalWidth = pageSize.Width - 80;
                HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

                PdfPCell HeaderLeftCell = new PdfPCell(new Phrase(8, HeaderLeft,HeaderFont));
                HeaderLeftCell.Padding = 5;
                HeaderLeftCell.PaddingBottom = 8;
                HeaderLeftCell.BorderWidthRight = 0;
                HeaderTable.AddCell(HeaderLeftCell);

                PdfPCell HeaderRightCell = new PdfPCell(new Phrase(8, HeaderRight, HeaderFont));
                HeaderRightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                HeaderRightCell.Padding = 5;
                HeaderRightCell.PaddingBottom = 8;
                HeaderRightCell.BorderWidthRight = 0;
                HeaderTable.AddCell(HeaderRightCell);

                cb.SetRGBColorFill(0, 0, 0);
                HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(40), pageSize.GetTop(50), cb);
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            //Obtenemos la pagina actual
            int pageN = writer.PageNumber;
            String text = "Page " + pageN + " of ";
            //Tamaño del texto
            float len = bf.GetWidthPoint(text, 8);
            //Creamos rectangulo del tamaño de la pagina
            iTextSharp.text.Rectangle pagesize = document.PageSize;
            cb.SetRGBColorFill(100, 100, 100);
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pagesize.GetLeft(40), pagesize.GetBottom(30));
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
                pagesize.GetBottom(30), 0);
            cb.EndText();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.BeginText();
            template.SetFontAndSize(bf, 40);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }
}
