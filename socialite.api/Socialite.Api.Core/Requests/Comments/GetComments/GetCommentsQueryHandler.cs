using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Comments.GetComments;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Comments.GetComments;

/// <summary>
/// Обработчик <see cref="GetCommentsQuery"/>
/// </summary>
public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, GetCommentsResponse>
{
    private readonly IDbContext _dbContext;

    public GetCommentsQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetCommentsResponse> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _dbContext.Comments
            .Where(x => x.PostId == request.PostId)
            .Select(x => new GetCommentsResponseItem()
            {
                CommentId = x.Id,
                Text = x.Text,
                CreatedDate = x.CreateDate,
                Owner = new GetCommentsResponseUser()
                {
                    UserId = x.OwnerId,
                    AvatarId = x.Owner.AvatarId,
                    UserName = x.Owner.UserName,
                    FirstName = x.Owner.FirstName,
                    LastName = x.Owner.LastName
                }
            })
            .Take(request.Request.Count)
            .ToListAsync(cancellationToken);

        return new GetCommentsResponse(comments, comments.Count);
    }
}