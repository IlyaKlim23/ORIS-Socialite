using MediatR;
using Socialite.Api.Contracts.Requests.User.RegisterUser;

namespace Socialite.Api.Core.Requests.User.RegisterUser;

/// <summary>
/// Команда запроса <see cref="RegisterUserRequest"/>
/// </summary>
public class RegisterUserCommand: RegisterUserRequest, IRequest<RegisterUserResponse>
{
}