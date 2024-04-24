using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Comments.PostComment;
using Socialite.Api.Core.Entities;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Comments.PostComment;

/// <summary>
/// Обработчик <see cref="PostCommentCommand"/>
/// </summary>
public class PostCommentCommandHandler : IRequestHandler<PostCommentCommand, PostCommentResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="userService"></param>
    public PostCommentCommandHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<PostCommentResponse> Handle(PostCommentCommand request, CancellationToken cancellationToken)
    {
        var innerRequest = request.Request;
        
        var user = await _userService.FindUserByIdAsync(request.CurrentUserId)
            ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);

        var post = await _dbContext.Posts
            .FirstOrDefaultAsync(x => x.Id == request.PostId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.Post>(request.PostId);

        if (string.IsNullOrEmpty(innerRequest.Text))
            throw new ValidationException("Текст комментария не может быть пустым");

        var comment = new Comment(innerRequest.Text, DateTime.Now, user.Id, post);

        _dbContext.Comments.Add(comment);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new PostCommentResponse(comment.Id);
    }
}