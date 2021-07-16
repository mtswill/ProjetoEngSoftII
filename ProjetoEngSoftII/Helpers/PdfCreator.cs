using PdfSharp;
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
        private string pathImagemModelo = Directory.GetCurrentDirectory() + @"\Files\modelo_carteira_vacinacao_covid.png";

        public void CreatePdf(VacinadoPdfModel vacinado)
        {
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                page.Orientation = PageOrientation.Landscape;
                page.Height = "524";
                page.Width = "910";
                var graphics = XGraphics.FromPdfPage(page);
                var textFormatter = new XTextFormatter(graphics);
                var fontNome = new XFont("Verdana", 18, XFontStyle.Bold);
                var fontInfo = new XFont("Verdana", 18, XFontStyle.Regular);

                graphics.DrawImage(XImage.FromFile(pathImagemModelo), 0, 0);

                textFormatter.Alignment = XParagraphAlignment.Left;

                //nome
                textFormatter.DrawString(vacinado.Nome, fontNome, XBrushes.Black, new XRect(130, 141, page.Width, page.Height));

                //unidade - 1a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(145, 213, page.Width, page.Height));
                //unidade - 2a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(565, 213, page.Width, page.Height));

                //cnes - 1a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(107, 253, page.Width, page.Height));
                //cnes - 2a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(525, 253, page.Width, page.Height));

                //data - 1a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(107, 296, page.Width, page.Height));
                //data - 2a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(525, 296, page.Width, page.Height));
                
                //lote - 1a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(107, 339, page.Width, page.Height));
                //lote - 2a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(525, 339, page.Width, page.Height));
                
                //fabricante - 1a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(180, 382, page.Width, page.Height));
                //fabricante - 2a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(600, 382, page.Width, page.Height));
                
                //vacinador - 1a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(175, 425, page.Width, page.Height));
                //vacinador - 2a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(595, 425, page.Width, page.Height));
                
                //reg prof - 1a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(165, 468, page.Width, page.Height));
                //reg prof - 2a dose
                textFormatter.DrawString(vacinado.Nome, fontInfo, XBrushes.Black, new XRect(585, 468, page.Width, page.Height));

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
