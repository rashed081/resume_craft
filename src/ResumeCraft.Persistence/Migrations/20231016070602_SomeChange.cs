using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeCraft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SomeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "SupervisorAddress", table: "References");

            migrationBuilder.DropColumn(name: "CredentialId", table: "Certifications");

            migrationBuilder.DropColumn(name: "CredentialUrl", table: "Certifications");

            migrationBuilder.RenameColumn(name: "IssueDate", table: "Certifications", newName: "StartDate");

            migrationBuilder.AddColumn<int>(name: "Level", table: "Skills", type: "int", nullable: true);

            migrationBuilder.AddColumn<string>(name: "Organization", table: "CurricularActivities", type: "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "EndDate", table: "Certifications", type: "datetime2", nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Level", table: "Skills");

            migrationBuilder.DropColumn(name: "Organization", table: "CurricularActivities");

            migrationBuilder.DropColumn(name: "EndDate", table: "Certifications");

            migrationBuilder.RenameColumn(name: "StartDate", table: "Certifications", newName: "IssueDate");

            migrationBuilder.AddColumn<string>(name: "SupervisorAddress", table: "References", type: "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>(name: "CredentialId", table: "Certifications", type: "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>(name: "CredentialUrl", table: "Certifications", type: "nvarchar(max)", nullable: true);
        }
    }
}
