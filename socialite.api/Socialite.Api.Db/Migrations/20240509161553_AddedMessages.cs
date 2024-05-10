using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Api.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "messages",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Text = table.Column<string>(type: "text", nullable: false, comment: "Текст сообщения"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата и время создания"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_messages_chats_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "public",
                        principalTable: "chats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_messages_users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id");
                },
                comment: "Сообщения");

            migrationBuilder.CreateIndex(
                name: "IX_messages_ChatId",
                schema: "public",
                table: "messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_messages_OwnerId",
                schema: "public",
                table: "messages",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages",
                schema: "public");
        }
    }
}
