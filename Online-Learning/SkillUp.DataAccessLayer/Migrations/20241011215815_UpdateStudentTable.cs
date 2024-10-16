using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "SecurityStamp" },
                values: new object[] { "62135f4d-7d5b-4ba6-abf0-a15645f82960", new DateTime(2024, 10, 12, 0, 58, 14, 650, DateTimeKind.Local).AddTicks(588), "c368a039-09c3-4991-b25b-3458a9db4759" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "SecurityStamp" },
                values: new object[] { "9da37fda-d926-4a7d-baaa-e406fa33069f", new DateTime(2024, 10, 12, 0, 58, 14, 650, DateTimeKind.Local).AddTicks(350), "17ec9199-1680-4c4e-9f89-857601047ba3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "SecurityStamp" },
                values: new object[] { "6f146fad-eecd-4888-b4c4-4f933fe678da", new DateTime(2024, 10, 12, 0, 58, 14, 650, DateTimeKind.Local).AddTicks(558), "b202b87c-5e54-4b5d-b8e0-269ca9f27bfc" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "2",
                column: "University",
                value: "Hogwarts Universty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "University",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "SecurityStamp" },
                values: new object[] { "ddf89285-ea9f-4bd4-95be-e7ec98cf21ce", new DateTime(2024, 10, 12, 0, 27, 54, 384, DateTimeKind.Local).AddTicks(8696), "1dc13cb8-b9dd-4936-95f5-b4ba6397009d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "SecurityStamp" },
                values: new object[] { "a8c38ead-ab95-4393-bea3-355d79516649", new DateTime(2024, 10, 12, 0, 27, 54, 384, DateTimeKind.Local).AddTicks(8066), "15985d43-5d3a-454f-afe5-69cf830d42d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "SecurityStamp" },
                values: new object[] { "8ae83ca6-d9f9-40f8-a657-e20482bbc884", new DateTime(2024, 10, 12, 0, 27, 54, 384, DateTimeKind.Local).AddTicks(8490), "5cd83842-88bb-4496-aeaa-9fba42d297a4" });
        }
    }
}
