using ResumeCraft.Domain.Entities.CoverLetterInfo;
using ResumeCraft.Domain.Repositories;

namespace ResumeCraft.Application.Features.CoverLetters.Repository
{
    public interface IAsyncCoverLetterRepository : IRepositoryBase<CoverLetter, Guid> { }
}
