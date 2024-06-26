﻿namespace Socialite.Api.Contracts.Requests.Post.GetPosts;

/// <summary>
/// Лайкнувший пользователь
/// </summary>
public class GetPostsResponseItemUser
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Аватар
    /// </summary>
    public GetPostsResponseItemFile? Avatar { get; set; }
    
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