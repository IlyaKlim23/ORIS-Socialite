using MediatR;
using Socialite.Api.Contracts.Requests.Files.UploadFiles;
using Socialite.Api.Core.Interfaces;
using Socialite.Api.Core.Managers;
using Socialite.Api.S3.Interfaces;
using File = Socialite.Api.Core.Entities.File;

namespace Socialite.Api.Core.Requests.Files.UploadFiles;

/// <summary>
/// Обработчик на загрузку файлов
/// </summary>
public class UploadFilesCommandHandler : IRequestHandler<UploadFilesCommand, UploadFilesResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IS3Service _s3Service;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    /// <param name="s3Service">Сервис для работы с S3</param>
    public UploadFilesCommandHandler(IDbContext dbContext, IS3Service s3Service)
    {
        _dbContext = dbContext;
        _s3Service = s3Service;
    }

    /// <inheritdoc />
    public async Task<UploadFilesResponse> Handle(UploadFilesCommand request, CancellationToken cancellationToken)
    {
        var filesToAdd = FileManager.GetFilesStreamEnumerable(request.Files).ToList();

        var result = new Dictionary<string, Guid>();
        foreach (var file in filesToAdd)
        {
            var fileToAdd = new File(file.Name ?? string.Empty, file.FileStream.Length, file.ContentType);
            _dbContext.Files.Add(fileToAdd);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await _s3Service.AddFileInBucketAsync(file.FileStream, fileToAdd.Id, fileToAdd.Extension ?? string.Empty, cancellationToken);
            result[file.Name ?? fileToAdd.Id.ToString()] = fileToAdd.Id;
        }

        return new UploadFilesResponse(result);
    }
}