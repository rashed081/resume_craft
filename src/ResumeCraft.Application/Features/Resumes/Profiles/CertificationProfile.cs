using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class CertificationProfile : Profile
    {
        public CertificationProfile()
        {
            CreateMap<Certification, CertificationDTO>()
                .ForMember(dest => dest.InstituteName, opt => opt.MapFrom(x => x.InstituteName))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(x => x.EndDate))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id));
        }
    }
}
