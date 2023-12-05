using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ExperienceService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<ExperienceDTO>> GetListAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Experiences);

            return _mapper.Map<IList<ExperienceDTO>>(resume?.Experiences);
        }

        public async Task<ExperienceDTO> AddAsync(Guid resumeId, ExperienceInputModel model)
        {
            var resume =
                await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Experiences)
                ?? throw new ArgumentNullException("Resume doesn't exist");

            var experience = new Experience
            {
                CompanyName = model.CompanyName,
                Designation = model.Designation,
                Achievement = model.Achievement,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };

            resume?.Experiences.Add(experience);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ExperienceDTO>(experience);
        }

        public async Task DeleteAsync(Guid resumeId, Guid experienceId)
        {
            var resume =
                await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Experiences)
                ?? throw new ArgumentNullException("Resume doesn't exist");

            var deleteExperience = resume?.Experiences.FirstOrDefault(x => x.Id == experienceId);
            if (deleteExperience is null)
            {
                return;
            }

            resume?.Experiences?.Remove(deleteExperience);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ExperienceDTO> UpdateAsync(Guid resumeId, Guid experienceId, ExperienceInputModel model)
        {
            var resume =
                await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Experiences)
                ?? throw new ArgumentNullException("Resume doesn't exist");

            var updateExperience =
                (resume?.Experiences.FirstOrDefault(y => y.Id == experienceId)) ?? throw new ArgumentNullException("Experience info is not valid");

            updateExperience.CompanyName = model.CompanyName;
            updateExperience.Designation = model.Designation;
            updateExperience.Achievement = model.Achievement;
            updateExperience.StartDate = model.StartDate;
            updateExperience.EndDate = model.EndDate;

            await _unitOfWork.SaveAsync();
            return _mapper.Map<ExperienceDTO>(updateExperience);
        }
    }
}
