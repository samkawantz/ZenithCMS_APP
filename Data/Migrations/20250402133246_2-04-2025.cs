using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenithCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2042025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$tn.LwXgTmvqY6lPoqj.jL.G..fIcPj/Vl.Se/5uhpACIz6pndTsZi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Zomwod5FOLv.fPHmHfgFP.wzIVxvxBz/u6hw4TpRb1txplL6yjDDG");
        }
    }
}
