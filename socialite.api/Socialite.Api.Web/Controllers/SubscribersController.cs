using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.Subscribers.GetSubscribedTo;
using Socialite.Api.Contracts.Requests.Subscribers.GetSubscribers;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Requests.Subscribers.GetSubscribedTo;
using Socialite.Api.Core.Requests.Subscribers.GetSubscribers;
using Socialite.Api.Core.Requests.Subscribers.Subscribe;
using Socialite.Api.Core.Requests.Subscribers.Unsubscribe;
using Socialite.Api.Web.Attributes;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер системы подписчиков
/// </summary>
public class SubscribersController : BaseController
{
    /// <summary>
    /// Подписаться
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="subscribeToId"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost("subscribe")]
    public async Task SubscribeToAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid subscribeToId,
        CancellationToken cancellationToken)
        => await mediator.Send(new SubscribeCommand(CurrentUserId, subscribeToId), cancellationToken);
    
    /// <summary>
    /// Отписаться
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="unsubscribeToId"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost("unsubscribe")]
    public async Task UnsubscribeToAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid unsubscribeToId,
        CancellationToken cancellationToken)
        => await mediator.Send(new UnsubscribeCommand(CurrentUserId, unsubscribeToId), cancellationToken);
    
    /// <summary>
    /// Получить подписчиков
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("subscribers")]
    public async Task<GetSubscribersResponse> GetSubscribersAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetSubscribersQuery(userId), cancellationToken);
    
    /// <summary>
    /// Получить подписки
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("subscriptions")]
    public async Task<GetSubscribedToResponse> GetSubscribedToAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetSubscribedToQuery(userId), cancellationToken);
}