namespace Socialite.Api.Core.Interfaces;

/// <summary>
/// Сервис для работы с Email
/// </summary>
public interface IEmailSenderService
{
    /// <summary>
    /// Отправить сообщение на почту
    /// </summary>
    /// <param name="subject">Заголовок сообщения</param>
    /// <param name="body">Тело сообщения</param>
    /// <param name="sendTo">Получатель</param>
    /// <param name="placeholders">Плейсхолдеры</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>-</returns>
    public Task SendMessageAsync(
        string? subject,
        string body,
        string sendTo,
        Dictionary<string, string>? placeholders,
        CancellationToken cancellationToken);
}