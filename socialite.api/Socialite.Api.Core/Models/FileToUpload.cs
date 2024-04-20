namespace Socialite.Api.Core.Models;

/// <summary>
/// Модель файла для записи
/// </summary>
public class FileToUpload
{
    /// <summary>
    /// Запись файла
    /// </summary>
    public Stream FileStream { get; set; }

    /// <summary>
    /// Имя файла
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Тип содержимого/Mime-type
    /// </summary>
    public string ContentType { get; set; } = default!;
}