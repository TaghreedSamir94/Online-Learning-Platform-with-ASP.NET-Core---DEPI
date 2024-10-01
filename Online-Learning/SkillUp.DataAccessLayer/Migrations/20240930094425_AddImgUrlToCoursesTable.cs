using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddImgUrlToCoursesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Courses",
                newName: "ImgUrl");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImgUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Courses",
                newName: "Content");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                column: "Content",
                value: "In this one-week class, we will provide a crash course in what these terms mean and how they play a role in successful organizations.\r\nThis class is for anyone who wants to learn what all the data science action is about, including those who will eventually need to manage data scientists.\r\nThe goal is to get you up to speed as quickly as possible on data science without all the fluff.\r\nWe've designed this course to be as convenient as possible without sacrificing any of the essentials.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                column: "Content",
                value: "1-Learn fundamentals of Blazor\r\n 2-Build real world e-commerce application using Blazor Web Assembly and Blazor Server\r\n 3-Forms in Blazor with Validation\r\n 4-Emails with Blazor");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Content",
                value: "1-Tools\r\n 2-Panels\r\n 3- Fashion Drawing Effects");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                column: "Content",
                value: "1-The definition of music\r\n2-The elements of music (rhythm & pitch)\r\n3-Division of pitch into melody and harmony\r\n 4-Rhythmic notation\r\n 5-Understanding relative durations of sound\r\n 6-The whole, half, quarter, 8th and 16th notes");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 5,
                column: "Content",
                value: "1-Create a financial model (projecting the future) for an income statement.\r\n 2-Create a financial model (projecting the future) for a balance sheet.\r\n 3-Create a financial model (projecting the future) for a cash flow statement.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 6,
                column: "Content",
                value: "1-You will learn and develop the ability to think, read and write abstractly and Mathematically.\r\n 2-You will learn the fundamentals of Set Theory including set builder notation, and set operations and properties.");
        }
    }
}
