using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Post.DislikePost;

public class DislikePostCommandHandler : IRequestHandler<DislikePostCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="userService"></param>
    public DislikePostCommandHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(DislikePostCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUsersAsQueryable()
            .Include(x => x.LikedPosts)
            .FirstOrDefaultAsync(x => x.Id == request.CurrentUserId, cancellationToken) 
            ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);

        var post = user.LikedPosts
            .FirstOrDefault(x => x.Id == request.PostId)
            ?? throw new ValidationException("Пост не был лайкнут");
        
        user.LikedPosts.Remove(post);

        await _userService.UpdateUserAsync(user);

        return default;
    }
}