namespace Socialite.Api.SignalR.Models;

/// <summary>
/// Модель сообщения
/// </summary>
/// <param name="ChatId">Идентификатор чата</param>
/// <param name="IsCurrent">Текущий пользователь</param>
/// <param name="Text">Текст</param>
public record MessageModel(Guid ChatId, bool IsCurrent, string Text);
