using AutoMapper;
using PDFSigner.Data.Entities;
using PDFSigner.DTOs;

namespace PDFSigner.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyPostDTO, Company>();
            CreateMap<CompanyPutDTO, Company>();
        }
    }
}
