namespace Socialite.Api.Contracts.Requests.Messages.GetMessages;

/// <summary>
/// Ответ на запрос получения сообщения
/// </summary>
public class GetMessagesResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="count"></param>
    /// <param name="items"></param>
    public GetMessagesResponse(int count, List<GetMessagesResponseItem> items)
    {
        Count = count;
        Items = items;
    }

    /// <summary>
    /// Кол-во
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Сообщения
    /// </summary>
    public List<GetMessagesResponseItem> Items { get; set; }
}