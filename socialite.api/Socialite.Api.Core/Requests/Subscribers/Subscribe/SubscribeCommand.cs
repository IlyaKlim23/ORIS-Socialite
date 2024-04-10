using MediatR;

namespace Socialite.Api.Core.Requests.Subscribers.Subscribe;

/// <summary>
/// Команда на подписку
/// </summary>
public class SubscribeCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Текущий пользователь</param>
    /// <param name="subscribedToId">Пользователь, на которого нужно подписаться</param>
    public SubscribeCommand(Guid currentUserId, Guid subscribedToId)
    {
        CurrentUserId = currentUserId;
        SubscribedToId = subscribedToId;
    }

    /// <summary>
    /// Текущий пользователь
    /// </summary>
    public Guid CurrentUserId { get; set; }
    
    /// <summary>
    /// Пользователь, на которого нужно подписаться
    /// </summary>
    public Guid SubscribedToId { get; set; }
}