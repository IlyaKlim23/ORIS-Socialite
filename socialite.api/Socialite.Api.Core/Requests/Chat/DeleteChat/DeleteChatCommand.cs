using MediatR;

namespace Socialite.Api.Core.Requests.Chat.DeleteChat;

/// <summary>
/// Команда на удаление чата
/// </summary>
public class DeleteChatCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="chatId">Идентификатор чата</param>
    public DeleteChatCommand(Guid chatId, Guid currentUserId)
    {
        ChatId = chatId;
        CurrentUserId = currentUserId;
    }

    /// <summary>
    /// Текущий пользователь
    /// </summary>
    public Guid CurrentUserId { get; set; }
    
    /// <summary>
    /// Идентификатор чата
    /// </summary>
    public Guid ChatId { get; set; }
}