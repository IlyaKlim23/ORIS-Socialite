using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Api.Core.Entities;

namespace Socialite.Api.Db.Configuration;

/// <summary>
/// Конфигурация сообщения
/// </summary>
internal class MessageConfiguration : EntityBaseConfiguration<Message>
{
    /// <inheritdoc />
    protected override void ConfigureChild(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("messages", "public")
            .HasComment("Сообщения");

        builder.Property(x => x.Text)
            .HasComment("Текст сообщения");

        builder.Property(x => x.CreatedAt)
            .HasComment("Дата и время создания");

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.OwnerId)
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.Chat)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ChatId)
            .HasPrincipalKey(x => x.Id);
    }
}