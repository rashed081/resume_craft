using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PublicationService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<PublicationDTO>> GetListOfPublicationAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Publications);

            return _mapper.Map<IList<PublicationDTO>>(resume?.Publications);
        }

        public async Task<PublicationDTO> AddIntoResumeAsync(Guid resumeId, PublicationInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Publications);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToSave = new Publication
            {
                InstituteName = model.InstituteName,
                Title = model.Title,
                PublishedDate = model.PublishedDate,
                PublishedUrl = model.PublishedUrl
            };

            resume?.Publications.Add(itemToSave);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<PublicationDTO>(itemToSave);
        }

        public async Task DeleteFromResumeAsync(Guid resumeId, Guid publicationIdToDelete)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Publications);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToDelete = resume?.Publications.FirstOrDefault(y => y.Id == publicationIdToDelete);
            if (itemToDelete == null)
            {
                return;
            }

            resume?.Publications?.Remove(itemToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<PublicationDTO> UpdateThePublicationAsync(Guid resumeId, Guid publicationIdToUpdate, PublicationInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Publications);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToUpdate = resume?.Publications.FirstOrDefault(y => y.Id == publicationIdToUpdate);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("Publication data is not valid");
            }

            itemToUpdate.InstituteName = model.InstituteName;
            itemToUpdate.Title = model.Title;
            itemToUpdate.PublishedDate = model.PublishedDate;
            itemToUpdate.PublishedUrl = model.PublishedUrl;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<PublicationDTO>(itemToUpdate);
        }
    }
}
