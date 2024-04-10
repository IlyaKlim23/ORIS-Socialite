using Microsoft.AspNetCore.Identity;

namespace Socialite.Api.Contracts.Requests.User.ResetPassword;

/// <summary>
/// Ответ на запрос <see cref="ResetPasswordRequest"/>
/// </summary>
public class ResetPasswordResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="result">Результат регистрации</param>
    public ResetPasswordResponse(IdentityResult result)
    {
        Result = result;
    }

    /// <summary>
    /// Результат регистрации
    /// </summary>
    public IdentityResult Result { get; }
}