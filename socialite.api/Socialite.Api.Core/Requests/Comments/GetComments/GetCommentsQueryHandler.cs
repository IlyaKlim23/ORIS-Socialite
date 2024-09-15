using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Comments;
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
        var query = _dbContext.Comments
            .Where(x => x.PostId == request.PostId);

        var totalCount = await query.CountAsync(cancellationToken);
        
        var comments = await query
            .Select(x => new GetCommentsResponseItem
            {
                CommentId = x.Id,
                Text = x.Text,
                CreatedDate = x.CreateDate,
                Owner = new GetCommentsResponseUser
                {
                    UserId = x.OwnerId,
                    AvatarId = x.Owner.AvatarId,
                    UserName = x.Owner.UserName,
                    FirstName = x.Owner.FirstName,
                    LastName = x.Owner.LastName
                }
            })
            .Skip((request.Request.BucketNumber - 1) * request.Request.Count)
            .Take(request.Request.Count)
            .OrderBy(x => x.CreatedDate)
            .ToListAsync(cancellationToken);

        return new GetCommentsResponse(comments, totalCount);
    }
}