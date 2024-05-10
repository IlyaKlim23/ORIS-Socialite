using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.Chat.GetChat;
using Socialite.Api.Contracts.Requests.Chat.GetChatsShortInfo;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Entities;
using Socialite.Api.Core.Requests.Chat.GetChat;
using Socialite.Api.Core.Requests.Chat.GetChatsShortInfo;
using Socialite.Api.Web.Attributes;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер <see cref="Chat"/>>
/// </summary>
public class ChatController : BaseController
{
    /// <summary>
    /// Создать чат
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpGet]
    public async Task<GetChatResponse> GetChatAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetChatCommand(CurrentUserId, userId), cancellationToken);

    /// <summary>
    /// Получить чаты
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost("shortInfo")]
    public async Task<GetChatsShortInfoResponse> GetChatsShortInfoAsync(
        [FromServices] IMediator mediator,
        [FromBody] GetChatsShortInfoRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetChatsShortInfoQuery(CurrentUserId, request), cancellationToken);
}