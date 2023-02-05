using PDFSigner.DTOs;

namespace PDFSigner.Managers.Interfaces
{
    public interface IDocumentManager
    {
        Task<DocumentDTO> GetAsync(int id);
        Task<DocumentDTO> InsertAsync(DocumentPostDTO incomingRecord);
        Task<DocumentDTO> UpdateAsync(int id, DocumentPutDTO rec);
        Task DeleteAsync(int id);
        Task<DocumentDTO> SignAsync(int id);
        Task<CompanyDocumentDTO> AddSigner(int companyId, int documentId);
        Task<CompanyDocumentDTO> ViewDocument(int companyId, int documentId);
    }
}
