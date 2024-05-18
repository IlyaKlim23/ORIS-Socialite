namespace Socialite.Api.Contracts.Requests.Chat.GetAllChats;

/// <summary>
/// Ответ на получение всех чатов пользователя
/// </summary>
public class GetAllChatsResponse
{
    public GetAllChatsResponse(List<Guid> chatIds)
    {
        ChatIds = chatIds;
    }

    /// <summary>
    /// Все идентификаторы чатов
    /// </summary>
    public List<Guid> ChatIds { get; set; } = null!;
}