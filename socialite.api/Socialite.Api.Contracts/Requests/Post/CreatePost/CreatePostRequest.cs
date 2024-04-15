namespace Socialite.Api.Contracts.Requests.Post.CreatePost;

/// <summary>
/// Создать пост
/// </summary>
public class CreatePostRequest
{
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Файлы
    /// </summary>
    public List<Guid>? FileIds { get; set; }
}