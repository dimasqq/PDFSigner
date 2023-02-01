using AutoMapper;
using PDFSigner.Data;
using PDFSigner.Data.Entities;
using PDFSigner.Data.Repositories;
using PDFSigner.Data.Repositories.Interfaces;
using PDFSigner.DTOs;
using PDFSigner.Managers.Interfaces;

namespace PDFSigner.Managers
{
    public class DocumentManager : BaseManager, IDocumentManager
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        public DocumentManager(Context context, IDocumentRepository documentRepository, IMapper mapper) : base(context, mapper)
        {
            this._documentRepository = documentRepository;
            this._mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            await _documentRepository.DeleteAsync(id);
            await SaveChangesAsync();
        }

        public async Task<DocumentDTO> GetAsync(int id)
        {
            var record = await _documentRepository.GetAsync(id);

            return _mapper.Map<DocumentDTO>(record);
        }

        public async Task<DocumentDTO> InsertAsync(DocumentPostDTO incomingRecord)
        {
            var mapped = _mapper.Map<Document>(incomingRecord);
            var inserted = await _documentRepository.InsertAsync(mapped);
            await SaveChangesAsync();
            return _mapper.Map<DocumentDTO>(inserted);
        }

        public async Task<DocumentDTO> UpdateAsync(int id, DocumentPutDTO incomingRecord)
        {
            var existing = await _documentRepository.GetAsync(id);
            var mapped = _mapper.Map(incomingRecord, existing);

            await _documentRepository.UpdateAsync(mapped);
            await SaveChangesAsync();

            return _mapper.Map<DocumentDTO>(mapped);
        }
    }
}
