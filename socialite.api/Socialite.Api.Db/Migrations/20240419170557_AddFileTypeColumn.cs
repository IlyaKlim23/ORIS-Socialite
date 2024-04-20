using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Api.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFileTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                schema: "public",
                table: "files",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Тип контента");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                schema: "public",
                table: "files");
        }
    }
}
