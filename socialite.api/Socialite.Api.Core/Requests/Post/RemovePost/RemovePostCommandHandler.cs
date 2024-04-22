using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;
using Socialite.Api.S3.Interfaces;

namespace Socialite.Api.Core.Requests.Post.RemovePost;

/// <summary>
/// Обработчик удаления поста
/// </summary>
public class RemovePostCommandHandler : IRequestHandler<RemovePostCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IS3Service _s3Service;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="s3Service"></param>
    public RemovePostCommandHandler(
        IDbContext dbContext,
        IS3Service s3Service)
    {
        _dbContext = dbContext;
        _s3Service = s3Service;
    }

    public async Task<Unit> Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _dbContext.Posts
            .Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == request.PostId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.Post>(request.PostId);

        foreach (var file in post.Files ?? [])
        {
            await _s3Service.RemoveFileFromBucketAsync(file.Id, file.Extension ?? string.Empty, cancellationToken);
            _dbContext.Files.Remove(file);
        }
        
        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return default;
    }
}