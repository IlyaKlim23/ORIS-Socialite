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
    public GetPostsQuery(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Пользователь
    /// </summary>
    public Guid UserId { get; set; }
}