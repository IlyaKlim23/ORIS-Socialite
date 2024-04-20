using Microsoft.AspNetCore.Http;
using Socialite.Api.Core.Models;

namespace Socialite.Api.Core.Managers;

/// <summary>
/// Менеджер файлов
/// </summary>
public class FileManager
{
    /// <summary>
    /// Получить записи файлов
    /// </summary>
    /// <param name="formFiles"></param>
    /// <returns></returns>
    public static IEnumerable<FileToUpload> GetFilesStreamEnumerable(List<IFormFile> formFiles)
    {
        ArgumentNullException.ThrowIfNull(formFiles);

        foreach (var file in formFiles)
            yield return new FileToUpload
            {
                FileStream = file.OpenReadStream(),
                Name = file.FileName,
                ContentType = file.ContentType
            };
    }
}