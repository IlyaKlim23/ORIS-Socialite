using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Api.Db.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "public",
                table: "users",
                type: "integer",
                nullable: true,
                comment: "Гендер",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                schema: "public",
                table: "users",
                type: "integer",
                nullable: true,
                comment: "Семейное положение");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "public",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "public",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "Гендер");
        }
    }
}
