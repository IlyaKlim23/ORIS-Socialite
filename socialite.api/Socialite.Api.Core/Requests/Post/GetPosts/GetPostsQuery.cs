using MediatR;
using Socialite.Api.Contracts.Requests.Post.GetPosts;

namespace Socialite.Api.Core.Requests.Post.GetPosts;

/// <summary>
/// Запрос на получение постов
/// </summary>
public class GetPostsQuery : GetPostsRequest, IRequest<GetPostsResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId">Пользователь</param>
    public GetPostsQuery(Guid userId, bool isFollowingPosts)
    {
        UserId = userId;
        IsFollowingPosts = isFollowingPosts;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Посты людей, на которых подписан пользователь
    /// </summary>
    public bool IsFollowingPosts { get; set; }
}