using AutoMapper;
using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Domain.Entities.CoverLetterInfo;

namespace ResumeCraft.Application.Features.CoverLetters.Profiler
{
    public class CoverLetterProfile : Profile
    {
        public CoverLetterProfile()
        {
            CreateMap<CoverLetter, CoverLetterDTO>()
                .ForMember(dest => dest.ToWhom, opt => opt.MapFrom(x => x.ToWhom))
                .ForMember(dest => dest.ApplyingDate, opt => opt.MapFrom(x => x.ApplyingDate))
                .ForMember(dest => dest.CompanyAddress, opt => opt.MapFrom(x => x.CompanyAddress))
                .ForMember(dest => dest.JobPosition, opt => opt.MapFrom(x => x.JobPosition))
                .ForMember(dest => dest.LetterContent, opt => opt.MapFrom(x => x.LetterContent))
                .ForMember(dest => dest.ApplicantsFullName, opt => opt.MapFrom(x => x.ApplicantsFullName))
                .ForMember(dest => dest.ApplicantsAddresss, opt => opt.MapFrom(x => x.ApplicantsAddresss));
        }
    }
}
