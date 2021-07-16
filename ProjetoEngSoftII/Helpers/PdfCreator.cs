﻿using PdfSharp;
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
                var font = new XFont("Verdana", 14, XFontStyle.Bold);

                graphics.DrawImage(XImage.FromFile(pathImagemModelo), 0, 0);

                textFormatter.Alignment = XParagraphAlignment.Center;
                textFormatter.DrawString(vacinado.Nome, font, XBrushes.Black, new XRect(0, 50, page.Width, page.Height));

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
