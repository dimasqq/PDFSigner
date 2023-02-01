using AutoMapper;
using PDFSigner.Data;
using PDFSigner.Data.Entities;
using PDFSigner.Data.Repositories.Interfaces;
using PDFSigner.DTOs;
using PDFSigner.Managers.Interfaces;

namespace PDFSigner.Managers
{
    public class CompanyManager : BaseManager, ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyManager(Context context, ICompanyRepository companyRepository, IMapper mapper) : base(context, mapper)
        {
            this._companyRepository = companyRepository;
            this._mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            await _companyRepository.DeleteAsync(id);
            await SaveChangesAsync();
        }

        public async Task<CompanyDTO> GetAsync(int id)
        {
            var record = await _companyRepository.GetAsync(id);

            return _mapper.Map<CompanyDTO>(record);
        }

        public async Task<CompanyDTO> InsertAsync(CompanyPostDTO incomingRecord)
        {
            var mapped = _mapper.Map<Company>(incomingRecord);
            var inserted = await _companyRepository.InsertAsync(mapped);
            await SaveChangesAsync();
            return _mapper.Map<CompanyDTO>(inserted);
        }

        public async Task<CompanyDTO> UpdateAsync(int id, CompanyPutDTO incomingRecord)
        {
            var existing = await _companyRepository.GetAsync(id);
            var mapped = _mapper.Map(incomingRecord, existing);

            await _companyRepository.UpdateAsync(mapped);
            await SaveChangesAsync();

            return _mapper.Map<CompanyDTO>(mapped);
        }
    }
}
