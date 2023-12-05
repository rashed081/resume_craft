using ResumeCraft.Application.Features.Account.Repositories;
using ResumeCraft.Application.Features.CoverLetters.Repository;
using ResumeCraft.Application.Features.Resumes.Repositories;
using ResumeCraft.Domain.UnitOfWorks;

namespace ResumeCraft.Application.Services.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IResumeRepository Resumes { get; }
        IUserActivityRepository UserActivityLogs { get; }
        IResumeTemplateRepository ResumeTemplates { get; }
        IAsyncCoverLetterRepository Coverletters { get; }
        IAsyncCoverLetterTemplateRepository CoverLetterTemplates { get; }
    }
}
