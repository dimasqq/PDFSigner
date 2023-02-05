using PDFSigner.Data.Entities;
using PDFSigner.DTOs;

namespace PDFSigner.Data.Repositories.Interfaces
{
    public interface IDocumentRepository : IBaseRepository<Document>
    {
        Task<Document> SignAsync(int id);
        Task<CompanyDocument> AddSigner(int companyId, int documentId);
        Task<CompanyDocument> ViewDocument(int companyId, int documentId);
    }
}
