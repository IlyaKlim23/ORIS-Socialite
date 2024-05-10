namespace Socialite.Api.Core.Entities;

/// <summary>
/// Чат
/// </summary>
public class Chat : EntityBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public Chat()
    {
        Messages = new List<Message>();
        Users = new List<User>();
    }
    
    /// <summary>
    /// Пользователи в чате
    /// </summary>
    public List<User> Users { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public List<Message> Messages { get; set; }
}