using ResumeCraft.Application.Features.CoverLetters.Repository;
using ResumeCraft.Domain.Entities.CoverLetterInfo;
using ResumeCraft.Persistence.Database;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.Repositories.Base;

namespace ResumeCraft.Persistence.Features.CoverLetters.Repositories
{
    public class CoverLetterTemplateRepository : Repository<CoverLetterTemplate, Guid>, IAsyncCoverLetterTemplateRepository
    {
        public CoverLetterTemplateRepository(IApplicationDbContext context)
            : base((ApplicationDbContext)context) { }
    }
}
