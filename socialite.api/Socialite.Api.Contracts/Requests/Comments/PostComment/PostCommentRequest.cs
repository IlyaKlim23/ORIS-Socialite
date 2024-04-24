namespace Socialite.Api.Contracts.Requests.Comments.PostComment;

/// <summary>
/// Запрос на создание комментария
/// </summary>
public class PostCommentRequest
{
    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Text { get; set; } = default!;
}