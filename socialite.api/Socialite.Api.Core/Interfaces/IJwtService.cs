namespace Socialite.Api.Core.Interfaces;

/// <summary>
/// Сервис для работы с Jwt
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Сгенерировать Jwt
    /// </summary>
    /// <returns></returns>
    public string GenerateJwt(Guid userId, string role, string? email);
}