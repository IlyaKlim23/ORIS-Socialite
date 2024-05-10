using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Api.Core.Entities;

namespace Socialite.Api.Db.Configuration;

/// <summary>
/// Конфигурация <see cref="Chat"/>
/// </summary>
internal class ChatConfiguration : EntityBaseConfiguration<Chat>
{
    /// <inheritdoc />
    protected override void ConfigureChild(EntityTypeBuilder<Chat> builder)
    {
        builder.ToTable("chats", "public")
            .HasComment("Чаты");

        builder.HasMany(x => x.Messages)
            .WithOne(x => x.Chat)
            .HasForeignKey(x => x.ChatId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.ClientCascade);
        
        builder.HasMany(x => x.Users)
            .WithMany(x => x.Chats)
            .UsingEntity(builder =>
                builder.ToTable("user_chats", "public")
                    .HasComment("Пользователи-чаты"));
    }
}