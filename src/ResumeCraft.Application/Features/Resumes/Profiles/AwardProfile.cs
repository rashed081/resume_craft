using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class AwardProfile : Profile
    {
        public AwardProfile()
        {
            CreateMap<Award, AwardDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dest => dest.InstituteName, opt => opt.MapFrom(x => x.InstituteName));
        }
    }
}
