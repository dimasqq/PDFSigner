using AutoMapper;
using PDFSigner.Data.Entities;
using PDFSigner.DTOs;

namespace PDFSigner.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentDTO>();
            CreateMap<DocumentPutDTO, Document>();
            CreateMap<DocumentPostDTO, Document>();
        }
    }
}
