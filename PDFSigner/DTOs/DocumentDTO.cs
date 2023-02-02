namespace PDFSigner.DTOs
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
    }

    public class DocumentPutDTO
    {
        public string FilePath { get; set; }
    }

    public class DocumentPostDTO
    {
        public string FilePath { get; set; }
    }
}
