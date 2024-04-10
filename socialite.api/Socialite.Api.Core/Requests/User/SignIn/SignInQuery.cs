using MediatR;
using Socialite.Api.Contracts.Requests.User.SignIn;

namespace Socialite.Api.Core.Requests.User.SignIn;

/// <summary>
/// Команда запроса <see cref="SignInRequest"/>
/// </summary>
public class SignInQuery: SignInRequest, IRequest<SignInResponse>
{
}