using MediatR;
using Socialite.Api.Contracts.Requests.Comments.GetComments;

namespace Socialite.Api.Core.Requests.Comments.GetComments;

/// <summary>
/// Запрос на получение комментариев
/// </summary>
public class GetCommentsQuery : IRequest<GetCommentsResponse>
{
    public GetCommentsQuery(Guid postId, GetCommentsRequest request)
    {
        PostId = postId;
        Request = request;
    }

    /// <summary>
    /// Идентификатор поста
    /// </summary>
    public Guid PostId { get; set; }
    
    /// <summary>
    /// Запрос
    /// </summary>
    public GetCommentsRequest Request { get; set; }
}