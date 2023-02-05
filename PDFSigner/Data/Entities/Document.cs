using PDFSigner.Data.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace PDFSigner.Data.Entities
{
    [Table("Document", Schema = "public")]
    public class Document : IDBEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("PdfFile")]
        [Required]
        public string FilePath { get; set; }
        public string DocumentURL { get; set; }
        public bool IsSigned { get; set; }
        public virtual ICollection<CompanyDocument> SignCompanies { get; set; }

    }
}
