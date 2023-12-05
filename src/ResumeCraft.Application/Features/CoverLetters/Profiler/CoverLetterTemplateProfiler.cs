using AutoMapper;
using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Domain.Entities.CoverLetterInfo;

namespace ResumeCraft.Application.Features.CoverLetters.Profiler
{
    public class CoverLetterTemplateProfiler : Profile
    {
        public CoverLetterTemplateProfiler()
        {
            CreateMap<CoverLetterTemplate, CoverLetterTemplateDTO>()
                .ForMember(dest => dest.TemplateName, opt => opt.MapFrom(x => x.TemplateName))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(x => x.Path));
        }
    }
}
