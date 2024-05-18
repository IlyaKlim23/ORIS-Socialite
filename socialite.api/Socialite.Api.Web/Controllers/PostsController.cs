using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Models;
using Socialite.Api.Contracts.Requests.Post.CreatePost;
using Socialite.Api.Contracts.Requests.Post.GetPosts;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Entities;
using Socialite.Api.Core.Requests.Post.CreatePost;
using Socialite.Api.Core.Requests.Post.DislikePost;
using Socialite.Api.Core.Requests.Post.GetPosts;
using Socialite.Api.Core.Requests.Post.LikePost;
using Socialite.Api.Core.Requests.Post.RemovePost;
using Socialite.Api.Web.Attributes;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер сущности <see cref="Post"/>
/// </summary>
public class PostsController : BaseController
{
    /// <summary>
    /// Получить посты пользователя
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="userId"></param>
    /// <param name="isFollowingPosts"></param>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost("getPosts")]
    public async Task<GetPostsResponse> GetPostsAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid? userId,
        [FromQuery] bool isFollowingPosts,
        [FromBody] PaginationRequestModel pagination,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetPostsQuery(userId ?? CurrentUserId, isFollowingPosts, CurrentUserId, pagination), cancellationToken);

    /// <summary>
    /// Создать пост
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost]
    public async Task<CreatePostResponse> CreatePostAsync(
        [FromServices] IMediator mediator,
        [FromBody] CreatePostRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new CreatePostCommand(CurrentUserId, request), cancellationToken);

    /// <summary>
    /// Удалить пост
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="postId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpDelete]
    public async Task DeletePostAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid postId,
        CancellationToken cancellationToken)
        => await mediator.Send(new RemovePostCommand(postId), cancellationToken);

    /// <summary>
    /// Лайкнуть пост
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="postId"></param>
    /// <param name="cancellationToken"></param>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost("like")]
    public async Task LikePostAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid postId,
        CancellationToken cancellationToken)
        => await mediator.Send(new LikePostCommand(CurrentUserId, postId), cancellationToken);

    /// <summary>
    /// Лайкнуть пост
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="postId"></param>
    /// <param name="cancellationToken"></param>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost("dislike")]
    public async Task DislikePostAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid postId,
        CancellationToken cancellationToken)
        => await mediator.Send(new DislikePostCommand(CurrentUserId, postId), cancellationToken);
}