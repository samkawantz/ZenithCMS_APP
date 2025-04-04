using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenithCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class _202526032 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$KuAiIwBXGegLkgLXLu18Eu49Pxxt52t.TkW3wdhwjLUIhvrpJGmUG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$lNidoxI0b9s1SctjjYxiIOyWQXkkmNUqw5pscZazBhFA3Y4fO0WBi");
        }
    }
}
