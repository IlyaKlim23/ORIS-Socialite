namespace Socialite.Api.SignalR.Models;

/// <summary>
/// Модель подключения к чату
/// </summary>
/// <param name="ChatId">Идентификатор чата</param>
public record ChatConnection(Guid ChatId);

/// <summary>
/// Модель подключения к множеству чатов
/// </summary>
/// <param name="ChatIds">Идентификаторы чатов</param>
public record ChatConnections(List<Guid> ChatIds);

/// <summary>
/// Отправить сообщение
/// </summary>
/// <param name="ChatId">Идентификатор чата</param>
/// <param name="Message">Сообщение</param>
public record SendMessageToChatModel(Guid ChatId, string Message);