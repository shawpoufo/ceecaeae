using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artisanal.Services.CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminPwdHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "�iv�A���M�߱g��s�K��o*�H�");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "AQAAAAIAAYagAAAAED2hJqZNSOWgKxCfGQNl4jX/Wb3tVeMC/xGNjnyhcx/cT7XEd2NmE4U8epOsv478sQ==");
        }
    }
}
