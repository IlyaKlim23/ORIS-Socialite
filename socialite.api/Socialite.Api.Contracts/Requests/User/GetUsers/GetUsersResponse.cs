using Socialite.Api.Contracts.Models;

namespace Socialite.Api.Contracts.Requests.User.GetUsers;

/// <summary>
/// Ответ на запрос на получение пользователей
/// </summary>
public class GetUsersResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="users">Пользователи</param>
    public GetUsersResponse(List<UserBaseInfoModel> users)
    {
        Users = users;
    }

    /// <summary>
    /// Пользователи
    /// </summary>
    public List<UserBaseInfoModel> Users { get; set; }
}