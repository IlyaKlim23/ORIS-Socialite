using MediatR;
using Socialite.Api.Contracts.Requests.User.SendResetPasswordCode;

namespace Socialite.Api.Core.Requests.User.SendResetPasswordCode;

/// <summary>
/// Команда запроса <see cref="SendResetPasswordCodeRequest"/>
/// </summary>
public class SendResetPasswordQuery: SendResetPasswordCodeRequest, IRequest<SendResetPasswordCodeResponse>
{
}