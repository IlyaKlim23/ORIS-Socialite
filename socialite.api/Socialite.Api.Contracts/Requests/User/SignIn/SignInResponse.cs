using Microsoft.AspNetCore.Identity;

namespace Socialite.Api.Contracts.Requests.User.SignIn;

/// <summary>
/// Ответ на запрос <see cref="SignInRequest"/>
/// </summary>
public class SignInResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="result">Результат входа</param>
    /// <param name="userName"></param>
    /// <param name="jwtToken">Jwt</param>
    /// <param name="userId"></param>
    public SignInResponse(SignInResult result, Guid userId, string userName, string jwtToken = default!)
    {
        JwtToken = jwtToken;
        Result = result;
        UserId = userId;
        UserName = userName;
    }
    
    /// <summary>
    /// Jwt
    /// </summary>
    public string JwtToken { get; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Никнейм пользователя
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Результат входа
    /// </summary>
    public SignInResult Result { get; }
}