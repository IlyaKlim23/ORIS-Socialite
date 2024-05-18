using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Chat.DeleteChat;

/// <summary>
/// Обработчик команды на удаление чата
/// </summary>
public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    public DeleteChatCommandHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
    {
        var chat = await _dbContext.Chats
            .Include(x => x.Messages)
            .Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == request.ChatId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.Chat>(request.ChatId);
        
        chat.Messages.Clear();
        _dbContext.Chats.Remove(chat);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return default;
    }
}