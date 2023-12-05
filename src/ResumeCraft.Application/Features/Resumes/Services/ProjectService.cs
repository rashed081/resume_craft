using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<ProjectDTO>> GetAllProjectAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Projects);
            var listOfProjects = resume?.Projects;

            return _mapper.Map<IList<ProjectDTO>>(listOfProjects);
        }

        public async Task<ProjectDTO> AddProjectAsync(Guid resumeId, ProjectInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Projects);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var projectToSave = new Project
            {
                ProjectName = model.ProjectName,
                Description = model.Description,
                RepositoryUrl = model.RepositoryUrl
            };

            resume?.Projects.Add(projectToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProjectDTO>(projectToSave);
        }

        public async Task DeleteProjectAsync(Guid resumeId, Guid projectId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Projects);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var projectToDelete = resume?.Projects.FirstOrDefault(y => y.Id == projectId);
            if (projectToDelete == null)
            {
                throw new ArgumentException("Project doesn't exist");
            }

            resume?.Projects?.Remove(projectToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ProjectDTO> UpdateProjectAsync(Guid resumeId, Guid projectIdToUpdate, ProjectInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Projects);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var projectToUpdate = resume?.Projects.FirstOrDefault(y => y.Id == projectIdToUpdate);
            if (projectToUpdate is null)
            {
                throw new ArgumentNullException("Project can not be found");
            }

            projectToUpdate.ProjectName = model.ProjectName;
            projectToUpdate.Description = model.Description;
            projectToUpdate.RepositoryUrl = model.RepositoryUrl;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProjectDTO>(projectToUpdate);
        }
    }
}
