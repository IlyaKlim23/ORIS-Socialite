using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Post.LikePost;

/// <summary>
/// Обработчик <see cref="LikePostCommand"/>
/// </summary>
public class LikePostCommandHandler : IRequestHandler<LikePostCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="userService"></param>
    public LikePostCommandHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.Users()
            .Include(x => x.LikedPosts)
            .FirstOrDefaultAsync(x => x.Id == request.CurrentUserId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);
        
        if (user.LikedPosts.Select(x => x.Id).Contains(request.PostId))
            throw new ValidationException("Пост уже был лайкнут");
        
        var post = await _dbContext.Posts
            .FirstOrDefaultAsync(x => x.Id == request.PostId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.Post>(request.PostId);
        
        user.LikedPosts.Add(post);

        await _userService.UpdateUserAsync(user);

        return default;
    }
}