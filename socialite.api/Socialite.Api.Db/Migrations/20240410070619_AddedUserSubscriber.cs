using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Api.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserSubscriber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_subscriber",
                schema: "public",
                columns: table => new
                {
                    SubscribedToId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscribersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_subscriber", x => new { x.SubscribedToId, x.SubscribersId });
                    table.ForeignKey(
                        name: "FK_user_subscriber_users_SubscribedToId",
                        column: x => x.SubscribedToId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_subscriber_users_SubscribersId",
                        column: x => x.SubscribersId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Пользователь-Подписчик");

            migrationBuilder.CreateIndex(
                name: "IX_user_subscriber_SubscribersId",
                schema: "public",
                table: "user_subscriber",
                column: "SubscribersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_subscriber",
                schema: "public");
        }
    }
}
