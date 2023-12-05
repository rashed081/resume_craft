using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;
using System.Globalization;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class PersonalDetailService : IPersonalDetailService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonalDetailService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonalDetailsDTO> GetDetialsOfUserAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.PersonalDetail!);

            if (resume?.PersonalDetail is null)
            {
                return default;
            }

            return _mapper.Map<PersonalDetailsDTO>(resume?.PersonalDetail);
        }

        public async Task<PersonalDetailsDTO> AddIntoResumeAsync(Guid resumeId, PersonalDetailInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.PersonalDetail!);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }
            if (resume.PersonalDetail is not null)
            {
                throw new InvalidOperationException("Already contact details exist");
            }

            resume.PersonalDetail = new PersonalDetail
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                ImageUrl = model.ImageUrl,
            };

            foreach (var social in model.Socials)
            {
                resume?.PersonalDetail?.Socials.Add(new() { PlatformName = social.PlatformName, ProfileUrl = social.ProfileUrl });
            }

            await _unitOfWork.SaveAsync();

            return _mapper.Map<PersonalDetailsDTO>(resume?.PersonalDetail);
        }

        public async Task DeleteFromResumeAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.PersonalDetail!);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }
            if (resume.PersonalDetail is null)
            {
                throw new ArgumentNullException("Personal detail does not exist");
            }

            resume.PersonalDetail = null;

            await _unitOfWork.SaveAsync();
        }

        public async Task<PersonalDetailsDTO> UpdateDetailsAsync(Guid resumeId, PersonalDetailInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.PersonalDetail!);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            if (resume?.PersonalDetail is null)
            {
                throw new ArgumentNullException("Personal detail doesn't exit");
            }

            resume.PersonalDetail.FirstName = model.FirstName;
            resume.PersonalDetail.LastName = model.LastName;
            resume.PersonalDetail.Address = model.Address;
            resume.PersonalDetail.DateOfBirth = model.DateOfBirth;
            resume.PersonalDetail.ImageUrl = model.ImageUrl;

            foreach (var social in model.Socials)
            {
                var socialToUpdate = resume.PersonalDetail.Socials.FirstOrDefault(x => x.Id == social.Id);

                if (socialToUpdate == null)
                    continue;

                socialToUpdate.PlatformName = social.PlatformName;
                socialToUpdate.ProfileUrl = social.ProfileUrl;
            }

            await _unitOfWork.SaveAsync();

            return _mapper.Map<PersonalDetailsDTO>(resume?.PersonalDetail);
        }

        public async Task<PersonalDetailsDTO> UpdateDynamic(Guid resumeId, ContactUpdateModel model)
        {

            string name = model.PropName;

            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.PersonalDetail!);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            if (resume?.PersonalDetail is null)
            {
                if (resume != null)
                {
                    resume.PersonalDetail = new PersonalDetail();
                }
            }

            if (name == "FirstName")
                resume.PersonalDetail.FirstName = model.PropValue.ToString();
            else if (name == "LastName")
                resume.PersonalDetail.LastName = model.PropValue.ToString();
            else if (name == "Email")
                resume.PersonalDetail.Email = model.PropValue.ToString();
            else if (name == "Phone")
                resume.PersonalDetail.Phone = Convert.ToInt32(model.PropValue);
            else if (name == "Address")
                resume.PersonalDetail.Address = model.PropValue.ToString();
            else if (name == "DateOfBirth")
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime dob;
                bool isSuccess3 = DateTime.TryParseExact(model.PropValue, "yyyy-dd-MM", provider, DateTimeStyles.None, out dob);

                resume.PersonalDetail.DateOfBirth = dob;
            }

            await _unitOfWork.SaveAsync();

            return _mapper.Map<PersonalDetailsDTO>(resume?.PersonalDetail);
        }
    }
}
