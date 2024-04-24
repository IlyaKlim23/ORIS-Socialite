using MediatR;
using Socialite.Api.Contracts.Requests.User.SignIn;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.User.SignIn;

/// <summary>
/// Обработчик запроса <see cref="SignInQuery"/>
/// </summary>
public class SignInQueryHandler : IRequestHandler<SignInQuery, SignInResponse>
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    /// <param name="jwtService">Сервис для работы с Jwt</param>
    public SignInQueryHandler(
        IUserService userService,
        IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    /// <inheritdoc />>
    public async Task<SignInResponse> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.FindUserByEmailAsync(request.Email);

        if (user == null)
            throw new EntityNotFoundException<Entities.User>("Пользователи не найдены");

        var result = await _userService.SignInWithPasswordAsync(user, request.Password);

        string token = null!;

        if (result.Succeeded)
        {
            var role = await _userService.GetRoleAsync(user);
            token = _jwtService.GenerateJwt(user.Id, role!, user.Email);
        }
        else
        {
            throw new AuthorizationException();
        }

        return new SignInResponse(result, user.Id, user.UserName ?? string.Empty, token);
    }
}