using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeCraft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changesExp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KeyAchivement",
                table: "Experiences",
                newName: "Achievement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Achievement",
                table: "Experiences",
                newName: "KeyAchivement");
        }
    }
}
