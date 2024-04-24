using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socialite.Api.Contracts.Requests.Comments.GetComments;
using Socialite.Api.Contracts.Requests.Comments.PostComment;
using Socialite.Api.Core.Constants;
using Socialite.Api.Core.Requests.Comments.GetComments;
using Socialite.Api.Core.Requests.Comments.PostComment;
using Socialite.Api.Web.Attributes;

namespace Socialite.Api.Web.Controllers;

/// <summary>
/// Контроллер для работы с комментариями
/// </summary>
public class CommentsController : BaseController
{
    /// <summary>
    /// Создать комментарий
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="postId"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost]
    public async Task<PostCommentResponse> PostCommentAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid postId,
        [FromBody] PostCommentRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new PostCommentCommand(CurrentUserId, postId, request), cancellationToken);
    
    /// <summary>
    /// Получить комментарии
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="postId"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Policy(PolicyConstants.IsDefaultUser)]
    [HttpPost("getComments")]
    public async Task<GetCommentsResponse> GetCommentsAsync(
        [FromServices] IMediator mediator,
        [FromQuery] Guid postId,
        [FromBody] GetCommentsRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetCommentsQuery(postId, request), cancellationToken);
}