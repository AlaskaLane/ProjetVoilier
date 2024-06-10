using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Penalite",
                table: "Penalite");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Penalite",
                table: "Penalite",
                columns: new[] { "VoilierEnCourseId", "Latitude", "Longitude" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Penalite",
                table: "Penalite");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Penalite",
                table: "Penalite",
                columns: new[] { "Latitude", "Longitude", "VoilierEnCourseId" });
        }
    }
}
