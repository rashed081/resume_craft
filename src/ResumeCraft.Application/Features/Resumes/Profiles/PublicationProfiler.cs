using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class PublicationProfiler : Profile
    {
        public PublicationProfiler()
        {
            CreateMap<Publication, PublicationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.InstituteName, opt => opt.MapFrom(x => x.InstituteName))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(x => x.PublishedDate))
                .ForMember(dest => dest.PublishedUrl, opt => opt.MapFrom(x => x.PublishedUrl));
        }
    }
}
