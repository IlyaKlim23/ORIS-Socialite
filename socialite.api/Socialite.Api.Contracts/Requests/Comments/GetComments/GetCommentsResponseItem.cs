namespace Socialite.Api.Contracts.Requests.Comments.GetComments;

public class GetCommentsResponseItem
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
    public GetCommentsResponseUser Owner { get; set; } = default!;
}