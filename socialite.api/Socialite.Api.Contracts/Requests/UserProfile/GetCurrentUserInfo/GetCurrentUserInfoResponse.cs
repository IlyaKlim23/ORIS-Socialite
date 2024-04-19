namespace Socialite.Api.Contracts.Requests.UserProfile.GetCurrentUserInfo;

/// <summary>
/// Ответ на запрос на получение информации о текущем пользователе
/// </summary>
public class GetCurrentUserInfoResponse
{
    /// <summary>
    /// Никнейм
    /// </summary>
    public string UserName { get; set; } = default!;
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = default!;
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = default!;
    
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
    
    /// <summary>
    /// Статус
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Гендер
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Кол-во подписчиков
    /// </summary>
    public int SubscribersCount { get; set; }
}