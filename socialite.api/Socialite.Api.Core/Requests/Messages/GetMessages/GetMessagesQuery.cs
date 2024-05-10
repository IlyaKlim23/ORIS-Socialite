using MediatR;
using Socialite.Api.Contracts.Requests.Messages.GetMessages;

namespace Socialite.Api.Core.Requests.Messages.GetMessages;

/// <summary>
/// Команда запроса на получение сообщений
/// </summary>
public class GetMessagesQuery : IRequest<GetMessagesResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="chatId"></param>
    /// <param name="currentUserId"></param>
    public GetMessagesQuery(Guid chatId, Guid currentUserId)
    {
        ChatId = chatId;
        CurrentUserId = currentUserId;
    }

    /// <summary>
    /// Идентификатор текущего пользователя
    /// </summary>
    public Guid CurrentUserId { get; set; }
    
    /// <summary>
    /// Идентификатор чата
    /// </summary>
    public Guid ChatId { get; set; }
}