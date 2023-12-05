using Microsoft.EntityFrameworkCore;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Persistence.Database.Extensions
{
    internal static class CustomTableNameModelBuilderExtension
    {
        internal static ModelBuilder ConfigureCustomTableNameModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>(entity => entity.ToTable("Awards"));
            modelBuilder.Entity<Certification>(entity => entity.ToTable("Certifications"));
            modelBuilder.Entity<CurricularActivity>(entity => entity.ToTable("CurricularActivities"));
            modelBuilder.Entity<Education>(entity => entity.ToTable("Educations"));
            modelBuilder.Entity<Experience>(entity => entity.ToTable("Experiences"));
            modelBuilder.Entity<Interest>(entity => entity.ToTable("Interests"));
            modelBuilder.Entity<PersonalDetail>(entity => entity.ToTable("PersonalDetails"));
            modelBuilder.Entity<Project>(entity => entity.ToTable("Projects"));
            modelBuilder.Entity<Publication>(entity => entity.ToTable("Publications"));
            modelBuilder.Entity<Reference>(entity => entity.ToTable("References"));
            modelBuilder.Entity<Skill>(entity => entity.ToTable("Skills"));
            modelBuilder.Entity<Social>(entity => entity.ToTable("Socials"));
            modelBuilder.Entity<Summary>(entity => entity.ToTable("Summaries"));

            return modelBuilder;
        }
    }
}
