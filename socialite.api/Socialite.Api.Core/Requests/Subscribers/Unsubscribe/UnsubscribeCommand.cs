using MediatR;

namespace Socialite.Api.Core.Requests.Subscribers.Unsubscribe;

/// <summary>
/// Команда запроса на отписку
/// </summary>
public class UnsubscribeCommand: IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Пользователь</param>
    /// <param name="userToUnsubscribeId">Пользователь на отписку</param>
    public UnsubscribeCommand(Guid currentUserId, Guid userToUnsubscribeId)
    {
        CurrentUserId = currentUserId;
        UserToUnsubscribeId = userToUnsubscribeId;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid CurrentUserId { get; set; }
    
    /// <summary>
    /// Пользователь на отписку
    /// </summary>
    public Guid UserToUnsubscribeId { get; set; }
}