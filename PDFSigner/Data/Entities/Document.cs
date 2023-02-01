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
        public byte[] PdfFile { get; set; }
    }
}
