using MediatR;

namespace Socialite.Api.Core.Requests.Post.RemovePost;

/// <summary>
/// Команда на удаление поста
/// </summary>
public class RemovePostCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="postId">Идентификатор поста</param>
    public RemovePostCommand(Guid postId)
    {
        PostId = postId;
    }

    /// <summary>
    /// Идентификатор поста
    /// </summary>
    public Guid PostId { get; set; }
}