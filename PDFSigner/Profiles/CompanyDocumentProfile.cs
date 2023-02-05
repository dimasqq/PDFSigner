using AutoMapper;
using PDFSigner.Data.Entities;
using PDFSigner.DTOs;

namespace PDFSigner.Profiles
{
    public class CompanyDocumentProfile : Profile
    {
        public CompanyDocumentProfile()
        {
            CreateMap<CompanyDocument, CompanyDocumentDTO>();
        }
    }
}
