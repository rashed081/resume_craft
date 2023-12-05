using Microsoft.EntityFrameworkCore;
using ResumeCraft.Application.Features.Admin.DTOs;
using ResumeCraft.Application.Features.Resumes.Repositories;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Persistence.Database;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.Repositories.Base;

namespace ResumeCraft.Persistence.Features.Resumes.Repositories
{
    public class ResumesRepository : Repository<Resume, Guid>, IResumeRepository
    {
        public ResumesRepository(IApplicationDbContext context)
            : base((ApplicationDbContext)context) { }

        public async Task<Resume> GetResumeWithRelatedData(Guid resumeId)
        {
            return (
                await _dbSet
                    .Include(x => x.PersonalDetail)
                    .ThenInclude(x => x.Socials)
                    .Include(x => x.Summary)
                    .Include(x => x.Awards)
                    .Include(x => x.Certifications)
                    .Include(x => x.CurricularActivities)
                    .Include(x => x.Educations)
                    .Include(x => x.Experiences)
                    .Include(x => x.Interests)
                    .Include(x => x.Projects)
                    .Include(x => x.Publications)
                    .Include(x => x.References)
                    .Include(x => x.Skills)
                    .Where(x => x.Id == resumeId)
                    .FirstOrDefaultAsync()
            )!;
        }

        public async Task<Resume?> GetResumeWithRelatedDataByUserAsync(Guid userId)
        {
            return await _dbSet
                .Include(x => x.PersonalDetail)
                .ThenInclude(x => x.Socials)
                .Include(x => x.Summary)
                .Include(x => x.Awards)
                .Include(x => x.Certifications)
                .Include(x => x.CurricularActivities)
                .Include(x => x.Educations)
                .Include(x => x.Experiences)
                .Include(x => x.Interests)
                .Include(x => x.Projects)
                .Include(x => x.Publications)
                .Include(x => x.References)
                .Include(x => x.Skills)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<(IList<UserDTO> users, IDictionary<string, object> outValues)> GetUserForDataTableDynamicAsync
            (IDictionary<string, object> parameters, IDictionary<string, Type> outParameters)
        {
            return await QueryWithStoredProcedureAsync<UserDTO>("GetUserInformationForDataTable", parameters, outParameters);
        }
    }
}
