namespace Socialite.Api.SignalR.Interfaces;

/// <summary>
/// Клиент для работы с чатом
/// </summary>
public interface IChatClient
{
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task ReceiveMessage(string message);
}

