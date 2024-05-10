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
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public GetPostsQueryHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<GetPostsResponse> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        List<Guid>? subscribedUserIds = null;
        
        if (request.IsFollowingPosts)
        {
            subscribedUserIds = await _userService.Users()
                .Where(x => x.Subscribers.Select(x => x.Id).Contains(request.UserId))
                .Select(x => x.Id)
                .ToListAsync(cancellationToken);
        }
        
        var query = subscribedUserIds == null
            ? _dbContext.Posts.Where(x => x.OwnerId == request.UserId)
            : _dbContext.Posts.Where(x => subscribedUserIds.Contains(x.OwnerId));
            
        var posts = await query
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
                CommentsCount = x.Comments!.Count
            })
            .OrderByDescending(x => x.CreateDate)
            .ToListAsync(cancellationToken);

        var count = await query.CountAsync(cancellationToken);

        return new GetPostsResponse(count, posts);
    }
}