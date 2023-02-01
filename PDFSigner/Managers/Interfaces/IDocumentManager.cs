using PDFSigner.DTOs;

namespace PDFSigner.Managers.Interfaces
{
    public interface IDocumentManager
    {
        Task<DocumentDTO> GetAsync(int id);
        Task<DocumentDTO> InsertAsync(DocumentPostDTO incomingRecord);
        Task<DocumentDTO> UpdateAsync(int id, DocumentPutDTO rec);
        Task DeleteAsync(int id);
    }
}
