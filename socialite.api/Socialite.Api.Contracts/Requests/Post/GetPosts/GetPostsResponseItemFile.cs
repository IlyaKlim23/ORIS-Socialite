namespace Socialite.Api.Contracts.Requests.Post.GetPosts;

/// <summary>
/// Файл
/// </summary>
public class GetPostsResponseItemFile
{
    /// <summary>
    /// Идентификатор файла
    /// </summary>
    public Guid FileId { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = default!;
}