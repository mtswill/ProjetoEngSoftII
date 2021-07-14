using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using ProjetoEngSoftII.Models.Pdf;
using System;
using System.IO;
using System.Reflection;

namespace ProjetoEngSoftII.Helpers
{
    public class PdfCreator
    {
        public void CreatePdf(VacinadoPdfModel vacinado)
        {
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                var graphics = XGraphics.FromPdfPage(page);
                var textFormatter = new XTextFormatter(graphics);
                var font = new XFont("Arial", 14, XFontStyle.BoldItalic);

                textFormatter.Alignment = XParagraphAlignment.Center;
                textFormatter.DrawString("Matheus Willian Polato", font, XBrushes.Black, new XRect(0, 50, page.Width, page.Height));

                graphics.DrawImage(XImage.FromFile(@"D:\foto.jpg"), 250, 300);

                var nomeArquivo = $"{vacinado.Cpf.RemovePontoEHifem()}.pdf";
                var path = Directory.GetCurrentDirectory() + @"\Files\" + nomeArquivo;

                try
                {
                    doc.Save(path);
                }
                catch { }
            }
        }
    }
}
