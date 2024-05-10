using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Messages.GetMessages;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Messages.GetMessages;

/// <summary>
/// Обработчик <see cref="GetMessagesQuery"/>
/// </summary>
public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, GetMessagesResponse>
{
    private readonly IDbContext _dbContext;

    public GetMessagesQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<GetMessagesResponse> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Messages
            .Where(x => x.ChatId == request.ChatId);

        var count = await query.CountAsync(cancellationToken);
        
        var entities = await query
            .Select(x => new GetMessagesResponseItem
            {
                IsCurrentUser = x.OwnerId == request.CurrentUserId,
                Text = x.Text,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync(cancellationToken);

        return new GetMessagesResponse(count, entities);
    }
}