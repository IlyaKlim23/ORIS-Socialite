using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.UserProfile.GetUserInfo;
using Socialite.Api.Contracts.Requests.UserProfile.PutCurrentUserInfo;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Requests.UserProfile.GetUserInfo;
using Socialite.Api.Core.Requests.UserProfile.PutCurrentUserInfo;
using Socialite.Api.Web.Attributes;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер для работы с профилем пользователя
/// </summary>
public class UserProfilesController : BaseController
{
    /// <summary>
    /// Получить информацию о пользователе
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpGet]
    public async Task<GetUserInfoResponse> GetUserInfoAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid? userId,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetUserInfoQuery(userId ?? CurrentUserId, CurrentUserId), cancellationToken);

    /// <summary>
    /// Обновить информацию о текущем пользователе
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPut("currentUserInfo")]
    public async Task PutCurrentUserInfoAsync(
        [FromServices] IMediator mediator,
        [FromBody] PutCurrentUserInfoRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new PutCurrentUserInfoCommand(request, CurrentUserId), cancellationToken);
}