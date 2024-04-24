namespace Socialite.Api.Contracts.Requests.UserProfile.GetUserInfo;

/// <summary>
/// Ответ на запрос на получение информации о текущем пользователе
/// </summary>
public class GetUserInfoResponse
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
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

    /// <summary>
    /// Кол-во подписок
    /// </summary>
    public int SubscriberToCount { get; set; }

    /// <summary>
    /// Кол-во друзей
    /// </summary>
    public int FriendCount { get; set; }

    /// <summary>
    /// Идентификатор аватара
    /// </summary>
    public Guid? AvatarId { get; set; }

    /// <summary>
    /// Является подписчиком
    /// </summary>
    public bool IsSubscriber { get; set; }

    /// <summary>
    /// Текущий пользователь подписан
    /// </summary>
    public bool IsSubscribeTo { get; set; }
}