using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Messages.PostMessage;
using Socialite.Api.Core.Entities;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Messages.PostMessage;

/// <summary>
/// Обработчик команды на создание сообщения
/// </summary>
public class PostMessageCommandHandler : IRequestHandler<PostMessageCommand, PostMessageResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;
    
    public PostMessageCommandHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    public async Task<PostMessageResponse> Handle(PostMessageCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.FindUserByIdAsync(request.CurrentUserId)
             ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);

        var chat = await _dbContext.Chats
            .FirstOrDefaultAsync(x => x.Id == request.ChatId, cancellationToken) 
            ?? throw new EntityNotFoundException<Entities.Chat>(request.ChatId);

        var message = new Message(request.Request.Text, DateTime.Now, chat, user.Id);

        _dbContext.Messages.Add(message);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new PostMessageResponse(message.Id);
    }
}