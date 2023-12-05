using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class CurricularActivityProfile : Profile
    {
        public CurricularActivityProfile()
        {
            CreateMap<CurricularActivity, CurricularActivityDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dest => dest.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(x => x.EndDate));
        }
    }
}
