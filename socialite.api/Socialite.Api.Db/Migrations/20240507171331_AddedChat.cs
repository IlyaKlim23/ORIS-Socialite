using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Api.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chats",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.Id);
                },
                comment: "Чаты");

            migrationBuilder.CreateTable(
                name: "user_chats",
                schema: "public",
                columns: table => new
                {
                    ChatsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_chats", x => new { x.ChatsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_user_chats_chats_ChatsId",
                        column: x => x.ChatsId,
                        principalSchema: "public",
                        principalTable: "chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_chats_users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Пользователи-чаты");

            migrationBuilder.CreateIndex(
                name: "IX_user_chats_UsersId",
                schema: "public",
                table: "user_chats",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_chats",
                schema: "public");

            migrationBuilder.DropTable(
                name: "chats",
                schema: "public");
        }
    }
}
