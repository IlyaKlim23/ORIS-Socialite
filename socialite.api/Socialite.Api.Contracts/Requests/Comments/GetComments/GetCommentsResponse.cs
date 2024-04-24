namespace Socialite.Api.Contracts.Requests.Comments.GetComments;

/// <summary>
/// Ответ на получение комментариев
/// </summary>
public class GetCommentsResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="items"></param>
    /// <param name="count"></param>
    public GetCommentsResponse(List<GetCommentsResponseItem> items, int count)
    {
        Items = items;
        Count = count;
    }

    /// <summary>
    /// Кол-во
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Комменты
    /// </summary>
    public List<GetCommentsResponseItem> Items { get; set; }
}