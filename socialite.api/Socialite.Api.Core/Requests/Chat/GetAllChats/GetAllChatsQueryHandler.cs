using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Chat.GetAllChats;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Chat.GetAllChats;

public class GetAllChatsQueryHandler : IRequestHandler<GetAllChatsQuery, GetAllChatsResponse>
{
    private readonly IDbContext _dbContext;

    public GetAllChatsQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetAllChatsResponse> Handle(GetAllChatsQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Chats
            .Where(x => x.Users.Select(x => x.Id).Contains(request.CurrentUserId))
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);

        return new GetAllChatsResponse(query);
    }
}