using MediatR;
using Socialite.Api.Contracts.Requests.UserProfile.PutCurrentUserInfo;

namespace Socialite.Api.Core.Requests.UserProfile.PutCurrentUserInfo;

public class PutCurrentUserInfoCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request"></param>
    /// <param name="userId"></param>
    public PutCurrentUserInfoCommand(PutCurrentUserInfoRequest request, Guid userId)
    {
        Request = request;
        UserId = userId;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Запрос
    /// </summary>
    public PutCurrentUserInfoRequest Request { get; set; }
}