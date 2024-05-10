using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Chat.GetChatsShortInfo;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Chat.GetChatsShortInfo;

/// <summary>
/// Обработчик запроса на получение чатов
/// </summary>
public class GetChatsShortInfoQueryHandler : IRequestHandler<GetChatsShortInfoQuery, GetChatsShortInfoResponse>
{
    private readonly IDbContext _dbContext;

    public GetChatsShortInfoQueryHandler(IDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
    }
    
    public async Task<GetChatsShortInfoResponse> Handle(GetChatsShortInfoQuery request, CancellationToken cancellationToken)
    {
        var chats = await _dbContext.Chats
            .Where(x => x.Users.Select(x => x.Id).Contains(request.CurrentUserId))
            .Select(x => new GetChatsShortInfoResponseItem
            {
                ChatId = x.Id,
                AvatarId = x.Users.FirstOrDefault(x => x.Id != request.CurrentUserId).AvatarId,
                FirstName = x.Users.FirstOrDefault(x => x.Id != request.CurrentUserId).FirstName,
                LastName = x.Users.FirstOrDefault(x => x.Id != request.CurrentUserId).LastName,
                UserId = x.Users.FirstOrDefault(x => x.Id != request.CurrentUserId).Id,
                UserName = x.Users.FirstOrDefault(x => x.Id != request.CurrentUserId).UserName,
                LastMessageText = x.Messages.Count != 0
                    ? x.Messages
                        .OrderByDescending(x => x.CreatedAt)
                        .FirstOrDefault()
                        .Text
                    : "Начните общаться!",
                LastMessageCreatedAt = x.Messages.Count != 0
                    ? x.Messages.OrderByDescending(x => x.CreatedAt).FirstOrDefault().CreatedAt
                    : null
            })
            .ToListAsync(cancellationToken);

        return new GetChatsShortInfoResponse(chats);
    }
}