using PDFSigner.DTOs;

namespace PDFSigner.Managers.Interfaces
{
    public interface ICompanyManager
    {
        Task<CompanyDTO> GetAsync(int id);
        Task<CompanyDTO> InsertAsync(CompanyPostDTO incomingRecord);
        Task<CompanyDTO> UpdateAsync(int id, CompanyPutDTO rec);
        Task DeleteAsync(int id);
    }
}
