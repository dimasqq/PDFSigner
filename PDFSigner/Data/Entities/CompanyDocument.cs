using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PDFSigner.Data.Entities
{
    [Table("RLCompanyDocument")]
    public class CompanyDocument
    {
        [Key, Column(Order = 0)]
        public int CompanyId { get; set; }
        [Key, Column(Order = 1)]
        public int DocumentId { get; set; }

        public virtual Company SignCompany { get; set; }
        public virtual Document SignDocument { get; set; }

        public bool IsViewed { get; set; }
    }
}
