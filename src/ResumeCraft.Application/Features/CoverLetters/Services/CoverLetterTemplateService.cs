using AutoMapper;
using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Application.Features.CoverLetters.Services.Interface;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.CoverLetterInfo;

namespace ResumeCraft.Application.Features.CoverLetters.Services
{
    public class CoverLetterTemplateService : IAsyncCoverLetterTemplateService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoverLetterTemplateService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CoverLetterTemplateDTO> AddAsync(string templateName, string path)
        {
            var itemToSave = new CoverLetterTemplate { TemplateName = templateName, Path = path };

            await _unitOfWork.CoverLetterTemplates.AddAsync(itemToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CoverLetterTemplateDTO>(itemToSave);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.CoverLetterTemplates.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<CoverLetterTemplateDTO>> GetAllAsync()
        {
            var coverLetterTemplates = await _unitOfWork.CoverLetterTemplates.GetAllAsync();

            return _mapper.Map<IList<CoverLetterTemplateDTO>>(coverLetterTemplates);
        }

        public async Task<CoverLetterTemplateDTO> GetAsync(Guid id)
        {
            var coverLetterTemplate = await _unitOfWork.CoverLetterTemplates.GetByIdAsync(id);

            return _mapper.Map<CoverLetterTemplateDTO>(coverLetterTemplate);
        }

        public async Task<CoverLetterTemplateDTO> UpdateAsync(Guid id, string templateName, string path)
        {
            var itemToUpdate = await _unitOfWork.CoverLetterTemplates.GetByIdAsync(id);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("CoverLetterTemplate data is not valid");
            }

            itemToUpdate.Path = path;
            itemToUpdate.TemplateName = templateName;

            await _unitOfWork.SaveAsync();
            return _mapper.Map<CoverLetterTemplateDTO>(itemToUpdate);
        }
    }
}
