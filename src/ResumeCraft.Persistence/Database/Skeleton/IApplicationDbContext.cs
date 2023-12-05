using Microsoft.EntityFrameworkCore;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Entities.CoverLetterInfo;
using ResumeCraft.Domain.Entities.ResumeInfo;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Persistence.Database.Skeleton
{
    public interface IApplicationDbContext
    {
        DbSet<Resume> Resumes { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<UserActivityLog> UserActivityLogs { get; set; }
        DbSet<CoverLetter> CoverLetters { get; set; }
        DbSet<CoverLetterTemplate> CoverLetterTemplates { get; set; }
        DbSet<ResumeTemplate> ResumeTemplates { get; set; }
    }
}
