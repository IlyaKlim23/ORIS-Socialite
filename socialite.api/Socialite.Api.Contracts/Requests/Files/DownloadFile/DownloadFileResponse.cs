namespace Socialite.Api.Contracts.Requests.Files.DownloadFile;

/// <summary>
/// Ответ на запрос скачивания файла
/// </summary>
public class DownloadFileResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="content">Данные файла</param>
    /// <param name="fileType">Тип файла</param>
    /// <param name="fileName">Название</param>
    /// <param name="contentType">Тип контента</param>
    public DownloadFileResponse(
        Stream content,
        string? fileType,
        string fileName,
        string contentType)
    {
        Content = content;
        FileType = fileType;
        FileName = fileName;
        ContentType = contentType;
    }

    /// <summary>
    /// Данные файла
    /// </summary>
    public Stream Content { get; set; }
    
    /// <summary>
    /// Тип файла
    /// </summary>
    public string? FileType { get; set; }
    
    /// <summary>
    /// Тип контента
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string FileName { get; set; }
}