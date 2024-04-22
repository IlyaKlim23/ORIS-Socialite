using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Post.GetPosts;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Post.GetPosts;

/// <summary>
/// Обработчик запроса <see cref="GetPostsQuery"/>
/// </summary>
public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, GetPostsResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    public GetPostsQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<GetPostsResponse> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Posts
            .Where(x => x.OwnerId == request.UserId);
            
        var posts = await query
            .Where(x => x.OwnerId == request.UserId)
            .Select(x => new GetPostsResponseItem
            {
                PostId = x.Id,
                Owner = new GetPostsResponseItemUser
                {
                    UserId = x.Owner.Id,
                    Avatar = x.Owner.Avatar != null
                        ? new GetPostsResponseItemFile
                            {
                                FileId = x.Owner.Avatar!.Id,
                                Name = x.Owner.Avatar.Name,
                            }
                        : null,
                    UserName = x.Owner.UserName!,
                    FirstName = x.Owner.FirstName,
                    LastName = x.Owner.LastName,
                },
                Description = x.Description,
                CreateDate = x.CreateDate,
                LikesCount = x.LikedUsers!.Count,
                Files = x.Files!.Select(y => new GetPostsResponseItemFile
                {
                    FileId = y.Id,
                    Name = y.Name,
                }).ToList(),
                Comments = x.Comments!.Select(y => new GetPostsResponseItemComment
                {
                    CommentId = y.Id,
                    Text = y.Text,
                    CreatedDate = y.CreateDate,
                    Owner = new GetPostsResponseItemUser
                    {
                        UserId = y.Owner.Id,
                        UserName = y.Owner.UserName!,
                        FirstName = y.Owner.FirstName,
                        LastName = y.Owner.LastName,
                        Avatar = new GetPostsResponseItemFile
                        {
                            FileId = y.Owner.Avatar!.Id,
                            Name = y.Owner.Avatar.Name,
                        }
                    }
                }).ToList(),
                CommentsCount = x.Comments!.Count
            })
            .OrderByDescending(x => x.CreateDate)
            .ToListAsync(cancellationToken);

        var count = await query.CountAsync(cancellationToken);

        return new GetPostsResponse(count, posts);
    }
}