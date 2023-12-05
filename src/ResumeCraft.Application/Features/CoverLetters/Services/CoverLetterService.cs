using AutoMapper;
using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Application.Features.CoverLetters.Models;
using ResumeCraft.Application.Features.CoverLetters.Services.Interface;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.CoverLetterInfo;

namespace ResumeCraft.Application.Features.CoverLetters.Services
{
    public class CoverLetterService : IAsyncCoverLetterService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoverLetterService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CoverLetterDTO>> GetListOfCoverLetterAsync()
        {
            var coverLetters = await _unitOfWork.Coverletters.GetAllAsync();

            return _mapper.Map<IList<CoverLetterDTO>>(coverLetters);
        }

        public async Task<CoverLetterDTO> AddAsync(Guid userId, Guid CoverLetterTemplateId, CoverLetterInputModel model)
        {
            var itemToSave = new CoverLetter
            {
                ToWhom = model.ToWhom,
                JobPosition = model.JobPosition,
                CompanyAddress = model.CompanyAddress,
                ApplyingDate = model.ApplyingDate,
                LetterContent = model.LetterContent,
                ApplicantsAddresss = model.ApplicantsAddresss,
                ApplicantsFullName = model.ApplicantsFullName,
                UserId = userId,
                CoverLetterTemplateId = CoverLetterTemplateId,
            };

            await _unitOfWork.Coverletters.AddAsync(itemToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CoverLetterDTO>(itemToSave);
        }

        public async Task<Guid> AddEmptyCoverLetter(Guid userId, Guid CoverLetterTemplateId)
        {
            var newCoverLetter = new CoverLetter { UserId = userId, CoverLetterTemplateId = CoverLetterTemplateId };
            var createdCoverLetterToReturn = await _unitOfWork.Coverletters.AddAsync(newCoverLetter);

            await _unitOfWork.SaveAsync();

            return createdCoverLetterToReturn.Id;
        }

        public async Task DeleteAsync(Guid coverLetterIdId)
        {
            await _unitOfWork.Coverletters.RemoveAsync(coverLetterIdId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CoverLetterDTO> UpdateTheCoverLetterAsync(
            Guid userId,
            Guid CoverLetterTemplateId,
            Guid coverLetterId,
            CoverLetterInputModel model
        )
        {
            var itemToUpdate = await _unitOfWork.Coverletters.GetByIdAsync(coverLetterId);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("CoverLetter data is not valid");
            }

            itemToUpdate.ToWhom = model.ToWhom;
            itemToUpdate.JobPosition = model.JobPosition;
            itemToUpdate.ApplyingDate = model.ApplyingDate;
            itemToUpdate.CompanyAddress = model.CompanyAddress;
            itemToUpdate.LetterContent = model.LetterContent;
            itemToUpdate.ApplicantsAddresss = model.ApplicantsAddresss;
            itemToUpdate.ApplicantsFullName = model.ApplicantsFullName;
            itemToUpdate.UserId = userId;
            itemToUpdate.CoverLetterTemplateId = coverLetterId;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<CoverLetterDTO>(itemToUpdate);
        }
    }
}
