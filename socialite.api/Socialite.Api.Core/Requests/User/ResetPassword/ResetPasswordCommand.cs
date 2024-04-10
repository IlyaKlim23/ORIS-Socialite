using MediatR;
using Socialite.Api.Contracts.Requests.User.ResetPassword;

namespace Socialite.Api.Core.Requests.User.ResetPassword;

/// <summary>
/// Команда запроса <see cref="ResetPasswordRequest"/>
/// </summary>
public class ResetPasswordCommand: ResetPasswordRequest, IRequest<ResetPasswordResponse>
{
}