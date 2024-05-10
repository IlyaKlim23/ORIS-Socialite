namespace Socialite.Api.Contracts.Requests.Messages.GetMessages;

/// <summary>
/// Сообщение
/// </summary>
public class GetMessagesResponseItem
{
    /// <summary>
    /// Написано текущим пользователем
    /// </summary>
    public bool IsCurrentUser { get; set; }
    
    /// <summary>
    /// Текст сообщения
    /// </summary>
    public string Text { get; set; } = null!;

    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
}