using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs;
using ResumeEntity = ResumeCraft.Domain.Entities;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {
            #region Resume List Mapping

            CreateMap<ResumeEntity.Resume, ResumeListDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.Name));

            #endregion

            #region Single Resume Mapping

            CreateMap<ResumeEntity.Resume, ResumeDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(dest => dest.SelectedTemplateId, opt => opt.MapFrom(x => x.ResumeTemplateId))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(x => x.PersonalDetail))
                .ForMember(dest => dest.Awards, opt => opt.MapFrom(x => x.Awards))
                .ForMember(dest => dest.Certifications, opt => opt.MapFrom(x => x.Certifications))
                .ForMember(dest => dest.CurricularActivities, opt => opt.MapFrom(x => x.CurricularActivities))
                .ForMember(dest => dest.Educations, opt => opt.MapFrom(x => x.Educations))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(x => x.Experiences))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(x => x.Interests))
                .ForMember(dest => dest.Projects, opt => opt.MapFrom(x => x.Projects))
                .ForMember(dest => dest.Publications, opt => opt.MapFrom(x => x.Publications))
                .ForMember(dest => dest.References, opt => opt.MapFrom(x => x.References))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(x => x.Skills));

            #endregion
        }
    }
}
