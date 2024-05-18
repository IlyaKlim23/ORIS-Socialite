using Microsoft.AspNetCore.SignalR;
using Socialite.Api.SignalR.Interfaces;
using Socialite.Api.SignalR.Models;

namespace Socialite.Api.SignalR.Hubs;

/// <summary>
/// Хаб чата
/// </summary>
public class ChatHub : Hub<IChatClient>
{
    /// <summary>
    /// Присоединиться в чат
    /// </summary>
    /// <param name="chatConnection">Модель подключения к чату</param>
    public async Task JoinChat(ChatConnection chatConnection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatConnection.ChatId.ToString());
    }

    /// <summary>
    /// Присоединиться в чаты
    /// </summary>
    /// <param name="chatConnections">Модель подключения к множеству чатов</param>
    public async Task JoinAllChats(ChatConnections chatConnections)
    {
        foreach (var chatId in chatConnections.ChatIds)
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    }

    /// <summary>
    /// Отправить сообщение в чат
    /// </summary>
    /// <param name="sendMessageToChatModel"></param>
    public async Task SendMessageToChat(SendMessageToChatModel sendMessageToChatModel)
    => await Clients
        .GroupExcept(sendMessageToChatModel.ChatId.ToString(), Context.ConnectionId)
        .ReceiveMessage(new MessageModel(sendMessageToChatModel.ChatId, false, sendMessageToChatModel.Message));
}