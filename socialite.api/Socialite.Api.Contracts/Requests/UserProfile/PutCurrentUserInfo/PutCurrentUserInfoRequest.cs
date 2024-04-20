namespace Socialite.Api.Contracts.Requests.UserProfile.PutCurrentUserInfo;

/// <summary>
/// Запрос на изменения профиля пользователя
/// </summary>
public class PutCurrentUserInfoRequest
{
    /// <summary>
    /// Идентификатор аватара
    /// </summary>
    public Guid? AvatarId { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Место жительства
    /// </summary>
    public string? PlaceOfLiving { get; set; }
    
    /// <summary>
    /// Место работы
    /// </summary>
    public string? PlaceOfWork { get; set; }
    
    /// <summary>
    /// Место учебы
    /// </summary>
    public string? PlaceOfStudy { get; set; }

    /// <summary>
    /// Семейное положение
    /// </summary>
    public string? MaritalStatus { get; set; }
}