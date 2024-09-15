using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
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
    private readonly IDistributedCache _distributedCache;

    private record UserModel
    {
        public int SubscribersCount { get; set; }
        
        public int SubscriberToCount { get; set; }
        
        public int FriendsCount { get; set; }
        
        public int PostsCount { get; set; }
        
        public Entities.User User { get; set; }
        
        public Guid? AvatarId { get; set; }
        
        public bool IsSubscribedTo { get; set; }
        
        public bool IsSubscriber { get; set; }
    };

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    /// <param name="distributedCache">Кэш Redis</param>
    public GetUserInfoQueryHandler(IUserService userService, IDistributedCache distributedCache)
    {
        _userService = userService;
        _distributedCache = distributedCache;
    }

    /// <inheritdoc />
    public async Task<GetUserInfoResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var userFromCache = await _distributedCache.GetStringAsync(request.UserId.ToString(), cancellationToken);
        if (userFromCache != null)
        {
            var userInfoFromCache = JsonSerializer.Deserialize<UserModel>(userFromCache)
                ?? throw new ApplicationExceptionBase("Неудачная попытка десериализации");
            
            return GetResult(userInfoFromCache);
        }

        var userInfo = await _userService.Users()
           .Select(x => new UserModel
           {
               SubscribersCount = x.Subscribers.Count,
               SubscriberToCount = x.SubscribedTo.Count,
               FriendsCount = x.Subscribers.Intersect(x.SubscribedTo).Count(),
               PostsCount = x.CreatedPosts.Count,
               User = x,
               AvatarId = x.AvatarId,
               IsSubscribedTo = x.Subscribers.Select(y => y.Id).Contains(request.CurrentUserId),
               IsSubscriber = x.SubscribedTo.Select(y => y.Id).Contains(request.CurrentUserId)
           })
           .FirstOrDefaultAsync(x => x.User.Id == request.UserId, cancellationToken)
       ?? throw new EntityNotFoundException<Entities.User>(request.UserId);

        userFromCache = JsonSerializer.Serialize(userInfo);

         await _distributedCache.SetStringAsync(
             request.UserId.ToString(),
             userFromCache,
             new DistributedCacheEntryOptions
             {
                 AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
             }, 
             cancellationToken);
        
        return GetResult(userInfo);
    }
    
    private GetUserInfoResponse GetResult(UserModel userInfo)
        => new()
        {
            UserId = userInfo.User.Id,
            UserName = userInfo.User.UserName ?? string.Empty,
            FirstName = userInfo.User.FirstName,
            LastName = userInfo.User.LastName,
            PlaceOfLiving = userInfo.User.PlaceOfLiving,
            PlaceOfWork = userInfo.User.PlaceOfWork,
            PostsCount = userInfo.PostsCount,
            PlaceOfStudy = userInfo.User.PlaceOfStudy,
            MaritalStatus = userInfo.User.MaritalStatus?.GetDescription(),
            Status = userInfo.User.Status,
            Gender = userInfo.User.Gender?.GetDescription(),
            SubscribersCount = userInfo.SubscribersCount,
            SubscriberToCount = userInfo.SubscriberToCount,
            AvatarId = userInfo.AvatarId,
            IsSubscriber = userInfo.IsSubscriber,
            IsSubscribeTo = userInfo.IsSubscribedTo,
            FriendCount = userInfo.FriendsCount,
        };
}