namespace Socialite.Api.Contracts.Requests.Post.GetPosts;

/// <summary>
/// Пост
/// </summary>
public class GetPostsResponseItem
{
    /// <summary>
    /// Идентификатор поста
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    /// Создатель
    /// </summary>
    public GetPostsResponseItemUser Owner { get; set; } = default!;
    
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Кол-во лайков
    /// </summary>
    public int LikesCount { get; set; }

    /// <summary>
    /// Файлы
    /// </summary>
    public List<GetPostsResponseItemFile> Files { get; set; } = default!;
    
    /// <summary>
    /// Кол-во комментариев
    /// </summary>
    public int CommentsCount { get; set; }
}