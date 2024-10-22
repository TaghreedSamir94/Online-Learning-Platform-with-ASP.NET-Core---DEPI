using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUP.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Enrollments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
