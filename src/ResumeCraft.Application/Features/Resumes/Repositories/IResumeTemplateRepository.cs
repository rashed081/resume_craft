using ResumeCraft.Domain.Entities.ResumeInfo;
using ResumeCraft.Domain.Repositories;

namespace ResumeCraft.Application.Features.Resumes.Repositories
{
    public interface IResumeTemplateRepository : IRepositoryBase<ResumeTemplate, Guid> { }
}
