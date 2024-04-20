using MediatR;
using Microsoft.AspNetCore.Http;
using Socialite.Api.Contracts.Requests.Files.UploadFiles;

namespace Socialite.Api.Core.Requests.Files.UploadFiles;

/// <summary>
/// Команда на загрузку файлов
/// </summary>
public class UploadFilesCommand : IRequest<UploadFilesResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="files">Файлы</param>
    public UploadFilesCommand(List<IFormFile> files)
    {
        Files = files;
    }

    /// <summary>
    /// Файлы
    /// </summary>
    public List<IFormFile> Files { get; set; }
}