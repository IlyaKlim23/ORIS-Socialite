using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Post.CreatePost;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Post.CreatePost;

/// <summary>
/// Обработчик запроса <see cref="CreatePostCommand"/>
/// </summary>
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="userService"></param>
    public CreatePostCommandHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var innerRequest = request.Request;
        
        var user = await _userService.FindUserByIdAsync(request.CurrentUserId)
            ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);

        var files = innerRequest.FileIds != null || innerRequest.FileIds?.Count is 0
            ? await _dbContext.Files
                .Where(x => innerRequest.FileIds.Contains(x.Id))
                .ToListAsync(cancellationToken)
            : null;

        var post = new Entities.Post(user.Id, DateTime.Now)
        {
            Description = innerRequest.Description,
            Files = files ?? null
        };

        _dbContext.Posts.Add(post);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePostResponse(post.Id);
    }
}