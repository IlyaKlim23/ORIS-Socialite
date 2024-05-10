using MediatR;
using Socialite.Api.Contracts.Requests.Chat.GetChat;

namespace Socialite.Api.Core.Requests.Chat.GetChat;

/// <summary>
/// Команда на создание чата
/// </summary>
public class GetChatCommand : IRequest<GetChatResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Текущий пользователь</param>
    /// <param name="userId">Второй пользователь в чате</param>
    public GetChatCommand(Guid currentUserId, Guid userId)
    {
        CurrentUserId = currentUserId;
        UserId = userId;
    }

    /// <summary>
    /// Текущий пользователь
    /// </summary>
    public Guid CurrentUserId { get; set; }

    /// <summary>
    /// Второй пользователь в чате
    /// </summary>
    public Guid UserId { get; set; }
}