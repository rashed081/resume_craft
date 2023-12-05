﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResumeCraft.Persistence.Database;

#nullable disable

namespace ResumeCraft.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResumeCraft.Domain.Entities.CoverLetterInfo.CoverLetter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ApplyingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LetterContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ToWhom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("CoverLetters", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.CoverLetterInfo.CoverLetterTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CoverLetterTemplates", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoverLetterTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResumeTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CoverLetterTemplateId");

                    b.HasIndex("ResumeTemplateId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.ResumeTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResumeTemplates", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Award", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InstituteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Awards", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Certification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstituteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Certifications", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.CurricularActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("CurricularActivities", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FieldOfStudy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstituteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Educations", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Achievement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Experiences", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Interest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Interests", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.PersonalDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId")
                        .IsUnique();

                    b.ToTable("PersonalDetails", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepositoryUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Publication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InstituteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublishedUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Publications", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Reference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SupervisorDesignation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupervisorEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupervisorInstituteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupervisorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupervisorPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("References", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Social", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonalDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlatformName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalDetailId");

                    b.ToTable("Socials", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Summary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId")
                        .IsUnique();

                    b.ToTable("Summaries", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.UserActivityLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserActivityLogs");
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.CoverLetterInfo.CoverLetter", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.Resume", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.CoverLetterInfo.CoverLetterTemplate", "CoverLetterTemplate")
                        .WithMany("Resumes")
                        .HasForeignKey("CoverLetterTemplateId");

                    b.HasOne("ResumeCraft.Domain.Entities.ResumeInfo.ResumeTemplate", "ResumeTemplate")
                        .WithMany("Resumes")
                        .HasForeignKey("ResumeTemplateId");

                    b.Navigation("CoverLetterTemplate");

                    b.Navigation("ResumeTemplate");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Award", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Awards")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Certification", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Certifications")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.CurricularActivity", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("CurricularActivities")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Education", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Educations")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Experience", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Experiences")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Interest", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Interests")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.PersonalDetail", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithOne("PersonalDetail")
                        .HasForeignKey("ResumeCraft.Domain.Entities.ResumeInfo.Sections.PersonalDetail", "ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Project", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Projects")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Publication", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Publications")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Reference", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("References")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Skill", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithMany("Skills")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Social", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.ResumeInfo.Sections.PersonalDetail", "PersonalDetail")
                        .WithMany("Socials")
                        .HasForeignKey("PersonalDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalDetail");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Summary", b =>
                {
                    b.HasOne("ResumeCraft.Domain.Entities.Resume", "Resume")
                        .WithOne("Summary")
                        .HasForeignKey("ResumeCraft.Domain.Entities.ResumeInfo.Sections.Summary", "ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationRoleClaim", b =>
                {
                    b.HasOne("ResumeCraft.Persistence.Features.Account.Membership.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserClaim", b =>
                {
                    b.HasOne("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserLogin", b =>
                {
                    b.HasOne("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserRole", b =>
                {
                    b.HasOne("ResumeCraft.Persistence.Features.Account.Membership.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUserToken", b =>
                {
                    b.HasOne("ResumeCraft.Persistence.Features.Account.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.CoverLetterInfo.CoverLetterTemplate", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.Resume", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("Certifications");

                    b.Navigation("CurricularActivities");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("Interests");

                    b.Navigation("PersonalDetail");

                    b.Navigation("Projects");

                    b.Navigation("Publications");

                    b.Navigation("References");

                    b.Navigation("Skills");

                    b.Navigation("Summary");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.ResumeTemplate", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("ResumeCraft.Domain.Entities.ResumeInfo.Sections.PersonalDetail", b =>
                {
                    b.Navigation("Socials");
                });
#pragma warning restore 612, 618
        }
    }
}
