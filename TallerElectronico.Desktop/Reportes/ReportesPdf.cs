using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using TallerElectronico.Entities;

using Font = iTextSharp.text.Font;

namespace TallerElectronico.Desktop.Reportes
{
    public static class ReportesPdf
    {
        public static void GenerarPDF(string rutaArchivo, ReparacionDTO rep)
        {
            Document doc = new Document(PageSize.LETTER, 36, 36, 36, 55);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));

            writer.PageEvent = new EventoPieDePaginaPdf();

            doc.Open();

            //definicion de variables para almacenar los colores
            BaseColor colorNegro = new BaseColor(30, 30, 30);
            BaseColor colorGrisOscuro = new BaseColor(80, 80, 80);
            BaseColor colorGrisLinea = new BaseColor(220, 220, 220);

            Font fLogo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, colorNegro);
            Font fHeaderRight = FontFactory.GetFont(FontFactory.HELVETICA, 9, colorGrisOscuro);
            Font fClienteTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, colorNegro);
            Font fClienteText = FontFactory.GetFont(FontFactory.HELVETICA, 9.5f, colorGrisOscuro);

            Font fTituloOrden = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, colorNegro);
            Font fMetaLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, colorNegro);
            Font fMetaValor = FontFactory.GetFont(FontFactory.HELVETICA, 9, colorGrisOscuro);

            Font fTableHead = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, colorNegro);
            Font fTableItemBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9.5f, colorNegro);
            Font fTableItemSub = FontFactory.GetFont(FontFactory.HELVETICA, 8.5f, colorGrisOscuro);
            Font fTableItemValue = FontFactory.GetFont(FontFactory.HELVETICA, 9.5f, colorNegro);

            Font fTotalBoldLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, colorNegro);
            Font fTotalBoldValue = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, colorNegro);

            // encabezado
            PdfPTable tblTop = new PdfPTable(2) { WidthPercentage = 100 };
            tblTop.SetWidths(new float[] { 50f, 50f });

            PdfPCell cellLogo = new PdfPCell(new Phrase("TALLER ELECTRÓNICO", fLogo))
            {
                Border = PdfPCell.NO_BORDER,
                VerticalAlignment = Element.ALIGN_TOP
            };

            string infoTaller = "Taller Electrónico S.A. de C.V.\n" +
                                "Tel: +503 7550-8477\n" +
                                "soportetallerelectronico@gmail.com\n";

            PdfPCell cellTallerInfo = new PdfPCell(new Phrase(infoTaller, fHeaderRight))
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_TOP
            };

            tblTop.AddCell(cellLogo);
            tblTop.AddCell(cellTallerInfo);
            doc.Add(tblTop);

            doc.Add(new Paragraph("\n"));

            // datos del cliente
            PdfPTable tblCliente = new PdfPTable(2) { WidthPercentage = 100 };
            tblCliente.SetWidths(new float[] { 50f, 50f });

            PdfPCell cellVacio = new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER };

            string datosClienteStr = $"{rep.ClienteNombre}\n" +
                                     $"Estado de orden: {rep.EstadoNombre}\n" +
                                     $"Técnico: {(string.IsNullOrWhiteSpace(rep.TecnicoNombre) ? "Sin Asignar" : rep.TecnicoNombre)}";

            PdfPCell cellCliente = new PdfPCell() { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT };
            cellCliente.AddElement(new Paragraph("CLIENTE / RECEPTOR", fClienteTitle) { Alignment = Element.ALIGN_RIGHT });
            cellCliente.AddElement(new Paragraph(datosClienteStr, fClienteText) { Alignment = Element.ALIGN_RIGHT });

            tblCliente.AddCell(cellVacio);
            tblCliente.AddCell(cellCliente);
            doc.Add(tblCliente);

            doc.Add(new Paragraph("\n"));

            //tituko y fechas
            doc.Add(new Paragraph($"Orden de Reparación {rep.CodigoSeguimiento}", fTituloOrden));
            doc.Add(new Paragraph(" "));

            PdfPTable tblFechas = new PdfPTable(2) { WidthPercentage = 100 };
            tblFechas.SetWidths(new float[] { 50f, 50f });

            string fechaIngreso = rep.FechaIngreso.ToString("dd/MM/yyyy HH:mm");
            string fechaEntrega = rep.FechaEntrega.HasValue ? rep.FechaEntrega.Value.ToString("dd/MM/yyyy HH:mm") : "Pendiente de Entrega";

            Phrase pFechaIngreso = new Phrase();
            pFechaIngreso.Add(new Chunk("Fecha Ingreso:\n", fMetaLabel));
            pFechaIngreso.Add(new Chunk(fechaIngreso, fMetaValor));

            Phrase pFechaEntrega = new Phrase();
            pFechaEntrega.Add(new Chunk("Fecha Entrega:\n", fMetaLabel));
            pFechaEntrega.Add(new Chunk(fechaEntrega, fMetaValor));

            PdfPCell cFI = new PdfPCell(pFechaIngreso) { Border = PdfPCell.NO_BORDER };
            PdfPCell cFE = new PdfPCell(pFechaEntrega) { Border = PdfPCell.NO_BORDER };

            tblFechas.AddCell(cFI);
            tblFechas.AddCell(cFE);
            doc.Add(tblFechas);

            doc.Add(new Paragraph("\n"));

            // datos del equipo
            PdfPTable tblItems = new PdfPTable(3) { WidthPercentage = 100 };
            tblItems.SetWidths(new float[] { 70f, 15f, 15f });

            tblItems.AddCell(CrearHeaderTabla("DESCRIPCIÓN DEL EQUIPO Y SERVICIO", fTableHead, colorNegro, Element.ALIGN_LEFT));
            tblItems.AddCell(CrearHeaderTabla("MARCA", fTableHead, colorNegro, Element.ALIGN_CENTER));
            tblItems.AddCell(CrearHeaderTabla("MODELO", fTableHead, colorNegro, Element.ALIGN_CENTER));

            Phrase pEquipo = new Phrase();
            pEquipo.Add(new Chunk($"[{rep.TipoEquipoNombre}] {rep.EquipoCompleto}\n", fTableItemBold));
            pEquipo.Add(new Chunk("Recepción de equipo para revisión técnica y mantenimiento.", fTableItemSub));

            PdfPCell cEqDesc = new PdfPCell(pEquipo) { Border = Rectangle.BOTTOM_BORDER, BorderColor = colorGrisLinea, PaddingTop = 8, PaddingBottom = 8 };
            PdfPCell cEqMarca = new PdfPCell(new Phrase(rep.MarcaNombre, fTableItemValue)) { Border = Rectangle.BOTTOM_BORDER, BorderColor = colorGrisLinea, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8 };
            PdfPCell cEqModelo = new PdfPCell(new Phrase(rep.Modelo, fTableItemValue)) { Border = Rectangle.BOTTOM_BORDER, BorderColor = colorGrisLinea, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8 };

            tblItems.AddCell(cEqDesc);
            tblItems.AddCell(cEqMarca);
            tblItems.AddCell(cEqModelo);

            doc.Add(tblItems);

            PdfPTable tblLineaBottom1 = new PdfPTable(1) { WidthPercentage = 100 };
            PdfPCell cellLinea1 = new PdfPCell(new Phrase(""))
            {
                Border = Rectangle.TOP_BORDER,
                BorderWidthTop = 1.5f,
                BorderColorTop = colorNegro
            };
            tblLineaBottom1.AddCell(cellLinea1);
            doc.Add(tblLineaBottom1);

            doc.Add(new Paragraph("\n\n"));

            // detalle
            PdfPTable tblDetalles = new PdfPTable(4) { WidthPercentage = 100 };
            tblDetalles.SetWidths(new float[] { 12f, 54f, 17f, 17f });

            tblDetalles.AddCell(CrearHeaderTabla("CANT.", fTableHead, colorNegro, Element.ALIGN_CENTER));
            tblDetalles.AddCell(CrearHeaderTabla("DESCRIPCIÓN DEL DETALLE / REPUESTO", fTableHead, colorNegro, Element.ALIGN_LEFT));
            tblDetalles.AddCell(CrearHeaderTabla("PRECIO UNIT.", fTableHead, colorNegro, Element.ALIGN_RIGHT));
            tblDetalles.AddCell(CrearHeaderTabla("SUBTOTAL", fTableHead, colorNegro, Element.ALIGN_RIGHT));

            if (rep.CostoManoObra > 0)
            {
                tblDetalles.AddCell(CrearCeldaDetalle("1", fTableItemValue, Element.ALIGN_CENTER, colorGrisLinea));
                tblDetalles.AddCell(CrearCeldaDetalle("Mano de Obra / Servicio Técnico", fTableItemValue, Element.ALIGN_LEFT, colorGrisLinea));
                tblDetalles.AddCell(CrearCeldaDetalle($"$ {rep.CostoManoObra:N2}", fTableItemValue, Element.ALIGN_RIGHT, colorGrisLinea));
                tblDetalles.AddCell(CrearCeldaDetalle($"$ {rep.CostoManoObra:N2}", fTableItemValue, Element.ALIGN_RIGHT, colorGrisLinea));
            }

            doc.Add(tblDetalles);

            PdfPTable tblLineaBottom2 = new PdfPTable(1) { WidthPercentage = 100 };
            PdfPCell cellLinea2 = new PdfPCell(new Phrase(""))
            {
                Border = Rectangle.TOP_BORDER,
                BorderWidthTop = 1.5f,
                BorderColorTop = colorNegro
            };
            tblLineaBottom2.AddCell(cellLinea2);
            doc.Add(tblLineaBottom2);

            doc.Add(new Paragraph("\n"));

            // total
            PdfPTable tblTotales = new PdfPTable(3) { WidthPercentage = 100 };
            tblTotales.SetWidths(new float[] { 45f, 30f, 25f });

            AgregarFilaTotal(tblTotales, "Total Reparación", $"$ {rep.TotalReparacion:N2}", fTotalBoldLabel, fTotalBoldValue, colorNegro);

            doc.Add(tblTotales);

            doc.Add(new Paragraph("\n\n"));

            // seccion de notas
            Paragraph pNota1 = new Paragraph($"Código de seguimiento para consulta: {rep.CodigoSeguimiento}", fMetaValor);
            Paragraph pNota2 = new Paragraph("Garantía del servicio: 30 días a partir de la fecha de entrega.", fTableItemSub);

            doc.Add(pNota1);
            doc.Add(pNota2);

            doc.Close();
        }

        //metodos
        private static PdfPCell CrearHeaderTabla(string texto, Font fHead, BaseColor colorNegro, int alineacion)
        {
            return new PdfPCell(new Phrase(texto, fHead))
            {
                Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER,
                BorderWidthTop = 1.5f,
                BorderWidthBottom = 1.5f,
                BorderColorTop = colorNegro,
                BorderColorBottom = colorNegro,
                PaddingTop = 6,
                PaddingBottom = 6,
                HorizontalAlignment = alineacion
            };
        }

        private static PdfPCell CrearCeldaDetalle(string texto, Font font, int alineacion, BaseColor colorBorde)
        {
            return new PdfPCell(new Phrase(texto, font))
            {
                Border = Rectangle.BOTTOM_BORDER,
                BorderColor = colorBorde,
                PaddingTop = 6,
                PaddingBottom = 6,
                HorizontalAlignment = alineacion
            };
        }

        private static void AgregarFilaTotal(PdfPTable tblTotales, string etiqueta, string valor, Font fontLabel, Font fontValor, BaseColor colorNegro)
        {
            tblTotales.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

            PdfPCell cellLbl = new PdfPCell(new Phrase(etiqueta, fontLabel))
            {
                Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER,
                BorderColor = colorNegro,
                BorderWidthTop = 1f,
                BorderWidthBottom = 1.5f,
                PaddingTop = 5,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_LEFT
            };

            PdfPCell cellVal = new PdfPCell(new Phrase(valor, fontValor))
            {
                Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER,
                BorderColor = colorNegro,
                BorderWidthTop = 1f,
                BorderWidthBottom = 1.5f,
                PaddingTop = 5,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };

            tblTotales.AddCell(cellLbl);
            tblTotales.AddCell(cellVal);
        }
    }

    public class EventoPieDePaginaPdf : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            BaseColor colorNegro = new BaseColor(30, 30, 30);
            BaseColor colorGrisOscuro = new BaseColor(80, 80, 80);

            Font fFooterText = FontFactory.GetFont(FontFactory.HELVETICA, 8, colorGrisOscuro);
            Font fFooterPage = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, colorGrisOscuro);

            PdfPTable tblFooter = new PdfPTable(3) { WidthPercentage = 100 };
            tblFooter.SetWidths(new float[] { 40f, 50f, 10f });
            tblFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;

            PdfPCell cFoot1 = new PdfPCell(new Phrase("Tel: +503 7550-8477\nsoportetallerelectronico@gmail.com", fFooterText))
            {
                Border = Rectangle.TOP_BORDER,
                BorderWidthTop = 1.5f,
                BorderColorTop = colorNegro,
                PaddingTop = 6
            };

            PdfPCell cFoot2 = new PdfPCell(new Phrase("Taller Electrónico\nSonsonate, El Salvador", fFooterText))
            {
                Border = Rectangle.TOP_BORDER,
                BorderWidthTop = 1.5f,
                BorderColorTop = colorNegro,
                PaddingTop = 6
            };

            PdfPCell cFoot3 = new PdfPCell(new Phrase(writer.PageNumber.ToString(), fFooterPage))
            {
                Border = Rectangle.TOP_BORDER,
                BorderWidthTop = 1.5f,
                BorderColorTop = colorNegro,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_TOP,
                PaddingTop = 6
            };

            tblFooter.AddCell(cFoot1);
            tblFooter.AddCell(cFoot2);
            tblFooter.AddCell(cFoot3);

            tblFooter.WriteSelectedRows(0, -1, document.LeftMargin, 45, writer.DirectContent);
        }
    }
}