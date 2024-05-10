using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Chat.GetChat;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Chat.GetChat;

/// <summary>
/// Обработчик <see cref="GetChatCommand"/>
/// </summary>
public class GetChatCommandHandler : IRequestHandler<GetChatCommand, GetChatResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public GetChatCommandHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<GetChatResponse> Handle(GetChatCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userService.FindUserByIdAsync(request.CurrentUserId)
            ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);
        
        var user = await _userService.FindUserByIdAsync(request.UserId)
            ?? throw new EntityNotFoundException<Entities.User>(request.UserId);

        var existedChat = await _dbContext.Chats
            .FirstOrDefaultAsync(x => x.Users.Contains(currentUser) && x.Users.Contains(user), cancellationToken);

        if (existedChat != null)
            return new GetChatResponse(existedChat.Id);

        var chat = new Entities.Chat();
        
        _dbContext.Chats.Add(chat);
        currentUser.Chats.Add(chat);
        user.Chats.Add(chat);

        await _userService.UpdateUserAsync(currentUser);

        return new GetChatResponse(chat.Id);
    }
}