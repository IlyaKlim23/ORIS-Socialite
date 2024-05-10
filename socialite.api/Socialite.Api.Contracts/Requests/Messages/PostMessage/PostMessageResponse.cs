namespace Socialite.Api.Contracts.Requests.Messages.PostMessage;

public class PostMessageResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="messageId"></param>
    public PostMessageResponse(Guid messageId)
    {
        MessageId = messageId;
    }

    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    public Guid MessageId { get; set; }
}