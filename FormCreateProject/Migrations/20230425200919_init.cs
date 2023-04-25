using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormCreateProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CretedBy = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentQuestion",
                columns: table => new
                {
                    ContentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentQuestion", x => new { x.ContentsId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_ContentQuestion_Contents_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DataType", "Name", "Required" },
                values: new object[,]
                {
                    { new Guid("446f656e-12cf-442b-af66-e5f59aa923ee"), "DATETIME", "Doğum Tarihi", false },
                    { new Guid("73d629fc-e9f7-4252-adfc-ad25af3c51e5"), "STRING", "Telefon", false },
                    { new Guid("927497fc-b604-44cc-a8c1-7a6d2a9bcda2"), "STRING", "Soyad", true },
                    { new Guid("95b2e335-e208-4650-9005-04e89d3c1134"), "STRING", "Ad", true },
                    { new Guid("a05c7265-cd9f-42eb-8f8b-285f57d2a214"), "NUMBER", "Yaş", false },
                    { new Guid("f5ee8d42-c449-4671-a191-8564117a6e21"), "STRING", "E-posta", false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Name", "Password" },
                values: new object[] { new Guid("206e12c8-9ed3-4751-9868-95888a220a02"), "Büşra", "Yumuşakkaya", "BusraYumusakkaya", "Busra123." });

            migrationBuilder.CreateIndex(
                name: "IX_ContentQuestion_QuestionsId",
                table: "ContentQuestion",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_FormId",
                table: "Contents",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentQuestion");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
