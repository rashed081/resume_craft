using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SummaryService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SummaryDTO> GetAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Summary!);

            if (resume?.Summary is null)
            {
                return default;
            }

            return _mapper.Map<SummaryDTO>(resume?.Summary);
        }

        public async Task<SummaryDTO> AddAsync(Guid resumeId, SummaryInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Summary!);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }
            var itemToAdd = new Summary { Content = model.Content };

            resume.Summary = itemToAdd;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<SummaryDTO>(resume.Summary);
        }

        public async Task DeleteAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Summary!);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }
            if (resume.Summary is null)
            {
                throw new ArgumentNullException("Summary does not exist");
            }

            resume.Summary = null;

            await _unitOfWork.SaveAsync();
        }

        public async Task<SummaryDTO> UpdateAsync(Guid resumeId, string content)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Summary!);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            if (resume?.Summary is null)
            {
                resume.Summary = new Summary();
            }

            resume.Summary.Content = content;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<SummaryDTO>(resume.Summary);
        }
    }
}
