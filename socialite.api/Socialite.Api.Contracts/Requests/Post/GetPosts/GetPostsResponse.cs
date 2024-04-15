namespace Socialite.Api.Contracts.Requests.Post.GetPosts;

/// <summary>
/// Ответ на запрос получения постов
/// </summary>
public class GetPostsResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="count">Кол-во записей</param>
    /// <param name="posts">Посты</param>
    public GetPostsResponse(int count, List<GetPostsResponseItem> posts)
    {
        Count = count;
        Posts = posts;
    }

    /// <summary>
    /// Кол-во записей
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Посты
    /// </summary>
    public List<GetPostsResponseItem> Posts { get; set; }
}