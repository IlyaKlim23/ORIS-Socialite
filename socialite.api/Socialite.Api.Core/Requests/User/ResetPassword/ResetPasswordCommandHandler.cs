using MediatR;
using Microsoft.AspNetCore.Identity;
using Socialite.Api.Contracts.Requests.User.ResetPassword;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.User.ResetPassword;

/// <summary>
/// Обработчик запроса <see cref="ResetPasswordCommand"/>
/// </summary>
public class ResetPasswordCommandHandler
    : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService"></param>
    public ResetPasswordCommandHandler(IUserService userService)
        => _userService = userService;

    /// <inheritdoc />
    public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.FindUserByEmailAsync(request.Email)
            ?? throw new EntityNotFoundException<Entities.User>($"Не найдены пользователи со следующим email: {request.Email}");

        IdentityResult result;
        try
        {
            result = await _userService.SetPasswordWithEmailAsync(user, request.Code, request.Password);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return new ResetPasswordResponse(result);
    }
}