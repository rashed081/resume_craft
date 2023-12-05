using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(x => x.ProjectName))
                .ForMember(dest => dest.RepositoryUrl, opt => opt.MapFrom(x => x.RepositoryUrl))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description));
        }
    }
}
