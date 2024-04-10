namespace Socialite.Api.Contracts.Requests.Subscribers;

/// <summary>
/// Подписчик
/// </summary>
public class UserBaseInfoModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Никнейм пользователя
    /// </summary>
    public string? UserName { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = default!;
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = default!;
}