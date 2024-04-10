using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using MediatR;
using Socialite.Api.Contracts.Requests.User.RegisterUser;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Extensions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.User.RegisterUser;

/// <summary>
/// Обработчик запроса <see cref="RegisterUserCommand"/>
/// </summary>
public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public RegisterUserCommandHandler(
        IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<RegisterUserResponse> Handle(
        RegisterUserCommand request, 
        CancellationToken cancellationToken)
    {
        var isUserExist = await _userService.FindUserByEmailAsync(request.Email);
        if (isUserExist != null)
            throw new ValidationException("Пользователь с данной почтой уже существует");  
        
        isUserExist = await _userService.FindUserByUserNameAsync(request.UserName);
        if (isUserExist != null)
            throw new ValidationException("Пользователь с данным никнеймом уже существует");
        
        var user = new Entities.User(request.FirstName, request.LastName)
        {
            UserName = request.UserName,
            Email = request.Email
        };
        
        var result = await _userService.RegisterUserAsync(user, request.Password);

        if (result.Succeeded)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Role, Roles.User.ToUpperFirstCharString())
            };

            await _userService.AddUserRoleAsync(user, Roles.User);
            await _userService.AddClaimsAsync(user, claims);
        }
        
        return new RegisterUserResponse(result);
    }
}