using MediatR;
using Socialite.Api.Contracts.Requests.Files;
using Socialite.Api.Contracts.Requests.Files.DownloadFile;

namespace Socialite.Api.Core.Requests.Files.DownloadFile;

/// <summary>
/// Скачать файл
/// </summary>
public class DownloadFileQuery : IRequest<DownloadFileResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Файл</param>
    public DownloadFileQuery(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Файл
    /// </summary>
    public Guid Id { get; set; }
}