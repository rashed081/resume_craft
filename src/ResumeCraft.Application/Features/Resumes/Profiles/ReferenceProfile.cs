using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class ReferenceProfile : Profile
    {
        public ReferenceProfile()
        {
            CreateMap<Reference, ReferenceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.SupervisorName, opt => opt.MapFrom(x => x.SupervisorName))
                .ForMember(dest => dest.SupervisorInstituteName, opt => opt.MapFrom(x => x.SupervisorInstituteName))
                .ForMember(dest => dest.SupervisorPhone, opt => opt.MapFrom(x => x.SupervisorPhone))
                .ForMember(dest => dest.SupervisorEmail, opt => opt.MapFrom(x => x.SupervisorEmail))
                .ForMember(dest => dest.SupervisorDesignation, opt => opt.MapFrom(x => x.SupervisorDesignation));
        }
    }
}
