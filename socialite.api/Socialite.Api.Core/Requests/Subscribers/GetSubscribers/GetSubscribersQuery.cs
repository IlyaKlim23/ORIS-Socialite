using MediatR;
using Socialite.Api.Contracts.Requests.Subscribers.GetSubscribers;

namespace Socialite.Api.Core.Requests.Subscribers.GetSubscribers;

/// <summary>
/// Запрос получения подписчиков 
/// </summary>
public class GetSubscribersQuery: GetSubscribersRequest, IRequest<GetSubscribersResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    public GetSubscribersQuery(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
}