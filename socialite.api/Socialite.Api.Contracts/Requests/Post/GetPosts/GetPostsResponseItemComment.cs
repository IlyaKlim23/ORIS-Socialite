namespace Socialite.Api.Contracts.Requests.Post.GetPosts;

/// <summary>
/// Комментарий
/// </summary>
public class GetPostsResponseItemComment
{
    /// <summary>
    /// Идентификатор комментария
    /// </summary>
    public Guid CommentId { get; set; }

    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Text { get; set; } = default!;

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Владелец
    /// </summary>
    public GetPostsResponseItemUser Owner { get; set; } = default!;
}