using System.Reflection.Metadata.Ecma335;

namespace PDFSigner.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }

    public class CompanyPutDTO
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }

    public class CompanyPostDTO
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }
}
