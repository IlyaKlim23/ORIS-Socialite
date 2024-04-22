using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Core.Interfaces;
using Socialite.Api.S3.Interfaces;

namespace Socialite.Api.Core.Requests.Files.RemoveUnusedFiles;

/// <summary>
/// Обработчик <see cref="RemoveUnusedFilesCommand"/>
/// </summary>
public class RemoveUnusedFilesCommandHandler : IRequestHandler<RemoveUnusedFilesCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IS3Service _s3Service;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    /// <param name="s3Service">Сервис для работы с S3</param>
    public RemoveUnusedFilesCommandHandler(IDbContext dbContext, IS3Service s3Service)
    {
        _dbContext = dbContext;
        _s3Service = s3Service;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveUnusedFilesCommand request, CancellationToken cancellationToken)
    {
        await _s3Service.CheckS3AvailabilityAsync(cancellationToken);

        var filesToDelete = await _dbContext.Files
            .Where(x => x.Posts.Count == 0)
            .Where(x => x.Users == null || x.Users.Count == 0)
            .ToListAsync(cancellationToken);

        foreach (var fileToDelete in filesToDelete)
        {
            await _s3Service.RemoveFileFromBucketAsync(
                fileToDelete.Id,
                fileToDelete.Extension ?? string.Empty,
                cancellationToken);
            
            _dbContext.Files.Remove(fileToDelete);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return default;
    }
}