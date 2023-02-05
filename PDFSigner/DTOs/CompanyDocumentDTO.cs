using PDFSigner.Data.Entities;

namespace PDFSigner.DTOs
{
    public class CompanyDocumentDTO
    {
        public int CompanyId { get; set; }
        public int DocumentId { get; set; }
        public bool IsViewed { get; set; }
    }
}
