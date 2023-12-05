using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class SummaryProfile : Profile
    {
        public SummaryProfile()
        {
            CreateMap<Summary, SummaryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(x => x.Content));
        }
    }
}
