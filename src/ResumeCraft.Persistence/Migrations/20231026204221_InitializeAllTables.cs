using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResumeCraft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitializeAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverLetters",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        ToWhom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        LetterContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ApplyingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        ApplicantsFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ApplicantsAddresss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        CoverLetterTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverLetters", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "CoverLetterTemplates",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverLetterTemplates", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                        ResumeTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "ResumeTemplates",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTemplates", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "UserActivityLogs",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                        UserIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Action = table.Column<int>(type: "int", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityLogs", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Gender = table.Column<byte>(type: "tinyint", nullable: true),
                        DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                        ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        CredentialId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        CredentialUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "CurricularActivities",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurricularActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurricularActivities_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Achievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                        ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        RepositoryUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                        PublishedUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "References",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        SupervisorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        SupervisorDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        SupervisorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        SupervisorInstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        SupervisorPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                    table.ForeignKey(
                        name: "FK_References_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Summaries_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table =>
                    new
                    {
                        Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                        RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table =>
                    new
                    {
                        Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table =>
                    new
                    {
                        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table =>
                    new
                    {
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table =>
                    new
                    {
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_UserTokens",
                        x =>
                            new
                            {
                                x.UserId,
                                x.LoginProvider,
                                x.Name
                            }
                    );
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        PersonalDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socials_PersonalDetails_PersonalDetailId",
                        column: x => x.PersonalDetailId,
                        principalTable: "PersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("45a666ed-ca89-40a0-9d5d-ec1de6469d5c"), null, "Admin", "ADMIN" },
                    { new Guid("a1e4e0d1-45fd-47c2-88d0-414804dd850a"), null, "User", "USER" }
                }
            );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id",
                    "AccessFailedCount",
                    "ConcurrencyStamp",
                    "DateOfBirth",
                    "Email",
                    "EmailConfirmed",
                    "FirstName",
                    "Gender",
                    "ImageUrl",
                    "LastName",
                    "LockoutEnabled",
                    "LockoutEnd",
                    "NormalizedEmail",
                    "NormalizedUserName",
                    "PasswordHash",
                    "PhoneNumber",
                    "PhoneNumberConfirmed",
                    "SecurityStamp",
                    "TwoFactorEnabled",
                    "UserName"
                },
                values: new object[,]
                {
                    {
                        new Guid("933d0b3e-dda0-49ed-a08f-0357553f3895"),
                        0,
                        "7e26c660-e469-4a93-aee5-26e7132a5ad3",
                        new DateTime(2023, 10, 27, 2, 42, 21, 251, DateTimeKind.Local).AddTicks(3521),
                        "user@resumecraft.com",
                        true,
                        "Guest",
                        (byte)1,
                        null,
                        "User",
                        true,
                        null,
                        "USER@RESUMECRAFT.COM",
                        "USER@RESUMECRAFT.COM",
                        "AQAAAAIAAYagAAAAECwQxcEyU6f4iIjDf7zbzFu+2ZyHBM6zI2o8ij4u9TH03SpFkG7aB2mkh80dPWVY1A==",
                        null,
                        false,
                        "PX7TSKXHPFXLAQXAWMMKTJRX4UJZR64A",
                        false,
                        "user@resumecraft.com"
                    },
                    {
                        new Guid("ad7cadf9-f854-47f3-9b75-f27ef88115c0"),
                        0,
                        "e12b731e-7f88-40ed-beb9-d6901e7b4dba",
                        new DateTime(2023, 10, 27, 2, 42, 21, 251, DateTimeKind.Local).AddTicks(3487),
                        "admin@resumecraft.com",
                        true,
                        "Reume",
                        (byte)1,
                        null,
                        "Craft",
                        true,
                        null,
                        "ADMIN@RESUMECRAFT.COM",
                        "ADMIN@RESUMECRAFT.COM",
                        "AQAAAAIAAYagAAAAECwQxcEyU6f4iIjDf7zbzFu+2ZyHBM6zI2o8ij4u9TH03SpFkG7aB2mkh80dPWVY1A==",
                        null,
                        false,
                        "PX7TSKXHPFXLAQXAWMMKTJRX4UJZR64A",
                        false,
                        "admin@resumecraft.com"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    {
                        1,
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
                        "admin@resumecraft.com",
                        new Guid("ad7cadf9-f854-47f3-9b75-f27ef88115c0")
                    },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", new Guid("ad7cadf9-f854-47f3-9b75-f27ef88115c0") },
                    {
                        3,
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
                        "user@resumecraft.com",
                        new Guid("933d0b3e-dda0-49ed-a08f-0357553f3895")
                    },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", new Guid("933d0b3e-dda0-49ed-a08f-0357553f3895") }
                }
            );

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a1e4e0d1-45fd-47c2-88d0-414804dd850a"), new Guid("933d0b3e-dda0-49ed-a08f-0357553f3895") },
                    { new Guid("45a666ed-ca89-40a0-9d5d-ec1de6469d5c"), new Guid("ad7cadf9-f854-47f3-9b75-f27ef88115c0") }
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Awards_ResumeId", table: "Awards", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_Certifications_ResumeId", table: "Certifications", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_CurricularActivities_ResumeId", table: "CurricularActivities", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_Educations_ResumeId", table: "Educations", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_Experiences_ResumeId", table: "Experiences", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_Interests_ResumeId", table: "Interests", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_PersonalDetails_ResumeId", table: "PersonalDetails", column: "ResumeId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Projects_ResumeId", table: "Projects", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_Publications_ResumeId", table: "Publications", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_References_ResumeId", table: "References", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_RoleClaims_RoleId", table: "RoleClaims", column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Skills_ResumeId", table: "Skills", column: "ResumeId");

            migrationBuilder.CreateIndex(name: "IX_Socials_PersonalDetailId", table: "Socials", column: "PersonalDetailId");

            migrationBuilder.CreateIndex(name: "IX_Summaries_ResumeId", table: "Summaries", column: "ResumeId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_UserClaims_UserId", table: "UserClaims", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_UserLogins_UserId", table: "UserLogins", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_UserRoles_RoleId", table: "UserRoles", column: "RoleId");

            migrationBuilder.CreateIndex(name: "EmailIndex", table: "Users", column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Awards");

            migrationBuilder.DropTable(name: "Certifications");

            migrationBuilder.DropTable(name: "CoverLetters");

            migrationBuilder.DropTable(name: "CoverLetterTemplates");

            migrationBuilder.DropTable(name: "CurricularActivities");

            migrationBuilder.DropTable(name: "Educations");

            migrationBuilder.DropTable(name: "Experiences");

            migrationBuilder.DropTable(name: "Interests");

            migrationBuilder.DropTable(name: "Projects");

            migrationBuilder.DropTable(name: "Publications");

            migrationBuilder.DropTable(name: "References");

            migrationBuilder.DropTable(name: "ResumeTemplates");

            migrationBuilder.DropTable(name: "RoleClaims");

            migrationBuilder.DropTable(name: "Skills");

            migrationBuilder.DropTable(name: "Socials");

            migrationBuilder.DropTable(name: "Summaries");

            migrationBuilder.DropTable(name: "UserActivityLogs");

            migrationBuilder.DropTable(name: "UserClaims");

            migrationBuilder.DropTable(name: "UserLogins");

            migrationBuilder.DropTable(name: "UserRoles");

            migrationBuilder.DropTable(name: "UserTokens");

            migrationBuilder.DropTable(name: "PersonalDetails");

            migrationBuilder.DropTable(name: "Roles");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropTable(name: "Resumes");
        }
    }
}
