namespace Socialite.Api.Contracts.Requests.Files.UploadFiles;

/// <summary>
/// Ответ на команду загрузки файла
/// </summary>
public class UploadFilesResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="files">Файлы</param>
    public UploadFilesResponse(Dictionary<string, Guid> files)
    {
        Files = files;
    }

    /// <summary>
    /// Файлы
    /// </summary>
    public Dictionary<string, Guid> Files { get; set; }
}