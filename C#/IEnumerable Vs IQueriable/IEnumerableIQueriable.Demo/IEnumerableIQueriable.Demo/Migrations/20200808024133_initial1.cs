using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IEnumerableIQueryable.Demo.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Salary = table.Column<float>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDay", "Department", "Name", "Salary" },
                values: new object[] { 1, new DateTime(2020, 8, 8, 2, 41, 32, 572, DateTimeKind.Utc).AddTicks(5156), "Mobile", "Mona", 7000f });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDay", "Department", "Name", "Salary" },
                values: new object[] { 2, new DateTime(2020, 8, 8, 2, 41, 32, 572, DateTimeKind.Utc).AddTicks(5824), "Web", "Ahmed", 50000f });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDay", "Department", "Name", "Salary" },
                values: new object[] { 3, new DateTime(2020, 8, 8, 2, 41, 32, 572, DateTimeKind.Utc).AddTicks(5847), "IOS", "Khalid", 50000f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
