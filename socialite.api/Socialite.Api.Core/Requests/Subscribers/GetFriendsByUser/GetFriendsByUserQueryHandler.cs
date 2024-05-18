using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Models;
using Socialite.Api.Contracts.Requests.Subscribers.GetFriendsByUser;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Subscribers.GetFriendsByUser;

public class GetFriendsByUserQueryHandler : IRequestHandler<GetFriendsByUserQuery, GetFriendsByUserResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService"></param>
    public GetFriendsByUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetFriendsByUserResponse> Handle(GetFriendsByUserQuery request, CancellationToken cancellationToken)
    {
        var query = _userService.Users()
            .Where(x => x.Subscribers.Select(x => x.Id).Contains(request.UserId))
            .Where(x => x.SubscribedTo.Select(x => x.Id).Contains(request.UserId));

        var count = await query.CountAsync(cancellationToken);
        
        var friends = await query
            .Select(x => new UserBaseInfoModel
            {
                UserId = x.Id,
                AvatarId = x.AvatarId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName
            })
            .ToListAsync(cancellationToken);

        return new GetFriendsByUserResponse(friends, count);
    }
}