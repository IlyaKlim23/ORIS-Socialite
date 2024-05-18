using Socialite.Api.Contracts.Models;

namespace Socialite.Api.Contracts.Requests.Subscribers.GetFriendsByUser;

/// <summary>
/// Ответ на получение друзей для пользователя
/// </summary>
public class GetFriendsByUserResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="users">Пользователи</param>
    /// <param name="count"></param>
    public GetFriendsByUserResponse(List<UserBaseInfoModel> users, int count)
    {
        Users = users;
        Count = count;
    }

    /// <summary>
    /// Кол-во
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Пользователи
    /// </summary>
    public List<UserBaseInfoModel> Users { get; set; }
}