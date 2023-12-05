using Microsoft.EntityFrameworkCore;
using ResumeCraft.Application.Features.Resumes.Repositories;
using ResumeCraft.Domain.Entities.ResumeInfo;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.Repositories.Base;

namespace ResumeCraft.Persistence.Features.Resumes.Repositories
{
    public class ResumeTemplateRepository : Repository<ResumeTemplate, Guid>, IResumeTemplateRepository
    {
        public ResumeTemplateRepository(IApplicationDbContext context)
            : base((DbContext)context) { }
    }
}
