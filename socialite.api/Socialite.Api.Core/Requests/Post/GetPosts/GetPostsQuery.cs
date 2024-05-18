using MediatR;
using Socialite.Api.Contracts.Models;
using Socialite.Api.Contracts.Requests.Post.GetPosts;

namespace Socialite.Api.Core.Requests.Post.GetPosts;

/// <summary>
/// Запрос на получение постов
/// </summary>
public class GetPostsQuery : IRequest<GetPostsResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId">Пользователь</param>
    /// <param name="isFollowingPosts"></param>
    /// <param name="currentUserId"></param>
    /// <param name="pagination"></param>
    public GetPostsQuery(Guid userId, bool isFollowingPosts, Guid currentUserId, PaginationRequestModel pagination)
    {
        UserId = userId;
        IsFollowingPosts = isFollowingPosts;
        CurrentUserId = currentUserId;
        Pagination = pagination;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Посты людей, на которых подписан пользователь
    /// </summary>
    public bool IsFollowingPosts { get; set; }

    /// <summary>
    /// Идентификатор текущего пользователя
    /// </summary>
    public Guid CurrentUserId { get; set; }

    /// <summary>
    /// Пагинация
    /// </summary>
    public PaginationRequestModel Pagination { get; set; }
}