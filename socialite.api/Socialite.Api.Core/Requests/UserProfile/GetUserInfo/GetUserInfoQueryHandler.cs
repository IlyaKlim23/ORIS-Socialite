using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.UserProfile.GetUserInfo;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Extensions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.UserProfile.GetUserInfo;

/// <summary>
/// Обработчик <see cref="GetUserInfoQuery"/>
/// </summary>
public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public GetUserInfoQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<GetUserInfoResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var userInfo = await _userService.Users()
            .Select(x => new
            {
                SubscribersCount = x.Subscribers.Count,
                SubscriberToCount = x.SubscribedTo.Count,
                FriendsCount = x.Subscribers.Intersect(x.SubscribedTo).Count(),
                User = x,
                IsSubscribedTo = x.Subscribers.Select(y => y.Id).Contains(request.CurrentUserId),
                IsSubscriber = x.SubscribedTo.Select(y => y.Id).Contains(request.CurrentUserId)
            })
            .FirstOrDefaultAsync(x => x.User.Id == request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.User>(request.UserId);

        return new GetUserInfoResponse
        {
            UserId = userInfo.User.Id,
            UserName = userInfo.User.UserName ?? string.Empty,
            FirstName = userInfo.User.FirstName,
            LastName = userInfo.User.LastName,
            PlaceOfLiving = userInfo.User.PlaceOfLiving,
            PlaceOfWork = userInfo.User.PlaceOfWork,
            PlaceOfStudy = userInfo.User.PlaceOfStudy,
            MaritalStatus = userInfo.User.MaritalStatus?.GetDescription(),
            Status = userInfo.User.Status,
            Gender = userInfo.User.Gender?.GetDescription(),
            SubscribersCount = userInfo.SubscribersCount,
            SubscriberToCount = userInfo.SubscriberToCount,
            AvatarId = userInfo.User.AvatarId,
            IsSubscriber = userInfo.IsSubscriber,
            IsSubscribeTo = userInfo.IsSubscribedTo,
            FriendCount = userInfo.FriendsCount,
        };
    }
}