using Autofac;
using DinkToPdf;
using DinkToPdf.Contracts;
using ResumeCraft.Application.Features.Account.Repositories;
using ResumeCraft.Application.Features.CoverLetters.Repository;
using ResumeCraft.Application.Features.PdfGenerate.Services;
using ResumeCraft.Application.Features.Resumes.Repositories;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Persistence.Database;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.DinkToPdf;
using ResumeCraft.Persistence.Features.Account.Repositories;
using ResumeCraft.Persistence.Features.CoverLetters.Repositories;
using ResumeCraft.Persistence.Features.Email.Services;
using ResumeCraft.Persistence.Features.Email.Services.Skeleton;
using ResumeCraft.Persistence.Features.PdfGenerate.Services;
using ResumeCraft.Persistence.Features.Resumes.Repositories;
using ResumeCraft.Persistence.Repositories.User;
using ResumeCraft.Persistence.Repositories.User.Skeleton;
using ResumeCraft.Persistence.UnitOfWorks;
using ResumeCraft.Persistence.UnitOfWorks.Base;

namespace ResumeCraft.Persistence
{
    public class PersistenceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public PersistenceModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region DbContext
            builder
                .RegisterType<ApplicationDbContext>()
                .AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ApplicationDbContext>()
                .As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();
            #endregion

            #region UnitOfWork
            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUserUnitOfWork>().InstancePerLifetimeScope();
            #endregion

            #region AccountServices
            builder.RegisterType<EmailUserService>().As<IEmailUserService>().InstancePerLifetimeScope();
            #endregion

            #region UserRepository
            builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>().InstancePerLifetimeScope();
            #endregion

            #region ResumeRepository
            builder.RegisterType<ResumesRepository>().As<IResumeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserActivityLogsRepository>().As<IUserActivityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ResumeTemplateRepository>().As<IResumeTemplateRepository>().InstancePerLifetimeScope();
            #endregion

            #region CoverLetterRepository
            builder.RegisterType<CoverLetterRepository>().As<IAsyncCoverLetterRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CoverLetterTemplateRepository>().As<IAsyncCoverLetterTemplateRepository>().InstancePerLifetimeScope();
            #endregion

            #region PdfGeneration
            builder.RegisterType<PdfGenerationService>().As<IAsyncPdfGenerationService>().InstancePerLifetimeScope();
            #endregion

            #region DinkToPdf
            builder.RegisterType<CustomAssemblyLoadContext>().AsSelf();
            builder.RegisterType<SynchronizedConverter>().As<IConverter>().WithParameter("tools", new PdfTools()).SingleInstance();
            #endregion
        }
    }
}
