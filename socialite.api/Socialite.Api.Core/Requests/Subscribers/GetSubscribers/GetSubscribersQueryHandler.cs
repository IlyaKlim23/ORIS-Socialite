using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Models;
using Socialite.Api.Contracts.Requests.Subscribers;
using Socialite.Api.Contracts.Requests.Subscribers.GetSubscribers;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Subscribers.GetSubscribers;

/// <summary>
/// Обработчик запроса <see cref="GetSubscribersQuery"/>
/// </summary>
public class GetSubscribersQueryHandler : IRequestHandler<GetSubscribersQuery, GetSubscribersResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService"></param>
    public GetSubscribersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetSubscribersResponse> Handle(GetSubscribersQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUsersAsQueryable()
            .Include(x => x.Subscribers)
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.User>(request.UserId);

        var result = user.Subscribers
            .Select(x => new UserBaseInfoModel
            {
                UserId = x.Id,
                AvatarId = x.AvatarId,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
            })
            .ToList();
        
        return new GetSubscribersResponse(result.Count, result);
    }
}