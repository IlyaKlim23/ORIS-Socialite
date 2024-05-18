using Socialite.Api.Core.Entities;
using Socialite.Api.SignalR.Models;

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
    public Task ReceiveMessage(MessageModel message);
}

