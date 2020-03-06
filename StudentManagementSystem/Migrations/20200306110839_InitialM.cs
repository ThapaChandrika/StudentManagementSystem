using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StudentManagementSystem.Migrations
{
    public partial class InitialM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scholarship",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scholarship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    ScholarshipId = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Scholarship_ScholarshipId",
                        column: x => x.ScholarshipId,
                        principalTable: "Scholarship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_FacultyId",
                table: "Student",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ScholarshipId",
                table: "Student",
                column: "ScholarshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Scholarship");
        }
    }
}
