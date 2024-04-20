using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Api.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "public",
                table: "files");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "public",
                table: "files");
            
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                schema: "public",
                table: "files",
                type: "bigint",
                nullable: false,
                comment: "Вес");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                schema: "public",
                table: "files",
                type: "text",
                nullable: false,
                comment: "Вес",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Вес");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "public",
                table: "files",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Адрес файла");
        }
    }
}
