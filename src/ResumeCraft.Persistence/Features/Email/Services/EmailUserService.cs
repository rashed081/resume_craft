using ResumeCraft.Persistence.Features.Account.Membership;
using ResumeCraft.Persistence.Features.Email.Services.Skeleton;
using ResumeCraft.Persistence.UnitOfWorks.Base;

namespace ResumeCraft.Persistence.Features.Email.Services
{
    public class EmailUserService : IEmailUserService
    {
        private readonly IApplicationUserUnitOfWork _unitOfWork;

        public EmailUserService(IApplicationUserUnitOfWork appUnitOfWork)
        {
            _unitOfWork = appUnitOfWork;
        }

        public IList<ApplicationUser> GetUsers()
        {
            return _unitOfWork.Users.GetAll();
        }
    }
}
