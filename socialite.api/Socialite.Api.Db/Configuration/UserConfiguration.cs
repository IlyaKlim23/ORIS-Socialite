using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Api.Core.Entities;

namespace Socialite.Api.Db.Configuration;

/// <summary>
/// Конфигурация для <see cref="User"/>>
/// </summary>
internal class UserConfiguration: IEntityTypeConfiguration<User>
{
    private const string GuidCommand = "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)";

    /// <summary>
    /// Конфигурация сущности
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", "public")
            .HasComment("Пользователи");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasDefaultValueSql(GuidCommand);
        
        builder.Property(p => p.UserName)
            .HasComment("Никнейм");
        
        builder.Property(p => p.FirstName)
            .HasComment("Имя");
        
        builder.Property(p => p.LastName)
            .HasComment("Фамилия");
        
        builder.Property(p => p.Email)
            .HasComment("Почта");
        
        builder.Property(p => p.PlaceOfLiving)
            .HasComment("Место жительства");
        
        builder.Property(p => p.PlaceOfWork)
            .HasComment("Место работы");
        
        builder.Property(p => p.PlaceOfStudy)
            .HasComment("Место учебы");
        
        builder.Property(p => p.Status)
            .HasComment("Статус");
        
        builder.HasMany(x => x.Subscribers)
            .WithMany(x => x.SubscribedTo)
            .UsingEntity(builder =>
                builder.ToTable("user_subscriber", "public")
                    .HasComment("Пользователь-Подписчик"));
    }
}