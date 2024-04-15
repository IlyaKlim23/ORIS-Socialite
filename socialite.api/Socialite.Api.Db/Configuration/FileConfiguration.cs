using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Socialite.Api.Core.Entities.File;

namespace Socialite.Api.Db.Configuration;

/// <summary>
/// Конфигурация <see cref="File"/>
/// </summary>
internal class FileConfiguration : EntityBaseConfiguration<File>
{
    /// <inheritdoc />
    protected override void ConfigureChild(EntityTypeBuilder<File> builder)
    {
        builder.ToTable("files", "public")
            .HasComment("Файлы");
        
        builder.Property(p => p.Name)
            .HasComment("Наименование файла");
        
        builder.Property(p => p.Address)
            .HasComment("Адрес файла");
        
        builder.Property(p => p.Weight)
            .HasComment("Вес");

        builder.HasMany(x => x.Users)
            .WithOne(x => x.Avatar)
            .HasForeignKey(x => x.AvatarId)
            .HasPrincipalKey(x => x.Id);
        
        builder.HasMany(x => x.Posts)
            .WithMany(x => x.Files)
            .UsingEntity(builder =>
                builder.ToTable("post_Files", "public")
                    .HasComment("Пост-Файлы"));
    }
}