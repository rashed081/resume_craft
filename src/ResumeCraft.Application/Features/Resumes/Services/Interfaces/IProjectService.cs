using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> AddProjectAsync(Guid resumeId, ProjectInputModel model);
        Task DeleteProjectAsync(Guid resumeId, Guid projectId);
        Task<IList<ProjectDTO>> GetAllProjectAsync(Guid resumeId);
        Task<ProjectDTO> UpdateProjectAsync(Guid resumeId, Guid projectIdToUpdate, ProjectInputModel model);
    }
}
