namespace Socialite.Api.Contracts.Requests.Comments.PostComment;

/// <summary>
/// Ответ на запрос добавления комментария к посту
/// </summary>
public class PostCommentResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="commentId">Идентификатор комментария</param>
    public PostCommentResponse(Guid commentId)
    {
        CommentId = commentId;
    }

    /// <summary>
    /// Идентификатор комментария
    /// </summary>
    public Guid CommentId { get; set; }
}