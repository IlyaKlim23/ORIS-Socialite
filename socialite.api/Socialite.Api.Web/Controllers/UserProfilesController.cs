using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.UserProfile.GetCurrentUserInfo;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Requests.UserProfile.GetCurrentUserInfo;
using Socialite.Api.Web.Attributes;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер для работы с профилем пользователя
/// </summary>
public class UserProfilesController : BaseController
{
    /// <summary>
    /// Получить информацию о текущем пользователе
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpGet("currentUserInfo")]
    public async Task<GetCurrentUserInfoResponse> GetCurrentUserInfoAsync(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetCurrentUserInfoQuery(CurrentUserId), cancellationToken);
}