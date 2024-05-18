using MediatR;
using Socialite.Api.Contracts.Requests.Subscribers.GetFriendsByUser;

namespace Socialite.Api.Core.Requests.Subscribers.GetFriendsByUser;

/// <summary>
/// Запрос на получение друзей
/// </summary>
public class GetFriendsByUserQuery : IRequest<GetFriendsByUserResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId"></param>
    public GetFriendsByUserQuery(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; set; }
}