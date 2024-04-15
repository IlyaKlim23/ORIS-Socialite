using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Api.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AvatarId",
                schema: "public",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                schema: "public",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "files",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование файла"),
                    Address = table.Column<string>(type: "text", nullable: false, comment: "Адрес файла"),
                    Weight = table.Column<string>(type: "text", nullable: false, comment: "Вес"),
                    NameWithoutExtension = table.Column<string>(type: "text", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.Id);
                },
                comment: "Файлы");

            migrationBuilder.CreateTable(
                name: "posts",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "Описание"),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата и время создания"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id");
                },
                comment: "Посты");

            migrationBuilder.CreateTable(
                name: "comments",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата и время создания"),
                    Text = table.Column<string>(type: "text", nullable: false, comment: "Текст комментария"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "public",
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id");
                },
                comment: "Комментарии");

            migrationBuilder.CreateTable(
                name: "post_Files",
                schema: "public",
                columns: table => new
                {
                    FilesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_Files", x => new { x.FilesId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_post_Files_files_FilesId",
                        column: x => x.FilesId,
                        principalSchema: "public",
                        principalTable: "files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_Files_posts_PostsId",
                        column: x => x.PostsId,
                        principalSchema: "public",
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Пост-Файлы");

            migrationBuilder.CreateTable(
                name: "user_likedPosts",
                schema: "public",
                columns: table => new
                {
                    LikedPostsId = table.Column<Guid>(type: "uuid", nullable: false),
                    LikedUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_likedPosts", x => new { x.LikedPostsId, x.LikedUsersId });
                    table.ForeignKey(
                        name: "FK_user_likedPosts_posts_LikedPostsId",
                        column: x => x.LikedPostsId,
                        principalSchema: "public",
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_likedPosts_users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Пользователь-Лайкнутые Посты");

            migrationBuilder.CreateIndex(
                name: "IX_users_AvatarId",
                schema: "public",
                table: "users",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_OwnerId",
                schema: "public",
                table: "comments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_PostId",
                schema: "public",
                table: "comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_post_Files_PostsId",
                schema: "public",
                table: "post_Files",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_OwnerId",
                schema: "public",
                table: "posts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_user_likedPosts_LikedUsersId",
                schema: "public",
                table: "user_likedPosts",
                column: "LikedUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_files_AvatarId",
                schema: "public",
                table: "users",
                column: "AvatarId",
                principalSchema: "public",
                principalTable: "files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_files_AvatarId",
                schema: "public",
                table: "users");

            migrationBuilder.DropTable(
                name: "comments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "post_Files",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_likedPosts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "files",
                schema: "public");

            migrationBuilder.DropTable(
                name: "posts",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_users_AvatarId",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "public",
                table: "users");
        }
    }
}
