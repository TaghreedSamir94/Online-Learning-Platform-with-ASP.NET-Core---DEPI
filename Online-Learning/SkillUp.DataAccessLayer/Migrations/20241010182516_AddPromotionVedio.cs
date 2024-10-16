using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddPromotionVedio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromotionalVideoUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                column: "PromotionalVideoUrl",
                value: "https://www.youtube.com/embed/lSwIe0TMUhc");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                column: "PromotionalVideoUrl",
                value: "https://www.youtube.com/embed/q9RdQa6pMx4");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                column: "PromotionalVideoUrl",
                value: "https://www.youtube.com/embed/vCUGYAdvLIs");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                column: "PromotionalVideoUrl",
                value: "https://www.youtube.com/embed/8p3hZ2Yonsc?list=PLdW0onEGGcNlrod2I8eWGdqFk7GYya-sU");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 5,
                column: "PromotionalVideoUrl",
                value: "https://www.youtube.com/embed/GsQ2MiPZszw");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 6,
                column: "PromotionalVideoUrl",
                value: "https://www.youtube.com/embed/7P_LC_AX6sA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionalVideoUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
    }
}
