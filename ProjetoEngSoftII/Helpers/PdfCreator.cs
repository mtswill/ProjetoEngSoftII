using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System.Diagnostics;

namespace ProjetoEngSoftII.Helpers
{
    public class PdfCreator
    {
        public void Teste()
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

                doc.Save("arquivo.pdf");
                Process.Start("arquivo.pdf");
            }
        }
    }
}
