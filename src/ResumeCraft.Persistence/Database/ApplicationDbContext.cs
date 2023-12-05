using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Entities.CoverLetterInfo;
using ResumeCraft.Domain.Entities.ResumeInfo;
using ResumeCraft.Persistence.Database.Extensions;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Persistence.Database
{
    public class ApplicationDbContext
        : IdentityDbContext<
            ApplicationUser,
            ApplicationRole,
            Guid,
            ApplicationUserClaim,
            ApplicationUserRole,
            ApplicationUserLogin,
            ApplicationRoleClaim,
            ApplicationUserToken
        >,
            IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<CoverLetterTemplate> CoverLetterTemplates { get; set; }
        public DbSet<ResumeTemplate> ResumeTemplates { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_connectionString, (x) => x.MigrationsAssembly(_migrationAssembly))
                    .EnableSensitiveDataLogging()
                    .LogTo((msg) => Console.WriteLine(msg), LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This need to be first

            modelBuilder.ConfigureIdentityModel();
            modelBuilder.ConfigureCustomTableNameModel();
            modelBuilder.CreateDefaultUsers();
        }
    }
}
