namespace Socialite.Api.SignalR.Models;

/// <summary>
/// Модель подключения к чату
/// </summary>
/// <param name="ChatId">Идентификатор чата</param>
public record ChatConnection(Guid ChatId);