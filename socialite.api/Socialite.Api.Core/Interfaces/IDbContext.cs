namespace Socialite.Api.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Контекст EF Core для приложения
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Сохранить изменения в БД
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Количество обновленных записей</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}