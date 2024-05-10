using Socialite.Api.Core.Entities;
using File = Socialite.Api.Core.Entities.File;

namespace Socialite.Api.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Контекст EF Core для приложения
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Файлы
    /// </summary>
    public DbSet<File> Files { get; set; }

    /// <summary>
    /// Посты
    /// </summary>
    public DbSet<Post> Posts { get; set; }

    /// <summary>
    /// Комментарии
    /// </summary>
    public DbSet<Comment> Comments { get; set; }

    /// <summary>
    /// Чаты
    /// </summary>
    public DbSet<Chat> Chats { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public DbSet<Message> Messages { get; set; }
    
    /// <summary>
    /// Сохранить изменения в БД
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Количество обновленных записей</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}