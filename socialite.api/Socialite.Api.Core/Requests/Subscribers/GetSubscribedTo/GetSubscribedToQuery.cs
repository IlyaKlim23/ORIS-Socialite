using MediatR;
using Socialite.Api.Contracts.Requests.Subscribers.GetSubscribedTo;

namespace Socialite.Api.Core.Requests.Subscribers.GetSubscribedTo;

/// <summary>
/// Запрос на получение пользователей, на которых подписан текущий пользователь
/// </summary>
public class GetSubscribedToQuery: GetSubscribedToRequest, IRequest<GetSubscribedToResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    public GetSubscribedToQuery(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
}