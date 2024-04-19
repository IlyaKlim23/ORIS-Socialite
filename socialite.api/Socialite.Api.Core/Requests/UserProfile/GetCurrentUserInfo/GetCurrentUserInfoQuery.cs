using MediatR;
using Socialite.Api.Contracts.Requests.UserProfile.GetCurrentUserInfo;

namespace Socialite.Api.Core.Requests.UserProfile.GetCurrentUserInfo;

/// <summary>
/// Запрос на получение информации о текущем пользователе
/// </summary>
public class GetCurrentUserInfoQuery : IRequest<GetCurrentUserInfoResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId">Пользователь</param>
    public GetCurrentUserInfoQuery(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; set; }
}