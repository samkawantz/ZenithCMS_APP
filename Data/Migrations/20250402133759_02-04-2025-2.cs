using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenithCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class _020420252 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDetail",
                table: "ProjectDetail");

            migrationBuilder.RenameTable(
                name: "ProjectDetail",
                newName: "ProjectDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDetails",
                table: "ProjectDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$tHuFSj/17J1AnBBuGyxSSeCAdn0aW4XWnHC7WjakfGdQfWese6kua");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDetails",
                table: "ProjectDetails");

            migrationBuilder.RenameTable(
                name: "ProjectDetails",
                newName: "ProjectDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDetail",
                table: "ProjectDetail",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$fvsSacIPv7GtJartUKLWee1I/Y4J9iQ9cx1jBj.mRaIzmGW8W6ysu");
        }
    }
}
