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
                            Address = x.Owner.Avatar.Address
                        }
                    : null,
                    UserName = x.Owner.UserName!
                },
                Description = x.Description,
                CreateDate = x.CreateDate,
                LikedUsers = x.LikedUsers!.Select(y => new GetPostsResponseItemUser
                {
                    UserId = y.Id,
                    UserName = y.UserName!,
                    Avatar = y.Avatar != null 
                    ? new GetPostsResponseItemFile
                        {
                            FileId = y.Avatar!.Id,
                            Name = y.Avatar.Name,
                            Address = y.Avatar.Address
                        }
                    : null
                }).ToList(),
                LikesCount = x.LikedUsers!.Count,
                Files = x.Files!.Select(y => new GetPostsResponseItemFile
                {
                    FileId = y.Id,
                    Name = y.Name,
                    Address = y.Address
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
                        Avatar = new GetPostsResponseItemFile
                        {
                            FileId = y.Owner.Avatar!.Id,
                            Name = y.Owner.Avatar.Name,
                            Address = y.Owner.Avatar.Address
                        }
                    }
                }).ToList(),
                CommentsCount = x.Comments.Count
            })
            .ToListAsync(cancellationToken);

        var count = await query.CountAsync(cancellationToken);

        return new GetPostsResponse(count, posts);
    }
}