using Socialite.Api.Contracts.Models;

namespace Socialite.Api.Contracts.Requests.Subscribers.GetSubscribedTo;

/// <summary>
/// Ответ на запрос на получение пользователей, на которых подписан текущий пользователь
/// </summary>
public class GetSubscribedToResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="count">Кол-во</param>
    /// <param name="subscribedTo">Подписчики</param>
    public GetSubscribedToResponse(
        int count,
        List<UserBaseInfoModel> subscribedTo)
    {
        Count = count;
        SubscribedTo = subscribedTo;
    }

    /// <summary>
    /// Кол-во
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Подписчики
    /// </summary>
    public List<UserBaseInfoModel> SubscribedTo { get; set; }
}