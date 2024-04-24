using MediatR;
using Socialite.Api.Contracts.Requests.Comments.PostComment;

namespace Socialite.Api.Core.Requests.Comments.PostComment;

/// <summary>
/// Команда на создание комментария
/// </summary>
public class PostCommentCommand : IRequest<PostCommentResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Идентификатор текущего пользователя</param>
    /// <param name="postId"></param>
    /// <param name="request">Текст комментария</param>
    public PostCommentCommand(Guid currentUserId, Guid postId, PostCommentRequest request)
    {
        CurrentUserId = currentUserId;
        PostId = postId;
        Request = request;
    }

    /// <summary>
    /// Идентификатор текущего пользователя
    /// </summary>
    public Guid CurrentUserId { get; set; }

    /// <summary>
    /// Идентификатор поста
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    /// Запрос
    /// </summary>
    public PostCommentRequest Request { get; set; }
}