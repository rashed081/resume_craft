using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, EducationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.ResumeId, opt => opt.MapFrom(x => x.ResumeId))
                .ForMember(dest => dest.City, opt => opt.MapFrom(x => x.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(x => x.Country))
                .ForMember(dest => dest.FieldOfStudy, opt => opt.MapFrom(x => x.FieldOfStudy))
                .ForMember(dest => dest.Grade, opt => opt.MapFrom(x => x.Grade))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(x => x.EndDate))
                .ForMember(dest => dest.InstituteName, opt => opt.MapFrom(x => x.InstituteName));
        }
    }
}
