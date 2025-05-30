using Back.Dtos;
using Back.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
namespace Back.Services;
public class PdfService : IPdfService
{
    public byte[] GeneratePdf(GetTicketDTO ticket)
    {
        var pdf = new PdfDocument();
        var page = pdf.AddPage();

        page.Size = PdfSharpCore.PageSize.A4;

        using var gfx = XGraphics.FromPdfPage(page);

        var backgroundBrush = new XSolidBrush(XColor.FromArgb(0x1e, 0x1e, 0x1e));
        gfx.DrawRectangle(backgroundBrush, 0, 0, page.Width, page.Height);

        double rectWidth = 400;
        double rectHeight = 250;
        double rectX = (page.Width - rectWidth) / 2;
        double rectY = (page.Height - rectHeight) / 2;

        var shadowBrush = new XSolidBrush(XColor.FromArgb(64, 0, 0, 0)); // полупрозрачный черный
        gfx.DrawRoundedRectangle(shadowBrush, rectX + 5, rectY + 5, rectWidth, rectHeight, 10, 10);

        var whiteBrush = XBrushes.White;
        gfx.DrawRoundedRectangle(whiteBrush, rectX, rectY, rectWidth, rectHeight, 10, 10);

        var fontTitle = new XFont("Arial", 20, XFontStyle.Bold);
        var fontText = new XFont("Arial", 16, XFontStyle.Regular);
        var fontLabel = new XFont("Arial", 16, XFontStyle.Bold);

        double lineHeight = 30;
        double padding = 30;

        double textX = rectX + padding;
        double textY = rectY + padding;

        gfx.DrawString("Талон для записи к врачу", fontTitle, XBrushes.Black, new XRect(textX, textY, rectWidth - 2 * padding, lineHeight), XStringFormats.TopLeft);
        textY += lineHeight + 10;

        void DrawLine(string label, string value)
        {
            gfx.DrawString(label, fontLabel, XBrushes.Black, new XPoint(textX, textY));
            gfx.DrawString(value, fontText, XBrushes.Black, new XPoint(textX + 150, textY));
            textY += lineHeight;
        }

        DrawLine("ФИО пациента:", ticket.FIO);
        DrawLine("Врач:", ticket.Doctor);
        DrawLine("Специальность:", ticket.SpecializationName);
        DrawLine("Дата:", ticket.Date.ToString("dd.MM.yyyy"));
        DrawLine("Время:", ticket.Time.ToString(@"hh\:mm"));
        DrawLine("Кабинет:", ticket.Cabinet.ToString());

        using var ms = new MemoryStream();
        pdf.Save(ms);
        return ms.ToArray();
    }
}