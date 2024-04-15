namespace Socialite.Api.Contracts.Requests.Post.CreatePost;

/// <summary>
/// Ответ на запрос создания поста
/// </summary>
public class CreatePostResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="postId">Идентификатор</param>
    public CreatePostResponse(Guid postId)
    {
        PostId = postId;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid PostId { get; set; }
}