using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUP.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class stImgValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/Images/Courses/default-course.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "/Images/Courses/default-course.png");
        }
    }
}
