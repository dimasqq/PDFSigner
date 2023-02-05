using QRCoder;
using System.DrawingCore.Imaging;
using System.DrawingCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf;

namespace PDFSigner.QRCode
{
    public class QRCodePlacer : IQRCodePlacer
    {
        private readonly XFont _font = new("Arial", 14, XFontStyle.Regular);

        public string GenerateQR(string text, string filename)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(filename, ImageFormat.Jpeg);
            return filename;
        }

        public void PlaceQRToPdf(string qrpath, string pdfpath, string caption, Position layout)
        {
            var qr = XImage.FromFile(qrpath);

            PdfDocument PDFDoc = PdfReader.Open(pdfpath, PdfDocumentOpenMode.Import);
            PdfDocument PDFQR = new();
            for (int Pg = 0; Pg < PDFDoc.Pages.Count; Pg++)
            {
                PDFQR.AddPage(PDFDoc.Pages[Pg]);
            }

            if (PDFQR.PageCount > 0)
            {
                var page = PDFQR.Pages[0];
                var gfx = XGraphics.FromPdfPage(page);
                var font = this._font;
                var xLayout = new XRect(layout.X, layout.Y, layout.Width, layout.Height);
                //var layout = new XRect(55, 690, 50, 0);
                gfx.DrawString(caption, font, XBrushes.Black, xLayout);
                gfx.DrawImage(qr, layout.X, layout.Y + 10, layout.Width + 50, layout.Height + 100);
                PDFQR.Save(pdfpath);
            }
        }
    }
}
