using Autofac;
using ResumeCraft.Application.Features.Account.Models;
using ResumeCraft.Application.Features.Admin.Models;
using ResumeCraft.Application.Features.CoverLetters.Models;
using ResumeCraft.Application.Features.CoverLetters.Services;
using ResumeCraft.Application.Features.CoverLetters.Services.Interface;
using ResumeCraft.Application.Features.Resumes.Services;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Application
{
    public class ApplicationModule : Module
    {
        public ApplicationModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region AccountModels
            builder.RegisterType<ChangeEmailModel>().AsSelf();
            builder.RegisterType<ChangePasswordModel>().AsSelf();
            builder.RegisterType<ConfirmEmailChangeModel>().AsSelf();
            builder.RegisterType<ConfirmEmailModel>().AsSelf();
            builder.RegisterType<ForgotPasswordModel>().AsSelf();
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<LogoutModel>().AsSelf();
            builder.RegisterType<RegisterModel>().AsSelf();
            builder.RegisterType<ResetPasswordModel>().AsSelf();
            #endregion

            #region AdminModels
            builder.RegisterType<AdminDashboardModel>().AsSelf();
            builder.RegisterType<AdminProfileModel>().AsSelf();
            #endregion

            #region ResumeServices
            builder.RegisterType<SummaryService>().As<ISummaryService>().InstancePerLifetimeScope();
            builder.RegisterType<AwardService>().As<IAwardService>().InstancePerLifetimeScope();
            builder.RegisterType<SkillService>().As<ISkillService>().InstancePerLifetimeScope();
            builder.RegisterType<ExperienceService>().As<IExperienceService>().InstancePerLifetimeScope();
            builder.RegisterType<ReferenceService>().As<IReferenceService>().InstancePerLifetimeScope();
            builder.RegisterType<ResumeCollectionService>().As<IResumesService>().InstancePerLifetimeScope();
            builder.RegisterType<EducationService>().As<IEducationService>().InstancePerLifetimeScope();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonalDetailService>().As<IPersonalDetailService>().InstancePerLifetimeScope();
            builder.RegisterType<CertificationService>().As<ICertificationService>().InstancePerLifetimeScope();
            builder.RegisterType<InterestService>().As<IInterestService>().InstancePerLifetimeScope();
            builder.RegisterType<ResumeTemplateService>().As<IResumeTemplateService>().InstancePerLifetimeScope();
            builder.RegisterType<PublicationService>().As<IPublicationService>().InstancePerLifetimeScope();
            builder.RegisterType<CurricularActivityService>().As<ICurricularActivityService>().InstancePerLifetimeScope();
            #endregion

            #region CoverLetterModel
            builder.RegisterType<CoverLetterInputModel>().AsSelf();
            builder.RegisterType<CoverLetterService>().As<IAsyncCoverLetterService>().InstancePerLifetimeScope();
            builder.RegisterType<CoverLetterTemplateService>().As<IAsyncCoverLetterTemplateService>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
