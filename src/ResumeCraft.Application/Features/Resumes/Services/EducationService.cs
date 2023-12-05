using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class EducationService : IEducationService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<EducationDTO>> GetListOfEducationAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Educations);
            var listOfEducation = resume?.Educations;

            return _mapper.Map<IList<EducationDTO>>(listOfEducation);
        }

        public async Task<EducationDTO> AddIntoResumeAsync(Guid resumeId, EducationInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Educations);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var educationToSave = new Education
            {
                InstituteName = model.InstituteName,
                City = model.City,
                Country = model.Country,
                FieldOfStudy = model.FieldOfStudy,
                Grade = model.Grade,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };

            resume?.Educations.Add(educationToSave);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<EducationDTO>(resume?.Educations.LastOrDefault());
        }

        public async Task DeleteFromResumeAsync(Guid resumeId, Guid educationIdToDelete)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Educations);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var educationToDelete = resume?.Educations.FirstOrDefault(y => y.Id == educationIdToDelete);
            if (educationToDelete == null)
            {
                throw new ArgumentException("Education doesn't exist");
            }

            resume?.Educations?.Remove(educationToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<EducationDTO> UpdateEducationAsync(Guid resumeId, Guid educationIdToUpdate, EducationInputModel model)
        {
            if (model.Id is null)
            {
                throw new ArgumentException("Updating data does not have any identity");
            }

            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Educations);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var educationToUpdate = resume?.Educations.FirstOrDefault(y => y.Id == educationIdToUpdate);
            if (educationToUpdate is null)
            {
                throw new ArgumentNullException("Education data is not valid");
            }

            educationToUpdate.InstituteName = model.InstituteName;
            educationToUpdate.City = model.City;
            educationToUpdate.Country = model.Country;
            educationToUpdate.FieldOfStudy = model.FieldOfStudy;
            educationToUpdate.Grade = model.Grade;
            educationToUpdate.StartDate = model.StartDate;
            educationToUpdate.EndDate = model.EndDate;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<EducationDTO>(resume?.Educations.FirstOrDefault(y => y.Id == educationIdToUpdate));
        }
    }
}
