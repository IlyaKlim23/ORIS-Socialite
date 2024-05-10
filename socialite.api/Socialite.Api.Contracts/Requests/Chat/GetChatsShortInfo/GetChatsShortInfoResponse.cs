namespace Socialite.Api.Contracts.Requests.Chat.GetChatsShortInfo;

/// <summary>
/// Ответ на запрос на получение короткой информации на чаты
/// </summary>
public class GetChatsShortInfoResponse
{
    public GetChatsShortInfoResponse(List<GetChatsShortInfoResponseItem> items)
    {
        Items = items;
    }

    /// <summary>
    /// Сущности
    /// </summary>
    public List<GetChatsShortInfoResponseItem> Items { get; set; }
}