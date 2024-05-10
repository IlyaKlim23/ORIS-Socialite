using MediatR;
using Socialite.Api.Contracts.Requests.Chat.GetChatsShortInfo;

namespace Socialite.Api.Core.Requests.Chat.GetChatsShortInfo;

/// <summary>
/// Запрос на получение чатов
/// </summary>
public class GetChatsShortInfoQuery : IRequest<GetChatsShortInfoResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId"></param>
    /// <param name="request"></param>
    public GetChatsShortInfoQuery(Guid currentUserId, GetChatsShortInfoRequest request)
    {
        CurrentUserId = currentUserId;
        Request = request;
    }

    /// <summary>
    /// Текущий пользователь
    /// </summary>
    public Guid CurrentUserId { get; set; }
    
    /// <summary>
    /// Запрос
    /// </summary>
    public GetChatsShortInfoRequest Request { get; set; }
}