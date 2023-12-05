using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class PersonalDetailProfile : Profile
    {
        public PersonalDetailProfile()
        {
            CreateMap<PersonalDetail, PersonalDetailsDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(x => x.Address))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(x => x.DateOfBirth))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(x => x.ImageUrl))
                .ForMember(dest => dest.Socials, opt => opt.MapFrom(x => x.Socials));
        }
    }
}
