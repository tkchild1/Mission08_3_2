using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mission08_3_2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskName = table.Column<string>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Quadrant = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskItemId);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Home" },
                    { 2, "School" },
                    { 3, "Work" },
                    { 4, "Church" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskItemId", "CategoryId", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pay bills" },
                    { 2, 2, false, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Study for exam" },
                    { 3, 1, false, null, 2, "Plan family vacation" },
                    { 4, 3, false, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Finish project proposal" },
                    { 5, 3, false, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Reply to emails" },
                    { 6, 1, false, null, 4, "Browse social media" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
