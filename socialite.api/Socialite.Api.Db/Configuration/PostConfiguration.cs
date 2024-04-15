using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Api.Core.Entities;

namespace Socialite.Api.Db.Configuration;

/// <summary>
/// Конфигурация <see cref="Post"/>
/// </summary>
internal class PostConfiguration : EntityBaseConfiguration<Post>
{
    /// <inheritdoc />
    protected override void ConfigureChild(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("posts", "public")
            .HasComment("Посты");

        builder.Property(p => p.Description)
            .HasComment("Описание");

        builder.Property(p => p.CreateDate)
            .HasComment("Дата и время создания");

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.CreatedPosts)
            .HasForeignKey(x => x.OwnerId)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId)
            .HasPrincipalKey(x => x.Id);
        
        builder.HasMany(x => x.LikedUsers)
            .WithMany(x => x.LikedPosts)
            .UsingEntity(builder =>
                builder.ToTable("user_likedPosts", "public")
                    .HasComment("Пользователь-Лайкнутые Посты"));

        builder.HasMany(x => x.Files)
            .WithMany(x => x.Posts)
            .UsingEntity(builder =>
                builder.ToTable("post_Files", "public")
                    .HasComment("Пост-Файлы"));
    }
}