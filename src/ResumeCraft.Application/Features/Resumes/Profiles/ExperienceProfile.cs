using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<Experience, ExperienceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(x => x.CompanyName))
                .ForMember(dest => dest.Designation, opt => opt.MapFrom(x => x.Designation))
                .ForMember(dest => dest.Achievement, opt => opt.MapFrom(x => x.Achievement))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(x => x.EndDate));
        }
    }
}
