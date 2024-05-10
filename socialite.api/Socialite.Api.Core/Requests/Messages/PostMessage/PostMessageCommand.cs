using MediatR;
using Socialite.Api.Contracts.Requests.Messages.PostMessage;

namespace Socialite.Api.Core.Requests.Messages.PostMessage;

/// <summary>
/// Команда запроса на создание сообщения
/// </summary>
public class PostMessageCommand : IRequest<PostMessageResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="chatId">Идентификатор чата</param>
    /// <param name="currentUserId">Идентификатор текущего пользователя</param>
    /// <param name="request">Запрос</param>
    public PostMessageCommand(Guid chatId, Guid currentUserId, PostMessageRequest request)
    {
        ChatId = chatId;
        Request = request;
        CurrentUserId = currentUserId;
    }

    /// <summary>
    /// Идентификатор чата
    /// </summary>
    public Guid ChatId { get; set; }

    /// <summary>
    /// Идентификатор текущего пользователя
    /// </summary>
    public Guid CurrentUserId { get; set; }
    
    /// <summary>
    /// Запрос
    /// </summary>
    public PostMessageRequest Request { get; set; }
}