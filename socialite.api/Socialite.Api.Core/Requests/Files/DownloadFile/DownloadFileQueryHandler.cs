using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Files;
using Socialite.Api.Contracts.Requests.Files.DownloadFile;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;
using Socialite.Api.S3.Interfaces;
using File = Socialite.Api.Core.Entities.File;

namespace Socialite.Api.Core.Requests.Files.DownloadFile;

/// <summary>
/// Обработчик запроса на получение файла
/// </summary>
public class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, DownloadFileResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IS3Service _s3Service;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    /// <param name="s3Service">Сервис для работы с S3</param>
    public DownloadFileQueryHandler(IDbContext dbContext, IS3Service s3Service)
    {
        _dbContext = dbContext;
        _s3Service = s3Service;
    }

    /// <inheritdoc />
    public async Task<DownloadFileResponse> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
    {
        await _s3Service.CheckS3AvailabilityAsync(cancellationToken);

        var file = await _dbContext.Files
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new EntityNotFoundException<File>(request.Id);

        var fileStream = await _s3Service.GetFileFromBucketAsync(file.Id, file.Extension ?? string.Empty, cancellationToken);

        if (fileStream == null)
            throw new Exception("Не удалось получить изображение");
        
        return new DownloadFileResponse(fileStream, file.Extension, file.NameWithoutExtension ?? string.Empty, file.ContentType);
    }
}