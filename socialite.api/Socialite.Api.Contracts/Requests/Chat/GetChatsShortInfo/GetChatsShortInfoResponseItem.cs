namespace Socialite.Api.Contracts.Requests.Chat.GetChatsShortInfo;

public class GetChatsShortInfoResponseItem
{
    /// <summary>
    /// Идентификатор чата
    /// </summary>
    public Guid ChatId { get; set; }
    
    /// <summary>
    /// Идентификатор аватара
    /// </summary>
    public Guid? AvatarId { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Никнейм
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// Текст последнего сообщения
    /// </summary>
    public string LastMessageText { get; set; } = null!;

    /// <summary>
    /// Дата и время создания последнего сообщения
    /// </summary>
    public DateTime? LastMessageCreatedAt { get; set; }
}