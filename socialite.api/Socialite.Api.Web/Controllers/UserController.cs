using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.User.RegisterUser;
using Socialite.Api.Contracts.Requests.User.ResetPassword;
using Socialite.Api.Contracts.Requests.User.SendResetPasswordCode;
using Socialite.Api.Contracts.Requests.User.SignIn;
using Socialite.Api.Core.Requests.User.RegisterUser;
using Socialite.Api.Core.Requests.User.ResetPassword;
using Socialite.Api.Core.Requests.User.SendResetPasswordCode;
using Socialite.Api.Core.Requests.User.SignIn;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер пользователя
/// </summary>
public class UserController : BaseController
{
    /// <summary>
    /// Зарегистрировать пользователя
    /// </summary>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<RegisterUserResponse> RegisterUser(
        [FromServices] IMediator mediator,
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new RegisterUserCommand
        {
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
        }, cancellationToken);

    /// <summary>
    /// Авторизоваться
    /// </summary>
    /// <returns></returns>
    [HttpPost("signIn")]
    public async Task<SignInResponse> SignIn(
        [FromServices] IMediator mediator,
        [FromBody] SignInRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new SignInQuery
        {
            Email = request.Email,
            Password = request.Password,
        }, cancellationToken);
    
    /// <summary>
    /// Отправить код восстановления пароля
    /// </summary>
    /// <param name="mediator">IMediator</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("sendResetPasswordCode")]
    public async Task<SendResetPasswordCodeResponse> SendResetPasswordCode(
        [FromServices] IMediator mediator,
        [FromBody] SendResetPasswordCodeRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new SendResetPasswordQuery
        {
            Email = request.Email
        }, cancellationToken);

    /// <summary>
    /// Сбросить пароль
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("resetPassword")]
    public async Task<ResetPasswordResponse> ResetPasswordByEmail(
        [FromServices] IMediator mediator,
        [FromBody] ResetPasswordRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new ResetPasswordCommand
        {
            Email = request.Email,
            Password = request.Password,
            Code = request.Code,
        }, cancellationToken);
}