using PDFSigner.Data.Entities;
using PDFSigner.Data.Repositories.Interfaces;

namespace PDFSigner.Data.Repositories
{
    public class DocumentRepository : BaseRepository<Document, Context>, IDocumentRepository
    {
        public DocumentRepository(Context context) : base(context)
        {
        }
    }
}
