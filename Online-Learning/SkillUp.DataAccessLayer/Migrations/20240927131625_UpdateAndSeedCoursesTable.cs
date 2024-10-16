using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillUp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAndSeedCoursesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Courses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalHours",
                table: "Courses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Content", "Description", "InstructorName", "Price", "Title", "TotalHours" },
                values: new object[,]
                {
                    { 1, "In this one-week class, we will provide a crash course in what these terms mean and how they play a role in successful organizations.\r\nThis class is for anyone who wants to learn what all the data science action is about, including those who will eventually need to manage data scientists.\r\nThe goal is to get you up to speed as quickly as possible on data science without all the fluff.\r\nWe've designed this course to be as convenient as possible without sacrificing any of the essentials.", "This course is part of the Executive Data Science Specialization ,When you enroll in this course, you'll also be enrolled in this Specialization.1-Learn new concepts from industry experts 2-Gain a foundational understanding of a subject or tool 4-Develop job-relevant skills with hands-on projects 5-Earn a shareable career certificate", "Jeff Leek", 3980f, "A Crash Course in Data Science", 29f },
                    { 2, "1-Learn fundamentals of Blazor\r\n 2-Build real world e-commerce application using Blazor Web Assembly and Blazor Server\r\n 3-Forms in Blazor with Validation\r\n 4-Emails with Blazor", "Blazor is an exciting new part of .NET Core (.NET 9) designed for building rich web user interfaces in C#. This course will help developers transition from building basic sample apps to implementing more real world concepts, design patterns, and features.", "Bhrugen Patel", 1250f, "Blazor - The Complete Guide [.NET 9] [2024] [E-commerce]", 12f },
                    { 3, "1-Tools\r\n 2-Panels\r\n 3- Fashion Drawing Effects", "Learn how to use Adobe Illustrator to draw fashion flats. Develop your skills to enable you to produce creative, accurate product designs quickly and to standards required for retail and manufacturing.", "Jo Hughes", 300f, "Learn to draw fashion with Adobe Illustrator CC - Beginners", 5f },
                    { 4, "1-The definition of music\r\n2-The elements of music (rhythm & pitch)\r\n3-Division of pitch into melody and harmony\r\n 4-Rhythmic notation\r\n 5-Understanding relative durations of sound\r\n 6-The whole, half, quarter, 8th and 16th notes", "", "Jonathan Peters", 800f, "Music Theory", 8f },
                    { 5, "1-Create a financial model (projecting the future) for an income statement.\r\n 2-Create a financial model (projecting the future) for a balance sheet.\r\n 3-Create a financial model (projecting the future) for a cash flow statement.", "This course will help you understand accounting, finance, financial modeling and valuation from scratch (no prior accounting, finance, modeling or valuation experience is required).\r\n\r\nBy the end of this course, you will also know how to value companies using several different valuation methodologies that I have used during my Wall Street career so you can come up with target prices for the companies that you are analyzing.", "Chris Haroun", 2600f, "Introduction to Finance, Accounting, Modeling and Valuation", 25f },
                    { 6, "1-You will learn and develop the ability to think, read and write abstractly and Mathematically.\r\n 2-You will learn the fundamentals of Set Theory including set builder notation, and set operations and properties.", "Discrete Mathematics (DM), or Discrete Math is the backbone of Mathematics and Computer Science. DM is the study of topics that are discrete rather than continuous, for that, the course is a MUST for any Math or CS student. The topics that are covered in this course are the most essential ones, those that will touch every Math and Science student at some point in their education. ", "Miran Fattah", 1250f, "Discrete Mathematics", 18f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "Courses");
        }
    }
}
