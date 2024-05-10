using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Core.Entities;
using Socialite.Api.Core.Interfaces;
using Socialite.Api.Db.Extensions;
using File = Socialite.Api.Core.Entities.File;

namespace Socialite.Api.Db;

/// <summary>
/// Контекст EF Core для приложения
/// </summary>
public class EfContext: IdentityDbContext<User, Role, Guid>, IDbContext
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="options">Параметры подключения к БД</param>
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    /// <summary>
    /// Добавление моделей при запуске
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
    }

    /// <inheritdoc />
    public DbSet<File> Files { get; set; }

    /// <inheritdoc />
    public DbSet<Post> Posts { get; set; }

    /// <inheritdoc />
    public DbSet<Comment> Comments { get; set; }

    /// <inheritdoc />
    public DbSet<Chat> Chats { get; set; }

    /// <inheritdoc />
    public DbSet<Message> Messages { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await SaveChangesAsync(true, cancellationToken);
}