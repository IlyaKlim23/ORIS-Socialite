namespace Socialite.Api.Contracts.Requests.Comments.GetComments;

public class GetCommentsResponseUser
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Аватар
    /// </summary>
    public Guid? AvatarId { get; set; }
    
    /// <summary>
    /// Никнейм пользователя
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; set; } = default!;
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; set; } = default!;
}