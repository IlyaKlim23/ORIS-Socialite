using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.Post.CreatePost;
using Socialite.Api.Contracts.Requests.Post.GetPosts;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Entities;
using Socialite.Api.Core.Requests.Post.CreatePost;
using Socialite.Api.Core.Requests.Post.GetPosts;
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
    /// <param name="request"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpGet]
    public async Task<GetPostsResponse> GetPostsAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid? userId,
        [FromQuery] bool isFollowingPosts,
        [FromQuery] GetPostsRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetPostsQuery(userId ?? CurrentUserId, isFollowingPosts), cancellationToken);

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
}