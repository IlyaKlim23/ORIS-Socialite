using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace Socialite.Api.S3;

/// <summary>
/// Класс настройки S3
/// </summary>
public static class Entry
{
    /// <summary>
    /// Добавить S3
    /// </summary>
    public static IServiceCollection AddS3(
        this IServiceCollection services,
        string? url,
        string? accessKey,
        string? secretKey)
        => services.AddMinio(
                c =>
                {
                    
                    c.WithEndpoint(url);
                    c.WithCredentials(
                        accessKey,
                        secretKey);
                    c.WithSSL(false);
                });
}