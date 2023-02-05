namespace PDFSigner.QRCode
{
    public interface IQRCodePlacer
    {
        public string GenerateQR(string text, string filename);
        public void PlaceQRToPdf(string qrpath, string pdfpath, string caption, Position layout);
    }
}
