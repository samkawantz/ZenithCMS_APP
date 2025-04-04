using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenithCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class _202526033 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WhoWeAre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AboutZMC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Vision = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Mission = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CoreValues = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Zomwod5FOLv.fPHmHfgFP.wzIVxvxBz/u6hw4TpRb1txplL6yjDDG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$KuAiIwBXGegLkgLXLu18Eu49Pxxt52t.TkW3wdhwjLUIhvrpJGmUG");
        }
    }
}
