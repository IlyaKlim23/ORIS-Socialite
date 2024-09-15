namespace Socialite.Api.Contracts.Requests.Comments.PostComment;

/// <summary>
/// Ответ на запрос добавления комментария к посту
/// </summary>
public class PostCommentResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="item">Идентификатор комментария</param>
    public PostCommentResponse(GetCommentsResponseItem item)
    {
        Item = item;
    }

    /// <summary>
    /// Созданная сущность
    /// </summary>
    public GetCommentsResponseItem Item { get; set; }
}