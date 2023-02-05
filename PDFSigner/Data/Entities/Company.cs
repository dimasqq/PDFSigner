using PDFSigner.Data.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDFSigner.Data.Entities
{
    [Table("Company", Schema = "public")]
    public class Company : IDBEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        [MaxLength(200)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Column("PhoneNumber")]
        [MaxLength(16)]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Column("Details")]
        [MaxLength(200)]
        [Required]
        public string Details { get; set; } = string.Empty;
        public virtual ICollection<CompanyDocument> DocumentSigners { get; set; }

    }
}
