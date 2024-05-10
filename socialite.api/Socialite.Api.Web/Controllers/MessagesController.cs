using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.Messages.GetMessages;
using Socialite.Api.Contracts.Requests.Messages.PostMessage;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Requests.Messages.GetMessages;
using Socialite.Api.Core.Requests.Messages.PostMessage;
using Socialite.Api.Web.Attributes;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер сообщения
/// </summary>
public class MessagesController : BaseController
{
    /// <summary>
    /// Создать сообщение
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="chatId"></param>
    /// <param name="request"></param>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost]
    public async Task<PostMessageResponse> PostMessageAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid chatId,
        [FromBody] PostMessageRequest request)
        => await mediator.Send(new PostMessageCommand(chatId, CurrentUserId, request));

    /// <summary>
    /// Получить сообщения
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="chatId"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpGet]
    public async Task<GetMessagesResponse> GetMessagesAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid chatId)
        => await mediator.Send(new GetMessagesQuery(chatId, CurrentUserId));
}