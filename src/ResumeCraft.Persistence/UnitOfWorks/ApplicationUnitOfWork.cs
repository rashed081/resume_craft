using Microsoft.EntityFrameworkCore;
using ResumeCraft.Application.Features.Account.Repositories;
using ResumeCraft.Application.Features.CoverLetters.Repository;
using ResumeCraft.Application.Features.Resumes.Repositories;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.Repositories.User.Skeleton;
using ResumeCraft.Persistence.UnitOfWorks.Base;

namespace ResumeCraft.Persistence.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork, IApplicationUserUnitOfWork
    {
        public IApplicationUserRepository Users { get; private set; }
        public IResumeRepository Resumes { get; private set; }
        public IUserActivityRepository UserActivityLogs { get; private set; }
        public IResumeTemplateRepository ResumeTemplates { get; private set; }
        public IAsyncCoverLetterRepository Coverletters { get; private set; }
        public IAsyncCoverLetterTemplateRepository CoverLetterTemplates { get; private set; }

        public ApplicationUnitOfWork(
            IApplicationDbContext dbContext,
            IApplicationUserRepository users,
            IResumeRepository resumes,
            IUserActivityRepository userActivityRepository,
            IAsyncCoverLetterRepository coverLetters,
            IAsyncCoverLetterTemplateRepository coverLetterTemplates,
            IResumeTemplateRepository resumeTemplateRepository
        )
            : base((DbContext)dbContext)
        {
            Users = users;
            Resumes = resumes;
            Coverletters = coverLetters;
            CoverLetterTemplates = coverLetterTemplates;
            UserActivityLogs = userActivityRepository;
            ResumeTemplates = resumeTemplateRepository;
        }
    }
}
