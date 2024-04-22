namespace Socialite.Api.Contracts.Requests.User.GetUsers;

/// <summary>
/// Запрос получения пользователей
/// </summary>
public class GetUsersRequest
{
    /// <summary>
    /// Кол-во записей
    /// </summary>
    public int CountItems { get; set; }
    
    /// <summary>
    /// Никнейм пользователя
    /// </summary>
    public string? UserName { get; set; }
}