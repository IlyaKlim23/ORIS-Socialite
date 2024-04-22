namespace Socialite.Api.Contracts.Models;

/// <summary>
/// Подписчик
/// </summary>
public class UserBaseInfoModel
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Идентификатор аватарки
    /// </summary>
    public Guid? AvatarId { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = default!;
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Никнейм
    /// </summary>
    public string? UserName { get; set; }
}