namespace PDFSigner.DTOs
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public byte[] PdfFile { get; set; }
    }

    public class DocumentPutDTO
    {
        public byte[] PdfFile { get; set; }
    }

    public class DocumentPostDTO
    {
        public byte[] PdfFile { get; set;}
    }
}
