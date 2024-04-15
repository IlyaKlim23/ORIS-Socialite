using MediatR;
using Socialite.Api.Contracts.Requests.Post.CreatePost;

namespace Socialite.Api.Core.Requests.Post.CreatePost;

/// <summary>
/// Команда запроса на создание поста
/// </summary>
public class CreatePostCommand : IRequest<CreatePostResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentUserId">Идентификатор текущего пользователя</param>
    /// <param name="request">Запрос</param>
    public CreatePostCommand(Guid currentUserId, CreatePostRequest request)
    {
        CurrentUserId = currentUserId;
        Request = request;
    }

    /// <summary>
    /// Запрос
    /// </summary>
    public CreatePostRequest Request { get; set; }
    
    /// <summary>
    /// Идентификатор текущего пользователя
    /// </summary>
    public Guid CurrentUserId { get; set; }
}