using MediatR;

namespace Socialite.Api.Core.Requests.Post.LikePost;

/// <summary>
/// Команда на лайк поста
/// </summary>
public class LikePostCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Текущий пользователь</param>
    /// <param name="postId">Пост</param>
    public LikePostCommand(Guid currentUserId, Guid postId)
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