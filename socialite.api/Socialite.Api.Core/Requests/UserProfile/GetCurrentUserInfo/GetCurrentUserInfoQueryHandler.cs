using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.UserProfile.GetCurrentUserInfo;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Extensions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.UserProfile.GetCurrentUserInfo;

/// <summary>
/// Обработчик <see cref="GetCurrentUserInfoQuery"/>
/// </summary>
public class GetCurrentUserInfoQueryHandler : IRequestHandler<GetCurrentUserInfoQuery, GetCurrentUserInfoResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public GetCurrentUserInfoQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<GetCurrentUserInfoResponse> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
    {
        var userInfo = await _userService.Users()
            .Select(x => new
            {
                SubscribersCount = x.Subscribers.Count,
                User = x
            })
            .FirstOrDefaultAsync(x => x.User.Id == request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.User>(request.UserId);;

        return new GetCurrentUserInfoResponse
        {
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
        };
    }
}