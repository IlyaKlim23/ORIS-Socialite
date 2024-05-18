using MediatR;
using Socialite.Api.Contracts.Requests.Chat.GetAllChats;

namespace Socialite.Api.Core.Requests.Chat.GetAllChats;

public class GetAllChatsQuery : IRequest<GetAllChatsResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Идентификатор пользователя</param>
    public GetAllChatsQuery(Guid currentUserId)
    {
        CurrentUserId = currentUserId;
    }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid CurrentUserId { get; set; }
}