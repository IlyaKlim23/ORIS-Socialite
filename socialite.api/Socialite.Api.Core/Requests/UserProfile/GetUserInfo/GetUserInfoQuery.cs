using MediatR;
using Socialite.Api.Contracts.Requests.UserProfile.GetUserInfo;

namespace Socialite.Api.Core.Requests.UserProfile.GetUserInfo;

/// <summary>
/// Запрос на получение информации о текущем пользователе
/// </summary>
public class GetUserInfoQuery : IRequest<GetUserInfoResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId">Пользователь</param>
    /// <param name="currentUserId"></param>
    public GetUserInfoQuery(Guid userId, Guid currentUserId)
    {
        UserId = userId;
        CurrentUserId = currentUserId;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Идентификатор текущего пользователя
    /// </summary>
    public Guid CurrentUserId { get; set; }
}