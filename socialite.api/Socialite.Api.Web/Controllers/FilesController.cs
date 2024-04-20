using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.Files.UploadFiles;
using Socialite.Api.Core.Requests.Files.DownloadFile;
using Socialite.Api.Core.Requests.Files.UploadFiles;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер для работы с файлами
/// </summary>
public class FilesController : BaseController
{
    /// <summary>
    /// Загрузить файлы
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="files"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<UploadFilesResponse> UploadFilesAsync(
        [FromServices] IMediator mediator,
        [FromForm] List<IFormFile> files,
        CancellationToken cancellationToken)
        => await mediator.Send(new UploadFilesCommand(files), cancellationToken);

    /// <summary>
    /// Скачать файл
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="fileId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<FileStreamResult?> DownloadFileAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid fileId,
        CancellationToken cancellationToken)
    {
        var file = await mediator.Send(new DownloadFileQuery(fileId), cancellationToken);
        return new FileStreamResult(file.Content, file.ContentType);
    }
}