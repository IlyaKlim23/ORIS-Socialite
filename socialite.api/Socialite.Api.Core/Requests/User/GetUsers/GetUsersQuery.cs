using MediatR;
using Socialite.Api.Contracts.Requests.User.GetUsers;

namespace Socialite.Api.Core.Requests.User.GetUsers;

/// <summary>
/// Запрос на получение пользователей
/// </summary>
public class GetUsersQuery : IRequest<GetUsersResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request"></param>
    /// <param name="currentUserId"></param>
    public GetUsersQuery(GetUsersRequest request, Guid currentUserId)
    {
        Request = request;
        CurrentUserId = currentUserId;
    }

    /// <summary>
    /// Текущий пользователь
    /// </summary>
    public Guid CurrentUserId { get; set; }
    
    /// <summary>
    /// Запрос
    /// </summary>
    public GetUsersRequest Request { get; set; }
}