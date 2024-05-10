namespace Socialite.Api.Contracts.Requests.Chat.GetChat;

/// <summary>
/// Ответ на команду создания чата
/// </summary>
public class GetChatResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="chatId">Идентификатор чата</param>
    public GetChatResponse(Guid chatId)
    {
        ChatId = chatId;
    }

    /// <summary>
    /// Идентификатор чата
    /// </summary>
    public Guid ChatId { get; set; }
}