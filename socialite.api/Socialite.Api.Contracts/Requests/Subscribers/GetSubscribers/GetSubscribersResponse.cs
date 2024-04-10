namespace Socialite.Api.Contracts.Requests.Subscribers.GetSubscribers;

/// <summary>
/// Ответ на получение подписчиков
/// </summary>
public class GetSubscribersResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="count">Кол-во</param>
    /// <param name="subscribers">Подписчики</param>
    public GetSubscribersResponse(
        int count,
        List<UserBaseInfoModel> subscribers)
    {
        Count = count;
        Subscribers = subscribers;
    }

    /// <summary>
    /// Кол-во
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Подписчики
    /// </summary>
    public List<UserBaseInfoModel> Subscribers { get; set; }
}