namespace Socialite.Api.Contracts.Requests.Messages.PostMessage;

/// <summary>
/// Запрос на создание сообщения
/// </summary>
public class PostMessageRequest
{
    /// <summary>
    /// Текст сообщения
    /// </summary>
    public string Text { get; set; } = null!;
}