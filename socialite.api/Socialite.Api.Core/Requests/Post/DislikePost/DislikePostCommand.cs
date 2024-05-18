using MediatR;

namespace Socialite.Api.Core.Requests.Post.DislikePost;

/// <summary>
/// Команда на дизлайк
/// </summary>
public class DislikePostCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Текущий пользователь</param>
    /// <param name="postId">Пост</param>
    public DislikePostCommand(Guid currentUserId, Guid postId)
    {
        CurrentUserId = currentUserId;
        PostId = postId;
    }

    /// <summary>
    /// Текущий пользователь
    /// </summary>
    public Guid CurrentUserId { get; set; }

    /// <summary>
    /// Пост
    /// </summary>
    public Guid PostId { get; set; }
}