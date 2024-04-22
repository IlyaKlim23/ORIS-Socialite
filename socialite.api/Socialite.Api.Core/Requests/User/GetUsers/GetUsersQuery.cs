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
    public GetUsersQuery(GetUsersRequest request)
    {
        Request = request;
    }

    /// <summary>
    /// Запрос
    /// </summary>
    public GetUsersRequest Request { get; set; }
}