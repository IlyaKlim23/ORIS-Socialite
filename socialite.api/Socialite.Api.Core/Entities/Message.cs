using Socialite.Api.Core.Exceptions;

namespace Socialite.Api.Core.Entities;

/// <summary>
/// Сообщение
/// </summary>
public class Message : EntityBase
{
    private User _owner;
    private Chat _chat;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="text">Текст сообщения</param>
    /// <param name="createdAt">Дата и время создания</param>
    /// <param name="chat">Чат</param>
    /// <param name="ownerId">Владелец</param>
    public Message(string text, DateTime createdAt, Chat chat, Guid ownerId)
    {
        Text = text;
        CreatedAt = createdAt;
        Chat = chat;
        OwnerId = ownerId;
    }

    private Message()
    {
    }

    /// <summary>
    /// Текст сообщения
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Идентификатор создателя
    /// </summary>
    public Guid OwnerId { get; set; }

    /// <summary>
    /// Чат
    /// </summary>
    public Guid ChatId { get; set; }

    /// <summary>
    /// Чат
    /// </summary>
    public Chat Chat
    {
        get => _chat;
        set
        {
            ChatId = value?.Id
                ?? throw new RequiredFieldIsEmpty("Чат");
            _chat = value;
        }
    }
    
    /// <summary>
    /// Создатель сообщения
    /// </summary>
    public User Owner
    {
        get => _owner;
        set
        {
            OwnerId = value?.Id
                ?? throw new RequiredFieldIsEmpty("Создатель сообщения");
            _owner = value;
        }
    }
}