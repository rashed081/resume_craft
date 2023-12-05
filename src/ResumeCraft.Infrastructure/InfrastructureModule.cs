using Autofac;
using ResumeCraft.Application.Features.Account.Services;
using ResumeCraft.Application.Features.Admin.Services;
using ResumeCraft.Application.Features.Email.Services;
using ResumeCraft.Application.Securities;
using ResumeCraft.Domain.Services;
using ResumeCraft.Infrastructure.Features.Account.Services;
using ResumeCraft.Infrastructure.Features.Admin.Services;
using ResumeCraft.Infrastructure.Features.Email.Services;
using ResumeCraft.Infrastructure.Securities;

namespace ResumeCraft.Infrastructure
{
    public class InfrastructureModule : Module
    {
        public InfrastructureModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region AccountServices
            builder.RegisterType<CaptchaService>().As<ICaptchaService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();

            builder.RegisterType<HtmlEmailService>().As<IHtmlEmailService>().InstancePerLifetimeScope();
            builder.RegisterType<EmailSendService>().As<IEmailSendService>().InstancePerLifetimeScope();
            #endregion

            #region AdminServices
            builder.RegisterType<AdminDashboardService>().As<IAdminDashboardService>().InstancePerLifetimeScope();
            builder.RegisterType<AdminUserManagementService>().As<IAdminUserManagementService>().InstancePerLifetimeScope();
            builder.RegisterType<AdminProfileService>().As<IAdminProfileService>().InstancePerLifetimeScope();
            #endregion

            #region UserActivityLogServices
            builder.RegisterType<UserActivityLogService>().As<IUserActivityLogService>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
