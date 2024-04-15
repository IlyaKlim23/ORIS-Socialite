using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Api.Core.Entities;

namespace Socialite.Api.Db.Configuration;

/// <summary>
/// Конфигурация <see cref="Comment"/>
/// </summary>
internal class CommentConfiguration : EntityBaseConfiguration<Comment>
{
    /// <inheritdoc />
    protected override void ConfigureChild(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments", "public")
            .HasComment("Комментарии");

        builder.Property(p => p.CreateDate)
            .HasComment("Дата и время создания");

        builder.Property(p => p.Text)
            .HasComment("Текст комментария");

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.OwnerId)
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.Post)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.PostId)
            .HasPrincipalKey(x => x.Id);
    }
}