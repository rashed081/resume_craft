using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.EnumCollections;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class SkillService : ISkillService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<SkillDTO>> GetListAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Skills);

            return _mapper.Map<IList<SkillDTO>>(resume?.Skills);
        }

        public async Task<SkillDTO> AddAsync(Guid resumeId, SkillInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Skills);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToSave = new Skill { Name = model.Name, Level = (Level)model.Level };

            resume?.Skills.Add(itemToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<SkillDTO>(itemToSave);
        }

        public async Task DeleteAsync(Guid resumeId, Guid skillIdToDelete)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Skills);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToDelete = resume?.Skills.FirstOrDefault(y => y.Id == skillIdToDelete);
            if (itemToDelete == null)
            {
                return;
            }

            resume?.Skills?.Remove(itemToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<SkillDTO> UpdateAsync(Guid resumeId, Guid skillIdToUpdate, SkillInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Skills);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToUpdate = resume?.Skills.FirstOrDefault(y => y.Id == skillIdToUpdate);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("Skill data is not valid");
            }

            itemToUpdate.Name = model.Name;
            itemToUpdate.Level = (Level)model.Level;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<SkillDTO>(itemToUpdate);
        }
    }
}
